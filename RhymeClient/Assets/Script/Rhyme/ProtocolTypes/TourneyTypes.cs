using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using Assets.Script.Extension;

using ProtoBuf;

using Rb.Services.Protocol.Account;
using Rb.Services.Protocol.Config;
using Rb.Services.Protocol.GameTable;

using Rhyme.Common;
using Rhyme.Common.Attributes;
using Rhyme.Common.Utilities;

namespace Rb.Services.Protocol
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyBlindStructureTemplateRequest
	{
		public int BlindStructureTemplateId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyBlindStructureTemplateReponse : Response
	{
		public TourneyBlindStructureInformation BlindStrucutreInfo;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyPrizePoolTemplateRequest
	{
		public int PrizePoolTemplateId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyPrizePoolTemplateResponse : Response
	{
		public TourneyPrizePoolInformation PrizePoolTemplate;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyPrizePoolAwardTemplatesRequest
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyPrizePoolAwardTemplatesResponse : Response
	{
		public List<TourneyPrizePoolAwardTemplate> PrizePoolAwardTemplates = new List<TourneyPrizePoolAwardTemplate>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreateTourneyRequest
	{
		public int TourneyId;
		public string Name;
		public DateTime StartTime;
		public long BuyIn;
		public long EntranceFee;
		public long Guaranteed;
		public int PrizePoolTemplateId;
		public int BlindStructureTemplateId;
		public int PlayType;
		public int GameType;
		public int LimitType;
		public int MinPlayers;
		public int MaxPlayers;
		public int RebuyCount;
		public int RebuyType;
		public int? RebuyPeriodLevel;  // until what level
		public TimeSpan? RebuyPeriod;
		public long RebuyAmount;
		public long RebuyChips;
		public long AddOnAmount;
		public long AddOnChips;
		public long StartingChips;
		public int? TourneyType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CreateTourneyResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyInfo
	{
		public int Id;
		public int BlindStructureTemplateId;
		public int PrizePoolTemplateId;
		public TourneyEntryStatus Status;
		public string Title;
		public int GameType;
		public int GameLimitType;
		public int MinPlayers;
		public int MaxPlayers;
		public long StartingChips;
		public string Description;
		public long GuaranteeAmount;
		public long BuyInAmount;
		public long EntranceFee;
		public long RebuyAmount;
		public long RebuyCount;
		public long RebuyType;
		public TimeSpan? RebuyPeriod;
		public int? RebuyPeriodLevel;
		public long RebuyChips;
		public long AddOnFee;
		public long AddOnChips;
		public string Name; // lifecyle name
		public DateTime AnnouncementTime;
		public DateTime RegistrationTime;
		public DateTime StartTime;
		public TimeSpan SeatingDuration;
		public int? LateRegistrationLevel;
		public TimeSpan RemainingDuration;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CancelTourneyRequest
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CancelTourneyResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyPrizePoolListRequest
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyPrizePoolListResponse : Response
	{
		public List<TourneyPrizePoolInformation> List = new List<TourneyPrizePoolInformation>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyPrizePoolRequest
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyPrizePoolResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyPrizePoolRequest
	{
		public Guid TourneyGuid;
		public int PrizePoolEntryIndex;
		public List<TourneyPrizePoolItem> PrizePools = new List<TourneyPrizePoolItem>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyPrizePoolResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyBlindStructureListRequest
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyBlindStructureListResponse : Response
	{
		public List<TourneyBlindStructureInformation> Items = new List<TourneyBlindStructureInformation>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyBlindStructureRequest
	{
		public int Id;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyBlindStructureResponse : Response
	{
		public TourneyBlindStructureInformation Item;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyBlindStructureRequest
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyBlindStructureResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetPlayerRegistrationInfoRequest
	{
		public Guid TourneyGuid;
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetPlayerRegistrationInfoResponse : Response
	{
		public long RegistrationId;
		public TourneyBuyInType BuyInType;
		public long SpentAmount;
		public Guid? SpentTicketId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RegisterTourneyPlayerRequest
	{
		public Guid TourneyGuid;
		public Guid UserId;
		public TourneyBuyInType BuyInType;
		public long SpentAmount;
		public Guid? SpentTicketId;
		public int TotalRebuyCount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RegisterTourneyPlayerResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UnregisterTourneyPlayerRequest
	{
		public long RegistrationId;
		public Guid TourneyGuid;
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UnregisterTourneyPlayerResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyPlayerChipsRequest
	{
		public Guid TourneyGuid;
		public Guid UserId;
		public long Chips;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyPlayerChipsResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyPlayerPlaceRequest
	{
		public Guid TourneyGuid;
		public Guid UserId;
		public long Place;
		public int ScoreEarned;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyPlayerPlaceResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyStatusRequest
	{
		public Guid TourneyGuid;
		public TourneyEntryStatus Status;
		public DateTime? CompletedTime;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyStatusResponse : Response
	{
	}

	//[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	//public class GetTourneyListRequest
	//{
	//	public bool TryPagenate;
	//	public int PageSize;
	//	public int Page;
	//}

	//[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	//public class GetTourneyListResponse : Response
	//{
	//	public int TotalItems;
	//	public List<TourneyInfo> List = new List<TourneyInfo>();
	//}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyAward
	{
		public TourneyAwardType Type;
		public long? AwardedMoney;
		public int AwardedTicketTemplateId;
		public long AwardedTicketValue;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TryDropOutPlayer
	{
		public Guid UserId;
		public int ButtonPosition;
		public long InitialBalance;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ImmigratedPlayer
	{
		public Guid UserId;
		public long Balance;
		public bool SitOutAutoAction;
		public TimeSpan TimeBankRemaining;
		public SitOutState SitOutState;
		public bool IsInTheMoney;  // only use for bounty tourney
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class MutableTourneyPlayer
	{
		public Guid UserId;
		public string NickName;
		public int? Place;
		public long? GameStartingChips;
		public long? Chips;
		public Guid? TableId;
		public TourneyAward Award;
		public bool IsDroppedOut;
		public int? SeatIndex;
		public int RebuyRemainingCount;
		public long AddOnAmount;
		public string CountryCode;
		public long Bounty;
		public int KoPlayersCount;
		public int AvatarId;
		public TourneyBuyInType BuyinType;
		public string UserName;
		public string AvatarType;
		public string ImageUrl;
		public string GpId;

		// Not used for serialization
		[ProtoIgnore]
		public long EntranceFeeAmount;
		[ProtoIgnore]
		public long BuyInAmount;
		[ProtoIgnore]
		public long BuyInGGPAmount;
		[ProtoIgnore]
		public long RebuyGGPAmount;
		[ProtoIgnore]
		public long AddOnGGPAmount;
		[ProtoIgnore]
		public bool IsAddOnProcessing;
		[ProtoIgnore]
		public long RebuyAmount;
		[ProtoIgnore]
		public long? InitialBalance;
		[ProtoIgnore]
		public DateTime UpdatedAt;
		[ProtoIgnore]
		public int ButtonRelativePosition;
		[ProtoIgnore]
		public Guid? AwardedTableId;
		[ProtoIgnore]
		public bool IsOutdated;
		[ProtoIgnore]
		public bool IsRemoved;
		[ProtoIgnore]
		public bool RegisterCompleted;
		[ProtoIgnore]
		public Guid ServiceProviderId;
		[ProtoIgnore]
		public DateTime DroppedoutTime;
		[ProtoIgnore]
		public bool PurchaseBonusTicket;
		[ProtoIgnore]
		public bool IsSendWinLossInfo;
		[ProtoIgnore]
		public bool IsDropOutNominee;
		[ProtoIgnore]
		public long UserSessionId;

		// use for CompletedTourneyInfo
		[ProtoIgnore]
		public long BuyInCash;
		[ProtoIgnore]
		public long BuyInGGP;
		[ProtoIgnore]
		public long BuyInTicket;
		[ProtoIgnore]
		public long RebuyCash;
		[ProtoIgnore]
		public long RebuyGGP;
		[ProtoIgnore]
		public long AddOnCash;
		[ProtoIgnore]
		public long AddOnGGP;
	}
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TournamentTable
	{
		public TournamentTable()
		{
			Players = new HashSet<MutableTourneyPlayer>();
		}

		public TableStatus Status;
		public TablePauseState PauseStatus;
		public Table TableInfo;
		public HashSet<MutableTourneyPlayer> Players;
		public Guid TourneyId;
		public Guid TableId;
		public DateTime DecayTime;
		// for use shootout
		public int AvaliableRegistSeat;

		[ProtoIgnore]
		public int TableServiceId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class EnterTourneyLobbyRequest
	{
		public Guid UserId;

		[SetByServer]
		public MutableTourneyPlayer Player;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TourneyEntryStatus
	{
		Created,
		Announcemented,
		Registration,
		Running,
		Canceled,
		Completed,
		Removed,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrizeSummary
	{
		public TourneyAwardType AwardType;

		/// <summary>
		/// 현재 시점의 총 상금
		/// 보상이 티켓인 경우 티켓 밸류의 총합
		/// CurrentTotalPrizePool과는 다른 개념 CurrentTotalPrizePool은 실제로 유저들이 토너에 부은 돈이고
		/// TotalPrizeAmount는 보상으로 나가는 돈이나 티켓 가치의 총 합임
		/// </summary>
		public long TotalPrizeAmount;

		/// <summary>
		/// 보상이 티켓인 경우 게런티 하는 티켓의 종류와 장수
		/// </summary>
		public List<PrizeTicketSummary> GauranteedTickets = new List<PrizeTicketSummary>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PrizeTicketSummary
	{
		public Guid TicketTemplateId;
		public long TicketValue;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class BriefTourneyEntryInformation
	{
		public BriefTourneyEntryInformation()
		{
			
		}

		public BriefTourneyEntryInformation(TourneyEntryInformation tourneyEntryInformation)
		{
			UtcDate = tourneyEntryInformation.UtcDate;
			Id = tourneyEntryInformation.Id;
			BuyIn = tourneyEntryInformation.BuyIn;
			EntranceFee = tourneyEntryInformation.EntranceFee;
			Guaranteed = tourneyEntryInformation.Guaranteed;
			Name = tourneyEntryInformation.Name;

			PrizeSummary = tourneyEntryInformation.PrizeSummary;

			BrandName = tourneyEntryInformation.BrandName;
			EventNumber = tourneyEntryInformation.EventNumber;

			// Add on Related
			AddOnFee = tourneyEntryInformation.AddOnFee;
			AddOnChips = tourneyEntryInformation.AddOnChips;

			// Rebuy Related
			RebuyFee = tourneyEntryInformation.RebuyFee;
			RebuyCount = tourneyEntryInformation.RebuyCount;
			RebuyPeriodLevel = tourneyEntryInformation.RebuyPeriodLevel;
			RebuyChips = tourneyEntryInformation.RebuyChips;

			Status = tourneyEntryInformation.Status;
			RegisteredPlayers = tourneyEntryInformation.RegisteredPlayers;
			LifeCycleData = tourneyEntryInformation.LifeCycleData;
			Configuration = tourneyEntryInformation.Configuration;
			CanRegister = tourneyEntryInformation.CanRegister;
			CanUnregister = tourneyEntryInformation.CanUnregister;
			IsSatellite = tourneyEntryInformation.IsSatellite;

			AwardEntries = tourneyEntryInformation.AwardEntries;

			OnlyTicket = tourneyEntryInformation.OnlyTicket;
			TicketTemplateList = tourneyEntryInformation.TicketTemplateList;

			CurrentTotalPrizePool = tourneyEntryInformation.CurrentTotalPrizePool;

			BonusTicketTemplateId = tourneyEntryInformation.BonusTicketTemplateId;
			DiscountAmount = tourneyEntryInformation.DiscountAmount;
			BonusTicketValue = tourneyEntryInformation.BonusTicketValue;

			BountyInformation = tourneyEntryInformation.BountyInformation;
			CurrentRegularPrizePool = tourneyEntryInformation.CurrentRegularPrizePool;
			CurrentBountyPrizePool = tourneyEntryInformation.CurrentBountyPrizePool;
			IsInTheMoney = tourneyEntryInformation.IsInTheMoney;

			IsCanceledByCRM = tourneyEntryInformation.IsCanceledByCRM;
			IsForceComplete = tourneyEntryInformation.IsForceComplete;

			AllowBuyInTypes = tourneyEntryInformation.AllowBuyInTypes;
			AllowRebuyTypes = tourneyEntryInformation.AllowRebuyTypes;
			AllowAddOnTypes = tourneyEntryInformation.AllowAddOnTypes;
			BuyInGGPAmount = tourneyEntryInformation.BuyInGGPAmount;
			ReBuyGGPAmount = tourneyEntryInformation.ReBuyGGPAmount;
			AddOnGGPAmount = tourneyEntryInformation.AddOnGGPAmount;
			TourneyType = tourneyEntryInformation.TourneyType;
			ChangeToRegularITM = tourneyEntryInformation.ChangeToRegularITM;
			EndTournamentITM = tourneyEntryInformation.EndTournamentITM;
			PayOutType = tourneyEntryInformation.PayOutType;
			CurrentGGPPrizePool = tourneyEntryInformation.CurrentGGPPrizePool;
		}

		public DateTime UtcDate;  // 로그 남기는거 외에 사용되지 않는 값인데.. 있어야 하나..
		public Guid Id;
		public long BuyIn;
		public long EntranceFee;
		public long Guaranteed;
		public string Name;

		/// <summary>
		/// 프라이즈 정보 서머리 (로비용)
		/// </summary>
		public PrizeSummary PrizeSummary;

		// Tourney brand info 
		public string BrandName;
		public int EventNumber;

		// Add on Related
		public long? AddOnFee;
		public long AddOnChips;

		// Rebuy Related
		public long? RebuyFee;
		public int RebuyCount;
		public int? RebuyPeriodLevel;
		public long RebuyChips;

		public TourneyEntryStatus Status;
		public int RegisteredPlayers;
		public TourneyLifeCycleConfiguration LifeCycleData;
		public TourneyTableConfiguration Configuration;
		public bool CanRegister;
		public bool CanUnregister;
		public bool IsSatellite;

		/// <summary>
		/// 현재 블라인드 레벨 (세션에 있는 인스턴스는 토너가 시작되면 값 세팅됨)
		/// 널 체크 필요
		/// </summary>
		public TourneyBlindStructureItem CurrentBlindStructure;

		// Use Only Ticket, Satellite Tourney
		public List<TourneyPrizePoolAwardTemplate> AwardEntries = new List<TourneyPrizePoolAwardTemplate>();

		public bool OnlyTicket;
		public List<int> TicketTemplateList = new List<int>();

		public long CurrentTotalPrizePool;

		public int? BonusTicketTemplateId;
		public long? DiscountAmount;
		public long? BonusTicketValue;

		// Use for Bounty Tournament
		public BountyInformation BountyInformation;
		public long CurrentRegularPrizePool;
		public long CurrentBountyPrizePool;
		public bool IsInTheMoney;

		public bool IsCanceledByCRM;
		public bool IsForceComplete;

		public TourneyBuyInType AllowBuyInTypes;
		public TourneyBuyInType AllowRebuyTypes;
		public TourneyBuyInType AllowAddOnTypes;
		public long BuyInGGPAmount;
		public long ReBuyGGPAmount;
		public long AddOnGGPAmount;
		public int? TourneyType;
		public bool ChangeToRegularITM;
		public bool EndTournamentITM;
		public PayOutType PayOutType;
		public long CurrentGGPPrizePool;

		public void UpdateFrom(TourneyEntryInformation tourneyEntry)
		{
			Status = tourneyEntry.Status;
			RegisteredPlayers = tourneyEntry.RegisteredPlayers;
			CanRegister = tourneyEntry.CanRegister;
			CanUnregister = tourneyEntry.CanUnregister;
			CurrentTotalPrizePool = tourneyEntry.CurrentTotalPrizePool;
			CurrentRegularPrizePool = tourneyEntry.CurrentRegularPrizePool;
			CurrentBountyPrizePool = tourneyEntry.CurrentBountyPrizePool;
			IsInTheMoney = tourneyEntry.IsInTheMoney;
			IsCanceledByCRM = tourneyEntry.IsCanceledByCRM;
			IsForceComplete = tourneyEntry.IsForceComplete;
			LifeCycleData = tourneyEntry.LifeCycleData;
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class BriefMegaSpinEntryInformation
	{
		public BriefMegaSpinEntryInformation()
		{
			
		}

		public BriefMegaSpinEntryInformation(TourneyEntryInformation tourneyEntryInformation)
		{
			UtcDate = tourneyEntryInformation.UtcDate;
			Id = tourneyEntryInformation.Id;
			BuyIn = tourneyEntryInformation.BuyIn;
			Name = tourneyEntryInformation.Name;

			Status = tourneyEntryInformation.Status;
			RegisteredPlayers = tourneyEntryInformation.RegisteredPlayers;
			Configuration = tourneyEntryInformation.Configuration;
			CanRegister = tourneyEntryInformation.CanRegister;
			CanUnregister = tourneyEntryInformation.CanUnregister;

			StartPlayersCount = tourneyEntryInformation.StartPlayersCount;

			OnlyTicket = tourneyEntryInformation.OnlyTicket;
			TicketTemplateList = tourneyEntryInformation.TicketTemplateList;

			AllowBuyInTypes = tourneyEntryInformation.AllowBuyInTypes;
			BuyInGGPAmount = tourneyEntryInformation.BuyInGGPAmount;

			MegaSpinMultiplier = tourneyEntryInformation.MegaSpinMultiplier;
			MegaSpinTypeIndex = tourneyEntryInformation.MegaSpinTypeIndex;
		}

		/// <summary>
		/// Announce Time
		/// </summary>
		public DateTime UtcDate;
		public Guid Id;
		public long BuyIn;
		public string Name;

		public TourneyEntryStatus Status;
		public int RegisteredPlayers;
		public TourneyTableConfiguration Configuration;
		public bool CanRegister;
		public bool CanUnregister;

		public int StartPlayersCount;

		public bool OnlyTicket;
		public List<int> TicketTemplateList = new List<int>();

		public TourneyBuyInType AllowBuyInTypes;
		public long BuyInGGPAmount;

		public int MegaSpinMultiplier;
		public int MegaSpinTypeIndex;

		public void UpdateFrom(TourneyEntryInformation tourneyEntry)
		{
			Status = tourneyEntry.Status;
			RegisteredPlayers = tourneyEntry.RegisteredPlayers;
			CanRegister = tourneyEntry.CanRegister;
			CanUnregister = tourneyEntry.CanUnregister;
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyEntryInformation
	{
		public TourneyEntryInformation()
		{
			Initialize();
		}

		public DateTime UtcDate;
		public Guid Id;
		public long BuyIn;
		public long EntranceFee;
		public long Guaranteed;
		public string Name;

		/// <summary>
		/// 프라이즈 정보 서머리 (로비용)
		/// </summary>
		public PrizeSummary PrizeSummary;

		// Tourney brand info 
		public string BrandName;
		public int EventNumber;

		// Add on Related
		public long? AddOnFee;
		public long AddOnChips;

		// Rebuy Related
		public long? RebuyFee;
		public int RebuyCount;
		public int? RebuyPeriodLevel;
		public long RebuyChips;

		public int Option;
		public TourneyEntryStatus Status;
		public int RegisteredPlayers;
		public TourneyLifeCycleConfiguration LifeCycleData;
		public TourneyTableConfiguration Configuration;
		public bool CanRegister;
		public bool CanUnregister;
		public bool IsSatellite;

		// Use Only SitAndGo
		public int SitAndGoIndex;
		public int MaxPlayersPerTable;
		public int StartPlayersCount;

		// Use Only Ticket, Satellite Tourney
		public List<TourneyPrizePoolAwardTemplate> AwardEntries = new List<TourneyPrizePoolAwardTemplate>();

		public bool OnlyTicket;
		public List<int> TicketTemplateList = new List<int>();

		public long CurrentTotalPrizePool;

		public int? BonusTicketTemplateId;
		public long? DiscountAmount;
		public long? BonusTicketValue;

		// Use for Bounty Tournament
		public BountyInformation BountyInformation;
		public long CurrentRegularPrizePool;
		public long CurrentBountyPrizePool;
		public bool IsInTheMoney;

		public bool IsCanceledByCRM;

		public bool IsForceComplete;

		public TourneyBuyInType AllowBuyInTypes;
		public TourneyBuyInType AllowRebuyTypes;
		public TourneyBuyInType AllowAddOnTypes;
		public long BuyInGGPAmount;
		public long ReBuyGGPAmount;
		public long AddOnGGPAmount;
		public int? TourneyType;
		public bool ResetTableITM;
		public int ResetTableNumITM;
		public bool ChangeToRegularITM;
		public bool EndTournamentITM;
		public PayOutType PayOutType;
		public long CurrentGGPPrizePool;
		public int MegaSpinMultiplier;
		public int MegaSpinTypeIndex;

		[ProtoIgnore]
		public List<Table> Tables;

		/// <summary>
		/// Contains details about currently running tourney including statistics
		/// </summary>
		[ProtoIgnore]
		public TourneyDetailedEntryInformation DetailedInformation;

		/// <summary>
		/// 
		/// </summary>
		[ProtoIgnore]
		public TourneyBlindStructureInformation BlindStructureInformation;

		/// <summary>
		/// 
		/// </summary>
		[ProtoIgnore]
		public TourneyPrizePoolInformation PrizePoolInformation;

		/// <summary>
		/// 
		/// </summary>
		[ProtoIgnore]
		public List<MutableTourneyPlayer> Players;

		// Breaktime related
		[ProtoIgnore]
		public TimeSpan? BreakDuration;
		[ProtoIgnore]
		public DateTime? BreakStartTime;
		[ProtoIgnore]
		public bool BreakIsWaitForSynchronization;

		public void UpdateFrom(TourneyEntryInformation entryInformation)
		{
			Debug.Assert(entryInformation != null);

			Status = entryInformation.Status;
			RegisteredPlayers = entryInformation.RegisteredPlayers;
			CanRegister = entryInformation.CanRegister;
			CanUnregister = entryInformation.CanUnregister;
			CurrentTotalPrizePool = entryInformation.CurrentTotalPrizePool;
			CurrentRegularPrizePool = entryInformation.CurrentRegularPrizePool;
			CurrentBountyPrizePool = entryInformation.CurrentBountyPrizePool;
			IsInTheMoney = entryInformation.IsInTheMoney;
			IsCanceledByCRM = entryInformation.IsCanceledByCRM;
			IsForceComplete = entryInformation.IsForceComplete;
			LifeCycleData = entryInformation.LifeCycleData;

			if (entryInformation.Id.GetGuidType() == GuidHelper.GuidType.SitAndGoId)
				LifeCycleData.StartTime = entryInformation.LifeCycleData.StartTime;

			if (BriefTourneyEntryInformation == null)
				BriefTourneyEntryInformation = new BriefTourneyEntryInformation(this);
			else
				BriefTourneyEntryInformation.UpdateFrom(this);


			if (BriefMegaSpinEntryInformation == null)
				BriefMegaSpinEntryInformation = new BriefMegaSpinEntryInformation(this);
			else
				BriefMegaSpinEntryInformation.UpdateFrom(this);
		}

		public void UpdateFrom(TourneyDetailedEntryInformation detailedInformation)
		{
			Debug.Assert(detailedInformation != null);

			DetailedInformation = detailedInformation;
		}

		public void UpdateFrom(IEnumerable<MutableTourneyPlayer> players, bool isDeleted)
		{
			Debug.Assert(players != null);

			if (Players == null)
				return;

			foreach (var player in players)
			{
				var lobbyPlayer = Players.FirstOrDefault(e => e.UserId == player.UserId);

				if (isDeleted)
				{
					if (lobbyPlayer != null)
					{
						lobbyPlayer.IsRemoved = true;
					}
				}
				else
				{
					if (lobbyPlayer == null)
					{
						player.IsOutdated = true;
						Players.Add(player);
						continue;
					}

					lobbyPlayer.TableId = player.TableId;
					lobbyPlayer.Place = player.Place;
					lobbyPlayer.Chips = player.Chips;
					lobbyPlayer.Award = player.Award;
					lobbyPlayer.SeatIndex = player.SeatIndex;
					lobbyPlayer.IsDroppedOut = player.IsDroppedOut;
					lobbyPlayer.RebuyRemainingCount = player.RebuyRemainingCount;
					lobbyPlayer.AddOnAmount = player.AddOnAmount;
					lobbyPlayer.Bounty = player.Bounty;
					lobbyPlayer.KoPlayersCount = player.KoPlayersCount;
					lobbyPlayer.IsOutdated = true;
				}
			}
		}

		public void Initialize()
		{
			if (Players == null)
				Players = new List<MutableTourneyPlayer>();

			if (Tables == null)
				Tables = new List<Table>();
		}

		public void UpdatePrizeSummary()
		{
			if (PrizeSummary == null)
				PrizeSummary = new PrizeSummary();

			if (PayOutType == PayOutType.EntryBase)
			{
				if (PrizePoolInformation.AwardEntries == null || PrizePoolInformation.AwardEntries.Any() == false)
				{
//					Logger.Log(LogInfo.Error, new
//					{
//						Event = "tourney_awardentries_not_found",
//						TourneyId = Id,
//					});

					return;
				}

				if (PrizePoolInformation.AwardEntries.Any(award => award.Type == TourneyAwardType.Ticket))
				{
					// 보상이 티켓인 경우
					// EntryBase에 티켓이 보상인경우 게런티의 개념이 없으므로 가장 낮은 엔트리 숫자에 주는 티켓 숫자를 게런티로 간주함

					var minimumEntry = PrizePoolInformation.PrizePoolEntries.OrderBy(e => e.EntryEnd).FirstOrDefault();
					var awardEntries = PrizePoolInformation.AwardEntries.Where(e => e.Index == minimumEntry.Index).ToList();

					Debug.Assert(awardEntries.All(e => e.Type == TourneyAwardType.Ticket && e.TicketTemplateGuid.HasValue));

					PrizeSummary.AwardType = TourneyAwardType.Ticket;
					PrizeSummary.GauranteedTickets = awardEntries.Select(e => new PrizeTicketSummary { TicketTemplateId = e.TicketTemplateGuid.Value, TicketValue = (long)Convert.ToDecimal(e.Award) }).ToList();
					PrizeSummary.TotalPrizeAmount = PrizeSummary.GauranteedTickets.Sum(t => t.TicketValue);
				}
				else if (PrizePoolInformation.AwardEntries.Any(award => award.Type == TourneyAwardType.Money))
				{
					// 보상이 머니인 경우
					PrizeSummary.AwardType = TourneyAwardType.Money;
					PrizeSummary.TotalPrizeAmount = Math.Max(CurrentTotalPrizePool, Guaranteed);
				}
				else
				{
//					Logger.Log(LogInfo.Warn, new
//					{
//						Event = "unknown_tourney_award_type",
//						TourneyId = Id,
//					});
				}
			}
			else if (PayOutType == PayOutType.Satellite)
			{
				var ticketValue = PrizePoolInformation.PrizePoolSatellite.GuaranteedTicketValue;

				PrizeSummary.AwardType = TourneyAwardType.Ticket;

				// Gaurantee는 한번 정해지면 바뀌지 않으므로 없는경우 한번만 업데이트 함
				if (PrizeSummary.GauranteedTickets.Any() == false)
				{
					for (var i = 0; i < PrizePoolInformation.PrizePoolSatellite.GuaranteedTicketCount; i++)
					{
						PrizeSummary.GauranteedTickets.Add(new PrizeTicketSummary { TicketTemplateId = PrizePoolInformation.PrizePoolSatellite.PrizeTicketGuid, TicketValue = ticketValue });
					}
				}

				if (PrizePoolInformation.PrizePoolSatellite.TicketPerEveryPrize <= 0)
				{
					Debug.Fail("tourney_with_wrong_settings");

//					Logger.Log(LogInfo.Error, new
//					{
//						Event = "tourney_with_wrong_settings",
//						TourneyId = Id,
//					});

					// 토너 설정이 잘못됨
					// 클라에 잘못된 값이 찍히나 토너 진행엔 문제 없으므로 그냥 리턴
					return;
				}

				// 지급 티켓 장수 계산
				var ticketCount = Math.Max(Convert.ToInt32(Math.Ceiling((double)CurrentTotalPrizePool / PrizePoolInformation.PrizePoolSatellite.TicketPerEveryPrize)), PrizePoolInformation.PrizePoolSatellite.GuaranteedTicketCount);

				PrizeSummary.TotalPrizeAmount = ticketCount * ticketValue;
			}
			// 메가스핀은 PayOutType.None
		}

		public ResultCode CheckACL(Account.Account account, List<ServiceProviderInformation> serviceProviderInformations)
		{
			// Check minimum rank is reached
			if (LifeCycleData.ServiceProviderACLItems != null && LifeCycleData.ServiceProviderACLItems.Any())
			{
				var aclItems = from acl in LifeCycleData.ServiceProviderACLItems
							   join spInfo in serviceProviderInformations on acl.ServiceProviderName equals spInfo.Name
							   select new { acl.ServiceProviderName, spInfo.Guid, acl.Policy };

				var aclItem = aclItems.FirstOrDefault(e => e.Guid == account.ServiceProviderId);
				if (aclItem != null)
				{
					// Check if service provider is allowed
					if (aclItem.Policy == ServiceProviderACLPolicy.Deny)
						return ResultCode.ErrorTourneyInvalidServiceProvider;
					else
					{
						// OK, good to go.
					}
				}
				else
				{
					// No entry? then look for default policy
					if (LifeCycleData.DefaultPolicy == ServiceProviderACLPolicy.Deny)
						return ResultCode.ErrorTourneyInvalidServiceProvider;
				}
			}
			else
			{
				// No ACL policy? then look up for default policy
				if (LifeCycleData.DefaultPolicy == ServiceProviderACLPolicy.Deny)
					return ResultCode.ErrorTourneyInvalidServiceProvider;
			}

			return ResultCode.Success;
		}

		[ProtoIgnore]
		public long MegaSpinTotalPrize { get { return BuyIn * MegaSpinMultiplier; } }

		[ProtoIgnore]
		public UpdatedInformations UpdatedInformations = new UpdatedInformations();

		[ProtoIgnore]
		public BriefTourneyEntryInformation BriefTourneyEntryInformation;

		[ProtoIgnore]
		public BriefMegaSpinEntryInformation BriefMegaSpinEntryInformation;
	}

	public class UpdatedInformations
	{
		public DateTime LastUpdated;

		public bool IsAddedTables;
		public List<Table> AddedTableList = new List<Table>();
		public bool IsRemovedTables;
		public List<Table> RemovedTableList = new List<Table>();
		public bool IsUpdatedTables;
		public List<Table> UpdatedTableList = new List<Table>();

		public bool IsUpdatedStatistics;	// 
		public bool IsUpdatedPrizePool;		// PrizePool
		public bool IsUpdatedGGPPrizePool;	// PrizePool
		public bool IsUpdatedPrizePools;	// PrizePoolItem
		public bool IsUpdatedCurrentBlindStructureId;	// 1. CurrentBlind
		public bool IsUpdatedStartTime;					// 1. CurrentBlind
		public bool IsUpdatedLifeCycleData;

		// Use for Bounty Tournament
		public bool IsUpdatedRegularPrizePool;	// RegularPrizePool
		public bool IsUpdatedBountyPrizePool;	// BountyPrizePool
		public bool IsUpdatedIsInTheMoney;		// 

		public bool IsAnyChanged()
		{
			return
				IsAddedTables || IsRemovedTables || IsUpdatedTables || IsUpdatedStatistics || IsUpdatedPrizePool
				|| IsUpdatedGGPPrizePool || IsUpdatedPrizePools || IsUpdatedCurrentBlindStructureId || IsUpdatedStartTime || IsUpdatedLifeCycleData
				|| IsUpdatedRegularPrizePool || IsUpdatedBountyPrizePool || IsUpdatedIsInTheMoney;
		}

		public void Reset()
		{
			LastUpdated = DateTime.UtcNow;

			IsAddedTables = false;
			AddedTableList.Clear();
			IsRemovedTables = false;
			RemovedTableList.Clear();
			IsUpdatedTables = false;
			UpdatedTableList.Clear();

			IsUpdatedStatistics = false;
			IsUpdatedPrizePool = false;
			IsUpdatedGGPPrizePool = false;
			IsUpdatedPrizePools = false;
			IsUpdatedCurrentBlindStructureId = false;
			IsUpdatedStartTime = false;
			IsUpdatedLifeCycleData = false;
			IsUpdatedRegularPrizePool = false;
			IsUpdatedBountyPrizePool = false;
			IsUpdatedIsInTheMoney = false;
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyDetailedEntryInformation
	{
		public DateTime StartedAt;
		public DateTime BlindStartedAt;
		public int CurrentBlindStructureItemId;
		public int NextBlindStructureItemId;
		public TourneyDetailedStatistics Statistics;
		public long PrizePool;
		public long GGPPrizePool;
		public List<TourneyPrizePoolItem> PrizePools = new List<TourneyPrizePoolItem>();

		// Use for Bounty Tournament
		public long RegularPrizePool;
		public long BountyPrizePool;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyDetailedStatistics
	{
		public int Entrants;
		public int Remaining;
		public long LargestStack;
		public long AverageStack;
		public long SmallestStack;
		public int RemainingTables;

		// for shootout late registration
		public int RemainLateRegistrationSeat;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyTableConfiguration
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public int PlayType { get; set; } // Tourney or SitNGo
		public int GameType { get; set; }
		public int GameLimitType { get; set; }
		public int GamePlayersCount { get; set; }
		public int MinPlayers { get; set; }
		public int MaxPlayers { get; set; }
		public long StartingChips { get; set; }
		public string Description { get; set; }
		public DateTime Created { get; set; }

		// Use Only SitAndGo
		public int TimeBetting { get; set; }
		public int TimeSandGlass { get; set; }
		public int TimeBankDisconnection { get; set; }
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum ServiceProviderACLPolicy
	{
		Allow,
		Deny,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class ServiceProviderACLItem
	{
		public string ServiceProviderName;
		public ServiceProviderACLPolicy Policy;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyLifeCycleConfiguration
	{
		public int Id;
		public string Name;
		public DateTime AnnouncementTime;
		public DateTime RegistrationTime;
		public DateTime StartTime;
		public DateTime EndTime;
		public TimeSpan SeatingDuration;
		public int? LateRegistrationLevel;
		public TimeSpan? LateRegistrationTime;
		public TimeSpan RemainingDuration;
		public bool IsFixed;
		public DateTime CreatedAt;
		public int? MinimumRank;
		public int? MaximumRank;
		public List<ServiceProviderACLItem> ServiceProviderACLItems = new List<ServiceProviderACLItem>();
		public ServiceProviderACLPolicy DefaultPolicy;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyPrizePoolInformation
	{
		public int Id; // Used for identify specific information to access..
		public string Name;
		public bool AwardMoneyByRatio;
		public List<TourneyPrizePoolTemplate> PrizePoolEntries = new List<TourneyPrizePoolTemplate>();
		public List<TourneyPrizePoolAwardTemplate> AwardEntries = new List<TourneyPrizePoolAwardTemplate>();
		public List<TourneyPrizePoolHandForHandTemplate> HandForHandEntries = new List<TourneyPrizePoolHandForHandTemplate>();

		public TourneyPrizePoolSatellite PrizePoolSatellite = new TourneyPrizePoolSatellite();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyPrizePoolTemplate
	{
		public int Id;
		public int Index;
		public int EntryStart;
		public int EntryEnd;
	}
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyPrizePoolSatellite
	{
		public long TicketPerEveryPrize;
		public TicketPrizeType TicketPrizeBaseType;
		public Guid PrizeTicketGuid;
		public int GuaranteedTicketCount;
		public long GuaranteedTicketValue;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyPrizePoolAwardTemplate
	{
		public int Id;
		public int Index;
		public int PlaceBegin;
		public int PlaceEnd;
		public TourneyAwardType Type;
		public Guid? TicketTemplateGuid;
		public Guid? TargetTourneyId;
		// if type is ticket, Award is ticket's value
		public string Award;
	}

	[Serializable]
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyPrizePoolItem
	{
		public int PlaceBegin;
		public int PlaceEnd;
		public TourneyAwardType Type;
		public Guid? TicketTemplateGuid;
		public Guid? TicketGuid;
		public string Award;
		public Guid? TargetTourneyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyPrizePoolHandForHandTemplate
	{
		public int Id;
		public int HandForHandStart;
		public int HandForHandEnd;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyPrizeSummary
	{
		public TourneyAwardType AwardType;
		public long GuaranteedAmount;
		public int GuaranteedTicketCount;
		public int TotalTicketValue;
		public string TicketName;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TourneyBreakType
	{
		EveryMinutes,
		EveryLevel,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyBlindStructureInformation
	{
		public int Id;
		public string Name;
		public List<TourneyBlindStructureItem> Items = new List<TourneyBlindStructureItem>();
		public TourneyBreakInformation BreakInformation;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyBlindStructureItem
	{
		public int Level;
		public long SmallBlind;
		public long BigBlind;
		public long Ante;
		public TimeSpan Timebank;
		public TimeSpan Duration;
		public int HandCount1;
		public int HandCount2;

		public Stake ToStake()
		{
			return new Stake()
			{
				Ante = Ante,
				BigBlind = BigBlind,
				SmallBlind = SmallBlind,
				MinBuyIn = 0,
				MaxBuyIn = 10000000,
			};
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TourneyBountyType
	{
		None = 0,
		//Normal = 1,
		Progressive = 2
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class BountyInformation
	{
		public TourneyBountyType BountyType;
		public long BountyAmount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyBreakInformation
	{
		public TourneyBreakType Type;
		public int? Level;
		public TimeSpan? Term;
		public TimeSpan Duration;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneySnapshotsRequest
	{
		public TourneyEntryStatus Status;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneySnapshotsResponse : Response
	{
		public List<TourneySnapshot> Snapshots = new List<TourneySnapshot>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneySnapshot
	{
		public int TourneyId;
		public Guid UserId;
		public long Chips;
		public TableInformationType PlayType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyResultRequest
	{
		public Guid TourneyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyResultResponse : Response
	{
		public List<TourneyResult> TourneyResult = new List<TourneyResult>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyResult
	{
		public int Place;
		public long FinalChipCount;
		public Guid UserId;
		public string UserName;
		public string NickName;
		public string CountryCode;
		public int AvatarId;
		public int RebuyRemainingCount;
		public long PrizeCash;
		public long PrizeGGP;
		public long PrizeTicket;
		public string GpId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyUnsubscribeRequest
	{
		public Guid TourneyId;
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneySubscribeRequest
	{
		public Guid TourneyId;
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyUnsubscribeResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneySubscribeResponse : Response
	{
		public Guid TourneyId;
		public TourneyDetailedEntryInformation DetailedInformation;
		public TourneyBlindStructureInformation BlindStructureInformation;
		public TourneyPrizePoolInformation PrizePoolInformation;
		public TourneyDetailedStatistics Statistics;
		public DateTime ServerTime;
		public TimeSpan? BreakDuration;
		public DateTime? BreakStartTime;
		public int? PlayingLevel;
		public long? CurrentGGPPrizePool;

		/// <summary>
		/// Subscribe 한 플레이어의 정보, 플레이 중이 아니라면 null
		/// </summary>
		public MutableTourneyPlayer Player;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyUnregistrationRequest
	{
		public Guid UserId;
		public Guid TourneyId;
	}

	public class TourneyUnregistrationResponse : Response
	{
	}

	public class TourneyRegistrationResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyRegistrationRequest
	{
		public Guid TourneyId;
		public Guid UserId;
		public TourneyBuyInType BuyInType;
		public bool DoubleBuyIn;
		public Guid? BuyInTicketId;

		[SetByServer]
		public AccountInfo AccountInfo;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyCreated
	{
		public TourneyEntryInformation Entry;
		[SetByServer]
		public TourneyDetailedEntryInformation DetailedEntryInformation;
		[SetByServer]
		public TourneyBlindStructureInformation BlindStructureInformation;
		[SetByServer]
		public TourneyPrizePoolInformation PrizePoolInformation;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyRemoved
	{
		public Guid TourneyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyNewHandStart
	{
		public Guid TourneyId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyDetailChanged
	{
		public Guid TourneyId;
		public List<Table> AddedTables = new List<Table>();
		public List<Table> RemovedTables = new List<Table>();
		public List<Table> UpdatedTables = new List<Table>();
		public TourneyDetailedStatistics Statistics;
		public long? PrizePool;
		public long? GGPPrizePool;
		public List<TourneyPrizePoolItem> PrizePools = new List<TourneyPrizePoolItem>();
		public int? CurrentBlindStructureId;
		public DateTime StartTime;
		public TourneyLifeCycleConfiguration LifeCycleData;

		// Use for Bounty Tournament
		public long? RegularPrizePool;
		public long? BountyPrizePool;
		public bool? IsInTheMoney;

		public NotifyTourneyDetailChanged Clone()
		{
			return new NotifyTourneyDetailChanged()
			{
				TourneyId = TourneyId,
				AddedTables = AddedTables,
				RemovedTables = RemovedTables,
				StartTime = StartTime,
				Statistics = Statistics,
				PrizePool = PrizePool,
				GGPPrizePool = GGPPrizePool,
				PrizePools = PrizePools,
				CurrentBlindStructureId = CurrentBlindStructureId,
				RegularPrizePool = RegularPrizePool,
				BountyPrizePool = BountyPrizePool,
				IsInTheMoney = IsInTheMoney,
			};
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyListingChanged
	{
		public TourneyEntryInformation TourneyEntry;
		public TourneyEntryStatus Status;
		// use when player state is subscribed
		public long? CurrentPrizePool;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyPlayersUpdated
	{
		public Guid TourneyId;

		public MutableTourneyPlayer[] UpdatedPlayerInfoes = new List<MutableTourneyPlayer>().ToArray();

		public bool IsDeleted;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyGameReady
	{
		public Guid TourneyId;
		public Guid TableId;
		public Guid UserId;
		public Table Table;
		public Guid FromTableId;
		public string TokenId;

		// use for megaspin
		public List<TourneyPrizePoolItem> MegaSpinPrizePoolItems = new List<TourneyPrizePoolItem>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyGameReadyBulk
	{
		public Guid TourneyId;
		public Dictionary<Guid, Table> Tables = new Dictionary<Guid, Table>();
		public Dictionary<Guid, Guid> Users = new Dictionary<Guid, Guid>();

		// use for megaspin
		[SetByServer]
		public List<TourneyPrizePoolItem> MegaSpinPrizePoolItems = new List<TourneyPrizePoolItem>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyBreakTime
	{
		public Guid TourneyId;
		public DateTime? StartTime;
		public TimeSpan? Duration;
		[SetByServer]
		public bool IsWaitForSynchronization;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyRewardAvatar
	{
		public Guid TourneyId;
		public Guid TableId;
		public Guid UserId;
		public int AvatarId;
		public string ImageUrl;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyDealerStateChanged
	{
		public Guid? TourneyId;
		public Guid TableId;
		public TablePauseType PauseType;
		public bool IsPaused;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyImmigration
	{
		public Guid TourneyId;
		public Guid TableId;
		public List<ImmigratedPlayer> ImmigratedPlayer = new List<ImmigratedPlayer>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyPlayerDropOutRequest
	{
		public Guid TourneyId;
		public Guid TableId;
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyPlayerDropOutResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RequestNotifyCashGameReady
	{
		public Guid TableId;
		public Guid UserId;
		public Table Table;
		public int SeatIndex;
		public Guid FromTableId;
		public string TokenId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyDroppedOut
	{
		public Guid TourneyId;
		public Guid? TableId;
		public Guid UserId;
		public int Place;
		public TourneyAward Award;

		// Bounty Tournament
		public long Bounty;
		public int KoPlayersCount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TryDropOutHuntedBountyPlayersRequest
	{
		public Guid TourneyId;
		public Guid TableId;

		public TryDropOutPlayer[] HuntedPlayers = new List<TryDropOutPlayer>().ToArray();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TryDropOutHuntedBountyPlayersResponse : Response
	{
		public bool IsInTheMoney;

		public List<Guid> InTheMoneyPlayers = new List<Guid>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyListingResponse : Response
	{
		public TourneyEntryInformation[] List = new List<TourneyEntryInformation>().ToArray();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyRequest
	{
		public Guid TourneyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyResponse : Response
	{
		public TourneyEntryInformation Entry;
		public TourneyDetailedEntryInformation DetailedEntryInformation;
		public TourneyBlindStructureInformation BlindStructureInformation;
		public TourneyPrizePoolInformation PrizePoolInformation;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyGetPlayersRequest
	{
		public Guid TourneyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyGetPlayersResponse : Response
	{
		public Guid TourneyId;
		public MutableTourneyPlayer[] Players = new List<MutableTourneyPlayer>().ToArray();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyGetTablePlayersRequest
	{
		public Guid TourneyId;

		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyGetTablePlayersResponse : Response
	{
		public Guid TourneyId;
		public Guid TableId;
		public List<MutableTourneyPlayer> Players = new List<MutableTourneyPlayer>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyGetTablesRequest
	{
		public Guid TourneyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyGetTablesResponse : Response
	{
		public Guid TourneyId;
		public List<Table> Tables = new List<Table>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyListingRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyHandForHandNotification
	{
		public bool Proceed;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyHandForHandInitiatedRequest
	{
		public Guid TableId;
		public Guid TourneyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyGetReconnectInformationRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyGetReconnectInformationResponse : Response
	{
		public Guid UserId;
		public List<Tuple<Guid, int?>> TourneyIdAndPlaces = new List<Tuple<Guid, int?>>();
		public List<Table> Tables = new List<Table>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PurchaseTourneyTicketRequest
	{
		public Guid TourneyId;

		[SetByServer]
		public Guid UserId;
		[SetByServer]
		public PlatformGameType GameType;
		[SetByServer]
		public int? BonusTicketTemplateId;
		[SetByServer]
		public long? DiscountAmount;
		[SetByServer]
		public long? BonusTicketValue;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PurchaseTourneyTicketResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyPlayerRebuyRemainingCountRequest
	{
		public Guid TourneyGuid;
		public Guid UserId;
		public int RebuyRemainingCount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UpdateTourneyPlayerRebuyRemainingCountResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetMegaSpinTypeListRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetMegaSpinTypeListResponse : Response
	{
		public List<MegaSpinInfo> MegaSpinInfos = new List<MegaSpinInfo>();

		// 클라이언트에서 빈테이블 열기위해 사용
		public TableType MegaSpinTableType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetMegaSpinListRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetMegaSpinListResponse : Response
	{
		public BriefMegaSpinEntryInformation[] List = new List<BriefMegaSpinEntryInformation>().ToArray();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyListRequest
	{
		public Guid UserId;

		/// <summary>
		/// 페이징시 한 페이지의 크기
		/// 0이나 null값이면 페이징 하지 않음
		/// </summary>
		public int? PageSize;

		/// <summary>
		/// 페이징시 해당 토너 이후의 토너를 찾는 방식으로 페이징함
		/// 1페이지는 Empty
		/// </summary>
		public Guid LastTourneyId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetTourneyListResponse : Response
	{
		public BriefTourneyEntryInformation[] List = new List<BriefTourneyEntryInformation>().ToArray();

		/// <summary>
		/// 클라가 페이징 요청한 경우 페이지 크기
		/// </summary>
		public int? PageSize;

		/// <summary>
		/// 요청한 페이지 크기에 따른 전체 페이지 수
		/// </summary>
		public int? TotalPage;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class MegaSpinInfo
	{
		public int Index { get; set; }
		public string BuyInType { get; set; }
		public long Amount { get; set; }
		public List<int> MultiplierList = new List<int>();
		public int CurrentPlayingCount { get; set; }
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class MegaSpinRegistrationRequest
	{
		public Guid UserId;
		public int MegaSpinId;
		public TourneyBuyInType BuyInType;
		public Guid? BuyInTicketGuid;

		[SetByServer]
		public AccountInfo AccountInfo;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class MegaSpinRegistrationResponse : Response
	{
		public Guid MegaSpinGuid;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class MegaSpinUnregistrationAllEntryRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class MegaSpinUnregistrationRequest
	{
		public Guid UserId;
		public Guid MegaSpinGuid;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class MegaSpinUnregistrationResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetMegaSpinStoriesRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetMegaSpinStoriesResponse : Response
	{
		public long MegaSpinTotalGaveAward;
		public List<MegaSpinStory> MegaSpinStories = new List<MegaSpinStory>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class MegaSpinStory
	{
		public Guid TourneyId;
		public int Multiplier;
		public long BuyInAmount;
		public DateTime CompletedDateTime;
		public List<MegaSpinPlayerInfo> Players = new List<MegaSpinPlayerInfo>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class MegaSpinPlayerInfo
	{
		public int Place;
		public string AvatarType;
		public string ImageUrl;
		public uint AccountId;
		public string UserName;
		public string NickName;
		public int AvatarId;
		public long Award;
		public DateTime CompletedDateTime;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyHighMultiplierParameter
	{
		public Guid MegaSpinGuid;
		[SetByServer]
		public List<Guid> SkipPlayerList = new List<Guid>();
		public Table Table;
		public List<Tuple<int/*avatarId*/, string/*avatartype*/, string/*imageUrl*/>> PlayerInfos = new List<Tuple<int, string, string>>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyMegaSpinStoryNewInfoParameter
	{
		public MegaSpinStory MegaSpinStoryNewInfo;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveMegaSpinRequest
	{
		public uint TourneyId;
		public DateTime EndTime;
		public long BuyInAmount;
		public int Multiplier;
		public List<MegaSpinPlayerInfo> MegaSpinPlayers = new List<MegaSpinPlayerInfo>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveMegaSpinResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyCurrentPlayingMegaSpinCountChangedParameter
	{
		public int MegaSpinTypeIndex;
		public int CurrentPlayingCount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetMegaSpinBestWinnersRequest
	{
		public Guid UserId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetMegaSpinBestWinnersResponse : Response
	{
		public List<MegaSpinPlayerInfo> BestWinners = new List<MegaSpinPlayerInfo>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyTourneyBlindUpParameter
	{
		public Guid TourneyId;
		public TourneyBlindStructureItem CurrentBlindStructure;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class NotifyMegaSpinBestWinnerNewInfoParameter
	{
		public MegaSpinPlayerInfo MegaSpinBestPlayerNewInfo;
	}
}