using System;
using System.IO;

namespace SocketFramework.Network.Serialize
{
	public class ProtoBufBinarySerializer : ISerializer
	{
		byte[] ISerializer.Serialize<T>(T instance)
		{
			using (var memStream = new MemoryStream())
			{
				ProtoBuf.Serializer.Serialize(memStream, instance);

				// Reference : http://sysnet.pe.kr/100194706623
				// ToArray : new array then copy then return
				// GetBuffer : return internal buffer. MUST USE stream.Length!.

				return memStream.ToArray();
				//return memStream.GetBuffer();
			}
		}

		T ISerializer.Deserialize<T>(byte[] buffer)
		{
			using (var memStream = new MemoryStream(buffer))
			{
				return ProtoBuf.Serializer.Deserialize<T>(memStream);
			}
		}

		object ISerializer.Deserialize(byte[] buffer, Type type)
		{
			using (var memStream = new MemoryStream(buffer))
			{
				return ProtoBuf.Serializer.NonGeneric.Deserialize(type, memStream);
			}
		}
	}
}