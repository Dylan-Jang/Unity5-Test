using System;
using System.Globalization;

using Rhyme.Common.Utilities;

using UnityEngine;

namespace Rhyme.Common
{
	public enum TableSize
	{
		TwoPlayer = 2,
		SixPlayer = 6,
		NinePlayer = 9,
	}

	public enum RittOptionFlag
	{
		RittDecision,
		RittAccept,
		RittDecline,
	}

	public enum SoundActiveWindowType
	{
		Always = 0,
		OnlyActivated
	}

	public enum SoundInTheHandType
	{
		Always = 0,
		OnlyIntheHand
	}

	public enum SoundOnlyForMyActionType
	{
		EveryOne = 0,
		OnlyMe
	}

	public enum SoundGameType
	{
		None = 0,
		HoldemNormal,
		HoldemAof,
		HoldemJump,
		OmahaNormal,
		OmahaAof,
		TournamentHoldem,
		SitNGoHoldem,
		Ofc
	}

	public enum SoundStatus
	{
		None = 0,
		Playing,
		Stop,
		Pause
	}

	public enum Configurations
	{
		//Server Address Options
		ServerAddress,
		ServerPort,

		//Login Options
		RememberId,
		StoredId,

		//Linking to URL Options
		MoneyShopPage,
		BonusShopPage,
		CreateAccountPage,
		ForgotIdPasswordPage,
		HomePage,

		//Table Filter Options
		TableFilter2Players,
		TableFilter6Players,
		TableFilter9Players,
		TableFilterHideOrFull,

		//Theme Options
		Theme,

		//Default Theme (All)
		ThemeFeltIndexAll,
		ThemeBoundaryIndexAll,
		ThemeBackgroundIndexAll,
		ThemeCardForegroundIndexAll,
		ThemeCardBackgroundIndexAll,

		ThemeFeltIndexRingGame,
		ThemeBoundaryIndexRingGame,
		ThemeBackgroundIndexRingGame,
		ThemeCardForegroundIndexRingGame,
		ThemeCardBackgroundIndexRingGame,

		ThemeFeltIndexSitAndGo,
		ThemeBoundaryIndexSitAndGo,
		ThemeBackgroundIndexSitAndGo,
		ThemeCardForegroundIndexSitAndGo,
		ThemeCardBackgroundIndexSitAndGo,

		ThemeFeltIndexTourney,
		ThemeBoundaryIndexTourney,
		ThemeBackgroundIndexTourney,
		ThemeCardForegroundIndexTourney,
		ThemeCardBackgroundIndexTourney,

		ThemeFeltIndexRingGameOmaha,
		ThemeFeltIndexRingGameAof,

		//Table Options
		TableOptionAnimation,
		TableOptionPlayerImageShow,
		TableOptionFourColorDeck,
		TableOptionSaveTableLocation,
		TableOptionRankImageShow,
		TableOptionNationalFlagShow,
		TableOptionRunItThreeTimes,
		TableOptionJackpotNoticeAllTables,

		//TableSeat Options
		TableSeatTwoIndex,
		TableSeatSixIndex,
		TableSeatNineIndex,

		//AutoBuyIn Options
		BuyInAutoUse,
		BuyInWindowAutoHide,
		BuyInAutoRatio,

		//AutoBuy Options
		AutoBuyUse,
		AutoBuyLowerLimit,
		AutoBuyUpperLimit,

		//MouseWheel Betting Option
		MouseWheelBettingInvert,
		MouseWheelBettingBigBlind,

		//EnterKey Betting Confirm Option
		EnterKeyBettingConfirm,

		//HandHistory Options
		HandHistorySave,
		HandHistoryFilePath,

		//Sound Options
		SoundMute,
		SoundVolume,
		SoundEffect,
		SoundMusic,
		SoundVoice,
		SoundNotification,

		//Language
		Language,

		//TimeZone
		TimeZone,

		//Chatting Options
		ChattingReceiveWhisper,
		ChattingPopupWhisper,
		ChattingReceiveMemo,
		ChattingShowTableChatting,
		ChattingShowTableChattingBalloon,
		ChattingReceiveBuddy,

