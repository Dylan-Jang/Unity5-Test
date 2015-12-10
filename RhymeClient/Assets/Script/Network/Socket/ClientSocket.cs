using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using Assets.Script.Network.PacketPackage;
using Assets.Script.Network.Protocol;
using Assets.Script.Network.Serialize;
using Assets.Script.Network.Utils;
using Rb.Services.Protocol;
using SocketFramework.Network.Serialize;
using UnityEngine;

namespace Assets.Script.Network.Socket
{
	public class StateObject
	{
		public const int MaxBuffSize = 1024 * 4;

		public PacketDefaultHeader Header;
		public byte[] Buffer = new byte[MaxBuffSize];
	}

	public class ClientSocket
	{
		enum ConnectEventType
		{
			OnConnected = 0,
			OnDisconnected = 1,
			MaxEvent = 2,
		}

		public enum ConnectResult
		{
			SUCCEEDED = 0,
			UnknownError,
		}

		protected IProtocolPackage ProtocolPackage { get; set; }

		// connect/disconnect callback delegate
		public delegate void DispatchEventFunctor(int result);
		// Connect Events
		readonly DispatchEventFunctor[] _callbackNetworkEventFunctor = new DispatchEventFunctor[(int)ConnectEventType.MaxEvent] { null, null };

		// socket impl
		private System.Net.Sockets.Socket _sock = null;

		// protobufserialize does not work
		private readonly ISerializer _serializer = new NewtonJsonSerializer();

		// thread block 문제로 별도로 메인쓰레드에서 polling할 task queue
		private readonly Queue<ProtocolDispatchTask> _taskQueue = new Queue<ProtocolDispatchTask>();
		// I/O lock - Input과 output이 별개의 쓰레드 루틴으로 처리가 됨으로 locking이 필요함. 
		// 클라이언트이므로 이 io lock의 비용은 무시 해도 된다.
		private readonly object _queueLock = new object();

		public ClientSocket()
		{
			ProtocolPackage = new RhymeTcpProtocolPackage(OnPacketBodyParseCompletedHandlerCallback, OnPacketHeaderReadCompletedHandlerCallback);
		}

		protected void OnPacketHeaderReadCompletedHandlerCallback(PacketDefaultHeader header)
		{
		}

		protected void OnPacketBodyParseCompletedHandlerCallback(PacketDefaultHeader header, byte[] readBytes)
		{
			EnqueueTask(header.ProtocolId, readBytes);
		}

		//  dispatch 받을 함수 delegate
		public delegate void DispatcherFunctor(object payload);
		//public delegate void DispatcherFunctor<TResponse>(TResponse payload);

		class ProtocolDispatchItem
		{
			//public DispatcherFunctor DispatchFunctor;
			public DispatcherFunctor DispatchFunctor;
			//public Type ResponseType;
		}

		// dispatch impl
		private readonly Dictionary<Int32, ProtocolDispatchItem> _packetDispatchList = new Dictionary<Int32, ProtocolDispatchItem>();

		//private void BindProtocol<TResponse>(int protocolId, DispatcherFunctor<TResponse> cb) where TResponse : Response
		private void BindProtocol(int protocolId, DispatcherFunctor cb)
		{
			if (true == _packetDispatchList.ContainsKey(protocolId))
			{
				return;
			}

			_packetDispatchList.Add(protocolId, new ProtocolDispatchItem { DispatchFunctor = cb, });
			//_packetDispatchList.Add(protocolId, new ProtocolDispatchItem { DispatchFunctor = (DispatcherFunctor<object>)cb });
		}

		public void UnbindProtocol(int protocolId)
		{
			if (true == _packetDispatchList.ContainsKey(protocolId))
			{
				_packetDispatchList.Remove(protocolId);
			}
		}

		private void EnqueueTask(int protocolId, byte[] buf)
		{
			var task = new ProtocolDispatchTask(protocolId, buf);
			lock (_queueLock)
			{
				_taskQueue.Enqueue(task);
			}
		}

		public void ExecuteTask()
		{
			lock (_queueLock)
			{
				while (_taskQueue.Count > 0)
				{
					ProtocolDispatchTask task = _taskQueue.Dequeue();

					Dispatch(task.Command, task.Buffer);

					task.Dispose();
					task = null;
				}
			}
		}

		public void Dispatch(Int32 protocolId, byte[] payload)
		{
			if (false == _packetDispatchList.ContainsKey(protocolId))
			{
				Debug.Log("Error protocolId not found " + protocolId);
				return;
			}

			BindedProtocolEntry protocolEntry;
			if (false == CompiledAllServiceProtocolMap.Instace.ProtocolMap.TryGetValue(protocolId, out protocolEntry))
			{
				//SendPacketErrorResponse(localHeader, ResultCode.ErrorProtocolNotMatched);
				Debug.Log(string.Format("Error protocol not registered in ProtocolMap: {0}", protocolId));
				return;
			}

			var resObject = _serializer.Deserialize(payload, protocolEntry.ResponseResultType);
			if (resObject == null)
			{
				Debug.Log(string.Format("Deserialize failed: {0}", protocolEntry.ResponseResultType));
				return;
			}

			// TODO: 
			//if (protocolEntry.IsNotifyMessage)
			//{

			//}
			//else
			{
				if (resObject is Response == false)
				{
					Debug.Log(string.Format("Type casting failed (Response): ResObject type: {0}, ResObject ToString(): {1}", resObject.GetType().Name, resObject));
					return;
				}

				if (resObject.GetType() != protocolEntry.ResponseResultType)
				{
					Debug.Log(string.Format("Type casting failed: ResObject type: {0}, ProtocolEntry type: {1}", resObject.GetType().Name, protocolEntry.ResponseResultType));
					return;
				}

				// 동기콜.
				_packetDispatchList[protocolId].DispatchFunctor.Invoke(resObject);
			}

			// TODO: need unique key
			_packetDispatchList.Remove(protocolId);
		}

