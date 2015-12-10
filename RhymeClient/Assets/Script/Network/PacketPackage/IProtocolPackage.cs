using System;
using System.Net.Sockets;

namespace Assets.Script.Network.PacketPackage
{
	public interface IProtocolPackage : IDisposable
	{
		bool Process(int bytesTransferred, byte[] buffer);
		void Reset();
	}
}
