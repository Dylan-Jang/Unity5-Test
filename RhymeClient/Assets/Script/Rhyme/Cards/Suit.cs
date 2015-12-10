using System;
using System.Collections.Generic;
using System.Linq;

namespace Rhyme.Holdem.Elements.Cards
{
	[Serializable]
	public class Suit
	{
		public static readonly Suit CLUBS = new Suit(0, "Clubs", "c", "♣", "007210");
		public static readonly Suit DIAMONDS = new Suit(1, "Diamonds", "d", "◆", "001EDA");
		public static readonly Suit HEARTS = new Suit(2, "Hearts", "h", "♥", "AC0000");
		public static readonly Suit SPADES = new Suit(3, "Spades", "s", "♠", "Black");
		private readonly String _longDescription;
		private readonly int _ordinal;
		private readonly String _shortDescription;
		private readonly String _displayCardSymbol;
		private readonly String _color;

		private Suit(int ordinal, String longDescription, String shortDescription, String displayCardSymbol, String color)
		{
			_ordinal = ordinal;
			_longDescription = longDescription;
			_shortDescription = shortDescription;
			_displayCardSymbol = displayCardSymbol;
			_color = color;
		}

		public string LongDescription
		{
			get { return _longDescription; }
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
			get { return Ordinal; }
		}

		public string DisplayCardSymbol
		{
			get { return _displayCardSymbol; }
		}

		public string Color
		{
			get { return _color; }
		}

		public static IEnumerable<Suit> Values
		{
			get
			{
				yield return CLUBS;
				yield return DIAMONDS;
				yield return HEARTS;
				yield return SPADES;
			}
		}

		public override String ToString()
		{
			return ShortDescription;
		}

		public static Suit GetSuit(String value)
		{
			return
				Values.FirstOrDefault(rank => rank.ToString().Equals(value, StringComparison.InvariantCultureIgnoreCase));
		}
	}
}