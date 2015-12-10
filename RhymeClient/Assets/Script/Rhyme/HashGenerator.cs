using System;
using System.Security.Cryptography;
using System.Text;

using Rb.Services.Protocol;

namespace Rhyme.Common
{
	public static class HashGenerator
	{
		public static MD5 Md5 = MD5.Create();

		public static string GenerateHash(EntityId id)
		{
			return GenerateHash(String.Format("Entity {0}", id.Value));
		}

		public static string GenerateHash(Guid guid)
		{
			return GenerateHash(guid.ToByteArray());
		}

		public static string GenerateHash(string text)
		{
			return GenerateHash(Encoding.UTF8.GetBytes(text));
		}

		public static string GenerateHash(byte[] bytes)
		{
			var bytesHashed = MD5.Create().ComputeHash(bytes);

			return ToHex(bytesHashed, false);
		}

		private static string ToHex(byte[] bytes, bool upperCase)
		{
			var result = new StringBuilder(bytes.Length * 2);

			for (int i = 0; i < bytes.Length; i++)
				result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

			return result.ToString();
		}

		public static string GenerateImageNameHash(string userName, Guid spId)
		{
			try
			{
				if (string.IsNullOrEmpty(userName))
				{
					return string.Empty;
				}

				var saltUserName = string.Format("so!gum!{0}@{1}_s!a!l!t", userName, spId);
				var bytes = Encoding.UTF8.GetBytes(saltUserName);

				var md5Bytes = MD5.Create().ComputeHash(bytes);
				md5Bytes[6] &= 0x0f;
				md5Bytes[6] |= 0x30;

				md5Bytes[8] &= 0x3f;
				md5Bytes[8] |= 0x80;

				// make guid from md5bytes
				var guid = new Guid(md5Bytes);

				var bigEndian = new byte[16];
				var net = guid.ToByteArray();

				for (var i = 8; i < 16; i++)
				{
					bigEndian[i] = net[i];
				}

				bigEndian[0] = net[3];
				bigEndian[1] = net[2];
				bigEndian[2] = net[1];
				bigEndian[3] = net[0];
				bigEndian[4] = net[5];
				bigEndian[5] = net[4];
				bigEndian[6] = net[7];
				bigEndian[7] = net[6];

				guid = new Guid(bigEndian);

				return GenerateHash(Encoding.UTF8.GetBytes(guid.ToString()));
			}
			catch (Exception e)
			{
//				Logger.Log(LogInfo.Warn, new
//				{
//					Event = "get_image_name_hash_failed",
//					UserName = userName,
//					Exception = e
//				});

				return string.Empty;
			}
		}
	}
}