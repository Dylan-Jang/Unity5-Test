using System.Security.Cryptography;
using System.Text;

namespace SocketFramework.Network.Crypt
{
	public class CryptAES
	{
		private const string KeyString = "01234567890123456789012345678901";

		private readonly byte[] _key = { 0x74, 0x6c, 0x9b, 0xf2, 0x24, 0xce, 0xdd, 0x55, 0x23, 0xba, 
							0x64, 0xfb, 0xe9, 0xbe, 0x17, 0x32, 0xcf, 0xf5, 0xe3, 0xf6, 0x18, 0xc0, 0x1f, 
							0xd5, 0x64, 0x5d, 0x84, 0xc1, 0x1a, 0xc8, 0x71, 0x7c };

		private readonly byte[] _iv = { 0x18, 0x13, 0xb1, 0xb3, 0x26, 0x2b, 0x80, 0xd1, 0xe, 0x80, 0x9f, 0x47, 0xa0, 0xd9, 0x6c, 0x1f };

		private readonly RijndaelManaged _rm = new RijndaelManaged();

		public CryptAES()
		{
			InitAES();
		}

		public void InitAES()
		{
			_rm.KeySize = 256;
			_rm.BlockSize = 128;
			_rm.Mode = CipherMode.ECB;
			_rm.Padding = PaddingMode.PKCS7; // default

			_rm.Key = Encoding.UTF8.GetBytes(KeyString);
			_rm.IV = _iv;
		}

		public byte[] Encrypt(byte[] plainTextBytes)
		{
			var ict = _rm.CreateEncryptor();
			var encryptBytes = ict.TransformFinalBlock(plainTextBytes, 0, plainTextBytes.Length);

			return encryptBytes;
		}

		public byte[] Decrypt(byte[] sourceBytes)
		{
			var ict = _rm.CreateDecryptor();
			var decryptBytes = ict.TransformFinalBlock(sourceBytes, 0, sourceBytes.Length);

			return decryptBytes;
		}
	}
}