		//Screenshot save path
		ScreenshotFilePath,

		//Buddy Window
		BuddyWindowShowOfflineBuddy,

		// Bet Amount Shortcut Option
		BetAmountShortcutOption1,
		BetAmountShortcutOption2,
		BetAmountShortcutOption3,
		/// <summary>
		/// Default Value : 50
		/// </summary>
		BetAmountShortcutOptionValue1,
		/// <summary>
		/// Default Value : 75
		/// </summary>
		BetAmountShortcutOptionValue2,
		/// <summary>
		/// Default Value : 100
		/// </summary>
		BetAmountShortcutOptionValue3,

		// MoveTableHelpMessageBox visible option
		IsShowMoveTableMessageBox,
	}

	public enum TourneyBrandFilter
	{
		[StringTableKeyName("AllTourneyBrands")]
		All,

		//[StringTableKeyName("Lucky8")]
		//Lucky8,

		//[StringTableKeyName("MicroSaturday")]
		//MicroSaturday,

		//[StringTableKeyName("MegaSunday")]
		//MegaSunday,

		[StringTableKeyName("SuperSunday")]
		SuperSunday,

		[StringTableKeyName("WuXing")]
		WuXing,

		[StringTableKeyName("ChineseZodiacFreeroll")]
		ChineseZodiacFreeroll,

		[StringTableKeyName("PrivateTourney", "PrivateTourneyAbbreviated")]
		PrivateTournaments,

		[StringTableKeyName("TourneyShowCompleted")]
		Completed
	}

	public enum ChineseZodiac
	{
		[StringTableKeyName("ChineseZodiacRat")]
		Rat = 1,

		[StringTableKeyName("ChineseZodiacOx")]
		Ox = 2,

		[StringTableKeyName("ChineseZodiacTiger")]
		Tiger = 3,

		[StringTableKeyName("ChineseZodiacRabbit")]
		Rabbit = 4,

		[StringTableKeyName("ChineseZodiacDragon")]
		Dragon = 5,

		[StringTableKeyName("ChineseZodiacSnake")]
		Snake = 6,

		[StringTableKeyName("ChineseZodiacHorse")]
		Horse = 7,

		[StringTableKeyName("ChineseZodiacGoat")]
		Goat = 8,

		[StringTableKeyName("ChineseZodiacMonkey")]
		Monkey = 9,

		[StringTableKeyName("ChineseZodiacRooster")]
		Rooster = 10,

		[StringTableKeyName("ChineseZodiacDog")]
		Dog = 11,

		[StringTableKeyName("ChineseZodiacPig")]
		Pig = 12,
	}

	[Flags]
	public enum TourneyEventType
	{
		[StringTableKeyName("BuyInNormal")]
		Normal = 1,

		[StringTableKeyName("TourneyEntryNameBuyInType1R1A")]
		OneRebuyAndOneAddon = 1 << 1,

		[StringTableKeyName("TourneyEntryNameBuyInTypeRebuy")]
		Rebuy = 1 << 2,

		[StringTableKeyName("TourneyEntryNameBounty")]
		Bounty = 1 << 3,

		[StringTableKeyName("QuickJoinBuyInJumpGame")]
		Jump = 1 << 4,

		[StringTableKeyName("BigCategoryShootoutGame")]
		Shootout = 1 << 5,
	}

	[Flags]
	public enum TourneyDisplayedType
	{
		None = 0,
		Flipout = 1 << 0,
		[StringTableKeyName("BigCategoryShootoutGame")]
		Shootout = 1 << 1,
		[StringTableKeyName("TourneyEntryNameBounty")]
		Bounty = 1 << 2
	}

	// There is no change from language changed.
	public enum TourneyBuyInKind
	{
		[StringTableKeyName("MenuGgp")]
		[Range(0, 0)]
		GGP,

		[Range(0, 0)]
		Freeroll,

		[Range(100, 990)]
		BuyInRangeOne,

		[Range(1000, 9990)]
		BuyInRangeTwo,

		[Range(10000, 49990)]
		BuyInRangeThree,

