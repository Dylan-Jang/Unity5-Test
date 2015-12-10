using System;
using System.Collections.Generic;
using System.Linq;

namespace Rhyme.Holdem.Elements.Cards
{
	public class Rank
	{
		public readonly static Rank TWO = new Rank(0, "Two", "2");
		public readonly static Rank THREE = new Rank(1, "Three", "3");
		public readonly static Rank FOUR = new Rank(2, "Four", "4");
		public readonly static Rank FIVE = new Rank(3, "Five", "5");
		public readonly static Rank SIX = new Rank(4, "Six", "6");
		public readonly static Rank SEVEN = new Rank(5, "Seven", "7");
		public readonly static Rank EIGHT = new Rank(6, "Eight", "8");
		public readonly static Rank NINE = new Rank(7, "Nine", "9");
		public readonly static Rank TEN = new Rank(8, "Ten", "T");
		public readonly static Rank JACK = new Rank(9, "Jack", "J");
		public readonly static Rank QUEEN = new Rank(10, "Queen", "Q");
		public readonly static Rank KING = new Rank(11, "King", "K");
		public readonly static Rank ACE = new Rank(12, "Ace", "A");

		private readonly String _longDescription;
		private readonly int _ordinal;
		private readonly int _prime;
		private readonly String _shortDescription;

		private Rank(int ordinal, string longDescription, string shortDescription)
		{
			_prime = PrimeInitializer.NextPrime;
			_ordinal = ordinal;
			_longDescription = longDescription;
			_shortDescription = shortDescription;
		}

		public string LongDescription
		{
			get { return _longDescription; }
		}

		public int Prime
		{
			get { return _prime; }
		}

		public string ShortDescription
		{
			get { return _shortDescription; }
		}

		public int Ordinal
		{
			get { return _ordinal; }
		}

		public int Value
		{
			get { return Ordinal + 2; }
		}

		public static IEnumerable<Rank> Values
		{
			get
			{
				yield return TWO;
				yield return THREE;
				yield return FOUR;
				yield return FIVE;
				yield return SIX;
				yield return SEVEN;
				yield return EIGHT;
				yield return NINE;
				yield return TEN;
				yield return JACK;
				yield return QUEEN;
				yield return KING;
				yield return ACE;
			}
		}

		public override string ToString()
		{
			return ShortDescription;
		}

		public static Rank GetRank(string value)
		{
			return
				Values.FirstOrDefault(rank => rank.ToString().Equals(value, StringComparison.InvariantCultureIgnoreCase));
		}

		public static Rank GetRank(int value)
		{
			return Values.FirstOrDefault(rank => rank.Ordinal == value);
		}

		#region Nested type: PrimeInitializer

		private static class PrimeInitializer
		{
			private static readonly int[] Primes = new[]
			{
				1, 3, 7, 11, 17, 23, 29, 37, 47, 59, 71, 89, 107, 131, 163, 197, 239,
				293, 353, 431, 521, 631, 761, 919, 1103, 1327, 1597, 1931, 2333, 2801, 3371,
				4049, 4861,
				5839, 7013, 8419, 10103, 12143, 14591, 17519, 21023, 25229, 30293, 36353,
				43627, 52361, 62851, 75431, 90523,
				108631, 130363, 156437, 187751, 225307, 270371, 324449, 389357, 467237,
				560689, 672827, 807403, 968897, 1162687, 1395263, 1674319,
				2009191, 2411033, 2893249, 3471899, 4166287, 4999559, 5999471, 7199369
			};

			private static int _idx;

			public static int NextPrime
			{
				get
				{
					int result = Primes[_idx++];

					return result;
				}
			}
		}

		#endregion
	}
}