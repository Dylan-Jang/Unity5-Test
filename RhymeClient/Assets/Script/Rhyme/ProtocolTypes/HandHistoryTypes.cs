using System;
using System.Collections.Generic;

using ProtoBuf;

using Rhyme.Common;
using Rhyme.Common.ProtocolTypes;

namespace Rb.Services.Protocol.HandHistory
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetLastHandHistoryIdResponse : Response
	{
		public long LastHandHistoryId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveHandHistoryRequest
	{
		// Unique for each table
		public long RequestId;
		public HandHistory HandHistory;
		public long HandHistoryId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveHandHistoryResponse : Response
	{
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SendHandHistoryRequest
	{
		// Unique for each table
		public Guid TableId;
		public HandHistoryInformation HandHistory;
		public List<Guid> SubscribedPlayers = new List<Guid>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class HandHistory
	{
		public long HandHistoryId;
		// This is actually TableId 
		public Guid TableId;
		public TableInformationType PlayType;
		public GameType GameType;
		public long Ante;
		public long SmallBlind;
		public long BigBlind;
		public string CommunityCards;
		public List<Pot> Pots = new List<Pot>();
		public List<HandPlayer> Players = new List<HandPlayer>();
		public List<GameTurn> GameTurns = new List<GameTurn>();
		public DateTime Created;
		public long TotalRakeAmount;
		public long TotalAccumJackpotAmount;
		public long TotalPotAmount;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class HandPlayer
	{
		public Account.Account AccountInfo;
		// player with the dealer button has a seatnumber of 0
		// note: seatnumber increases clockwise
		public byte SeatNumber;
		public bool IsDealtIn;
		public BlindType BlindType;
		public bool ShowedHand;
		// e.g. AcAs, AcTh
		public string HoleCards;
		public long ContributedPot;
		public long ContributedRake;
		public bool IsWinner;
		public long InitialBalance;
		public long FinalBalance;
		public long RebuyAmount;
		public long RemoveBalance;
		public long JackpotAmount;
		public long TablePlayerId;
		public long ReservedRequestId;
		public int JackpotTicketTemplateId;
		public long JackpotTicketValue;
		public long TotalContributedJackpot;

		// use only calc rake
		[ProtoIgnore]
		public bool IsFolded;
		[ProtoIgnore]
		public long CashedOutBalance;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Pot
	{
		// 0 = main pot, 1 = sidepot1, 2 = sidepot2, ...
		public byte PotId;
		public long Amount;
		public List<Guid> ContributorUserIds = new List<Guid>();
		public List<Guid> WinnerUserIds = new List<Guid>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GameTurn
	{
		public string Name;
		public List<PlayerAction> Actions = new List<PlayerAction>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class PlayerAction
	{
		public byte PlayerSeatNumber;
		public ActionType ActionType;

		[ProtoIgnore]
		public long Bet;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveCashGameRecordRequest
	{
		public long HandId;
		public List<CashGameRecord> Records = new List<CashGameRecord>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class SaveTourneyGameRecordRequest
	{
		public long TourneyId;
		public List<TourneyGameRecord> Records = new List<TourneyGameRecord>();
	}
}