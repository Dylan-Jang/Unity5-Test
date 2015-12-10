using System;
using System.Collections.Generic;
using System.Linq;

using ProtoBuf;

using Rb.Services.Protocol.Config;

using Rhyme.Common;
using Rhyme.Common.Utilities;

namespace Rb.Services.Protocol.Game
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GameHoldem : ICloneable
	{
		public Guid TableId;
		public uint GameId;
		public uint ButtonPosition;
		public List<GamePot> Pots = new List<GamePot>();
		public long HandHistoryId;
		public Stake Stake;
		public bool IsOnRITT;
		public TourneyBountyType BountyType = TourneyBountyType.None;

		// user for Mega Spin
		public int CurrentHandCount;

		public object Clone()
		{
			return new GameHoldem
			{
				TableId = TableId,
				GameId = GameId,
				ButtonPosition = ButtonPosition,
				Pots = Pots.Select(e => e.Clone() as GamePot).ToList(),
				Stake = Stake,
				HandHistoryId = HandHistoryId,
				IsOnRITT = IsOnRITT,
				BountyType = BountyType,
				CurrentHandCount = CurrentHandCount,
			};
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class GamePot : ICloneable
	{
		public long Amount;
		public long RakedAmount;

		public object Clone()
		{
			return new GamePot { Amount = Amount };
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Blind : ICloneable
	{
		public BlindType BlindType;
		public long BlindAmount;
		public Guid UserId;
		public string UserName;
		public long Balance;

		public object Clone()
		{
			return new Blind
			{
				BlindType = BlindType,
				BlindAmount = BlindAmount,
				UserId = UserId.Clone(),
				UserName = UserName,
				Balance = Balance,
			};
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class Winner : ICloneable
	{
		public Guid UserId;
		public string UserName;
		public int SeatIndex;
		public long EarnedAmount;
		public long Balance;
		public int PotIndex;
		public int RunStage;

		public object Clone()
		{
			return new Winner
			{
				UserId = UserId.Clone(),
				UserName = UserName,
				SeatIndex = SeatIndex,
				EarnedAmount = EarnedAmount,
				Balance = Balance,
				PotIndex = PotIndex,
				RunStage = RunStage,
			};
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class BountyPlayer : ICloneable
	{
		public Guid UserId;
		public string UserName;
		public string NickName;
		public int SeatIndex;

		public long ToBalance;
		public long ToBounty;
		public long BeforeBounty;
		public long AfterBounty;

		public int PotIndex;
		public int RunStage;

		public object Clone()
		{
			return new BountyPlayer
			{
				UserId = UserId.Clone(),
				UserName = UserName,
				NickName = NickName,
				SeatIndex = SeatIndex,
				ToBalance = ToBalance,
				ToBounty = ToBounty,
				BeforeBounty = BeforeBounty,
				AfterBounty = AfterBounty,
				PotIndex = PotIndex,
				RunStage = RunStage,
			};
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class BountyHunter
	{
		public BountyPlayer Hunter;
		public List<BountyPlayer> HuntedPlayers = new List<BountyPlayer>();
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class CheckRequet
	{
		public Guid UserId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class FoldRequet
	{
		public Guid UserId;
		public Guid TableId;
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RaiseRequet
	{
		public Guid UserId;
		public Guid TableId;
		public long Amount;
	}

	// To expose enum AutoActionFlag to the proxy.
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class DummyAutoActionFlag
	{
		public AutoActionFlag Dummy;
	}
}