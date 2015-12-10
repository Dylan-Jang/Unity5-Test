using ProtoBuf;

namespace Rhyme.Common
{
	[ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
	public enum DumpBuyInType
	{
		Unknown,

		/// <summary>
		/// 2Ace 게임머니 (실제화폐, 머니상용)
		/// </summary>
		Bean,

		/// <summary>
		/// 연습용 가짜 머니 (유저용)
		/// </summary>
		VirtualCurrency,
	}
}
