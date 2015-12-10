using System;
using System.IO;
using System.Threading;

using Assets.Script.Network.Serialize;

using SocketFramework;
using SocketFramework.Network.Serialize;

namespace Assets.Script.Network.Protocol
{
	// use for proxy
	public class PacketDefaultHeader : IByteArraySerializableObject
	{
		private static int _packetId = 1;

		public static int NewPacketId()
		{
			// remove lock
			return Interlocked.Increment(ref _packetId);
		}

		// helpers
		public const int CurrentFixedHeaderSize = 24;
		public const uint MagicKey = 0xBAB0DA00;

		// header fields
		public int PayloadSize { get; set; }
		public int ProtocolId { get; set; }
		public uint Magic { get; set; }
		public int SerializeMode { get; set; }
		public int PacketId { get; set; }
		public int RelatesTo { get; set; }

		public PacketDefaultHeader()
		{
			PayloadSize = 0;
			ProtocolId = 0;
			Magic = MagicKey;
			SerializeMode = (int)SerializeMode;
			PacketId = 0;
			RelatesTo = 0;
		}

		public PacketDefaultHeader(int payloadSize, int protocolId, int serializeMode)
		{
			PayloadSize = payloadSize;
			ProtocolId = protocolId;
			Magic = MagicKey;
			SerializeMode = serializeMode;
			PacketId = NewPacketId();
			RelatesTo = 0;
		}

		public bool IsValid
		{
			get { return Magic == MagicKey; }
		}

		public byte[] Serialize()
		{
			var buffer = new byte[CurrentFixedHeaderSize];
			Buffer.BlockCopy(BitConverter.GetBytes(PayloadSize), 0, buffer, 0, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(ProtocolId), 0, buffer, 4, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(Magic), 0, buffer, 8, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(SerializeMode), 0, buffer, 12, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(PacketId), 0, buffer, 16, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(RelatesTo), 0, buffer, 20, 4);

			ThrowIfNotValidateHeader();

			return buffer;
		}

		public void Deserialize(byte[] byteArray)
		{
			PayloadSize = BitConverter.ToInt32(byteArray, 0);
			ProtocolId = BitConverter.ToInt32(byteArray, 4);
			Magic = BitConverter.ToUInt32(byteArray, 8);
			SerializeMode = BitConverter.ToInt32(byteArray, 12);
			PacketId = BitConverter.ToInt32(byteArray, 16);
			RelatesTo = BitConverter.ToInt32(byteArray, 20);

			ThrowIfNotValidateHeader();
		}

		private void ThrowIfNotValidateHeader()
		{
			// *** check, invalid packet header ***

			// *** all exceptions are INVALID DATA EXCEPTION

			// Body size is must 0 ~ 1 Mega byte. (1024 Kilo byte, 1,048,576 byte)
			if (PayloadSize < 0)
				throw new Exception("Payload (body) size must greater than or equal to 0.");
			if (PayloadSize > SocketSetting.MaxAllowBlockSize)
				throw new Exception(string.Format("Payload (body) size is too large. (Max allow byte is {0}.)", SocketSetting.MaxAllowBlockSize));

			// Protocol id is must 1 ~ 4999. (not start 0)
			if (ProtocolId < SocketSetting.MinAllowProtocolId)
				throw new Exception(string.Format("Protocol id not less than {0}.", SocketSetting.MinAllowProtocolId));
			if (ProtocolId > SocketSetting.MaxAllowProtocolId)
				throw new Exception(string.Format("Protocol id can not be greater than {0}.", SocketSetting.MaxAllowProtocolId));

			if (false == IsValid)
				throw new Exception("Current processing header is invalid.");

			// 0 or 1
			if (SerializeMode != (int)PacketSerializeMode.ProtoBuf &&
				SerializeMode != (int)PacketSerializeMode.JsonText)
				throw new Exception(string.Format("[{0}] serialize mode is not support.", SerializeMode));

			// Not use 0 and minus.
			if (PacketId <= 0)
				throw new Exception("Packet id is must greater than 0.");

			// Not use minus.
			if (RelatesTo < 0)
				throw new Exception("Relates to is must greater than or equal to 0.");
		}
	}
}