using Assets.Script.Network.Socket;
using Rb.Services.Protocol;
using Rb.Services.Protocol.Account;
using Rb.Services.Protocol.Auth;
using Rb.Services.Protocol.GameTable;
using Rhyme.Client.Protocol.Enum;
using Rhyme.Common.Protocol.Session;
using UnityEngine;

namespace Assets
{
	public partial class UnitySocketClient
	{
		private void BindAllSessionProtocol()
		{
			////////////////////////////////////////////////////////////////////////
			// auto generated code
			// do not modify manually
			////////////////////////////////////////////////////////////////////////

			_socket.BindProtocol((int)RhymeClientSessionEnum.Ping, new SocketCallbackBinder<PingResponse> { DispatchFunctor = SessionOnPing, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.ProtocolTest, new SocketCallbackBinder<ProtocolTestResponse> { DispatchFunctor = SessionOnProtocolTest, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.Login, new SocketCallbackBinder<LoginResponse> { DispatchFunctor = SessionOnLogin, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetBalance, new SocketCallbackBinder<GetBalanceResponse> { DispatchFunctor = SessionOnGetBalance, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetRankInfo, new SocketCallbackBinder<GetRankInfoResponse> { DispatchFunctor = SessionOnGetRankInfo, IsNotify = false, });
			//_socket.BindProtocol((int)RhymeClientSessionEnum.RequestNotifyRecentHandHistories, null);
			_socket.BindProtocol((int)RhymeClientSessionEnum.UpdateUserOption, new SocketCallbackBinder<UpdateUserOptionResponse> { DispatchFunctor = SessionOnUpdateUserOption, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetUserOption, new SocketCallbackBinder<GetUserOptionResponse> { DispatchFunctor = SessionOnGetUserOption, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.SetNickName, new SocketCallbackBinder<SetNickNameResponse> { DispatchFunctor = SessionOnSetNickName, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetTickets, new SocketCallbackBinder<GetTicketsResponse> { DispatchFunctor = SessionOnGetTickets, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.PurchaseTourneyTicket, new SocketCallbackBinder<PurchaseTourneyTicketResponse> { DispatchFunctor = SessionOnPurchaseTourneyTicket, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetBuddyList, new SocketCallbackBinder<GetBuddyListResponse> { DispatchFunctor = SessionOnGetBuddyList, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.DeleteBuddyList, new SocketCallbackBinder<DeleteBuddyListResponse> { DispatchFunctor = SessionOnDeleteBuddyList, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetJackpotHistoryList, new SocketCallbackBinder<JackpotHistoryResponse> { DispatchFunctor = SessionOnGetJackpotHistoryList, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.UpdatePlayerImage, new SocketCallbackBinder<UploadPlayerImageResponse> { DispatchFunctor = SessionOnUpdatePlayerImage, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetJackpotHandHistory, new SocketCallbackBinder<GetJackpotHandHistoryResponse> { DispatchFunctor = SessionOnGetJackpotHandHistory, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetAvailableAvatarList, new SocketCallbackBinder<GetAvailableAvatarListResponse> { DispatchFunctor = SessionOnGetAvailableAvatarList, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetJackpotAmount, new SocketCallbackBinder<GetJackpotAmountResponse> { DispatchFunctor = SessionOnGetJackpotAmount, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetLogoInfo, new SocketCallbackBinder<GetLogoInfoResponse> { DispatchFunctor = SessionOnGetLogoInfo, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.CreateToken, new SocketCallbackBinder<CreateTokenResponse> { DispatchFunctor = SessionOnCreateToken, IsNotify = false, });
			//_socket.BindProtocol((int)RhymeClientSessionEnum.RequestAddBuddyAccept, null);
			_socket.BindProtocol((int)RhymeClientSessionEnum.EnterLobby, new SocketCallbackBinder<EnterLobbyResponse> { DispatchFunctor = SessionOnEnterLobby, IsNotify = false, });
			//_socket.BindProtocol((int)RhymeClientSessionEnum.LeaveLobby, null);
			_socket.BindProtocol((int)RhymeClientSessionEnum.EnterGameLobby, new SocketCallbackBinder<EnterGameLobbyResponse> { DispatchFunctor = SessionOnEnterGameLobby, IsNotify = false, });
			//_socket.BindProtocol((int)RhymeClientSessionEnum.LeaveGameLobby, null);
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetLobbyPlayers, new SocketCallbackBinder<GetLobbyPlayersResponse> { DispatchFunctor = SessionOnGetLobbyPlayers, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetGameLobbyPlayers, new SocketCallbackBinder<GetGameLobbyPlayersResponse> { DispatchFunctor = SessionOnGetGameLobbyPlayers, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.SendWhisper, new SocketCallbackBinder<SendWhisperResponse> { DispatchFunctor = SessionOnSendWhisper, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.RequestAddBuddy, new SocketCallbackBinder<RequestAddBuddyResponse> { DispatchFunctor = SessionOnRequestAddBuddy, IsNotify = false, });
			//_socket.BindProtocol((int)RhymeClientSessionEnum.RequestAddBuddyDecline, null);
			//_socket.BindProtocol((int)RhymeClientSessionEnum.TestChat, null);
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetTables, new SocketCallbackBinder<GetTablesResponse> { DispatchFunctor = SessionOnGetTables, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetTableTypes, new SocketCallbackBinder<GetTableTypesResponse> { DispatchFunctor = SessionOnGetTableTypes, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetTablePlayers, new SocketCallbackBinder<GetTablePlayersResponse> { DispatchFunctor = SessionOnGetTablePlayers, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetMultiTablePlayers, new SocketCallbackBinder<GetMultiTablePlayersResponse> { DispatchFunctor = SessionOnGetMultiTablePlayers, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.WaitingQueuePlace, new SocketCallbackBinder<WaitingQueuePlaceResponse> { DispatchFunctor = SessionOnWaitingQueuePlace, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.WaitingQueueCancel, new SocketCallbackBinder<WaitingQueueCancelResponse> { DispatchFunctor = SessionOnWaitingQueueCancel, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.JoinCashGame, new SocketCallbackBinder<JoinCashGameResponse> { DispatchFunctor = SessionOnJoinCashGame, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetTourneyList, new SocketCallbackBinder<GetTourneyListResponse> { DispatchFunctor = SessionOnGetTourneyList, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetTourneyPlayers, new SocketCallbackBinder<TourneyGetPlayersResponse> { DispatchFunctor = SessionOnGetTourneyPlayers, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetTourneyTablePlayers, new SocketCallbackBinder<TourneyGetTablePlayersResponse> { DispatchFunctor = SessionOnGetTourneyTablePlayers, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.RegisterTourneyEntry, new SocketCallbackBinder<TourneyRegistrationResponse> { DispatchFunctor = SessionOnRegisterTourneyEntry, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.UnregisterTourneyEntry, new SocketCallbackBinder<TourneyUnregistrationResponse> { DispatchFunctor = SessionOnUnregisterTourneyEntry, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.SubscribeTourney, new SocketCallbackBinder<TourneySubscribeResponse> { DispatchFunctor = SessionOnSubscribeTourney, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.UnsubscribeTourney, new SocketCallbackBinder<TourneyUnsubscribeResponse> { DispatchFunctor = SessionOnUnsubscribeTourney, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetTourneyTables, new SocketCallbackBinder<TourneyGetTablesResponse> { DispatchFunctor = SessionOnGetTourneyTables, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetTourneyReconnectInformation, new SocketCallbackBinder<TourneyGetReconnectInformationResponse> { DispatchFunctor = SessionOnGetTourneyReconnectInformation, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetMegaSpinTypeList, new SocketCallbackBinder<GetMegaSpinTypeListResponse> { DispatchFunctor = SessionOnGetMegaSpinTypeList, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetMegaSpinList, new SocketCallbackBinder<GetMegaSpinListResponse> { DispatchFunctor = SessionOnGetMegaSpinList, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.RegisterMegaSpinEntry, new SocketCallbackBinder<MegaSpinRegistrationResponse> { DispatchFunctor = SessionOnRegisterMegaSpinEntry, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.UnregisterMegaSpinEntry, new SocketCallbackBinder<MegaSpinUnregistrationResponse> { DispatchFunctor = SessionOnUnregisterMegaSpinEntry, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetMegaSpinStories, new SocketCallbackBinder<GetMegaSpinStoriesResponse> { DispatchFunctor = SessionOnGetMegaSpinStories, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetMegaSpinBestWinners, new SocketCallbackBinder<GetMegaSpinBestWinnersResponse> { DispatchFunctor = SessionOnGetMegaSpinBestWinners, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.CreateDumpTable, new SocketCallbackBinder<CreateDumpTableResponse> { DispatchFunctor = SessionOnCreateDumpTable, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.UseItem, new SocketCallbackBinder<UseItemResponse> { DispatchFunctor = SessionOnUseItem, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.BuyItem, new SocketCallbackBinder<BuyItemResponse> { DispatchFunctor = SessionOnBuyItem, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetMegaPhoneUseHistory, new SocketCallbackBinder<GetMegaPhoneUseHistoryResponse> { DispatchFunctor = SessionOnGetMegaPhoneUseHistory, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.GetLoginReward, new SocketCallbackBinder<GetLoginRewardResponse> { DispatchFunctor = SessionOnGetLoginReward, IsNotify = false, });
			_socket.BindProtocol((int)RhymeClientSessionEnum.CollectLoginStamp, new SocketCallbackBinder<CollectLoginStampResponse> { DispatchFunctor = SessionOnCollectLoginStamp, IsNotify = false, });

			////////////////////////////////////////////////////////////////////////
			// auto generated code
			// do not modify manually
			////////////////////////////////////////////////////////////////////////

			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifySessionDisconnect, new SocketCallbackBinder<NotifySessionDisconnectParameter> { DispatchFunctor = SessionCallbackOnNotifySessionDisconnect, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyNotice, new SocketCallbackBinder<NotifyNoticeParameter> { DispatchFunctor = SessionCallbackOnNotifyNotice, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTestChat, new SocketCallbackBinder<NotifyTestChatParameter> { DispatchFunctor = SessionCallbackOnNotifyTestChat, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyRelevantRank, new SocketCallbackBinder<NotifyRelevantRankParameter> { DispatchFunctor = SessionCallbackOnNotifyRelevantRank, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTransferFund, new SocketCallbackBinder<NotifyTransferFundParameter> { DispatchFunctor = SessionCallbackOnNotifyTransferFund, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyUpdateBuddy, new SocketCallbackBinder<NotifyUpdateBuddyParameter> { DispatchFunctor = SessionCallbackOnNotifyUpdateBuddy, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyDeleteBuddy, new SocketCallbackBinder<NotifyDeleteBuddyParameter> { DispatchFunctor = SessionCallbackOnNotifyDeleteBuddy, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyJackpotAnnounce, new SocketCallbackBinder<NotifyJackpotAnnounceParameter> { DispatchFunctor = SessionCallbackOnNotifyJackpotAnnounce, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyCreateHandHistory, new SocketCallbackBinder<NotifyCreateHandHistoryParameter> { DispatchFunctor = SessionCallbackOnNotifyCreateHandHistory, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyRecentHandHistories, new SocketCallbackBinder<RequestNotifyRecentHandHistoriesRequest> { DispatchFunctor = SessionCallbackOnNotifyRecentHandHistories, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyUpdatePlayerAvatarId, new SocketCallbackBinder<NotifyUpdatePlayerAvatarIdParameter> { DispatchFunctor = SessionCallbackOnNotifyUpdatePlayerAvatarId, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyUpdateNickNameForGP, new SocketCallbackBinder<NotifyUpdateNickNameForGPRequest> { DispatchFunctor = SessionCallbackOnNotifyUpdateNickNameForGP, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyEnterLobby, new SocketCallbackBinder<NotifyEnterLobbyParameter> { DispatchFunctor = SessionCallbackOnNotifyEnterLobby, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyLeaveLobby, new SocketCallbackBinder<NotifyLeaveLobbyParameter> { DispatchFunctor = SessionCallbackOnNotifyLeaveLobby, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyEnterGameLobby, new SocketCallbackBinder<NotifyEnterGameLobbyParameter> { DispatchFunctor = SessionCallbackOnNotifyEnterGameLobby, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyLeaveGameLobby, new SocketCallbackBinder<NotifyLeaveGameLobbyParameter> { DispatchFunctor = SessionCallbackOnNotifyLeaveGameLobby, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyWhisperReceived, new SocketCallbackBinder<NotifyWhisperReceivedParameter> { DispatchFunctor = SessionCallbackOnNotifyWhisperReceived, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyRequestAddBuddy, new SocketCallbackBinder<NotifyRequestAddBuddyParameter> { DispatchFunctor = SessionCallbackOnNotifyRequestAddBuddy, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyRequestAddBuddyDecline, new SocketCallbackBinder<NotifyRequestAddBuddyDeclineParameter> { DispatchFunctor = SessionCallbackOnNotifyRequestAddBuddyDecline, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyCreateTable, new SocketCallbackBinder<NotifyCreateTableParameter> { DispatchFunctor = SessionCallbackOnNotifyCreateTable, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyCloseTable, new SocketCallbackBinder<NotifyCloseTableParameter> { DispatchFunctor = SessionCallbackOnNotifyCloseTable, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyWaitJoinTable, new SocketCallbackBinder<NotifyWaitJoinTableParameter> { DispatchFunctor = SessionCallbackOnNotifyWaitJoinTable, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTablePlayerBalance, new SocketCallbackBinder<NotifyTablePlayerBalanceParameter> { DispatchFunctor = SessionCallbackOnNotifyTablePlayerBalance, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyWaitingCancel, new SocketCallbackBinder<NotifyWaitingCancelParameter> { DispatchFunctor = SessionCallbackOnNotifyWaitingCancel, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyCashGameReady, new SocketCallbackBinder<NotifyCashGameReadyParameter> { DispatchFunctor = SessionCallbackOnNotifyCashGameReady, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTablePlayerCountChanged, new SocketCallbackBinder<NotifyTablePlayerCountChangedParameter> { DispatchFunctor = SessionCallbackOnNotifyTablePlayerCountChanged, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTourneyCreated, new SocketCallbackBinder<NotifyTourneyCreated> { DispatchFunctor = SessionCallbackOnNotifyTourneyCreated, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTourneyRemoved, new SocketCallbackBinder<NotifyTourneyRemoved> { DispatchFunctor = SessionCallbackOnNotifyTourneyRemoved, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTourneyListChanged, new SocketCallbackBinder<NotifyTourneyListingChanged> { DispatchFunctor = SessionCallbackOnNotifyTourneyListChanged, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTourneyDetailChanged, new SocketCallbackBinder<NotifyTourneyDetailChanged> { DispatchFunctor = SessionCallbackOnNotifyTourneyDetailChanged, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTourneyNewHandStart, new SocketCallbackBinder<NotifyTourneyNewHandStart> { DispatchFunctor = SessionCallbackOnNotifyTourneyNewHandStart, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTourneyPlayersUpdated, new SocketCallbackBinder<NotifyTourneyPlayersUpdated> { DispatchFunctor = SessionCallbackOnNotifyTourneyPlayersUpdated, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTourneyGameReady, new SocketCallbackBinder<NotifyTourneyGameReady> { DispatchFunctor = SessionCallbackOnNotifyTourneyGameReady, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTourneyDroppedOut, new SocketCallbackBinder<NotifyTourneyDroppedOut> { DispatchFunctor = SessionCallbackOnNotifyTourneyDroppedOut, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTourneyGameReadyBulk, new SocketCallbackBinder<NotifyTourneyGameReadyBulk> { DispatchFunctor = SessionCallbackOnNotifyTourneyGameReadyBulk, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTourneyBreakTime, new SocketCallbackBinder<NotifyTourneyBreakTime> { DispatchFunctor = SessionCallbackOnNotifyTourneyBreakTime, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTourneyRewardAvatar, new SocketCallbackBinder<NotifyTourneyRewardAvatar> { DispatchFunctor = SessionCallbackOnNotifyTourneyRewardAvatar, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyHighMultiplier, new SocketCallbackBinder<NotifyHighMultiplierParameter> { DispatchFunctor = SessionCallbackOnNotifyHighMultiplier, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyMegaSpinStoryNewInfo, new SocketCallbackBinder<NotifyMegaSpinStoryNewInfoParameter> { DispatchFunctor = SessionCallbackOnNotifyMegaSpinStoryNewInfo, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyMegaSpinPlayingCountChanged, new SocketCallbackBinder<NotifyCurrentPlayingMegaSpinCountChangedParameter> { DispatchFunctor = SessionCallbackOnNotifyMegaSpinPlayingCountChanged, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyTourneyBlindUp, new SocketCallbackBinder<NotifyTourneyBlindUpParameter> { DispatchFunctor = SessionCallbackOnNotifyTourneyBlindUp, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyMegaSpinBestWinnerNewInfo, new SocketCallbackBinder<NotifyMegaSpinBestWinnerNewInfoParameter> { DispatchFunctor = SessionCallbackOnNotifyMegaSpinBestWinnerNewInfo, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyBuyItem, new SocketCallbackBinder<NotifyBuyItemParameter> { DispatchFunctor = SessionCallbackOnNotifyBuyItem, IsNotify = true, });
			_socket.BindProtocol((int)RhymeClientSessionCallbackEnum.NotifyMegaPhone, new SocketCallbackBinder<NotifyMegaPhoneParameter> { DispatchFunctor = SessionCallbackOnNotifyMegaPhone, IsNotify = true, });
		}

		////////////////////////////////////////////////////////////////////////
		// auto generated code
		// do not modify manually
		////////////////////////////////////////////////////////////////////////

		private void SessionOnPing(PingResponse response)
		{
			Debug.Log(string.Format("Execute: Session-Ping: Result={0}", response.Result));
		}

		private void SessionOnProtocolTest(ProtocolTestResponse response)
		{
			Debug.Log(string.Format("Execute: Session-ProtocolTest: Result={0}", response.Result));

			// TODO: for test
			SessionOnProtocolTestInternal(response);
		}

		private void SessionOnLogin(LoginResponse response)
		{
			Debug.Log(string.Format("Execute: Session-Login: Result={0}", response.Result));

			OnLoginResponseInternal(response);
		}

		private void SessionOnGetBalance(GetBalanceResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetBalance: Result={0}", response.Result));

			OnGetBalanceResponseInternal(response);
		}

		private void SessionOnGetRankInfo(GetRankInfoResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetRankInfo: Result={0}", response.Result));
		}


		private void SessionOnUpdateUserOption(UpdateUserOptionResponse response)
		{
			Debug.Log(string.Format("Execute: Session-UpdateUserOption: Result={0}", response.Result));
		}

		private void SessionOnGetUserOption(GetUserOptionResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetUserOption: Result={0}", response.Result));
		}

		private void SessionOnSetNickName(SetNickNameResponse response)
		{
			Debug.Log(string.Format("Execute: Session-SetNickName: Result={0}", response.Result));
		}

		private void SessionOnGetTickets(GetTicketsResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetTickets: Result={0}", response.Result));
		}

		private void SessionOnPurchaseTourneyTicket(PurchaseTourneyTicketResponse response)
		{
			Debug.Log(string.Format("Execute: Session-PurchaseTourneyTicket: Result={0}", response.Result));
		}

		private void SessionOnGetBuddyList(GetBuddyListResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetBuddyList: Result={0}", response.Result));
		}

		private void SessionOnDeleteBuddyList(DeleteBuddyListResponse response)
		{
			Debug.Log(string.Format("Execute: Session-DeleteBuddyList: Result={0}", response.Result));
		}

		private void SessionOnGetJackpotHistoryList(JackpotHistoryResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetJackpotHistoryList: Result={0}", response.Result));
		}

		private void SessionOnUpdatePlayerImage(UploadPlayerImageResponse response)
		{
			Debug.Log(string.Format("Execute: Session-UpdatePlayerImage: Result={0}", response.Result));
		}

		private void SessionOnGetJackpotHandHistory(GetJackpotHandHistoryResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetJackpotHandHistory: Result={0}", response.Result));
		}

		private void SessionOnGetAvailableAvatarList(GetAvailableAvatarListResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetAvailableAvatarList: Result={0}", response.Result));
		}

		private void SessionOnGetJackpotAmount(GetJackpotAmountResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetJackpotAmount: Result={0}", response.Result));
		}

		private void SessionOnGetLogoInfo(GetLogoInfoResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetLogoInfo: Result={0}", response.Result));
		}

		private void SessionOnCreateToken(CreateTokenResponse response)
		{
			Debug.Log(string.Format("Execute: Session-CreateToken: Result={0}", response.Result));
		}


		private void SessionOnEnterLobby(EnterLobbyResponse response)
		{
			Debug.Log(string.Format("Execute: Session-EnterLobby: Result={0}", response.Result));
		}


		private void SessionOnEnterGameLobby(EnterGameLobbyResponse response)
		{
			Debug.Log(string.Format("Execute: Session-EnterGameLobby: Result={0}", response.Result));
		}


		private void SessionOnGetLobbyPlayers(GetLobbyPlayersResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetLobbyPlayers: Result={0}", response.Result));
		}

		private void SessionOnGetGameLobbyPlayers(GetGameLobbyPlayersResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetGameLobbyPlayers: Result={0}", response.Result));
		}

		private void SessionOnSendWhisper(SendWhisperResponse response)
		{
			Debug.Log(string.Format("Execute: Session-SendWhisper: Result={0}", response.Result));
		}

		private void SessionOnRequestAddBuddy(RequestAddBuddyResponse response)
		{
			Debug.Log(string.Format("Execute: Session-RequestAddBuddy: Result={0}", response.Result));
		}



		private void SessionOnGetTables(GetTablesResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetTables: Result={0}", response.Result));
		}

		private void SessionOnGetTableTypes(GetTableTypesResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetTableTypes: Result={0}", response.Result));

			OnGetTableTypesResponseInternal(response);
		}

		private void SessionOnGetTablePlayers(GetTablePlayersResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetTablePlayers: Result={0}", response.Result));
		}

		private void SessionOnGetMultiTablePlayers(GetMultiTablePlayersResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetMultiTablePlayers: Result={0}", response.Result));
		}

		private void SessionOnWaitingQueuePlace(WaitingQueuePlaceResponse response)
		{
			Debug.Log(string.Format("Execute: Session-WaitingQueuePlace: Result={0}", response.Result));
		}

		private void SessionOnWaitingQueueCancel(WaitingQueueCancelResponse response)
		{
			Debug.Log(string.Format("Execute: Session-WaitingQueueCancel: Result={0}", response.Result));
		}

		private void SessionOnJoinCashGame(JoinCashGameResponse response)
		{
			Debug.Log(string.Format("Execute: Session-JoinCashGame: Result={0}", response.Result));
		}

		private void SessionOnGetTourneyList(GetTourneyListResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetTourneyList: Result={0}", response.Result));
		}

		private void SessionOnGetTourneyPlayers(TourneyGetPlayersResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetTourneyPlayers: Result={0}", response.Result));
		}

		private void SessionOnGetTourneyTablePlayers(TourneyGetTablePlayersResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetTourneyTablePlayers: Result={0}", response.Result));
		}

		private void SessionOnRegisterTourneyEntry(TourneyRegistrationResponse response)
		{
			Debug.Log(string.Format("Execute: Session-RegisterTourneyEntry: Result={0}", response.Result));
		}

		private void SessionOnUnregisterTourneyEntry(TourneyUnregistrationResponse response)
		{
			Debug.Log(string.Format("Execute: Session-UnregisterTourneyEntry: Result={0}", response.Result));
		}

		private void SessionOnSubscribeTourney(TourneySubscribeResponse response)
		{
			Debug.Log(string.Format("Execute: Session-SubscribeTourney: Result={0}", response.Result));
		}

		private void SessionOnUnsubscribeTourney(TourneyUnsubscribeResponse response)
		{
			Debug.Log(string.Format("Execute: Session-UnsubscribeTourney: Result={0}", response.Result));
		}

		private void SessionOnGetTourneyTables(TourneyGetTablesResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetTourneyTables: Result={0}", response.Result));
		}

		private void SessionOnGetTourneyReconnectInformation(TourneyGetReconnectInformationResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetTourneyReconnectInformation: Result={0}", response.Result));
		}

		private void SessionOnGetMegaSpinTypeList(GetMegaSpinTypeListResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetMegaSpinTypeList: Result={0}", response.Result));
		}

		private void SessionOnGetMegaSpinList(GetMegaSpinListResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetMegaSpinList: Result={0}", response.Result));
		}

		private void SessionOnRegisterMegaSpinEntry(MegaSpinRegistrationResponse response)
		{
			Debug.Log(string.Format("Execute: Session-RegisterMegaSpinEntry: Result={0}", response.Result));
		}

		private void SessionOnUnregisterMegaSpinEntry(MegaSpinUnregistrationResponse response)
		{
			Debug.Log(string.Format("Execute: Session-UnregisterMegaSpinEntry: Result={0}", response.Result));
		}

		private void SessionOnGetMegaSpinStories(GetMegaSpinStoriesResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetMegaSpinStories: Result={0}", response.Result));
		}

		private void SessionOnGetMegaSpinBestWinners(GetMegaSpinBestWinnersResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetMegaSpinBestWinners: Result={0}", response.Result));
		}

		private void SessionOnCreateDumpTable(CreateDumpTableResponse response)
		{
			Debug.Log(string.Format("Execute: Session-CreateDumpTable: Result={0}", response.Result));
		}

		private void SessionOnUseItem(UseItemResponse response)
		{
			Debug.Log(string.Format("Execute: Session-UseItem: Result={0}", response.Result));
		}

		private void SessionOnBuyItem(BuyItemResponse response)
		{
			Debug.Log(string.Format("Execute: Session-BuyItem: Result={0}", response.Result));
		}

		private void SessionOnGetMegaPhoneUseHistory(GetMegaPhoneUseHistoryResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetMegaPhoneUseHistory: Result={0}", response.Result));
		}

		private void SessionOnGetLoginReward(GetLoginRewardResponse response)
		{
			Debug.Log(string.Format("Execute: Session-GetLoginReward: Result={0}", response.Result));
		}

		private void SessionOnCollectLoginStamp(CollectLoginStampResponse response)
		{
			Debug.Log(string.Format("Execute: Session-CollectLoginStamp: Result={0}", response.Result));
		}

		////////////////////////////////////////////////////////////////////////
		// auto generated code
		// do not modify manually
		////////////////////////////////////////////////////////////////////////

		private void SessionCallbackOnNotifySessionDisconnect(NotifySessionDisconnectParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifySessionDisconnect"));
		}

		private void SessionCallbackOnNotifyNotice(NotifyNoticeParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyNotice"));
		}

		private void SessionCallbackOnNotifyTestChat(NotifyTestChatParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTestChat"));
		}

		private void SessionCallbackOnNotifyRelevantRank(NotifyRelevantRankParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyRelevantRank"));
		}

		private void SessionCallbackOnNotifyTransferFund(NotifyTransferFundParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTransferFund"));
		}

		private void SessionCallbackOnNotifyUpdateBuddy(NotifyUpdateBuddyParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyUpdateBuddy"));
		}

		private void SessionCallbackOnNotifyDeleteBuddy(NotifyDeleteBuddyParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyDeleteBuddy"));
		}

		private void SessionCallbackOnNotifyJackpotAnnounce(NotifyJackpotAnnounceParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyJackpotAnnounce"));
		}

		private void SessionCallbackOnNotifyCreateHandHistory(NotifyCreateHandHistoryParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyCreateHandHistory"));
		}

		private void SessionCallbackOnNotifyRecentHandHistories(RequestNotifyRecentHandHistoriesRequest notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyRecentHandHistories"));
		}

		private void SessionCallbackOnNotifyUpdatePlayerAvatarId(NotifyUpdatePlayerAvatarIdParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyUpdatePlayerAvatarId"));
		}

		private void SessionCallbackOnNotifyUpdateNickNameForGP(NotifyUpdateNickNameForGPRequest notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyUpdateNickNameForGP"));
		}

		private void SessionCallbackOnNotifyEnterLobby(NotifyEnterLobbyParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyEnterLobby"));
		}

		private void SessionCallbackOnNotifyLeaveLobby(NotifyLeaveLobbyParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyLeaveLobby"));
		}

		private void SessionCallbackOnNotifyEnterGameLobby(NotifyEnterGameLobbyParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyEnterGameLobby"));
		}

		private void SessionCallbackOnNotifyLeaveGameLobby(NotifyLeaveGameLobbyParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyLeaveGameLobby"));
		}

		private void SessionCallbackOnNotifyWhisperReceived(NotifyWhisperReceivedParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyWhisperReceived"));
		}

		private void SessionCallbackOnNotifyRequestAddBuddy(NotifyRequestAddBuddyParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyRequestAddBuddy"));
		}

		private void SessionCallbackOnNotifyRequestAddBuddyDecline(NotifyRequestAddBuddyDeclineParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyRequestAddBuddyDecline"));
		}

		private void SessionCallbackOnNotifyCreateTable(NotifyCreateTableParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyCreateTable"));
		}

		private void SessionCallbackOnNotifyCloseTable(NotifyCloseTableParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyCloseTable"));
		}

		private void SessionCallbackOnNotifyWaitJoinTable(NotifyWaitJoinTableParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyWaitJoinTable"));
		}

		private void SessionCallbackOnNotifyTablePlayerBalance(NotifyTablePlayerBalanceParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTablePlayerBalance"));
		}

		private void SessionCallbackOnNotifyWaitingCancel(NotifyWaitingCancelParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyWaitingCancel"));
		}

		private void SessionCallbackOnNotifyCashGameReady(NotifyCashGameReadyParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyCashGameReady"));
		}

		private void SessionCallbackOnNotifyTablePlayerCountChanged(NotifyTablePlayerCountChangedParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTablePlayerCountChanged"));
		}

		private void SessionCallbackOnNotifyTourneyCreated(NotifyTourneyCreated notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTourneyCreated"));
		}

		private void SessionCallbackOnNotifyTourneyRemoved(NotifyTourneyRemoved notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTourneyRemoved"));
		}

		private void SessionCallbackOnNotifyTourneyListChanged(NotifyTourneyListingChanged notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTourneyListChanged"));
		}

		private void SessionCallbackOnNotifyTourneyDetailChanged(NotifyTourneyDetailChanged notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTourneyDetailChanged"));
		}

		private void SessionCallbackOnNotifyTourneyNewHandStart(NotifyTourneyNewHandStart notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTourneyNewHandStart"));
		}

		private void SessionCallbackOnNotifyTourneyPlayersUpdated(NotifyTourneyPlayersUpdated notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTourneyPlayersUpdated"));
		}

		private void SessionCallbackOnNotifyTourneyGameReady(NotifyTourneyGameReady notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTourneyGameReady"));
		}

		private void SessionCallbackOnNotifyTourneyDroppedOut(NotifyTourneyDroppedOut notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTourneyDroppedOut"));
		}

		private void SessionCallbackOnNotifyTourneyGameReadyBulk(NotifyTourneyGameReadyBulk notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTourneyGameReadyBulk"));
		}

		private void SessionCallbackOnNotifyTourneyBreakTime(NotifyTourneyBreakTime notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTourneyBreakTime"));
		}

		private void SessionCallbackOnNotifyTourneyRewardAvatar(NotifyTourneyRewardAvatar notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTourneyRewardAvatar"));
		}

		private void SessionCallbackOnNotifyHighMultiplier(NotifyHighMultiplierParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyHighMultiplier"));
		}

		private void SessionCallbackOnNotifyMegaSpinStoryNewInfo(NotifyMegaSpinStoryNewInfoParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyMegaSpinStoryNewInfo"));
		}

		private void SessionCallbackOnNotifyMegaSpinPlayingCountChanged(NotifyCurrentPlayingMegaSpinCountChangedParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyMegaSpinPlayingCountChanged"));
		}

		private void SessionCallbackOnNotifyTourneyBlindUp(NotifyTourneyBlindUpParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyTourneyBlindUp"));
		}

		private void SessionCallbackOnNotifyMegaSpinBestWinnerNewInfo(NotifyMegaSpinBestWinnerNewInfoParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyMegaSpinBestWinnerNewInfo"));
		}

		private void SessionCallbackOnNotifyBuyItem(NotifyBuyItemParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyBuyItem"));
		}

		private void SessionCallbackOnNotifyMegaPhone(NotifyMegaPhoneParameter notify)
		{
			Debug.Log(string.Format("Execute: SessionCallback-SessionOnNotifyMegaPhone"));
		}
	}
}
