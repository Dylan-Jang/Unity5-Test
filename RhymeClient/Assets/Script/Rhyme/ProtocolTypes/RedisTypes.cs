using System;

using ProtoBuf;

namespace Rhyme.Common.ProtocolTypes
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class WriteCompletedTourneyRecordRequest
	{
		public long RecordIndex;
		public int TourneyId;
		public DateTime StartDateTime;
		public DateTime EndDateTime;
		public string PlayType;
		public string GameType;
		public string ModeType;
		public string UserName;
		public long BuyIn;
		public long Fee;
		public long Prize;
		public long GuaranteeDeduction;
		public long BuyInCash;
		public long BuyInGGP;
		public long BuyInTicket;
		public long FeeCash;
		public long FeeGGP;
		public long FeeTicket;
		public long PrizeCash;
		public long PrizeGGP;
		public long PrizeTicket;

		// use for gp
		public string GpId;
		public int Place;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CashGameRecord
	{
		public long handId;
		public string modeType;
		public string playType;
		public string gameType;
		public string startDate;
		public string endDate;
		public long smallBlind;
		public long bigBlind;
		public long totalPot;
		public long totalRake;
		public string board;
		public string gpId;
		public int isWinner;
		public long winloss;
		public long jackpot;
		public long contributedRake;
		public string holeCards;
		public long totalContributedJackpot;
		public long sessionId;
		public long jackpotTicket;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class TourneyGameRecord
	{
		public long tourneyId;
		public string modeType;
		public string playType;
		public string gameType;
		public string startDate;
		public string endDate;
		public string gpId;
		public long buyin;
		public long buyinCash;
		public long buyinGgp;
		public long buyinTicket;
		public long fee;
		public long feeCash;
		public long feeGgp;
		public long feeTicket;
		public long prize;
		public long prizeCash;
		public long prizeGgp;
		public long prizeTicket;
		public int place;
		public long tournamentOverlay;
	}
}