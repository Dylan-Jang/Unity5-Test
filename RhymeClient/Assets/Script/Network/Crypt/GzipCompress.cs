using System.IO;
using Unity.IO.Compression;

namespace SocketFramework.Network.Crypt
{
	public static class GzipCompress
	{
		public static byte[] EnCompress(Stream sourceStream)
		{
			var memory = new MemoryStream();

			sourceStream.Seek(0, SeekOrigin.Begin);
			memory.Seek(0, SeekOrigin.Begin);
			try
			{
				using (var zipStream = new GZipStream(memory, CompressionMode.Compress))
				{
					var fileByte = new byte[1024];
					var readLen = 0;
					do
					{
						readLen = sourceStream.Read(fileByte, 0, fileByte.Length);
						zipStream.Write(fileByte, 0, readLen);
					}
					while (readLen > 0);
				}
			}
			finally
			{
				memory.Dispose();
			}
			return memory.ToArray();
		}

		public static byte[] EnCompress(byte[] sourceStream, int index, int count)
		{
			using (var memory = new MemoryStream(sourceStream, index, count))
			{
				return EnCompress(memory);
			}
		}

		public static byte[] DeCompress(Stream sourceStream)
		{
			byte[] unZipByte = null;

			using (var memory = new MemoryStream())
			{
				var unZipStream = new GZipStream(sourceStream, CompressionMode.Decompress);
				try
				{
					var tempByte = new byte[1024];
					int readLen = 0;
					do
					{
						readLen = unZipStream.Read(tempByte, 0, tempByte.Length);
						memory.Write(tempByte, 0, readLen);
					}
					while (readLen > 0);
					unZipStream.Close();
				}
				finally
				{
					unZipStream.Dispose();
				}
				unZipByte = memory.ToArray();
			}
			return unZipByte;
		}

		public static byte[] DeCompress(byte[] sourceByte, int index, int count)
		{
			using (var memory = new MemoryStream(sourceByte, index, count))
			{
				return DeCompress(memory);
			}
		}
	}
}
