//using System.Threading.Tasks;

using System;

namespace Assets.Script.Network.Socket
{
	public class ProtocolDispatchTask
	{
		internal ProtocolDispatchTask(int command, byte[] buf)
		{
			this.Command = command;
			Buffer = buf;
		}

		internal void Dispose()
		{
			Command = 0;
			Buffer = null;
		}

		internal int Command { get; private set; }
		internal byte[] Buffer { get; private set; }
	}
}
