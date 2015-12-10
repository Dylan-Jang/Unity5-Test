using System;
using System.Diagnostics;

using ProtoBuf;

namespace Rhyme.Common
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class RankInformation : ICloneable
	{
		public int Rank;
		public int RetentionCP;
		public int RankUpCP;
		public int RetentionBonusMoney;
		public int RankUpBonusMoney;
		public int Duration;

		public object Clone()
		{
			var exportedRankInfo = MemberwiseClone() as RankInformation;
			Debug.Assert(exportedRankInfo != null);

			return exportedRankInfo;
		}
	}

	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public class UserRankInfo : ICloneable
	{
		public int Rank;
		// UtcDate on which user's rank expires
		public DateTime RankExpirationDate;
		public long Xp;

		public UserRankInfo()
		{
			Xp = 0;
			RankExpirationDate = new DateTime(0);
		}

		public object Clone()
		{
			var exportedUserRankInfo = MemberwiseClone() as UserRankInfo;
			Debug.Assert(exportedUserRankInfo != null);

			return exportedUserRankInfo;
		}
	}
}
