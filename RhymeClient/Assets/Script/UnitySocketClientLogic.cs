using System;
using Rb.Services.Protocol.Account;
using Rb.Services.Protocol.GameTable;
using Rhyme.Bot.Common;
using Rhyme.Bot.Helper;
using Rhyme.Client.Protocol.Enum;
using Rhyme.Common;
using UnityEngine;
using DeviceType = Rhyme.Common.DeviceType;

namespace Assets.Script
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
			}
			, OnLoginResponse);
		}

		private void OnLoginResponse(object payload)
		{
			var response = payload as LoginResponse;
			if (response == null)
			{
				Debug.Log(string.Format("TResponse type casting failed: {0}, ToString: {1}", payload.GetType(), payload));
				return;
			}

			Debug.Log(string.Format("TResponse {0}, Type: {1}, ToString: {2}, ResultCode: {3} ({4})",
				response.Result == ResultCode.Success ? "Success" : "Failed",
				payload.GetType().Name, payload, response.Result, (int)response.Result));
		}

		// TODO: need generate. like Impl class.
		public void Protocol_GetTableTypes()
		{
			_socket.Send((int)RhymeClientSessionEnum.GetTableTypes, new GetTableTypesRequest { UserDeviceType = DeviceType.Pc, }, OnGetTableTypesResponse);
		}

		private void OnGetTableTypesResponse(object payload)
		{
			// 현재는 이게 최선 인듯
			var response = payload as GetTableTypesResponse;
			if (response == null)
			{
				Debug.Log(string.Format("TResponse type casting failed: {0}, ToString: {1}", payload.GetType(), payload));
				return;
			}

			Debug.Log(string.Format("TResponse {0}, Type: {1}, ToString: {2}, ResultCode: {3} ({4})",
				response.Result == ResultCode.Success ? "Success" : "Failed",
				payload.GetType().Name, payload, response.Result, (int)response.Result));

			foreach (var tableType in response.TableTypes)
			{
				Debug.Log(string.Format("{0}, {1}/{2}, {3}, {4}", tableType.Id, tableType.Stake.SmallBlind, tableType.Stake.BigBlind, tableType.GameBuyInType, tableType.GameType));
			}
		}

		//private void OnGetTableTypesResponse2<TResponse>(TResponse res)
		//	where TResponse : Response
		//{
		//	// TODO: need interface. cast object to TResponse.

		//	var response = (TResponse)res;

		//	Debug.Log(string.Format("TResponse name: {0}, Result: {1}", typeof(TResponse).Name, response.Result));
		//}

		public void Protocol_GetBalance()
		{
			_socket.Send((int)RhymeClientSessionEnum.GetBalance, new GetBalanceRequest
			{
				UserId = Guid.NewGuid(),
				UserName = "userName",
			}, OnGetBalanceResponse);
		}

		private void OnGetBalanceResponse(object payload)
		{
			var response = payload as GetBalanceResponse;
			if (response == null)
			{
				Debug.Log(string.Format("TResponse type casting failed: {0}, ToString: {1}", payload.GetType(), payload));
				return;
			}

			Debug.Log(string.Format("TResponse {0}, Type: {1}, ToString: {2}, ResultCode: {3} ({4})",
				response.Result == ResultCode.Success ? "Success" : "Failed",
				payload.GetType().Name, payload, response.Result, (int)response.Result));
		}
	}
}
