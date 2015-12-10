using System.Collections.Generic;

using ProtoBuf;

using Rhyme.Common;

namespace Rb.Services.Protocol.Config
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Stake
	{
		public uint Id;
		public long Ante;
		public long SmallBlind;
		public long BigBlind;
		public long Straddle;
		public long MinChipUnit;
		public long DealMin;
		public long MinBuyIn;
		public long DefaultBuyIn;
		public long MaxBuyIn;
		public long SmallBet;
		public long BigBet;
		public GameBuyInType GameBuyInType;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GetStakeListResponse : Response
	{
		public List<Stake> StakeList = new List<Stake>();
	}
}