using System.Collections.Generic;

using Assets.Script.Network.Protocol;
using Assets.Script.Network.Utils;

using SocketFramework.Network.Serialize;
using SocketFramework.Utils;

namespace Assets.Script.Network.Serialize
{
	public sealed class SerializerManager : SingletonBase<SerializerManager>
	{
		private readonly Dictionary<int, ISerializer> _serializers = new Dictionary<int, ISerializer>();

		private SerializerManager()
		{
			_serializers.Add((int)PacketSerializeMode.ProtoBuf, new ProtoBufBinarySerializer());
			_serializers.Add((int)PacketSerializeMode.JsonText, new NewtonJsonSerializer());
		}

		public ISerializer GetSerializer(int serializeMode)
		{
			if (serializeMode == -1)
			{
				return null;
			}

			ISerializer serializer;
			if (_serializers.TryGetValue(serializeMode, out serializer) == false)
			{
				return null;
			}

			return serializer;
		}

		// make packet helper
		public byte[] ConvertToWholeBuffer<TParam>(int serializeMode, int protocolId, TParam param) where TParam : class
		{
			var serializer = GetSerializer(serializeMode);
			if (serializer == null)
				return null;

			var bodyBytes = serializer.Serialize(param);
			var header = new PacketDefaultHeader(bodyBytes.Length, protocolId, serializeMode);

			return ByteHelper.MergeBytes(header.Serialize(), bodyBytes);
		}
	}
}
