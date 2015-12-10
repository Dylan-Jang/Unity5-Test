using System;

namespace SocketFramework.Network.Serialize
{
	public interface ISerializer
	{
		byte[] Serialize<T>(T instance) where T : class;
		T Deserialize<T>(byte[] buffer) where T : class, new();
		object Deserialize(byte[] buffer, Type type);
	}
}
