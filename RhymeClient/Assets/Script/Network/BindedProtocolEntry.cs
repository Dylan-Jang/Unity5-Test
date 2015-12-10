using System;
using System.Reflection;

namespace Assets.Script.Network
{
	internal class BindedProtocolEntry
	{
		private readonly int _protocolId;
		//private readonly Type _interfaceType;
		private readonly string _interfaceTypeString;
		private readonly MethodInfo _methodInfo;
		private readonly Type _requestType;
		private readonly Type _responseType;
		private readonly Type _responseResultType;
		//private readonly AsyncFastMethodInvoker _binedMethodInvoker;

		public override string ToString()
		{
			return string.Format("ProtocolId:{0},InterfaceType:{1},RequestType:{2},ResponseType:{3}", _protocolId, _interfaceTypeString, _requestType.Name, _responseResultType.Name);
		}

		//public BindedProtocolEntry(int protocolId, Type interfaceType, MethodInfo methodInfo, Type requestType, Type responseType, Type responseResultType, AsyncFastMethodInvoker binedMethodInvoker)
		public BindedProtocolEntry(int protocolId, String interfaceTypeString, MethodInfo methodInfo, Type requestType, Type responseType, Type responseResultType)
		{
			_protocolId = protocolId;					// 1101
			//_interfaceType = interfaceType;			// IRhymeClientSession
			_interfaceTypeString = interfaceTypeString;	// IRhymeClientSession
			_methodInfo = methodInfo;
			_requestType = requestType;					// LoginRequest
			_responseType = responseType;				// Task<LoginResponse>
			_responseResultType = responseResultType;	// LoginResponse
			//_binedMethodInvoker = binedMethodInvoker;
		}

		public int ProtocolId
		{
			get { return _protocolId; }
		}

		//public Type InterfaceType
		//{
		//	get { return _interfaceType; }
		//}

		public string InterfaceTypeString
		{
			get { return _interfaceTypeString; }
		}

		public MethodInfo MethodInfo
		{
			get { return _methodInfo; }
		}

		public Type RequestType
		{
			get { return _requestType; }
		}

		public Type ResponseType
		{
			get { return _responseType; }
		}

		public Type ResponseResultType
		{
			get { return _responseResultType; }
		}

		//public AsyncFastMethodInvoker BinedMethodInvoker
		//{
		//	get { return _binedMethodInvoker; }
		//}
	}
}
