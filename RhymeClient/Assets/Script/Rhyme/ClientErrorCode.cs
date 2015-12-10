namespace Rhyme.Common
{
	public enum ClientErrorCode
	{
		Success = 0,

		// General error codes 1-1000
		Error = 1,
		ErrorException = 2,

		// Lobby related error codes 1001-2000
		ErrorOpenTable = 1001,
		ErrorInviteeNotFound = 1002,
		ErrorInviteeDeclined = 1003,
		ErrorInvitedTableNotFound = 1004,
		ErrorInvalidThumbImage = 1005,
		ErrorAccountNotFound = 1006,
		ErrorMailDenied = 1007,
		ErrorMultipleLogIn = 1008,

		// Table related error codes 2001- 3000
		ErrorStandUpFailed = 2001,
		ErrorReservedSeatFailed = 2002,
		ErrorBuyInFailed = 2003,
		ErrorKickedByTable = 2004,
		ErrorBuyInTimedOut = 2005,
		ErrorUnableToCreatePrivateTable = 2006,
		ErrorInternalTableError = 2007,
		ErrorTableNotFound = 2008,
		ErrorUnableToConnectTableService = 2009,
		ErrorSecurityNegotiationFailed = 2010,
		ErrorMaxObserving = 2011,
		ErrorMaxParticipating = 2012,
		ErrorWaitingListFull = 2013,
		ErrorLessThanMinBuyIn = 2014,
		ErrorLessThanLastSaveBalance = 2015,
		ErrorReEntryFrequencyLimit = 2016,

		// Server related error codes 3001-4000
		ErrorDisconnectedFromServer = 3001,
		ErrorServerNotFound = 3002,

		// Misc 4001-5000
		ErrorRunUpdater = 4001,
		ErrorInvalidVersion = 4002,
		ErrorBlockCountryCode = 4003,
		ErrorAccountLocked = 4004,
		ErrorImageLocked = 4005,
		ErrorNotEnoughBalance = 4006,
		ErrorServiceProviderMismatch = 4007,
		ErrorUnknownIPAddress = 4008,

		// Jump Service 5001-6000
		ErrorJumpTooManyEntries = 5001,
		ErrorJumpEntryNotFound = 5002,
		ErrorJumpFindEntryByUserNotFound = 5003,
		ErrorJumpFindUserEntryNotFound = 5004,
		ErrorJumpAlreadyAddedSubscriber = 5005,
		ErrorJumpRegistSubscriberFailed = 5006,
		ErrorJumpUnRegistSubscriberFailed = 5007,
		ErrorJumpChangeUserStateFailed = 5008,
		ErrorJumpGetTableInformationFailed = 5009,
		ErrorJumpGetUserEntriesFailed = 5010,
		ErrorJumpAddUserEntryFailed = 5011,
		ErrorJumpTableNotFound = 5012,
		ErrorJumpNotEnoughBalance = 5013,

		// Tourney related error codes 6001-7000
		ErrorTourneyUserAlreadyRegistered = 6001,
		ErrorTourneyUserNotRegistered = 6002,
		ErrorTourneyUserAlreadySubscribed = 6003,
		ErrorTourneyUserNotSubscribed = 6004,
		ErrorTourneyRegisterNotAllowed = 6005,
		ErrorTourneyUnregisterNotAllowed = 6006,
		ErrorTourneyNotFound = 6007,
		ErrorTourneyTableNotFound = 6008,
		ErrorTourneyRegisterMaxPlayersExceeded = 6009,
		ErrorTourneyPlayerAlreadyAddedOn = 6010,
		ErrorTourneyPlayerNotOnBreak = 6011,
		ErrorTourneyPlayerNoRemainingRebuy = 6012,
		ErrorTourneyIsNotAddonPeriod = 6013,
		ErrorTourneyTooManyChipsRebuyNotAllowed = 6014,
		ErrorTourneyAlreadyExistingPendingRebuy = 6015,
		ErrorTourneyTicketNotFound = 6016,
		ErrorTourneyInvalidUserRank = 6017,
		ErrorTourneyInvalidServiceProvider = 6018,
		ErrorTourneyMoneyInsufficient = 6019,
		ErrorTourneyTicketAlreadyUsedOrExpired = 6020,
		ErrorTourneyTicketNotUsed = 6021,
		ErrorTourneyFailedToCancelTicketUse = 6022,
		ErrorTourneyAlreadyCreated = 6023,
		ErrorTourneyMustUseTicket = 6024,
		ErrorTourneyTicketDiscountTimeOver = 6025,
		ErrorTourneyTicketAlreadyDiscountPurchase = 6026,

		ErrorTourneyIsNotRebuyPeriod = 6030,
		ErrorTourneyMegaSpinRegisterMaxExceeded = 6031,
		ErrorStopMegaSpinRegistration = 6032,

		//Client related error codes 10001-11000
		ErrorQuickJoinRingGameFailed = 10001,
		ErrorQuickJoinTourneyFailed = 10002,
		ErrorInvalidFindImage = 10003,
	}

	public static class ClientErrorCodeHelper
	{
		public static string GetErrorCodeString(ClientErrorCode errorCode)
		{
			string retString = errorCode.ToString().Replace("ClientErrorCodes.", "");
			return retString;
		}
	}
}