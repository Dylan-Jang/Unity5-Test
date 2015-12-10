using System.Net.Sockets;

namespace Assets.Script.Network.PacketPackage
{
	public interface IPacketExtractor
	{
		bool IsDone { get; }
		int Process(byte[] buffer, int remainingBytes);
		byte[] GetBuffer();
		void Reset(int fixedExtractSize, bool isClearBuffer = false);

		void CurrentSocketBufferOffSet(int offset);
	}
}
