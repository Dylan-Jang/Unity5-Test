using SocketFramework.Network.Crypt;

namespace SocketFramework.Network.PipesAndFilter
{
	public class AesDecryptFilter : IFilterOperation<byte[]>
	{
		private static readonly CryptAES AESChiper = new CryptAES();

		byte[] IFilterOperation<byte[]>.Execute(byte[] input)
		{
			return AESChiper.Decrypt(input);
		}
	}
}