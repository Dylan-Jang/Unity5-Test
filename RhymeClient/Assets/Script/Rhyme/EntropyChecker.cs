using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Rhyme.Common
{
	public static class EntropyChecker
	{
		private static string CreateHash(string text)
		{
			var md5 = MD5.Create();
			var hash = new Guid(md5.ComputeHash(Encoding.Default.GetBytes(text)));
			return hash.ToString();
		}

		private static bool IsHighestEntropy(string text)
		{
			var count = text.Length;
			var upperCount = 0;
			var numberCount = 0;
			var punctuationCount = 0;
			var originCount = count;

			foreach (var ch in text)
			{
				if (Char.IsNumber(ch))
				{
					count--;
					numberCount++;
				}
				if (Char.IsPunctuation(ch))
				{
					count--;
					punctuationCount++;
				}
				if (Char.IsUpper(ch))
				{
					count--;
					upperCount++;
				}
			}

			var totalCount = upperCount + numberCount + punctuationCount;

			if (totalCount >= count && totalCount != 0 && count != 0 && totalCount != originCount && upperCount >= numberCount)
			{
				return true;
			}

			return false;
		}

		public static string GetHash(string text)
		{
			var sb = new StringBuilder();

			var textLines = text.Split(new[] { Environment.NewLine, " ", ".", "(", ")", ",", "'", ":", "@", "-", "<", ">", "at" }, StringSplitOptions.None);

			foreach (var textLine in textLines)
			{
				var result = Regex.Replace(textLine, @"[^a-zA-Z0-9\s~`!@#$%^&*()_\-+={}[\]|\\;:'""<>,.?/]", "");

				if (result.Equals(string.Empty))
					continue;

				if (IsHighestEntropy(result))
					continue;

				sb.AppendLine(result);
			}

			var hash = CreateHash(sb.ToString());

			return string.IsNullOrEmpty(hash) ? "(INVALID HASH)" : hash;
		}
	}
}