		[Range(50000, 199990)]
		BuyInRangeFour,

		[StringTableKeyName("FilterTypeTourneyBuyInFilterOverRange")]
		[Range(200000, 0)]
		BuyInRangeFive,
	}

	public enum TourneyPlayersType
	{
		[StringTableKeyName("FilterTypeTourneyOneOrMorePlayersUnit")]
		[Range(0, 19)]
		PlayerRangeOne,

		[StringTableKeyName("FilterTypeTourneyPlayersUnit")]
		[Range(20, 99)]
		PlayerRangeTwo,

		[StringTableKeyName("FilterTypeTourneyPlayersFilterOverRange")]
		[Range(100, 0)]
		PlayerRangeThree
	}

	public enum TourneyPrizeType
	{
		[StringTableKeyName("TourneyRegisterMoney")]
		Cash,

		[StringTableKeyName("TourneyTicket")]
		Ticket
	}

	public enum MegaSpinTableTypes
	{
		Waiting,
		Normal,
		LowPrize,
		HighPrize
	}

	public enum MegaSpinFeltTypes
	{
		Green,
		Orange,
		Blue,
		Red,
		Purple
	}

	public static partial class Constants
	{
		public const int NumTableKind = 3;
		public const double BlindPostDelayInSeconds = 0.5;
		public const double DealHoleCardDelayInSeconds = 0.5;
		public const double CardRunDelayInSeconds = 2;
		public const double ShowCardDelayInSeconds = 2;
		public const double InitialRemainingTimeBank = -1;
		public static double RITTAskingDelayInSeconds = 6;
		public const int LobbyWindowMinHeight = 600;
		public const int TableWindowWidth = 800; //삭제예정
		public const int TableWindowHeight = 600;
		public const int TableWindowMinWidth = 500;
		public const int TableWindowMinHeight = 375;
		public const int TableWindowMarginX = 40;
		public const int TableWindowMarginY = 40;
		public const int TableWindowLocationProcedure = 4;
		public const double WindowBaseTitleHeaderHeight = 30d;
		public const int RITTRountCount = 3;

		public const double WindowSizeAspectRatio = 1.333d;
		public const double WindowDefaultSizeWidth = 808d;
		public const double WindowDefaultSizeHeight = 608d;

		public const int MaxJumpEntries = 8;
		public const int MaxBuyInTime = 10; // It was decreased from 30sec to 10sec.
		public const int InvalidJumpGroupId = -1;
		public const int MaxParticipatableTableCount = 12;
		public const int MaxObservableTableCount = 12;
		public const int MaxPrivateTablesPerAccount = 5;
		public const int MaxRankImageCount = 10;
		public const int NoticeExposureTime = 10;  //Seconds
		public const int NotifyRankExposureTime = 5; //Seconds
		public const int RefreshExposureTime = 60; //Seconds
		public const int GetRewardCount = 100;
		public const int GGPro = -1;
		public const int HHKing = -2;
		public const int MaxMessageLength = 200;
		public const int HoleCardCountHoldemTexas = 2;
		public const int HoleCardCountHoldemOmaha = 4;
		public const int MaxHoleCardCount = 4;
		public const int MaxLimitBetCount = 4;
		public const int MaxRetryLoginCount = 2;
		public const long MinInputValue = 10;
		public const int MinusAmountInSitOutTime = 60;
		public const int MinEnableSitOutTime = 60;
		public const int CashGameStartWaitInterval = 5;  // sec
		public const int DealerReadyStateWaitInterval = 1;  // sec
		// 해당시간 동안 혼자 있으면 대기모드로 변경
		public const int MaxLimitWatingInterval = 10; // sec

		// 링게임에서 게임에 참여하기 위한 최소금액을 계산하는 상수 (BigBlind * Multiplier 가 최소금액)
		public const int MinParticipateChipMultiplier = 2;

		//handHighlight constants
		public const double HandHighlightCaptureScreenWidth = 800;
		public const double HandHighlightRunItThreeTimesRowOffset = 300;
		public const double HandHighlightNormalRowOffset = 200;
		public const double HandScreenshowWindowHeight = 850;

