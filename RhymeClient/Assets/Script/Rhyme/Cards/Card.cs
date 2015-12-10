using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using ProtoBuf;

namespace Rhyme.Holdem.Elements.Cards
{
	public class CardJsonSerializer : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var card = value as Card;
			writer.WriteStartObject();

			writer.WritePropertyName("OrdinalForSerializationOnly");
			if (card != null)
			{
				serializer.Serialize(writer, card.Ordinal );
			}
			writer.WriteEndObject();

		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			JObject jsonObject = JObject.Load(reader);
			var properties = jsonObject.Properties().ToList();

			return Card.FromOrdinal((int)properties[0].Value);

		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(CardJsonSerializer).IsAssignableFrom(objectType);
		}
	}

	[DataContract]
	[ProtoContract(SkipConstructor = true)]
	[JsonConverter(typeof(CardJsonSerializer))]
	public class Card
		: IComparable<Card>
	{
		//ORDER IS IMPORTANT!
		public static readonly Card TWO_CLUBS = new Card(0, Rank.TWO, Suit.CLUBS);
		public static readonly Card TWO_DIAMONDS = new Card(1, Rank.TWO, Suit.DIAMONDS);
		public static readonly Card TWO_HEARTS = new Card(2, Rank.TWO, Suit.HEARTS);
		public static readonly Card TWO_SPADES = new Card(3, Rank.TWO, Suit.SPADES);

		public static readonly Card THREE_CLUBS = new Card(4, Rank.THREE, Suit.CLUBS);
		public static readonly Card THREE_DIAMONDS = new Card(5, Rank.THREE, Suit.DIAMONDS);
		public static readonly Card THREE_HEARTS = new Card(6, Rank.THREE, Suit.HEARTS);
		public static readonly Card THREE_SPADES = new Card(7, Rank.THREE, Suit.SPADES);

		public static readonly Card FOUR_CLUBS = new Card(8, Rank.FOUR, Suit.CLUBS);
		public static readonly Card FOUR_DIAMONDS = new Card(9, Rank.FOUR, Suit.DIAMONDS);
		public static readonly Card FOUR_HEARTS = new Card(10, Rank.FOUR, Suit.HEARTS);
		public static readonly Card FOUR_SPADES = new Card(11, Rank.FOUR, Suit.SPADES);

		public static readonly Card FIVE_CLUBS = new Card(12, Rank.FIVE, Suit.CLUBS);
		public static readonly Card FIVE_DIAMONDS = new Card(13, Rank.FIVE, Suit.DIAMONDS);
		public static readonly Card FIVE_HEARTS = new Card(14, Rank.FIVE, Suit.HEARTS);
		public static readonly Card FIVE_SPADES = new Card(15, Rank.FIVE, Suit.SPADES);

		public static readonly Card SIX_CLUBS = new Card(16, Rank.SIX, Suit.CLUBS);
		public static readonly Card SIX_DIAMONDS = new Card(17, Rank.SIX, Suit.DIAMONDS);
		public static readonly Card SIX_HEARTS = new Card(18, Rank.SIX, Suit.HEARTS);
		public static readonly Card SIX_SPADES = new Card(19, Rank.SIX, Suit.SPADES);

		public static readonly Card SEVEN_CLUBS = new Card(20, Rank.SEVEN, Suit.CLUBS);
		public static readonly Card SEVEN_DIAMONDS = new Card(21, Rank.SEVEN, Suit.DIAMONDS);
		public static readonly Card SEVEN_HEARTS = new Card(22, Rank.SEVEN, Suit.HEARTS);
		public static readonly Card SEVEN_SPADES = new Card(23, Rank.SEVEN, Suit.SPADES);

		public static readonly Card EIGHT_CLUBS = new Card(24, Rank.EIGHT, Suit.CLUBS);
		public static readonly Card EIGHT_DIAMONDS = new Card(25, Rank.EIGHT, Suit.DIAMONDS);
		public static readonly Card EIGHT_HEARTS = new Card(26, Rank.EIGHT, Suit.HEARTS);
		public static readonly Card EIGHT_SPADES = new Card(27, Rank.EIGHT, Suit.SPADES);

		public static readonly Card NINE_CLUBS = new Card(28, Rank.NINE, Suit.CLUBS);
		public static readonly Card NINE_DIAMONDS = new Card(29, Rank.NINE, Suit.DIAMONDS);
		public static readonly Card NINE_HEARTS = new Card(30, Rank.NINE, Suit.HEARTS);
		public static readonly Card NINE_SPADES = new Card(31, Rank.NINE, Suit.SPADES);

		public static readonly Card TEN_CLUBS = new Card(32, Rank.TEN, Suit.CLUBS);
		public static readonly Card TEN_DIAMONDS = new Card(33, Rank.TEN, Suit.DIAMONDS);
		public static readonly Card TEN_HEARTS = new Card(34, Rank.TEN, Suit.HEARTS);
		public static readonly Card TEN_SPADES = new Card(35, Rank.TEN, Suit.SPADES);

		public static readonly Card JACK_CLUBS = new Card(36, Rank.JACK, Suit.CLUBS);
		public static readonly Card JACK_DIAMONDS = new Card(37, Rank.JACK, Suit.DIAMONDS);
		public static readonly Card JACK_HEARTS = new Card(38, Rank.JACK, Suit.HEARTS);
		public static readonly Card JACK_SPADES = new Card(39, Rank.JACK, Suit.SPADES);

		public static readonly Card QUEEN_CLUBS = new Card(40, Rank.QUEEN, Suit.CLUBS);
		public static readonly Card QUEEN_DIAMONDS = new Card(41, Rank.QUEEN, Suit.DIAMONDS);
		public static readonly Card QUEEN_HEARTS = new Card(42, Rank.QUEEN, Suit.HEARTS);
		public static readonly Card QUEEN_SPADES = new Card(43, Rank.QUEEN, Suit.SPADES);

		public static readonly Card KING_CLUBS = new Card(44, Rank.KING, Suit.CLUBS);
		public static readonly Card KING_DIAMONDS = new Card(45, Rank.KING, Suit.DIAMONDS);
		public static readonly Card KING_HEARTS = new Card(46, Rank.KING, Suit.HEARTS);
		public static readonly Card KING_SPADES = new Card(47, Rank.KING, Suit.SPADES);

		public static readonly Card ACE_CLUBS = new Card(48, Rank.ACE, Suit.CLUBS);
		public static readonly Card ACE_DIAMONDS = new Card(49, Rank.ACE, Suit.DIAMONDS);
		public static readonly Card ACE_HEARTS = new Card(50, Rank.ACE, Suit.HEARTS);
		public static readonly Card ACE_SPADES = new Card(51, Rank.ACE, Suit.SPADES);

		private int _ordinal;
		private Rank _rank;
		private int _rankOrdinal;
		private Suit _suit;
		private int _suitOrdinal;

		public static Card FromDescription(string description)
		{
			if (description.Length != 2)
			{
				return null;
			}

			return Values.FirstOrDefault(c => string.CompareOrdinal(c.GetShortDescription(), description) == 0);
		}

		public static Card FromOrdinal(int ordinal)
		{
			return Values.FirstOrDefault(e => e.Ordinal == ordinal);
		}

		public Card(int ordinal)
		{
			FromOrdinal(ordinal);
		}

		private Card(int order, Rank rank, Suit suit)
		{
			_ordinal = order;
			_rank = rank;
			_suit = suit;

			if (_suit != null)
				_suitOrdinal = _suit.Ordinal;

			if (_rank != null)
				_rankOrdinal = _rank.Ordinal;
		}

		[DataMember]
		[ProtoMember(1)]
		public int OrdinalForSerializationOnly
		{
			get { return _ordinal; }
			set
			{
				_ordinal = value;

				var fromCard = FromOrdinal(value);
				Debug.Assert(fromCard != null);

				_rank = fromCard._rank;
				_suit = fromCard._suit;
				_rankOrdinal = fromCard._rankOrdinal;
				_suitOrdinal = fromCard._suitOrdinal;
			}
		}

		[ProtoAfterDeserialization]
		public void OnAfterDeserialization()
		{
			var fromCard = FromOrdinal(_ordinal);
			Debug.Assert(fromCard != null);

			_rank = fromCard._rank;
			_suit = fromCard._suit;
			_rankOrdinal = fromCard._rankOrdinal;
			_suitOrdinal = fromCard._suitOrdinal;
		}

		protected bool Equals(Card other)
		{
			return _ordinal == other._ordinal && _rankOrdinal == other._rankOrdinal && _suitOrdinal == other._suitOrdinal;
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hashCode = _ordinal;
				hashCode = (hashCode * 397) ^ _rankOrdinal;
				hashCode = (hashCode * 397) ^ _suitOrdinal;
				return hashCode;
			}
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
				return false;
			if (ReferenceEquals(this, obj))
				return true;
			if (obj.GetType() != this.GetType())
				return false;
			return Equals((Card)obj);
		}

		public int SuitOrdinal
		{
			get { return _suitOrdinal; }
		}

		public int RankOrdinal
		{
			get { return _rankOrdinal; }
		}

		public static IEnumerable<Card> Values
		{
			get
			{
				yield return TWO_CLUBS;
				yield return TWO_DIAMONDS;
				yield return TWO_HEARTS;
				yield return TWO_SPADES;

				yield return THREE_CLUBS;
				yield return THREE_DIAMONDS;
				yield return THREE_HEARTS;
				yield return THREE_SPADES;

				yield return FOUR_CLUBS;
				yield return FOUR_DIAMONDS;
				yield return FOUR_HEARTS;
				yield return FOUR_SPADES;

				yield return FIVE_CLUBS;
				yield return FIVE_DIAMONDS;
				yield return FIVE_HEARTS;
				yield return FIVE_SPADES;

				yield return SIX_CLUBS;
				yield return SIX_DIAMONDS;
				yield return SIX_HEARTS;
				yield return SIX_SPADES;

				yield return SEVEN_CLUBS;
				yield return SEVEN_DIAMONDS;
				yield return SEVEN_HEARTS;
				yield return SEVEN_SPADES;

				yield return EIGHT_CLUBS;
				yield return EIGHT_DIAMONDS;
				yield return EIGHT_HEARTS;
				yield return EIGHT_SPADES;

				yield return NINE_CLUBS;
				yield return NINE_DIAMONDS;
				yield return NINE_HEARTS;
				yield return NINE_SPADES;

				yield return TEN_CLUBS;
				yield return TEN_DIAMONDS;
				yield return TEN_HEARTS;
				yield return TEN_SPADES;

				yield return JACK_CLUBS;
				yield return JACK_DIAMONDS;
				yield return JACK_HEARTS;
				yield return JACK_SPADES;

				yield return QUEEN_CLUBS;
				yield return QUEEN_DIAMONDS;
				yield return QUEEN_HEARTS;
				yield return QUEEN_SPADES;

				yield return KING_CLUBS;
				yield return KING_DIAMONDS;
				yield return KING_HEARTS;
				yield return KING_SPADES;

				yield return ACE_CLUBS;
				yield return ACE_DIAMONDS;
				yield return ACE_HEARTS;
				yield return ACE_SPADES;
			}
		}

		#region IComparable<Card> Members

		public int CompareTo(Card obj)
		{
			Card v2 = obj;
			if (v2._ordinal == _ordinal)
			{
				return 0;
			}
			if (v2._ordinal > _ordinal)
			{
				return -1;
			}

			return 1;
		}

		#endregion

		public string LongDescription
		{
			get { return _rank.LongDescription + " of " + _suit.LongDescription; }
		}

		public Rank Rank
		{
			get { return _rank; }
		}

		public Suit Suit
		{
			get { return _suit; }
		}

		public int Ordinal
		{
			get { return _ordinal; }
		}

		public override String ToString()
		{
			if (_rank == null || _suit == null)
			{
				return "Back"; // We just see the back of the card ...
			}
			return _rank.ShortDescription + _suit.ShortDescription;
		}

		public String GetShortDescription()
		{
			return _rank.ShortDescription + _suit.ShortDescription;
		}

		// For game table's chat log.
		public String GetDisplayCardCharacter(bool withColorString = false)
		{
			if (_rank == null || _suit == null)
			{
				return "Back"; // We just see the back of the card ...
			}

			// strings for list control with color. 
			// 'haveColorString = true'  is Client Chat.
			// 'haveColorString = false' is Client HandHistory.
			// ex) [#Black]4♠[]  or 4♠
			//     [#AC0000]8♥[] or 8♥
			if (withColorString)
			{
				return string.Format("[#{0}]{1}[]", _suit.Color, _rank.ShortDescription + _suit.DisplayCardSymbol);
			}
			else
			{
				return _rank.ShortDescription + _suit.DisplayCardSymbol;
			}
		}

		public static Card Back
		{
			get { return new Card(-1, null, null); }
		}
	}
}