		public bool HasProtocol(int protocolId)
		{
			if (false == _packetDispatchList.ContainsKey(protocolId))
			{
				return false;
			}
			return true;
		}

		public void Connect(String ip, int port, DispatchEventFunctor callbackConnectResult = null, DispatchEventFunctor callbackDisconnectResult = null)
		{
			if (null != _sock)
			{
				Close();
				_sock = null;
			}

			try
			{
				_sock = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

				IPAddress ipAddr;

				if (false == IPAddress.TryParse(ip, out ipAddr))
				{
					IPHostEntry ipHostInfo = Dns.GetHostEntry(ip);
					ipAddr = ipHostInfo.AddressList[0];
				}
				var remote = new IPEndPoint(ipAddr, port);

				_callbackNetworkEventFunctor[(int)ConnectEventType.OnConnected] = callbackConnectResult;
				_callbackNetworkEventFunctor[(int)ConnectEventType.OnDisconnected] = callbackDisconnectResult;

				_sock.BeginConnect(remote, ConnectComplete, _sock);
			}
			catch (SocketException ex)
			{
				Debug.Log("sock error " + ex.Message);
			}
		}

		public bool IsConnected()
		{
			if (_sock == null)
			{
				return false;
			}
			bool isRead = _sock.Poll(1000, SelectMode.SelectRead);
			bool isAvailable = (_sock.Available == 0);

			if (isRead & isAvailable)
			{
				return false;
			}

			return true;
		}

		private void ConnectComplete(IAsyncResult ar)
		{
			if (_sock.Connected)
			{
				Debug.Log("client connected");

				// callback to owner
				if (null != _callbackNetworkEventFunctor[(int)ConnectEventType.OnConnected])
				{
					_callbackNetworkEventFunctor[(int)ConnectEventType.OnConnected].Invoke((int)ConnectResult.SUCCEEDED);
				}

				StartReceive();
			}
			else
			{
				try
				{
					_sock.EndConnect(ar);
				}
				catch (Exception e)
				{
					Debug.Log("Connect Complete Error : " + e.Message);
				}
				_callbackNetworkEventFunctor[(int)ConnectEventType.OnConnected].Invoke((int)ConnectResult.UnknownError);
			}
		}

		private void StartReceive()
		{
			var state = new StateObject();
			_sock.BeginReceive(state.Buffer,
								0,
								StateObject.MaxBuffSize,
								SocketFlags.None,
								ReceiveComplete,
								state
							  );
		}

		private void ReceiveComplete(IAsyncResult ar)
		{
			var state = (StateObject)ar.AsyncState;
			try
			{
				if (null == _sock)
					return;

				var receiveBytes = _sock.EndReceive(ar);

				// zero bytes read
				if (receiveBytes == 0)
				{
					Shutdown();
					return;
				}

				if (false == ProtocolPackage.Process(receiveBytes, state.Buffer))
				{
					Shutdown();
					return;
				}

				StartReceive();

			}
			catch (Exception e)
			{
				Debug.Log("Error : " + e.Message);
				Shutdown();
			}
		}

		//public void Send<T, TResponse>(int protocolId, T requestObject, DispatcherFunctor<TResponse> cb)
		//	where T : class
		//	where TResponse : Response
		public void Send<T>(int protocolId, T requestObject, DispatcherFunctor cb)
			where T : class
		{
			if (_sock == null || _sock.Connected == false)
			{
				Debug.Log("Send failed. _sock is null or disconnected.");
				return;
			}
			BindProtocol(protocolId, cb);
			SendInternal(protocolId, _serializer.Serialize(requestObject));
		}

		private void SendInternal(int protocolId, byte[] payload)
		{
			var state = new StateObject();
			try
			{
				var header = new PacketDefaultHeader(payload.Length, protocolId, (int)PacketSerializeMode.JsonText);

				var buffer = ByteHelper.MergeBytes(header.Serialize(), payload);
				if (buffer == null)
					return;

				_sock.BeginSend(buffer, 0, buffer.Length, 0, SendComplete, state);
			}
			catch (SocketException sockEx)
			{
				Debug.Log("Socket Exception : " + sockEx.ToString());
				Close();
				// retry connection             
			}
			catch (Exception generalEx)
			{
				Debug.Log("general Exception : " + generalEx.ToString());
				Close();
			}
		}

		private void SendComplete(IAsyncResult ar)
		{
			// StateObject state = (StateObject)ar.AsyncState;
			Debug.Log("Send Completed");
			try
			{
				if (null == _sock)
					return;

				int len = _sock.EndSend(ar);
			}
			catch (Exception e)
			{
				Debug.Log("Error : " + e.Message);
				Shutdown();
			}
		}

		public void Close()
		{
			Shutdown();
		}

		private void Shutdown()
		{
			if (_sock != null)
			{
				// callback to callee
				if (null != _callbackNetworkEventFunctor[(int)ConnectEventType.OnDisconnected])
				{
					_callbackNetworkEventFunctor[(int)ConnectEventType.OnDisconnected].Invoke(0);
				}

				_sock.Shutdown(SocketShutdown.Both);
				_sock = null;
			}
		}
	}
}