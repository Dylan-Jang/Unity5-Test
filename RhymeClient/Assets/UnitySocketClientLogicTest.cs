using System;
using Rb.Services.Protocol.Account;
using Rb.Services.Protocol.GameTable;
using Rhyme.Bot.Common;
using Rhyme.Bot.Helper;
using Rhyme.Client.Protocol.Enum;
using Rhyme.Common;
using UnityEngine;
using DeviceType = Rhyme.Common.DeviceType;

namespace Assets
{
	public partial class UnitySocketClient
	{
		public void Protocol_Login()
		{
			var token = new PlatformToken
			{
				gp_id = "bot1",
				token = "bot1",
			};

			_socket.Send((int)RhymeClientSessionEnum.Login, new LoginRequest
			{
				Token = token.token,
				ProtocolVersion = Protocols.ProtocolVersion,
				ServiceProviderName = "2ACE",
				BrandId = "2ACE",
				GpId = token.gp_id,
				//HardwareSerialNumber = await NetworkHelper.CreateHardwareNumber(),
				MacAddress = NetworkHelper.GetMacAddress(),
				UserDeviceType = DeviceType.Pc,
				UserOsType = OSType.Windows,
			});
		}

		private void OnLoginResponseInternal(LoginResponse response)
		{
			Debug.Log(string.Format("TResponse {0}, Type: {1}, ToString: {2}, ResultCode: {3} ({4})",
				response.Result == ResultCode.Success ? "Success" : "Failed",
				response.GetType().Name, response, response.Result, (int)response.Result));
		}

		public void Protocol_GetTableTypes()
		{
			_socket.Send((int)RhymeClientSessionEnum.GetTableTypes, new GetTableTypesRequest
			{
				UserDeviceType = DeviceType.Pc,
			});
		}

		private void OnGetTableTypesResponseInternal(GetTableTypesResponse response)
		{
			Debug.Log(string.Format("TResponse {0}, Type: {1}, ToString: {2}, ResultCode: {3} ({4})",
				response.Result == ResultCode.Success ? "Success" : "Failed",
				response.GetType().Name, response, response.Result, (int)response.Result));

			foreach (var tableType in response.TableTypes)
			{
				Debug.Log(string.Format("{0}, {1}/{2}, {3}, {4}", tableType.Id, tableType.Stake.SmallBlind, tableType.Stake.BigBlind, tableType.GameBuyInType, tableType.GameType));
			}
		}

		public void Protocol_GetBalance()
		{
			_socket.Send((int)RhymeClientSessionEnum.GetBalance, new GetBalanceRequest
			{
				UserId = Guid.NewGuid(),
				UserName = "userName",
			});
		}

		private void OnGetBalanceResponseInternal(GetBalanceResponse response)
		{
			Debug.Log(string.Format("TResponse {0}, Type: {1}, ToString: {2}, ResultCode: {3} ({4})",
				response.Result == ResultCode.Success ? "Success" : "Failed",
				response.GetType().Name, response, response.Result, (int)response.Result));
		}
	}
}