		//tableSeatIndex constants
		public const int NinePlayerStandardSeatIndex = 5;
		public const int EightPlayerStandardSeatIndex = 4;
		public const int SixPlayerStandardSeatIndex = 3;
		public const int FivePlayerStandardSeatIndex = 3;
		public const int FourPlayerStandardSeatIndex = 2;
		public const int ThreePlayerStandardSeatIndex = 1;
		public const int TwoPlayerStandardSeatIndex = 1;

		//tourney constants
		public const int TourneyCancelDurationMinutes = 2;
		public const int TourneyUnlimitedRebuyCount = 999;
		public const int TourneyIgnoreRebuyAndAddonCount = -1;
		public const int TourneyNoticeTimerRebuyPeriod = 15;
		public const long TourneyStakeCategoryMicroLimit = 5000;
		public const long TourneyStakeCategoryLowLimit = 50000;
		public const long TourneyStakeCategoryMediumLimit = 150000;
		public const string TourneyTicketExpirationUnlimited = "2999-12-31 23:59:59.997";
		public const int TourneyTicketDiscountMinuteLimit = 30;
		public const int TourneyTimeBankMinSeconds = 3;

		//sitandgo constants
		public const int SitAndGoBuyInLimitLoki = 1000;
		public const int SitAndGoBuyInLimitHeracles = 5000;
		public const int SitAndGoBuyInLimitThor = 18000;
		public const int SitAndGoBuyInLimitAres = 48000;
		public const int SitAndGoBuyInLimitPoseidon = 110000;
		public const int SitAndGoBuyInLimitHades = 240000;
		public static double SitAndGoLobbyMinHeight = 640;

		// stake category filter constants
		public const int StakeCategoryMicroLimit = 50;
		public const int StakeCategoryLowLimit = 500;
		public const int StakeCategoryMediumLimit = 3000;

		public const int AllInOrFoldStakeCategoryMicroLimit = 500;
		public const int AllInOrFoldStakeCategoryLowLimit = 5000;
		public const int AllInOrFoldStakeCategoryMediumLimit = 10000;

		public const int JumpStakeCategoryMicroLimit = 50;
		public const int JumpStakeCategoryLowLimit = 500;
		public const int JumpStakeCategoryMediumLimit = 3000;

		// Registry specific
		public const long TableControllerMask = 0x0100000000000000L;
		public const long PlayerNoteControllerMask = 0x0200000000000000L;

		public const string DefaultLanguage = "en";

		public const int GoodsPerPage = 6;
		public const long GGPtoTournamentMoneyRate = 8;

		public const int LeaderBoardItemsPerPage = 12;

		public const int RedisConnectionPoolSize = 30;
		public const int RedisPoolTimeoutSeconds = 20;

		public const int MaxLimitMessageLength = 140;

		public const int ReEntryFrequencyLimitCount = 2;
		// sec
		public const int ReEntryFrequencyLimitTime = 60;

		public const int CheckTimeBettingHandCount = 50;

		//Tourney Brand constants
		public const string TourneyBrandChineseZodiac = "Chinese Zodiac";
		public const string TourneyBrandWuXing = "Wu Xing";
		public const string TourneyBrandWuXingSatellite = "Wu Xing Satellite";
		public const string TourneyBrandSuperSunday = "Super Sunday";
		public const string TourneyBrandSuperSundaySatellite = "Super Sunday Satellite";
		public const string TourneyBrandPrivate = "Private";
		public const string TourneyBrandMiniSunday = "Mini Sunday";

		public const int TourneyBrandSuperSundayTurboBuyIn = 5000;
		public const int TourneyBrandSuperSundayHyperBuyIn = 1000;

		public const int TourneyBrandSuperWuxingTurboBuyIn = 1000;
		public const int TourneyBrandSuperWuxingHyperBuyIn = 250;

		public const long TourneyDeepStackChips = 9999;

