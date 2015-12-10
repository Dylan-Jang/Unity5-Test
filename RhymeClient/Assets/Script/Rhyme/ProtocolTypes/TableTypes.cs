using System;
using System.Collections.Generic;
using System.ComponentModel;

using Assets.Script.Extension;

using ProtoBuf;

using Rb.Services.Protocol.Config;
using Rb.Services.Protocol.Game;
using Rb.Services.Protocol.HandHistory;

using Rhyme.Common;
using Rhyme.Common.Attributes;
using Rhyme.Common.ProtocolTypes;
using Rhyme.Common.Utilities;
using Rhyme.Holdem.Elements.Cards;

namespace Rb.Services.Protocol.GameTable
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ServiceConnectInfo
	{
		public string ServiceImplName;
		public uint HostAddress;
		// use HostAddress or TableURL
		public string TableURL;
		public short HostPort;
		public uint ServiceId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TableType
	{
		public uint Id;
		public GameType GameType = GameType.Holdem;
		public GameLimitType GameLimitType = GameLimitType.NoLimit;
		public Stake Stake;
		public uint MaxPlayers = 9;
		public BuyInLevel BuyInLevel = BuyInLevel.Normal;
		public GameSpeed GameSpeed = GameSpeed.Fast;
		public bool BettingCapEnabled = false;
		public int MinEmptyTables = 5;
		public uint MinPlayerStartGame = 2;
		public uint FirstGameStartPlayers = 2;
		public GameBuyInType GameBuyInType = GameBuyInType.Normal;
		public TableInformationType Category = TableInformationType.Ring;
		public DeviceType AllowedDeviceType = DeviceType.Unknown;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TableStat
	{
		public double AveragePotSize = 0;
		public double SeenFlopRatio = 0;
		public double HandPerHour = 0;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TableName
	{
		public string Id;
		public int Suffix;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Table
	{
		public Guid Id;
		public TableName Name;
		public string TourneyName;
		public string TourneyBrandName;
		public int TourneyEventNumber;
		public long TourneyBuyIn;
		public TableType TableType;
		public TableStat Stat;
		public Stake Stake;
		public int? PlayingLevel;
		public int? Level;
		public int CurrentPlayers = 0;
		public List<WaitingPlayer> WaitingPlayers = new List<WaitingPlayer>();
		public Guid TourneyId;
		public bool IsPrivate;
		public bool IsFinalTable;
		public ServiceConnectInfo ServiceConnectInfo;
		public ServiceConnectInfo ServiceConnectInfoPublic;
		public BountyInformation BountyInformation;
		public int? TourneyType;
		public bool IsWaitingNextRound;

		// use for MegaSpin
		public int HandCount;
		public int MegaSpinMultiplier;
		public long MegaSpinTotalPrize;
		public List<TourneyPrizePoolItem> MegaSpinPrizePoolItems = new List<TourneyPrizePoolItem>();

		[ProtoIgnore]
		public TableForLobby TableForLobby;
	}

	/// <summary>
	/// 바로 위에 있는 Table의 경량 버전으로 클라 처음 시작시 GetTables를 통해가져가서 테이블 목록을 보여주는 용도
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TableForLobby
	{
		public Guid Id;
		public TableName Name;
		public TableType TableType;
		public TableStat Stat;
		public Stake Stake;
		public int CurrentPlayers = 0;
		public List<WaitingPlayer> WaitingPlayers = new List<WaitingPlayer>();
		public ServiceConnectInfo ServiceConnectInfo;
		public ServiceConnectInfo ServiceConnectInfoPublic;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TablePlayer : ICloneable
	{
		public Guid UserId;
		public string NickName;
		public int Rank;
		public long Balance;

		// -1 if the player hasn't sat in.
		[DefaultValue(-1)]
		public int SeatIndex = -1;
		public GamePlayerStatus PlayerStatus;
		public bool IsWaitForJoin;
		public long UserSessionId;
		public string CountryCode;
		public int ButtonPosition;
		public bool IsDroppedOut;
		public int RemainingRebuyCount;
		public long AddonAmount;
		public TimeSpan TimeBankRemaining;
		public bool IsTourneySitOut;
		public SitOutState SitOutState;
		public int AvatarId;

		[DefaultValue(PlayerPositionType.None)]
		public PlayerPositionType PlayerPosition;
		public long Bounty;
		public bool IsInTheMoney;
		public bool IsSitOutNextHand;
		public string Username;
		public bool IsAskingBigBlindPost;
		public DateTime KickOutEndTime;
		public string AvatarType;
		public string ImageUrl;

		[ExposeBranch(ExposeBranchType.TwoAce)]
		public DumpBuyInType DumpBuyInType;

		public object Clone()
		{
			return new TablePlayer
			{
				UserId = UserId.Clone(),
				NickName = NickName,
				Rank = Rank,
				Balance = Balance,
				SeatIndex = SeatIndex,
				PlayerStatus = PlayerStatus,
				IsWaitForJoin = IsWaitForJoin,
				UserSessionId = UserSessionId,
				CountryCode = CountryCode,
				ButtonPosition = ButtonPosition,
				IsDroppedOut = IsDroppedOut,
				RemainingRebuyCount = RemainingRebuyCount,
				AddonAmount = AddonAmount,
				TimeBankRemaining = TimeBankRemaining,
				IsTourneySitOut = IsTourneySitOut,
				SitOutState = SitOutState,
				AvatarId = AvatarId,
				PlayerPosition = PlayerPosition,
				Bounty = Bounty,
				IsInTheMoney = IsInTheMoney,
				IsSitOutNextHand = IsSitOutNextHand,
				Username = Username,
				IsAskingBigBlindPost = IsAskingBigBlindPost,
				KickOutEndTime = KickOutEndTime,
				AvatarType = AvatarType,
				ImageUrl = ImageUrl,
				DumpBuyInType = DumpBuyInType,
			};
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class WaitingPlayer
	{
		public Guid UserId;
		public string UserName;
		public string NickName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TableUserId
	{
		public Guid TargetUserId;
		public Guid TableId;
	}

	/// <summary>
	/// Get to all tables
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTablesRequest
	{
		/// <summary>
		/// Gets or sets the type of the game.
		/// </summary>
		/// <value>
		/// The type of the game. (Holdem = 0,	Badugi = 1, SevenOrdinary = 2, Omaha = 3, Irish = 4, UnKnown = 5)
		/// </value>
		public GameType GameType;

		/// <summary>
		/// Gets or sets the last requested UTC time.
		/// </summary>
		/// <value>
		/// The last requested UTC time.
		/// </value>
		public DateTime LastRequestedUtcTime;

		public DeviceType UserDeviceType;
	}

	/// <summary>
	/// Response to GetTables.
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTablesResponse : Response
	{
		/// <summary>
		/// The tables
		/// </summary>
		public List<TableForLobby> Tables = new List<TableForLobby>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTableTypesRequest
	{
		public DeviceType UserDeviceType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTableTypesResponse : Response
	{
		// Set by TableManagerService
		public List<TableType> TableTypes = new List<TableType>();

		// Set by LobbyService
		public Dictionary<uint/*tabletypeid*/, int/*playercount*/> GameLobbyPlayerCounts = new Dictionary<uint, int>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTablePlayersRequest
	{
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTableWaitingPlayersRequest
	{
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTablePlayersResponse : Response
	{
		public Guid TableId;
		public List<TablePlayer> Players = new List<TablePlayer>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetMultiTablePlayersRequest
	{
		public List<Guid> TableId = new List<Guid>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetMultiTablePlayersResponse : Response
	{
		public List<TablePlayers> TablePlayers = new List<TablePlayers>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TablePlayers
	{
		public Guid TableId;
		public List<TablePlayer> Players = new List<TablePlayer>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTableWaitingPlayersResponse : Response
	{
		public List<string/*nickname*/> WaitingPlayers = new List<string>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyTableCreationContext
	{
		public Guid TourneyId;
		public TablePauseType PauseState;
		public Stake Stake;
		public bool IsRebuyPeriod;
		public int? Level;

		// use only sitandgo
		public int TimeBetting;
		public int TimeSandGlass;
		public int TimeBankDisconnection;
		public int MegaSpinMultiplier;
		public long MegaSpinTotalPrize;
		public List<TourneyPrizePoolItem> MegaSpinPrizePoolItems = new List<TourneyPrizePoolItem>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreateTableRequest
	{
		public Guid TableId;
		public TableName TableName;
		public TableType TableType;
		public string TourneyName;
		public string TourneyBrandName;
		public int TourneyEventNumber;

		// only use for EXTRAinfo of handhistory
		// BuyIn + EntranceFee
		public long TourneyBuyIn;
		public TourneyTableCreationContext TourneyContext;
		public BountyInformation BountyInformation;
		public int? TourneyType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreateTableResponse : Response
	{
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CloseTableRequest
	{
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CloseTableResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PlayerEntry
	{
		public Guid UserId;
		public string TokenId;
		public long BuyInAmount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrepareEnterPlayerRequest
	{
		public Guid TableId;
		public List<Tuple<Guid/*userid*/, long/*buyin_amount*/>> Players = new List<Tuple<Guid, long>>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrepareEnterPlayerResponse : Response
	{
		public List<Guid/*UserId*/> FailedPlayers = new List<Guid>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LoginTableRequest
	{
		public string TokenId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LoginTableResponse : Response
	{
		public Guid UserId;
		public Guid TableId;
		public string Username;
		public string GpId;
	}

	/// <summary>
	/// Request to EnterTable.
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class EnterTableRequest
	{
		/// <summary>
		/// Gets or sets the user id.
		/// </summary>
		/// <value>
		/// The user id.
		/// </value>
		public Guid UserId;

		/// <summary>
		/// Gets or sets the table id.
		/// </summary>
		/// <value>
		/// The table id.
		/// </value>
		public Guid TableId;

		/// <summary>
		/// The is join before tourney start
		/// </summary>
		public bool IsJoinBeforeTourneyStart = false;

		// 테이블 서비스에서 토너먼트 관련 캐시 아웃을 하는경우 필요
		public long TourneyUserSessionId;
	}

	/// <summary>
	/// Response to EnterTable.
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class EnterTableResponse : Response
	{
		public DateTime CurrentServerTime;
		public Table Table;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LeaveTableRequest
	{
		public Guid UserId;
		public Guid TableId;

		// Don't use notify leave table to client. (Only use in Jump)
		public bool IsSilently;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class JoinCashGameRequest
	{
		public Guid UserId;
		public JoinGameType JoinGameType;
		public uint TableTypeId;			// NOTE : Auto join
		public Guid TableId;				// NOTE : Manual join
		[DefaultValue(-1)]
		public int SeatIndex = -1;			// NOTE : Manual join
		public long BuyInAmount;
		public int EntryCount;
		public AutoActionFlag AutoActionFlag;
		public int AutoBuyLowerLimit;
		public int AutoBuyUpperLimit;

		[ExposeBranch(ExposeBranchType.TwoAce)]
		public DumpBuyInType DumpBuyInType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class JoinCashGameResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyAddOnRequest
	{
		public Guid TourneyId;
		public Guid UserId;
		public Guid TableId;
		public TourneyBuyInType AddOnType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyRebuyRequest
	{
		public Guid TourneyId;
		public Guid TableId;
		public Guid UserId;
		public int RebuyCount;
		public bool Cancel;
		public TourneyBuyInType RebuyType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyRebuyResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyAddOnResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NormalTerminationTableRequest
	{
		public Guid UserId;
		public Guid TableId;
		public TableTerminationType TerminationType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NormalTerminationTableResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SitInRequest
	{
		public Guid UserId;
		public Guid TableId;
		public int SeatIndex;
		public long BuyInAmount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SitInResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SitOutRequest
	{
		public Guid UserId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SitOutResponse : Response
	{
	}

	/// <summary>
	/// Request to TakeSeat
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TakeSeatRequest
	{
		/// <summary>
		/// Gets or sets the user id.
		/// </summary>
		/// <value>
		/// The user id.
		/// </value>
		public Guid UserId;

		/// <summary>
		/// Gets or sets the table id.
		/// </summary>
		/// <value>
		/// The table id.
		/// </value>
		public Guid TableId;

		/// <summary>
		/// Gets or sets the index of the seat.
		/// </summary>
		/// <value>
		/// The index of the seat.
		/// </value>
		public int SeatIndex;

		/// <summary>
		/// Gets or sets the buy in amount.
		/// </summary>
		/// <value>
		/// The buy in amount.
		/// </value>
		public long BuyInAmount;

		/// <summary>
		/// The automatic action flags
		/// </summary>
		public AutoActionFlag AutoActionFlags;

		/// <summary>
		/// Gets or sets the automatic buy lower limit.
		/// </summary>
		/// <value>
		/// The automatic buy lower limit.
		/// </value>
		public int AutoBuyLowerLimit;

		/// <summary>
		/// Gets or sets the automatic buy upper limit.
		/// </summary>
		/// <value>
		/// The automatic buy upper limit.
		/// </value>
		public int AutoBuyUpperLimit;

		[ExposeBranch(ExposeBranchType.TwoAce)]
		public DumpBuyInType DumpBuyInType;

		[ProtoIgnore]
		[DefaultValue(false)]
		public bool IsEmigrating;

		[ProtoIgnore]
		public long Bounty;
		[ProtoIgnore]
		public int KoCount;
		[ProtoIgnore]
		public bool IsInTheMoney;

		// Internal usage / not exposed
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="TakeSeatRequest"/> is force.
		/// </summary>
		/// <value>
		/// <c>true</c> if force;
		/// <c>false</c> otherwise;
		/// </value>

		[ProtoIgnore]
		public bool Force;
		/// <summary>
		/// Gets or sets the remaining rebuy count.
		/// </summary>
		/// <value>
		/// The remaining rebuy count.
		/// </value>
		[ProtoIgnore]
		public int RemainingRebuyCount;

		/// <summary>
		/// Gets or sets the add on amount.
		/// </summary>
		/// <value>
		/// The add on amount.
		/// </value>
		[ProtoIgnore]
		public long AddOnAmount;

		/// <summary>
		/// Gets or sets a value indicating whether this instance is tourney sit out.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is tourney sit out;
		/// <c>false</c> otherwise;
		/// </value>
		[ProtoIgnore]
		public bool IsTourneySitOut;

		/// <summary>
		/// Gets or sets the time bank.
		/// </summary>
		/// <value>
		/// The time bank.
		/// </value>
		[ProtoIgnore]
		public TimeSpan? TimeBank;

		/// <summary>
		/// Gets or sets the sitout time bank.
		/// </summary>
		/// <value>
		/// The time bank.
		/// </value>
		[ProtoIgnore]
		public TimeSpan? SitOutTimeBankRemaining;

		/// <summary>
		/// Gets or sets the state of the sit out.
		/// </summary>
		/// <value>
		/// The state of the sit out.
		/// </value>
		[ProtoIgnore]
		public SitOutState SitOutState;
	}

	/// <summary>
	/// Response to TakeSeat
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TakeSeatResponse : Response
	{
		/// <summary>
		/// The seat index
		/// </summary>
		[DefaultValue(-1)]
		public int SeatIndex = -1;

		/// <summary>
		/// Gets or sets a value indicating whether this instance is wait for join.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is wait for join;
		/// <c>false</c> otherwise;
		/// </value>
		public bool IsWaitForJoin;

		/// <summary>
		/// To enalbe or disable, client sitoutNextHand and sitoutNextBB function.
		/// </summary>
		public DateTime SitoutBankRemaining;
	}

	/// <summary>
	/// Requset to ReserveSeat
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ReserveSeatRequest
	{
		/// <summary>
		/// Gets or sets the table id.
		/// </summary>
		/// <value>
		/// The table id.
		/// </value>
		public Guid TableId;

		/// <summary>
		/// Gets or sets the user id.
		/// </summary>
		/// <value>
		/// The user id.
		/// </value>
		public Guid UserId;

		/// <summary>
		/// Gets or sets the index of the seat.
		/// </summary>
		/// <value>
		/// The index of the seat.
		/// </value>
		public int SeatIndex;

		// if ReserveSeat called by server, set this flag with true
		[SetByServer]
		public bool IsCalledByServer;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ReserveSeatResponse : Response
	{
		[DefaultValue(-1)]
		public int SeatIndex = -1;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ReserveSeatCancelRequest
	{
		public Guid TableId;
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ReserveSeatCancelResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LeaveSeatRequest
	{
		public Guid UserId;
		public Guid TableId;
		public bool FromClient = false;
		[SetByServer]
		public LeaveSeatReason Reason;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LeaveSeatResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class WaitingQueuePlaceRequest
	{
		public Guid UserId;
		public string UserName;
		public string NickName;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class WaitingQueuePlaceResponse : Response
	{
		public long LastSaveBalance;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class WaitingQueueCancelRequest
	{
		public Guid UserId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class WaitingQueueCancelResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RemoveUserAllWaitingListRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RemoveUserAllWaitingListResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class BuyInRequest
	{
		public Guid ServiceProviderId;
		public Guid UserId;
		public Guid TableId;
		public PlatformGameType GameType;
		public long Amount;
		public string UserName;
		public TransactionTag TransactionTag;
		public string GameName;
		public Guid TicketId;
		public long Value;

		// Set by the account service impl
		[ProtoIgnore]
		public long RequestId;
		[SetByServer]
		public long TransactionId;
		[SetByServer]
		public long UserSessionId;
		[SetByServer]
		public string PaymentType;
		[SetByServer]
		public string GpId;
		[SetByServer]
		public string UserIp;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class BuyInResponse : Response
	{
		[SetByServer]
		public Guid UserId;
		[SetByServer]
		public Guid TableId;
		[SetByServer]
		public string PlatformResult;
		[SetByServer]
		public long TransactionId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CashOutRequest
	{
		public Guid UserId;
		public Guid TableId;
		public long Amount;
		[SetByServer]
		public Guid TicketId;
		public long Value;
		public long RakeOrFee;
		public string GameName;
		public TransactionTag TransactionTag;
		public long TournamentOverlay;
		[SetByServer]
		public long RakedHands;
		[SetByServer] 
		public string UserIp;

		[SetByServer]
		public Guid ServiceProviderId;
		[SetByServer]
		public string UserName;
		[SetByServer]
		public PlatformGameType GameType;

		// Set by the account service impl
		[ProtoIgnore]
		public long RequestId;
		[SetByServer]
		public long TransactionId;
		[SetByServer]
		public long UserSessionId;
		[SetByServer]
		public CashOutTag CashOutTag;
		[SetByServer]
		public string GpId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SetMoveTableRequest
	{
		public Guid UserId;
		public Guid TableId;
		public bool MoveTableOn;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SetMoveTableResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreditDeductRequest
	{
		public Guid ServiceProviderId;
		public Guid UserId;
		public string UserName;
		public Guid TableId;
		public PlatformGameType GameType;
		public long TournamentOverlay;
		public string TourneyName;
		public long RakeOrFee;
		public string PaymentType;
		public TransactionTag TransactionTag;

		// Set by the account service impl
		public long RequestId;
		public long TransactionId;
		public long UserSessionId;
		public string GpId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreditDeductResponse : Response
	{
		public Guid UserId;
		public string PlatformResult;
		public long TransactionId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CashOutResponse : Response
	{
		[SetByServer]
		public Guid UserId;
		public string PlatformResult;
		public long TransactionId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SitInRequest2
	{
		public Guid UserId;
		public Guid TableId;
		public AutoActionFlag AutoActionFlags = 0;
		public int AutoBuyLowerLimit;
		public int AutoBuyUpperLimit;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SitInResponse2 : Response
	{
		public bool IsWaitForJoin;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SitOutRequest2
	{
		public Guid UserId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SitOutResponse2 : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ReserveTimeBankRequest
	{
		public Guid UserId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ReserveTimeBankResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DoActionRequest
	{
		public Guid UserId;
		public Guid TableId;
		public uint GameId;
		public uint ActionId;
		public ActionType ActionType;
		public long Amount = 0;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DoActionResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SetPlayerAutoActionFlagsRequest
	{
		public Guid UserId;
		public Guid TableId;
		public bool IsAdd;
		public AutoActionFlag ChangingFlag;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SetPlayerAutoActionFlagsResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ShowMuckRequest
	{
		public Guid UserId;
		public Guid TableId;
		public uint GameId;
		public List<int> ShowCardsIndex = new List<int>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ShowMuckResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DecideRITTRequest
	{
		public Guid UserId;
		public Guid TableId;
		public uint GameId;
		public bool IsAgreed;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DecideRITTResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UploadPlayerImageRequest
	{
		public Guid UserId;
		public int AvatarId;
		public string AvatarType;
		public byte[] Image = new List<byte>().ToArray();

		// set by session Service
		public string GpId;
		public Guid ServiceProviderId;
		public string UserName;

		[ProtoBeforeSerialization]
		public void OnBeforeSerialization()
		{
			var type = (AvatarType)Enum.Parse(typeof(AvatarType), AvatarType);
			
			/*if (Enum.TryParse(AvatarType, out type) == false)
				return;*/

			if (type.Equals(Rhyme.Common.AvatarType.CUSTOM))
				return;

			Image = null;
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UploadPlayerImageResponse : Response
	{
		public string AvatarUrl;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class HandleDisconnectedPlayerRequest
	{
		public Guid UserId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class HandleDisconnectedPlayerResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class AutoReBuyInRequest
	{
		public Guid UserId;
		public Guid TableId;
		public bool IsAutoReBuyIn;
		public int AutoBuyLowerLimit;
		public int AutoBuyUpperLimit;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class AutoReBuyInResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreatePrivateTableRequest
	{
		public Guid UserId;
		public Guid TableId;
		public bool Creatable;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreatePrivateTableResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTablePlayerBalanceRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ForceTakeSeatPlayerResponse : Response
	{
		public Guid? TableId;
		public int? SeatIndex;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ForceTakeSeatPlayerRequest
	{
		public Guid TableId;
		public Guid UserId;
		public long BuyInAmount;
		public int RemainingRebuyCount;
		public long AddOnAmount;
		public bool IsTourneySitOut;
		public TimeSpan? TimeBank;
		public SitOutState SitOutState;
		public long TourneyUserSessionId;

		// auto rebuy option
		public AutoActionFlag AutoActionFlag;
		public int AutoBuyLowerLimit;
		public int AutoBuyUpperLimit;

		// for cash game auto sit
		public bool IsChooseSeat;

		[DefaultValue(-1)]
		public int SeatIndex = -1;

		// Tournament
		[DefaultValue(false)]
		public bool IsEmigrating;

		// Bounty Tournament
		[DefaultValue(-1)]
		public long Bounty = -1;
		[DefaultValue(-1)]
		public int KoCount = -1;
		public bool IsInTheMoney;

		[ExposeBranch(ExposeBranchType.TwoAce)]
		public DumpBuyInType DumpBuyInType;

		/// <summary>
		/// Gets or sets the sitout time bank. (set by server)
		/// </summary>
		/// <value>
		/// The time bank.
		/// </value>
		[SetByServer]
		public TimeSpan? SitOutTimeBankRemaining;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SetTableStakeRequest
	{
		public Guid TableId;
		public Stake Stake;

		// Optional, only affects tourney
		public bool IsRebuyPeriod;
		public int? Level;
		public TimeSpan TimeBankAdded;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SetTableStakeResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SetDealerStateRequest
	{
		public Guid TableId;
		public bool IsPaused;
		public TablePauseType PauseType;
		public TimeSpan? Duration;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class AddPlayerChipsRequest
	{
		public Guid TableId;
		public Guid UserId;
		public int? RebuyCount;
		public long? Amount;
		public Guid? TourneyId;
		public long CurrentBalance;
		public TourneyBuyInType AddChipType;

		[ProtoIgnore]
		public bool IsRebuy;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableClientsRequest : NotifyTableParameter
	{
		public string Message;
		public TimeSpan Data;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class KickOutPlayerRequest
	{
		public Guid TableId;
		public Guid UserId;
		public bool IsWinner;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RequestNotifyInTheMoneyRequest
	{
		public Guid TourneyId;
		public Guid TableId;
		public List<Guid> InTheMoneyUsers = new List<Guid>();
		public bool NeedWaitingInTheMoneyAnimation;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class KickOutPlayerResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class AddPlayerChipsResponse : Response
	{
		public long AmountAdded;
		public int RebuyCount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyUpdateProgressRequest
	{
		public Guid TourneyId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyUpdateProgressResponse : Response
	{

	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyImmigrationRequest
	{
		public Guid TourneyId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyImmigrationResponse : Response
	{
		public List<Guid> ImmigratedPlayers = new List<Guid>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CashGameImmigrationRequest
	{
		public Guid TableId;

		// if this flag is true, move requested players only
		public bool OnlyThisPlayers;

		public List<Guid> RequestMoveTableUsers = new List<Guid>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CashGameImmigrationResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ReseatRequest
	{
		public uint TableTypeId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SetDealerStateResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTablePlayerBalanceResponse : Response
	{
		public List<TablePlayerBalance> TablePlayerBalanceList = new List<TablePlayerBalance>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class OrderedMessage
	{
		public long Sequence;
		public int Trial;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableParameter : OrderedMessage
	{
		public TableUserId TableUserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableDisconnectParameter : NotifyTableParameter
	{
	}

	/// <summary>
	/// EnterTable to NotifyTable.
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableEnterTableParameter : NotifyTableParameter
	{
		/// <summary>
		/// The list of players 
		/// </summary>
		public List<TablePlayer> Players = new List<TablePlayer>();

		// if player is sat in, send remain sitout bank
		public DateTime RemainingKickOutInitialTime;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableLeaveTableParameter : NotifyTableParameter
	{
		public Guid PlayerId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableTakeSeatParameter : NotifyTableParameter
	{
		public TablePlayer Player;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableLeaveSeatParameter : NotifyTableParameter
	{
		public Guid PlayerId;
		public LeaveSeatReason Reason;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableReserveSeatParameter : NotifyTableParameter
	{
		public int SeatIndex;
		public Guid ReservedPlayerId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableReserveSeatCanceledParameter : NotifyTableParameter
	{
		public int SeatIndex;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableSitInParameter : NotifyTableParameter
	{
		public TablePlayer Player;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableSitOutParameter : NotifyTableParameter
	{
		public Guid PlayerId;
		public DateTime KickOutTime;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneySitOutParameter : NotifyTableParameter
	{
		public Guid PlayerId;
		public bool IsSitOut;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyBountyTourneyInTheMoneyParameter : NotifyTableParameter
	{
		public List<Guid> InTheMoneyPlayers = new List<Guid>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableDealerNewStateParameter : NotifyTableParameter
	{
		public DealerState NewState;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableGameHoldemNewStateParameter : NotifyTableParameter
	{
		public GameHoldem Game;
		public GameHoldemState GameHoldemState;
		public List<TablePlayer> Players = new List<TablePlayer>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableHoleCardsParameter : NotifyTableParameter
	{
		public TablePlayer Player { get; set; }
		public List<Card> Cards { get; set; }
		public List<Guid> DealtPlayers = new List<Guid>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableShowMuckParameter : NotifyTableParameter
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableAskActionParameter : NotifyTableParameter
	{
		public uint GameId;
		public List<GamePot> Pots = new List<GamePot>();
		public long SmallBlind;
		public long BigBlind;
		public uint SeatIndex;
		public uint ActionId;
		public long CommittedAmount;
		public long CallAmount;
		public int AvailableActionTypes;
		public long MinBetAmount;
		public long MaxBetAmount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableActionParameter : NotifyTableParameter
	{
		public ActionType ActionType;
		public long ActionAmount;
		public long RaisedAmount;
		public Guid UserId;
		public string NickName;
		public long Balance;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableCommunityCardsParameter : NotifyTableParameter
	{
		public bool IsOnRITT;
		public GameHoldemState State;
		public int Index;
		public List<Card> DealtCards = new List<Card>();
		public List<Card> Cards = new List<Card>();
	}

	/// <summary>
	/// [hdkim][shlee]
	/// Notify RabbitCard Parameter
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableRabbitCardParameter : NotifyTableParameter
	{
		public GameHoldemState State;
		// RabbitCard Information
		public List<Card> Cards = new List<Card>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableBlindsPostedParameter : NotifyTableParameter
	{
		public List<GamePot> Pots = new List<GamePot>();
		public List<Blind> Blinds = new List<Blind>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableWaitForBlindPlayersParameter : NotifyTableParameter
	{
		public Dictionary<Guid /* UserId */, BlindType> WaitingForPostBlindPlayers = new Dictionary<Guid, BlindType>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableUncalledBetParameter : NotifyTableParameter
	{
		public Guid PlayerId;
		public string PlayerName;
		public long Amount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableWinnersParameter : NotifyTableParameter
	{
		public List<GamePot> Pots = new List<GamePot>();
		public bool IsOnRITT;
		public List<Winner> Winners = new List<Winner>();
		public List<JackpotRecipientInfo> JackpotRecipients = new List<JackpotRecipientInfo>();
		public List<BountyHunter> BountyHunters = new List<BountyHunter>();
		public double Delay;
		public List<JackpotTicketRecipientInfo> TicketRecipientList = new List<JackpotTicketRecipientInfo>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableShowSelectedCardsParameter : NotifyTableParameter
	{
		public List<GamePot> Pots = new List<GamePot>();
		public Guid OpponentUserId;
		public string OpponentUserName;
		public List<Card> OpponentSelectedCards = new List<Card>();
		public List<int> ShowCardsIndex = new List<int>();
		public bool IsLoserCards;
		public bool IsShowMuck;
		public bool FromClient = false;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableTimeBankParameter : NotifyTableParameter
	{
		public Guid UserId;
		public uint AlertType;
		public TimeSpan HurryTimeRemaining;
		public TimeSpan TimeBankRemaining;

		// foe calc timebank when entertable in gameplaying
		public DateTime TimeBankEndTime;
	}

	/// <summary>
	/// CatchUpEvent to NotifyTable 
	/// </summary>
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableCatchUpEventParameter : NotifyTableParameter
	{
		/// <summary>
		/// Gets or sets a value indicating whether this instance is catch up start.
		/// </summary>
		/// <value>
		/// <c>true</c> if this instance is catch up start; 
		/// <c>false</c> otherwise;
		/// </value>
		public bool IsCatchUpStart;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableStartCardRunParameter : NotifyTableParameter
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableNewHandStartParameter : NotifyTableParameter
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableWaitingListCountChangedParameter : NotifyTableParameter
	{
		public int Count;
		public int Order;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyCreateTableParameter : NotifyTableParameter
	{
		public Table Table;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyCloseTableParameter : NotifyTableParameter
	{
		public Guid TableId;
		public Table Table;
		public Guid? TourneyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTablePlayerCountChangedParameter
	{
		public List<UpdatedTableInfo> UpdatedTableInfos = new List<UpdatedTableInfo>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdatedTableInfo
	{
		public Guid TableId;
		public int PlayerCount;
		public int WaitingCount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyUpdateTableParameter : NotifyTableParameter
	{
		public Table Table;
		[SetByServer]
		public List<TablePlayer> Players = new List<TablePlayer>();
		// LeaveSeat or LeaveTable Players를 TableManager와 동기화 하기 위하여
		[SetByServer]
		public List<TablePlayer> LeaveSeatOrTablePlayers = new List<TablePlayer>();
		[SetByServer]
		public List<Guid> ReservedOnlyPlayers = new List<Guid>();
		[SetByServer]
		public List<WaitingPlayer> WaitingPlayers = new List<WaitingPlayer>();
		[SetByServer]
		public List<Guid> MoveTableQueue = new List<Guid>();
		[SetByServer]
		public List<LastSaveBalanceInfo> LastSaveBalances = new List<LastSaveBalanceInfo>();
		[SetByServer]
		public TableUpdateReason UpdateReason;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LastSaveBalanceInfo
	{
		public LastSaveBalanceInfo()
		{

		}

		public LastSaveBalanceInfo(Guid userId, long balance, int rejoinDuration)
		{
			UserId = userId;
			Balance = balance;
			ExpirationTime = DateTime.UtcNow.AddSeconds(rejoinDuration);
		}

		public Guid UserId;
		public long Balance;
		public DateTime ExpirationTime;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyWaitJoinTableParameter
	{
		public Guid UserId;
		public Guid TableId;
		public int SeatIndex;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyWaitingQueuePlacedParameter : NotifyTableParameter
	{
		public Guid TableId;
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyWaitingQueueCanceledParameter : NotifyTableParameter
	{
		public Guid TableId;
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyLeavePlayerParameter
	{
		public Guid TableId;
		public Guid UserId;
		public long Balance;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableChangeBuyInParameter : NotifyTableParameter
	{
		public TablePlayer Player;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableStakeChangedParameter : NotifyTableParameter
	{
		public Stake Stake;
		public int? Level;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyRebuyConfirmParameter
	{
		public Guid TourneyId;
		public Guid TableId;
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTablePausedParameter
	{
		public Guid TableId;
		public TablePauseType PauseType;
		public bool IsPaused;
		public TimeSpan? Duration;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyCreatePrivateTableParameter
	{
		public Guid UserId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyCreatePrivateTableResultParameter
	{
		public Guid TableId;
		public uint ResultCode;
		public Stake Stake;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TablePlayerBalance
	{
		public Guid UserId;
		public Table Table;
		public long UserSessionId;
		public long Balance;
		public bool IsParticipating;
		public int ButtonRelativePosition;
		public long? InitialBalance;
		public long Bounty;
		public int KoPlayerCount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class InPlayerChip
	{
		public string UserName;
		public Guid TableId;
		public long Balance;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTablePlayerBalanceParameter
	{
		public Guid UserId;
		public List<TablePlayerBalance> Balances = new List<TablePlayerBalance>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TablePlayerBounty
	{
		public Guid UserId;
		public Table Table;
		public long TablePlayerId;
		public long Bounty;
		public int KoPlayerCount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTablePlayerBountyParameter
	{
		public Guid UserId;
		// Will be empty string when sending to client.
		public string UserName;
		public List<TablePlayerBounty> Bounties = new List<TablePlayerBounty>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTablePlayerChangedRankParameter : NotifyTableParameter
	{
		// The user id whose rank was changed.
		public Guid UserId;
		public int Rank;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LastSaveBalanceRequest
	{
		public Guid UserId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class LastSaveBalanceResponse : Response
	{
		public long LastSaveBalance;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TableChatRequest
	{
		public Guid TableId;
		public string Name;
		public string Text;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableChatParameter : NotifyTableParameter
	{
		public string Name;
		public string Text;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class BubbleMessageRequest
	{
		public BubbleMessageType MessageType;
		public int Category;
		public int Index;
		public Guid UserId;
		public Guid TableId;
		public uint GameId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class BubbleMessageResponse : Response
	{
		// blocked time to send message (if user flood message too many)
		public int BlockedTime;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyBubbleMessageParameter : NotifyTableParameter
	{
		public BubbleMessageType MessageType;
		public int Category;
		public int Index;
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyWaitingCancelParameter : Response
	{
		public Guid TableId;
		public Guid UserId;
		public long MinBuyIn;
		public long LastSaveBalance;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyCashGameReadyParameter : Response
	{
		public Guid TableId;
		public Guid UserId;
		public Table Table;
		public Guid FromTableId;
		public long BuyInAmount;
		public int SeatIndex;
		public AutoJoinActionType JoinType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NewHandHistoryIdResponse : Response
	{
		public long NewId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ChangeSitOutStateRequest
	{
		public Guid UserId;
		public Guid TableId;
		public SitOutState State;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ChangeSitOutStateResponse : Response
	{
		public Guid UserId;
		public bool IsUsedSitOutAddedTime;
		public bool IsPlayerRejoin;
		public SitOutState State;
		public TimeSpan AddedTimeBankRemaining;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyChangeSitOutStateParameter : NotifyTableParameter
	{
		public TablePlayer Player;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SpentJackpotAmountRequest
	{
		public long SpentJackpotAmount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SpentJackpotAmountResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class JackpotRecipientInfo
	{
		public Guid UserId;
		public string UserName;
		public DateTime CreatedDateTime;
		// set while give jacpot amount
		public Guid JackpotHistoryId;
		public string NickName;
		public int SeatIndex;
		public long JackPotAmount;
		public int[] JackpotHand = new List<int>().ToArray();
		public int AvartarId;
		public int[] PlayerHands = new List<int>().ToArray();
		public int[] CommunityCards = new List<int>().ToArray();
		public long TotalEarnedAmountIncludedRake;
		public string AvatarType;
		public string ImageUrl;

		///// <summary>
		///// Omaha AOF에서만 사용하는 값으로 잭팟터진 플레이어의 상대 플레이어의 핸드
		///// </summary>
		public int[] NextTopRankHand = new List<int>().ToArray();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class JackpotTicketRecipientInfo
	{
		public Guid UserId;
		public string NickName;
		public int JackpotTicketTemplateId;
		public long JackpotTicketValue;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyCreateHandHistoryParameter
	{
		public HandHistoryInformation HandHistory;

		[SetByServer]
		public List<Guid> SubscribedPlayers = new List<Guid>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveCompletedTourneyRecordRequest
	{
		public List<WriteCompletedTourneyRecordRequest> Records = new List<WriteCompletedTourneyRecordRequest>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveCompletedTourneyRecordResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetMaxCompletedTourneyRecordIndexResponse : Response
	{
		public long MaxRecordIndex;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifySitoutBankGrowUp : NotifyTableParameter
	{
		public TimeSpan CurrentSitoutBankRemaining;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyCancelAddOnRequest
	{
		public Guid TourneyId;
		public Guid UserId;
		public TourneyBuyInType AddOnType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyCancelAddOnResponse : Response
	{
	}

	// table Join/Move plan
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum AutoJoinActionType
	{
		ActionJoin = 0,
		ActionMove = 1,
		ActionReseat = 2,
		ActionLeave = 3,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TableJoinInformation
	{
		public Guid EnterTableId;	// 신규로 들어갈 테이블
		public Guid? LeaveTableId;	// Move로 인해 나갈 테이블
		public long BuyInAmount;	// BuyIn

		public string ProcessLabel;
		public string ServiceName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TableAutoJoinPlanReqeust
	{
		public Guid UserId;			// 타겟 유저
		public List<TableJoinInformation> TargetTables = new List<TableJoinInformation>();
		public AutoActionFlag AutoActionFlag;
		public int AutoBuyLowerLimit;
		public int AutoBuyUpperLimit;
		public AutoJoinActionType JoinType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TableAutoJoinPlanResponse : Response
	{
		// Join 요청인 경우에만 사용되는 필드
		// Join 요청으로 들어가게 된 테이블 리스트
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyAutoJoinActionResult
	{
		public uint Result;
		public AutoJoinActionType ActionType;
		public Guid UserId;
		public TableJoinInformation TableJoinInformation;
		public int SeatIndex;
		public long BuyInAmount;
	}


	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateCashGameTableToPortalRequest
	{
		public Table Table;
		public List<TablePlayer> Players = new List<TablePlayer>();
		public List<TablePlayer> LeaveSeatOrTablePlayers = new List<TablePlayer>();
		public string CurrentTableStatus = "";
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyToPortalRequest
	{
		public TourneyEntryInformation EntryInformation;
		public bool IsOnHandForHand;
		public bool IsTourneyRunning;
		public Stake CurrentStake;
		public bool IsRebuyPeriod;
		public bool IsAddOnPeriod;
		public bool IsInTheMoney;
		public List<MutableTourneyPlayer> LobbyPlayers = new List<MutableTourneyPlayer>();
		public TourneyPrizePoolInformation PrizePoolInformation = new TourneyPrizePoolInformation();
		public TourneyBlindStructureInformation BlindStructureInformation = new TourneyBlindStructureInformation();
		public TourneyBlindStructureItem CurrentBlindStructure = new TourneyBlindStructureItem();
		public TourneyBlindStructureItem NextBlindStructure = new TourneyBlindStructureItem();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyTableToPortalRequest
	{
		public TournamentTable TournamentTable;
		public List<TablePlayer> TablePlayers = new List<TablePlayer>();
		public TourneyEntryInformation EntryInformation;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTableTypeToPortalRequest
	{
		public List<TableType> AllTableTypes = new List<TableType>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateJackpotToPortalRequest
	{
		public Guid TableId;
		public List<JackpotRecipientInfo> RecipientInfos = new List<JackpotRecipientInfo>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateJackpotAmountToPortalRequest
	{
		public long JackpotAmount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RegisterTourneyPortalIntegrationRequest
	{
		public Guid TourneyId;
		public string UserName;
		public TourneyBuyInType BuyInType;
		public Guid BuyInTicketId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyRegistrationInfoRequest
	{
		public Guid TourneyId;
		public string UserName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UnregisterTourneyPortalIntegrationRequest
	{
		public Guid TourneyId;
		public string UserName;
		public bool AlreadyRefund;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateMegaSpinTypeToPortalRequest
	{
		public int Index;
		public string BuyInType;
		public long Amount;
		public int StartingChips;
		public string TicketTemplateList;
		public long GGPoint;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateMegaSpinStoryToPortalRequest
	{
		public List<MegaSpinStory> MegaSpinStories = new List<MegaSpinStory>();
		public List<MegaSpinPlayerInfo> BestWinners = new List<MegaSpinPlayerInfo>();
		public long TotalGaveAward;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateMegaSpinHighMultiplierToPortalRequest
	{
		public int Multiplier { get; set; }
		public long BuyInAmount { get; set; }
		public List<MutableTourneyPlayer> Players = new List<MutableTourneyPlayer>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyAskingForBlindPostParameter : NotifyTableParameter
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTableNoticeParameter : NotifyTableParameter
	{
		public string Message;
	}
}