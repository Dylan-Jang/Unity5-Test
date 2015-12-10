using System;
using System.Linq;
using System.Linq.Expressions;

namespace Rhyme.Common.Utilities
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public class StringTableKeyNameAttribute : Attribute
	{
		public string KeyName { get; private set; }

		public string AbbreviateKeyName { get; private set; }

		public StringTableKeyNameAttribute(string keyName, string abbreviateKeyName = null)
		{
			KeyName = keyName;
			AbbreviateKeyName = abbreviateKeyName;
		}
	}

	public static class StringKeyExtension
	{
		public static string GetEnumKeyName<T>(this T target, bool isAbbreviate = false) where T : struct, IConvertible
		{
			var type = target.GetType();
			var memInfos = type.GetMembers();
			foreach (var info in memInfos)
			{
				if (info.DeclaringType == null)
				{
					continue;
				}

				if (info.DeclaringType != type)
				{
					continue;
				}

				if (string.CompareOrdinal(info.Name, target.ToString()) != 0)
				{
					continue;
				}

				var stringKeyAttribute = info.GetCustomAttributes(typeof(StringTableKeyNameAttribute), false).OfType<StringTableKeyNameAttribute>().FirstOrDefault();
				if (stringKeyAttribute == null)
				{
					return string.Empty;
				}

				return isAbbreviate ? stringKeyAttribute.AbbreviateKeyName : stringKeyAttribute.KeyName;
			}

			return string.Empty;
		}

		public static string GetKeyName<T, TR>(this T target, Expression<Func<TR>> expr) where T : class
		{
			var memberName = ((MemberExpression)expr.Body).Member.Name;
			var stringKeyAttribute = GetInnerMember<T, StringTableKeyNameAttribute>(target, memberName);
			if (stringKeyAttribute == null)
			{
				return string.Empty;
			}

			return stringKeyAttribute.KeyName;
		}

		public static string GetKeyName<T>(this T target, string memberName)
		{
			var stringKeyAttribute = GetInnerMember<T, StringTableKeyNameAttribute>(target, memberName);
			if (stringKeyAttribute == null)
			{
				return string.Empty;
			}

			return stringKeyAttribute.KeyName;
		}

		private static TR GetInnerMember<T, TR>(T target, string targetName) where TR : class
		{
			var type = target.GetType();
			var memInfo = type.GetMembers().FirstOrDefault(m => string.CompareOrdinal(m.Name, targetName) == 0);
			if (memInfo == null)
				return null;

			return memInfo.GetCustomAttributes(typeof(TR), false).OfType<TR>().FirstOrDefault();
		}
	}
}
