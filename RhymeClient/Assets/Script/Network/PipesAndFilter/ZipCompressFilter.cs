using SocketFramework.Network.Crypt;

namespace SocketFramework.Network.PipesAndFilter
{
	public class ZipCompressFilter : IFilterOperation<byte[]>
	{
		byte[] IFilterOperation<byte[]>.Execute(byte[] input)
		{
			return GzipCompress.EnCompress(input, 0, input.Length);
		}
	}
}