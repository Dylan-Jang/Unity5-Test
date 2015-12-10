using System.Collections.Generic;
using Rb.Services.Protocol;
using Rb.Services.Protocol.Account;
using Rb.Services.Protocol.GameTable;
using Rhyme.Client.Protocol.Enum;

namespace Assets.Script.Network
{
	internal class CompiledAllServiceProtocolMap
	{
		private static readonly CompiledAllServiceProtocolMap _instance = new CompiledAllServiceProtocolMap();
		public static CompiledAllServiceProtocolMap Instace
		{
			get { return _instance; }
		}

		private readonly Dictionary<int, BindedProtocolEntry> _protocolMap = new Dictionary<int, BindedProtocolEntry>();
		public Dictionary<int, BindedProtocolEntry> ProtocolMap
		{
			get { return _protocolMap; }
		}

		public CompiledAllServiceProtocolMap()
		{
			// TODO: need generate
			BindServiceProtocol(new BindedProtocolEntry((int)RhymeClientSessionEnum.Ping, "IRhymeClientSession", null, null, typeof(PingResponse), typeof(PingResponse)));
			BindServiceProtocol(new BindedProtocolEntry((int)RhymeClientSessionEnum.Login, "IRhymeClientSession", null, typeof(LoginRequest), typeof(LoginResponse), typeof(LoginResponse)));
			BindServiceProtocol(new BindedProtocolEntry((int)RhymeClientSessionEnum.GetBalance, "IRhymeClientSession", null, typeof(GetBalanceRequest), typeof(GetBalanceResponse), typeof(GetBalanceResponse)));
			BindServiceProtocol(new BindedProtocolEntry((int)RhymeClientSessionEnum.GetRankInfo, "IRhymeClientSession", null, typeof(GetRankInfoRequest), typeof(GetRankInfoResponse), typeof(GetRankInfoResponse)));
			BindServiceProtocol(new BindedProtocolEntry((int)RhymeClientSessionEnum.RequestNotifyRecentHandHistories, "IRhymeClientSession", null, typeof(void), typeof(RequestNotifyRecentHandHistoriesRequest), typeof(RequestNotifyRecentHandHistoriesRequest)));
			BindServiceProtocol(new BindedProtocolEntry((int)RhymeClientSessionEnum.UpdateUserOption, "IRhymeClientSession", null, typeof(UpdateUserOptionRequest), typeof(UpdateUserOptionResponse), typeof(UpdateUserOptionResponse)));

			BindServiceProtocol(new BindedProtocolEntry((int)RhymeClientSessionEnum.GetTableTypes, "IRhymeClientSession", null, typeof(GetTableTypesRequest), typeof(GetTableTypesResponse), typeof(GetTableTypesResponse)));
		}

		private void BindServiceProtocol(BindedProtocolEntry info)
		{
			BindedProtocolEntry protocolEntryType;
			if (_protocolMap.TryGetValue(info.ProtocolId, out protocolEntryType))
				return;

			//_protocolMap.Add(info.ProtocolId, new BindedProtocolEntry(info.ProtocolId, info.InterfaceType, info.MethodInfo, info.RequestType, info.ResponseType, info.ResponseResultType, info.MethodBuildInfos.GetAsyncMethodInvoker()));
			_protocolMap.Add(info.ProtocolId, new BindedProtocolEntry(info.ProtocolId, info.InterfaceTypeString, info.MethodInfo, info.RequestType, info.ResponseType, info.ResponseResultType));
		}
	}
}
