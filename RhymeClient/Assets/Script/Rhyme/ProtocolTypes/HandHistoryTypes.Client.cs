using System;
using System.Collections.Generic;
using System.Linq;

using ProtoBuf;

using Rb.Services.Protocol.GameTable;

using Rhyme.Common;
using Rhyme.Common.Attributes;
using Rhyme.Holdem.Elements.Cards;

namespace Rb.Services.Protocol.HandHistory
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Blinds
	{
		public long SmallBlind;
		public long BigBlind;
		public long Straddle;
		public long Ante;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Player : ICloneable
	{
		public Guid Id;
		public string NickName;
		public string CountryCode;
		public int AvatarId;
		public int SeatIndex;
		public PlayerPositionType PositionType;
		public bool IsSittingOut;
		public Card[] HoleCards = new List<Card>().ToArray();
		public Card[] RabbitCards = new List<Card>().ToArray();
		public bool IsWinner;
		public bool IsShowCard;
		public int[] ShowCardsIndex = new List<int>().ToArray();
		public bool IsDealtPlayer;
		public bool IsFolded;
		public long InitialBalance;
		public long InitialBounty;
		public long FinalBounty;
		public long RebuyAmount;
		public long RemoveAmount;
		public long PostedAnte;
		public long PostedSmallBlind;
		public long PostedBigBlind;
		public long PostedStraddle;

		[ExposeBranch(ExposeBranchType.TwoAce)]
		public long PostedChineseFee;

		public long JackpotAmount;
		public int[] JackpotHand = new List<int>().ToArray();
		public long ContributedPot;
		public string ImageNameHash;
		public int Rank;
		public bool? IsRITTOn;
		public long TotalEarnedAmountIncludedRake;
		public int JackpotTicketTemplateId;
		public long JackpotTicketValue;
		public string AvatarType;
		public string ImageUrl;
		public long TotalEarnedAmount;

		public object Clone()
		{
			var cloned = new Player
			{
				Id = Id,
				NickName = NickName,
				CountryCode = CountryCode,
				AvatarId = AvatarId,
				SeatIndex = SeatIndex,
				PositionType = PositionType,
				IsSittingOut = IsSittingOut,
				HoleCards = HoleCards,
				RabbitCards = RabbitCards,
				IsWinner = IsWinner,
				IsShowCard = IsShowCard,
				ShowCardsIndex = ShowCardsIndex,
				IsDealtPlayer = IsDealtPlayer,
				IsFolded = IsFolded,
				InitialBalance = InitialBalance,
				InitialBounty = InitialBounty,
				FinalBounty = FinalBounty,
				RebuyAmount = RebuyAmount,
				RemoveAmount = RemoveAmount,
				PostedAnte = PostedAnte,
				PostedSmallBlind = PostedSmallBlind,
				PostedBigBlind = PostedBigBlind,
				PostedStraddle = PostedStraddle,
				PostedChineseFee = PostedChineseFee,
				JackpotAmount = JackpotAmount,
				JackpotHand = JackpotHand,
				ContributedPot = ContributedPot,
				ImageNameHash = ImageNameHash,
				Rank = Rank,
				IsRITTOn = IsRITTOn,
				TotalEarnedAmountIncludedRake = TotalEarnedAmountIncludedRake,
				AvatarType = AvatarType,
				ImageUrl = ImageUrl,
				JackpotTicketTemplateId = JackpotTicketTemplateId,
				JackpotTicketValue = JackpotTicketValue,
				TotalEarnedAmount = TotalEarnedAmount
			};

			return cloned;
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UserAction
	{
		// only for client.
		[ProtoIgnore]
		public Guid PlayerId;

		// player index in handhistoryinformation in player list
		public int PlayerIndex;
		public TableActionType TableActionType;
		// turn type
		public ActionType TurnActionType;
		public AfterAction AfterAction;
		public long ActionAmount;
		public bool IsAllIn;
		// bubble message type
		public BubbleMessageType MessageType;
		public int BubbleCategory;
		public int BubbleIndex;
		// ritt decision
		public bool? IsOnRITT;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Turn
	{
		public Guid PlayerId;
		public ActionType Action;
		public AfterAction AfterAction;
		public long ActionAmount;
		public bool IsAllIn;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Street
	{
		public GameHoldemState State; // preflop, flop, turn, river
		// 사용하지 않음
		public List<Card> CommunityCards = new List<Card>();
		public List<Turn> Turns = new List<Turn>();
		// 사용하지 않음
		public bool IsRitt;
		public List<UserAction> Actions = new List<UserAction>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Streets : ICloneable
	{
		public List<Street> Sequences = new List<Street>();

		public object Clone()
		{
			return new Streets
			{
				Sequences = new List<Street>(this.Sequences),
			};
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PlayerSummary
	{
		public int SeatId;
		public string PlayerName;
		public PlayerPositionType PositionType;
		public OpenCardState CardOpen;
		public bool IsWinner;
		public GameHoldemState FoldedWhen;
		public string HandValueDescription;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum OpenCardState
	{
		Show,
		Muck,
		Folded
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum TableActionType
	{
		Unknown = 0,
		Turn = 1,
		Bubble = 2,
		RITTDecision = 3,
		ShowCard = 4,
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Summary : ICloneable
	{
		public long TotalPot;
		public long Rake;
		public long Jackpot;
		public List<Board> Board = new List<Board>();
		//public Queue<PlayerSummary> PlayerSummaries;

		public object Clone()
		{
			return new Summary
			{
				TotalPot = this.TotalPot,
				Rake = this.Rake,
				Jackpot = this.Jackpot,
				Board = new List<Board>(this.Board),
			};
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Board
	{
		public List<Card> Cards = new List<Card>();
	}

	// version 1.0 (serialize version)
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class HandHistoryInformation : ICloneable // for client
	{
		public string Version;
		public long HandId;
		public Guid TableId;
		public TableName NameInfo;
		public Guid TourneyId;
		public string TourneyBrandName;
		public int TourneyEventNumber;
		public TourneyBountyType BountyType;
		public bool IsPrivate;
		public bool IsInTheMoney;
		public bool IsFinalTable;
		public TableInformationType TableType;
		public GameType GameType;
		public GameLimitType LimitType;
		public GameBuyInType BuyInType;
		public List<Player> Players;	// initialize on ctor
		public int MaxPlayer;
		public Streets HandInformation;
		public DateTime StartTime;
		public DateTime EndTime;
		public long TourneyBuyIn;
		public long DefaultBuyIn;
		public long MaxBuyIn;
		public long MinBuyIn;
		public long Ante;
		public long BigBlind;
		public long SmallBlind;
		public Summary Summary;
		public List<HandHistoryPot> Pots;	// initialize on ctor
		public int MegaSpinMultiplier;

		public HandHistoryInformation()
		{
			// hand history version 1.0
			Version = "v1.0";

			Players = new List<Player>();
			HandInformation = new Streets();
			HandInformation.Sequences = new List<Street>();
			Summary = new Summary();
			Summary.Board = new List<Board>();
			Pots = new List<HandHistoryPot>();
		}

		public void Clear()
		{
			Ante = 0;
			BigBlind = 0;
			EndTime = default(DateTime);
			GameType = GameType.UnKnown;
			HandId = 0;
			HandInformation.Sequences.Clear();
			BountyType = TourneyBountyType.None;
			IsPrivate = false;
			IsInTheMoney = false;
			IsFinalTable = false;
			LimitType = GameLimitType.Unknown;
			Players.Clear();
			MaxPlayer = 0;
			SmallBlind = 0;
			StartTime = default(DateTime);
			Summary.Board.Clear();
			Summary.Jackpot = 0;
			Summary.Rake = 0;
			Summary.TotalPot = 0;
			TableId = Guid.Empty;
			NameInfo = null;
			TourneyId = Guid.Empty;
			TourneyBrandName = string.Empty;
			TourneyEventNumber = 0;
			TourneyBuyIn = 0;
			Pots.Clear();
		}

		public int GetPlayerIndex(Guid userId)
		{
			return Players.FindIndex(p => p.Id == userId);
		}

		public object Clone()
		{
			return new HandHistoryInformation
			{
				HandId = this.HandId,
				TableId = this.TableId,
				NameInfo = this.NameInfo,
				TourneyId = this.TourneyId,
				TourneyBrandName = this.TourneyBrandName,
				TourneyEventNumber = this.TourneyEventNumber,
				BountyType = this.BountyType,
				IsPrivate = this.IsPrivate,
				IsInTheMoney = this.IsInTheMoney,
				IsFinalTable = this.IsFinalTable,
				TableType = this.TableType,
				GameType = this.GameType,
				LimitType = this.LimitType,
				BuyInType = this.BuyInType,
				Players = new List<Player>(this.Players.Select(p => p.Clone() as Player)),
				MaxPlayer = this.MaxPlayer,
				HandInformation = this.HandInformation.Clone() as Streets,
				StartTime = this.StartTime,
				EndTime = this.EndTime,
				TourneyBuyIn = this.TourneyBuyIn,
				DefaultBuyIn = this.DefaultBuyIn,
				MaxBuyIn = this.MaxBuyIn,
				MinBuyIn = this.MinBuyIn,
				Ante = this.Ante,
				BigBlind = this.BigBlind,
				SmallBlind = this.SmallBlind,
				Summary = this.Summary.Clone() as Summary,
				Pots = new List<HandHistoryPot>(Pots.Select(pot => pot.Clone() as HandHistoryPot)),
				MegaSpinMultiplier = this.MegaSpinMultiplier,
			};
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class HandHistoryPot : ICloneable // for HandHistoryInformation
	{
		public long Amount;
		public List<Guid> Winners = new List<Guid>();
		public List<int> WinnerIndex = new List<int>();

		public object Clone()
		{
			return new HandHistoryPot()
			{
				Amount = Amount,
				Winners = new List<Guid>(Winners ?? new List<Guid>()),
				WinnerIndex = new List<int>(WinnerIndex)
			};
		}
	}
}
