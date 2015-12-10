using Assets.Script.Network.Socket;
using Rhyme.Client.Protocol.Enum;
using UnityEngine;

namespace Assets.Script
{
	public partial class UnitySocketClient : MonoBehaviour
	{
		//private static readonly UnitySocketClient _instance = new UnitySocketClient();
		//public static UnitySocketClient Instance
		//{
		//	get { return _instance; }
		//}

		public int SendIterationCount = 1;

		private readonly ClientSocket _socket = new ClientSocket();
		private bool _isConnected = false;
		internal ClientSocket Socket
		{
			get { return _socket; }
		}

		internal bool IsConnected
		{
			get { return _socket != null && _socket.IsConnected(); }
		}

		//private UnitySocketClientLogic _logic;

		public UnitySocketClient()
		{
			//_logic = new UnitySocketClientLogic();
		}

		// Use this for initialization
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{
			// TODO: fetch in thread pool then post to UI Thread ?
			if (_socket.IsConnected())
			{
				_socket.ExecuteTask();
			}
		}

		// Connect test
		public void Connect()
		{
			_socket.Connect("localhost", 6124, OnConnected, OnDisconnected);
		}

		protected void OnConnected(int result)
		{
			_isConnected = true;
		}

		protected void OnDisconnected(int result)
		{
			_isConnected = false;
		}

		public RhymeClientSessionEnum sessionEnum;

		public void Send()
		{
			if (_isConnected == false) return;

			for (var i = 0; i < SendIterationCount; ++i)
			{
				//SendGetTableTypes(new GetTableTypesRequest { UserDeviceType = DeviceType.Pc, }, OnGetTableTypesResponse);

				// 1402
				//_socket.Send((int)RhymeClientSessionEnum.GetTableTypes, requestGetTableType, OnGetTableTypesResponse);
			}
		}
	}
}
