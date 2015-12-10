using System;

namespace Rhyme.Common.Utilities
{
	public static class GuidHelper
	{
		public enum GuidType
		{
			UserId = 0,
			GuestId,
			RingTableId = 10,
			JumpTableId,
			SitAndGoId,
			SitAndGoTableId,
			TournamentId,
			TournamentTableId,
			CashOutRequestId, // use for GGPMarket, LeaderBoard
			JumpEntryId = 100,
			JumpPlayerId,
			TicketId = 200,
			JackpotHistoryId,
		}

		public static Guid GenerateGuid(GuidType prefix, int bogus, int serviceLabel, uint seqId)
		{
			var bytes = new byte[16];
			BitConverter.GetBytes((int)prefix).CopyTo(bytes, 0);
			BitConverter.GetBytes(bogus).CopyTo(bytes, 4);
			BitConverter.GetBytes(serviceLabel).CopyTo(bytes, 8);
			BitConverter.GetBytes(seqId).CopyTo(bytes, 12);
			return new Guid(bytes);
		}

		public static Guid GenerateGuid(GuidType prefix, int bogus, int serviceLabel, int seqId)
		{
			return GenerateGuid(prefix, bogus, serviceLabel, (uint)seqId);
		}

		public static GuidType GetGuidType(this Guid guid)
		{
			return (GuidType)BitConverter.ToInt32(guid.ToByteArray(), 0);
		}

		public static uint GetValue(this Guid guid)
		{
			return BitConverter.ToUInt32(guid.ToByteArray(), 12);
		}

		/// <summary>
		/// Debug 빌드에서 TransactionKey 발급을 위해 사용
		/// </summary>
		/// <param name="guid"></param>
		/// <returns></returns>
		public static long GetUniqueKey(this Guid guid)
		{
			return BitConverter.ToInt64(guid.ToByteArray(), 0);
		}

		public static uint GetUserId(this Guid guid)
		{
			if (GetGuidType(guid) != GuidType.UserId)
				return 0;

			return GetValue(guid);
		}

		public static uint GetTourneyId(this Guid guid)
		{
			if (GetGuidType(guid) != GuidType.TournamentId && GetGuidType(guid) != GuidType.SitAndGoId)
				return 0;

			return GetValue(guid);
		}

		public static Guid Clone(this Guid guid)
		{
			return new Guid(guid.ToByteArray());
		}

		public static int GetServiceLabel(this Guid guid)
		{
			if (GetGuidType(guid) != GuidType.RingTableId)
				return 0;

			return BitConverter.ToInt32(guid.ToByteArray(), 8);
		}
	}
}
