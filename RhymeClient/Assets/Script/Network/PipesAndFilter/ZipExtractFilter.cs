using SocketFramework.Network.Crypt;

namespace SocketFramework.Network.PipesAndFilter
{
	public class ZipExtractFilter : IFilterOperation<byte[]>
	{
		byte[] IFilterOperation<byte[]>.Execute(byte[] input)
		{
			return GzipCompress.DeCompress(input, 0, input.Length);
		}
	}
}