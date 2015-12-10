using System;

using Assets.Script.Network.Protocol;

namespace Assets.Script.Network.Utils
{
	internal class ByteHelper
	{
		public static byte[] MergeBytes(byte[] firstBytes, byte[] secondBytes)
		{
			// combine first bytes and second bytes.
			var buffer = new byte[PacketDefaultHeader.CurrentFixedHeaderSize + secondBytes.Length];
			Buffer.BlockCopy(firstBytes, 0, buffer, 0, firstBytes.Length);
			Buffer.BlockCopy(secondBytes, 0, buffer, firstBytes.Length, secondBytes.Length);

			return buffer;
		}
	}
}