		//obsoletes
		public const string TourneyBrandLucky8 = "Lucky 88 Everyday";
		public const string TourneyBrandMicroSaturday = "Micro Saturday";
		public const string TourneyBrandMegaSunday = "Mega Sunday";
		public const string TourneyBrandMegaSundaySatellite = "Mega Sunday Satellite";
		//

		//Jump Disconncet reason
		public const uint EndedJumpGame = 1;

		// $1,000
		public const int LeastAccumJackpotAmount = 1000000;
		// $20,000
		public const int LeastGiveTicketJackpotAmount = 20000000;

		public static readonly CultureInfo DisplayDefaultCulture = new CultureInfo("en-us");

		//Monitor Screen constants
		public static double MimimumSupportedMonitorSizeHeight = 900;
		public static double MinimumSupportedHandHighlightSizeHeight = 600;

		// value for sync between client, server
		public const int TimeBankSyncToClient = 4;
		public const int AskingBlindPostSyncToClient = 3; // sec

		// Sound 
		public const int SoundMultiple = 2;

		//predefined avatars count (change later)
		public const int MaxExtendPredefinedAvatarCount = 40;

		//font URI
		public const string FontSegoeUI = "/Rhyme.Resources;component/Common/Fonts/#Arial";
		public const string FontYaHeiUI = "/Rhyme.Resources;component/Common/Fonts/#Microsoft YaHei UI";
		public const string FontNanumGothic = "/Rhyme.Resources;component/Common/Fonts/#NanumGothic";
		public const string FontLucidaSansTypeWriter = "/Rhyme.Resources;component/Common/Fonts/#Arial";

		public const string LanguageKorean = "ko";
		public const string LanguageEnglish = "en";
		public const string LanguageChineseCn = "zh-cn";
		public const string LanguageChineseTw = "zh-tw";
		public const string LanguageChinesePlay = "zh-play";
		public const string LanguageIndonesian = "id";
		public const string LanguageVietnam = "vi";
		public const string LanguageKhmer = "km";
		public const string LanguageThai = "th";
		public const string LanguageJapanese = "ja";

		//PreferenceConstants
		public const string PreferenceXml = "Preferences.xml";
		public const string PlayerNoteXml = "PlayerNotes.xml";
		public const string BrandXml = "Brand.xml";
		public const string LauncherIni = "launcher.ini";

		// Mega Spin
		public const int MaxLimitMegaSpinEntryPerBuyInAmountCount = 999;
		public const int MaxLimitMegaSpinEntryCount = 999;
		public const int MegaSpinMinPlayerStartGame = 3;
		public const int MaxMegaSpinStoriesCount = 5;
		public const int MaxMegaSpinBestWinnersCount = 3;
		public const int MegaSpinDefaultStartingTimeAddDuration = 19;
		public const int MegaSpinMegaStartingTimeAddDuration = 34;
		public const int MegaSpinHighMultiplierTimeAddDuration = 47;
		public const string StopMegaSpinRegistrationKeyword = "stopmegaspinregistration";
		public const string StartMegaSpinRegistrationKeyword = "startmegaspinregistration";

		// auto join
		public const int MaxCanTakeSeatTableForEachBlind = 999;
		public const int MaxCanTakeSeatTableCount = 999;
		public const int BlockTimeToMoveSameTable = 10;
		public const bool TurnOffComparePersonalMinBuyInCheckLogic = true;

		// couchdb (portal)
		public const string CouchdbConflictMessage = "conflict";

		public const int AddedSitoutTime = 30;

		public const string GPRedisCashGameKeyName = "cashGame";
		public const string GPRedisTourneyGameKeyName = "tourney";

		public const int JoinGameEntryMinCount = 1;
		public const int JoinGameEntryMaxCount = 4;

		public const string CertificateUrl = "http://www.ggnet.com/certificate/bmm";
		public const string DownloadImagesPath = "DownloadImages\\";

		//card
		public const double DefaultMyCardWidth = 64;	//my hole card, community card;
		public const double DefaultMyCardHeight = 89;	//my hole card, community card;

		public const double DefaultCardWidth = 56;		//normal player hole card
		public const double DefaultCardHeight = 78;		//normal player hole card
	}
}
