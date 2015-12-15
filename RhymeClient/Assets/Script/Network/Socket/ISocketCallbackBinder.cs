using SocketFramework.Network.Serialize;

namespace Assets.Script.Network.Socket
{
	public interface ISocketCallbackBinder
	{
		void Dispatch(ref ISerializer serializer, byte[] payload);
	}
}