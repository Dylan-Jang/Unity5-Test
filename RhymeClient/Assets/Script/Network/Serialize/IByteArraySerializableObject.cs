namespace SocketFramework.Network.Serialize
{
	internal interface IByteArraySerializableObject
	{
		byte[] Serialize();
		void Deserialize(byte[] byteArray);
	}
}