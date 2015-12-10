using System;

using ProtoBuf;

using Rhyme.Common.Attributes;

namespace Rhyme.Common
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum GameType
	{
		Holdem = 0,
		Badugi = 1,
		SevenOrdinary = 2,
		Omaha = 3,
		Irish = 4,
		UnKnown = 5,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum LeaveSeatReason
	{
		None = 0,
		ByUser = 1,
		TimedOut = 2,
		DropOutFromTournament = 3,
		Immigration = 4,
		MoveNewRound = 5,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TableInformationType
	{
		Ring,
		// for sync with CRM
		Jump,
		Tourney,
		/// <summary>
		/// 싯앤고에서 메가스핀으로 변경됐습니다.
		/// </summary>
		SitAndGo,
		TeamGame,
		HomeGame,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum BuyInLevel
	{
		Short = 0,
		Normal = 1,
		Deep = 2
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum GameSpeed
	{
		Slow,
		Normal,
		Fast
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	[Flags]
	public enum SitAndGoBrand
	{
		Unknown = 0,
		FreeRoll = 1,
		Theomachy = 2,
		Dogfight = 4,
		Qualifier = 8,
		Multiple = 16,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	[Flags]
	public enum GameLimitType
	{
		Unknown = 0,
		Limit = 1,
		NoLimit = 2,
		PotLimit = 4,
		Half = 8,
		Quarter = 16,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	[Flags]
	public enum StakeCategory
	{
		Unknown = 0,
		High = 1,
		Medium = 2,
		Low = 4,
		Micro = 8,
		FreeRoll = 16,
		All = 31,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	[Flags]
	public enum GameBuyInType
	{
		Unknown = 0,
		Normal = 1,
		AllInOrFold = 1 << 1,

		[ExposeBranch(ExposeBranchType.TwoAce)]
		Dump = 1 << 2,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum CardKind
	{
		Club = 0,
		Diamond = 1,
		Heart = 2,
		Spade = 3,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum GamePlayerStatus
	{
		Observing = 0,
		Waiting = 1,
		SittingOut = 2,
		Playing = 3,
		LeftTable = 4,
	};

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum BlindType
	{
		Small = 0,
		Big = 1,
		Dead = 2,
		Ante = 3,
		Straddle = 4,
		ChineseFee = 5,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum DealerState
	{
		Waiting = 0,
		Ready = 1,
		Dealing = 2,
		AskBlindPost = 3,

		[ExposeBranch(ExposeBranchType.TwoAce)]
		AskReadyToConfirm = 4,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum GameHoldemState
	{
		Unknown = 0,
		PreFlop = 1,
		Flop = 2,
		Turn = 3,
		River = 4,
		ShowDown = 10,
		End = 99,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum ActionType
	{
		Unknown = 0,
		Check = 1,
		Call = 2,
		Bet = 3,
		Raise = 4,
		Fold = 5,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum AfterAction
	{
		Unknown = 0,
		UncalledBet = 1,
		Show = 2,
		Collect = 3,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	[Flags]
	public enum AutoActionFlag
	{
		None = 0,	// Default action after sit-in.
		PostBlinds = 1 << 0,
		SitOutNextHand = 1 << 1,
		SitOutNextBlind = 1 << 2,
		CheckOrFold = 1 << 3,
		AutoBuyIn = 1 << 4,
		LeaveTable = 1 << 5,
		TimeBank = 1 << 6,
		WaitForJoinNow = 1 << 7,
		WaitForBigBlind = 1 << 8,
		TourneySitOutNextHand = 1 << 9,
		TourneySitOut = 1 << 10,
		RITT = 1 << 11,
		ForceLeaveTableNextHand = 1 << 12,
		PostStraddle = 1 << 13,
		AskingForBlindPost = 1 << 14,
		InitSitoutTimeBank = 1 << 15,
		AskingForBigBlindPost = 1 << 16,	// 대기모드인 플레이어가 리싯된경우 사용

		[ExposeBranch(ExposeBranchType.TwoAce)]
		AskReadyToConfirm = 1 << 17,
		[ExposeBranch(ExposeBranchType.TwoAce)]
		ForceLeaveTableNow = 1 << 18,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum NotifyRankInfoType
	{
		None = 0,
		RewardGGPoint = 1,
		RankUp = 2,
		RankDown = 3,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum NoticeType
	{
		Notice,
		Reward,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TablePauseState
	{
		Unpaused,
		WaitForUnpauseSynchronization,
		Paused,
		WaitForPauseSynchronization,
	}
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TableStatus
	{
		Creating,
		Created,
		ReadyToClose,
		Closing,
		Closed,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TourneyAwardType
	{
		None,
		Money,
		Satellite,
		Ticket,
		GGPoint,
	}

	[Flags]
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TourneyBuyInType
	{
		None = 0,
		Money = 1,
		Satellite = 2,
		Ticket = 4,
		TourneyMoney = 8,
		GGPoint = 16,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum PayOutType
	{
		None = 0,

		/// <summary>
		/// 등록 인원수에 따라 보상 변화
		/// </summary>
		EntryBase = 1,

		/// <summary>
		/// 바이인, 리바이 등으로 토너에 소비한 금액에 따라 보상 변화
		/// </summary>
		Satellite = 2
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TicketPrizeType
	{
		None = 0,
		Money = 1,
		GGPoint = 2
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TableTerminationType
	{
		Abnormal = 0,
		Normal = 1,
		PrepareEmmigration = 2,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TablePauseType
	{
		None,
		Admin,
		WaitForRunning,
		HandForHand,
		Break,
		WaitForNewRound,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	[Flags]
	public enum UserOptionFlag
	{
		None = 0,
		DenyWhisper = 1 << 0,
		DenyMail = 1 << 1,
		DenyBuddy = 1 << 2,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TourneyWinLossType
	{
		// be careful not to change the order of enum below, it goes into DB
		TourneyBuyIn = 0,
		TourneyFee = 1,
		TourneyPayOut = 2,
		TourneyRebuy = 3,
		TourneyAddOn = 4,
		TourneyPayOutBounty = 5,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	[Flags]
	public enum SitOutState
	{
		Default = 0,
		Smoking = 1,
		Toilet = 2,
		Drink = 4,
		Charge = 8,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum RBCommandType
	{
		None = 0,
		TableKickOut,
		ClientKickOut,			// 정상적으로 kickout -> leave table 시킴
		ClientAbnomralKickOut,	// 비정상적으로 kickout -> sitting out 시킴(테이블 복구를 위해서)
		ResetPlayerImage,
		ChangeUserFlags,
		ModifyJackpotAmount,
		UpdateIPBlackList,
		ForceTourneyComplete,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum LeaderBoardRequestType
	{
		None = 0,
		TopThree,
		TopFifty,
		MyInfo,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TourneySeatingStatus
	{
		None,
		Waiting,
		CreatingTable,
		SeatingNewPlayers,
		SeatingComplete,
		ImmigratingTable,
		AwardingTable,
		ClosingTable,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TourneyBreakState
	{
		None,
		Paused,
		WaitForPauseSynchronization,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum BetAmountShortcutOption
	{
		Disable,
		OfPot,
		AllIn,
		None,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	[Flags]
	public enum PlayerPositionType
	{
		None = 0,
		Dealer = 1 << 0,
		SmallBlind = 1 << 1,
		BigBlind = 1 << 2,
		Straddle = 1 << 3,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum JumpPlayerState
	{
		None,
		Waiting,
		Playing,
		Canceled,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum JumpMessagingType
	{
		None,
		EnterTableFailed,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum BubbleMessageType
	{
		/// <summary>
		/// Text Message
		/// </summary>
		Text,

		/// <summary>
		/// Graphic Emoticon
		/// </summary>
		Emoticon,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TourneyTableBackgroundImageType
	{
		None = 0,
		ChinesezodiacMouseTable = 1,
		ChinesezodiacCowTable = 2,
		ChinesezodiacTigerTable = 3,
		ChinesezodiacRabbitTable = 4,
		ChinesezodiacDragonTable = 5,
		ChinesezodiacSnakeTable = 6,
		ChinesezodiacHorseTable = 7,
		ChinesezodiacSheepTable = 8,
		ChinesezodiacMonkeyTable = 9,
		ChinesezodiacChickenTable = 10,
		ChinesezodiacDogTable = 11,
		ChinesezodiacPigTable = 12
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TourneyType
	{
		Normal = 0,
		Shootout = 1,
		MegaSpin = 2,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TransactionTag
	{
		NONE,

		// User entered cash game table with funds.
		DEBIT_CASHGAME_BUYIN,
		// User bought more chips into cash game table.
		DEBIT_CASHGAME_REBUY,
		// User bought into a cash tournament or sit&go.
		DEBIT_TOURNAMENT_BUYIN,
		// User purchased add-on in a tournament.
		DEBIT_TOURNAMENT_ADDON,
		// User purchased a re-buy in a tournament.
		DEBIT_TOURNAMENT_REBUY,
		// User left cash game table with funds or with no fund (lost all cash).
		CREDIT_CASHGAME_CASHOUT,
		// User cashed out some chips at the table.
		CREDIT_CASHGAME_REMOVE_CHIPS,
		// User won a jackpot at the table.
		CREDIT_CASHGAME_JACKPOT,
		// User must be refunded the buy-in amount in cash game.
		CREDIT_CASHGAME_REFUND,
		// User won a tournament or sit&go prize.
		CREDIT_TOURNAMENT_PRIZE,
		// Tournament is completed and tournament overlay is finalized for the user.
		CREDIT_TOURNAMENT_COMPLETED,
		// User earned bounty from a bounty tournament.
		CREDIT_TOURNAMENT_BOUNTY,
		// User's tournament or sit&go entry (buy-in + fee) was refunded due to unregistration.
		CREDIT_TOURNAMENT_UNREGISTER,
		// User's tournament or sit&go entry (buy-in + fee), tournament rebuy/addon was refunded due to tournament cancellation.
		CREDIT_TOURNAMENT_ENTRY_REFUND,

		CREDIT_TOURNAMENT_CANCEL_ADDON,

		// User bought into a SNG.
		DEBIT_SNG_BUYIN,
		// User won a SNG prize.
		CREDIT_SNG_PRIZE,
		// SNG is completed and tournament overlay is finalized for the user.
		CREDIT_SNG_COMPLETED,
		// User's SNG entry (buy-in + fee) was refunded due to unregistration.
		CREDIT_SNG_UNREGISTER,
		// User's SNG entry (buy-in + fee) was refunded due to SNG cancellation.
		CREDIT_SNG_ENTRY_REFUND
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum CashOutTag
	{
		NONE,
		LEAVETABLE,
		REMOVECHIPS,
		BUYINFAILED,
		LEADERBOARD,
		REFUND,
		TOURNAMENTBOUNTY,
		TOURNAMENTCANCELADDON,
		TOURNAMENTREFUND,
		TOURNAMENTPRIZE,

		// end
		CashOutTagCount,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum AvatarType
	{
		NONE,
		DEFAULT,
		SPECIAL,
		CUSTOM
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TableUpdateReason
	{
		None = 0,
		GameEndDone = 1,
		GameInit = 2,
		GetLastSaveBalance = 3,
		ResetLastSaveBalance = 4,
		SaveLastBalance = 5,
		ReserveSeat = 6,
		ReserveSeatCancel = 7,
		TakeSeat = 8,
		LeaveSeat = 9,
		WaitingQueuePlace = 10,
		WaitingQueueCancel = 11,
		SitIn2 = 12,
		SitOut2 = 13,
		GameTableCreated = 14,
		GameTableClosed = 15,
		OnGameEnd = 16,
		OnPlayerBuyInChanged = 17,
		CheckReservedExpire = 18,
		SetPrivateTable = 19,
		QueueMoveTablePlayer = 20,
		CheckStandbyPlayerOn = 21,
		CheckStandbyPlayerOff = 22,
		OnDealingEntering = 23,
		ProcessCreateTourneyTable = 24,
		ProcessCloseTourneyTable = 25,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum PlatformGameType
	{
		None,
		HOLDEM,
		OMAHA,
		AOF,
		MEGASPIN,
		TOURNAMENT
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum JoinGameType
	{
		Auto,
		Manual,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TableAlertMessageType
	{
		LeaveTable,
		LeaveTableByAllIn,
		LeaveTableByLess2BB,
		LeaveTableByReject,
		LeaveTableByOneNotAnswer,
		LeaveTableByAllNotAnswer,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	[Flags]
	public enum DeviceType
	{
		Unknown = 0,
		Pc = 1 << 0,
		Web = 1 << 1,
		Mobile = 1 << 2,
		All = Pc | Web | Mobile
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum OSType
	{
		Unknown,
		Windows,
		Mac,
		IOS,
		Android
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum HandIdPlayType
	{
		Unknown = 0,
		Cash = 1,
		Tournament = 2,
		SitAndGo = 3,
	};

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum HandIdGameType
	{
		Unknown = 0,
		Holdem = 1,
		Omaha = 2,
		OFCPineApple = 3,
	};

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum HandIdModeType
	{
		Unknown = 0,
		Normal = 1,
		AOF = 2,
		Jump = 3,

		[ExposeBranch(ExposeBranchType.TwoAce)]
		Dump = 4,
	};
}
