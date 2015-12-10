using System;

using Assets.Script.Extension;

namespace Rhyme.Common
{
	public static class HandIdConverter
	{
		public static long[] GetHandIdRange(HandIdPlayType playType, HandIdGameType gameType, HandIdModeType modeType)
		{
			var from = ((long)((int)playType) << (8 + 4 + 8 + 40))
					   + ((long)((int)gameType) << (4 + 8 + 40))
					   + ((long)((int)modeType) << (8 + 40));

			var to = ((long)((int)playType) << (8 + 4 + 8 + 40))
					 + ((long)((int)gameType) << (4 + 8 + 40))
					 + (((long)((int)modeType + 1)) << (8 + 40)) - 1;

			return new[] { from, to };
		}

		public static Tuple<HandIdPlayType, HandIdGameType, HandIdModeType> FromHandId(long handId)
		{
			var handIdPlayType = ((HandIdPlayType)(handId >> (8 + 4 + 8 + 40)));
			var handIdGameType = ((HandIdGameType)(handId << 8 >> 8 >> (4 + 8 + 40)));
			var handIdModeType = ((HandIdModeType)(handId << (8 + 4) >> (8 + 4) >> (8 + 40)));

			return new Tuple<HandIdPlayType, HandIdGameType, HandIdModeType>(handIdPlayType, handIdGameType, handIdModeType);
		}

		public static long ToHandId(HandIdPlayType playType, HandIdGameType gameType, HandIdModeType modeType, long handHistoryId)
		{
			return ((long)((int)playType) << (8 + 4 + 8 + 40))
				   + ((long)((int)gameType) << (4 + 8 + 40))
				   + ((long)((int)modeType) << (8 + 40))
				   + handHistoryId;
		}
	}
}
