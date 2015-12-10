using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Rhyme.Holdem.Elements.Cards
{
	/// <summary>
	/// 클라 사이드에서 사용하는 Deck 클래스
	/// 서버 사이드에선 Server.Lib.Common.Elements.Cards.Deck 클래스를 사용하세요
	/// </summary>
	public class Deck
	{
		public const int NumCards = 52;
		private static readonly Card[] _protoDeck;
		private readonly Card[] _cards;
		private readonly object _padlock = new object();
		private Random _r;
		private Random _r2;
		private int _position;

		static Deck()
		{
			// Initialize prototype deck
			_protoDeck = Card.Values.ToArray();
		}

		private Deck(IEnumerable<Card> cards)
		{
			_cards = cards.ToArray();
			_position = 0;

			InitRandom();
		}

		private Deck()
		{
			_cards = _protoDeck.Clone() as Card[];
			_position = 0;

			InitRandom();
		}

		public Deck(Deck copy)
		{
			_cards = copy._cards.Clone() as Card[];
			_position = copy._position;

			InitRandom();
		}

		Guid NewGuid()
		{
			Guid guid;
			do
			{
				guid = Guid.NewGuid();
			} while (guid == Guid.Empty);

			return guid;
		}

		void InitRandom()
		{
			_r = new Random(NewGuid().GetHashCode() ^ NewGuid().GetHashCode());
			_r2 = new Random(_r.Next() ^ NewGuid().GetHashCode());
		}

		public void Shuffle()
		{
			for (var i = 0; i < NumCards; i++)
			{
				var j = i + RandInt(NumCards - i);
				var tempCard = _cards[j];
				_cards[j] = _cards[i];
				_cards[i] = tempCard;
			}

			_position = 0;
		}

		public static Deck CreateTruelyRandomDeck()
		{
			var deck = new Deck();
			deck.Shuffle();

			return deck;
		}

		public static Deck CreateWeaklyRandomDeck()
		{
			var deck = new Deck();
			deck.Shuffle();

			return deck;
		}

		public IList<Card> Deal(int number)
		{
			lock (_padlock)
			{
				var hand = new LinkedList<Card>();

				for (var i = 0; i < number; i++)
					hand.AddLast(ExtractRandomCard());

				return hand.ToList();
			}
		}

		public Card ExtractRandomCard()
		{
			lock (_padlock)
			{
				var pos = _position + RandInt2(NumCards - _position);
				var c = _cards[pos];
				_cards[pos] = _cards[_position];
				_cards[_position] = c;
				_position++;
				return c;
			}
		}

		public Card PickRandomCard()
		{
			return _cards[_position + RandInt(NumCards - _position)];
		}

		public Card DrawCard()
		{
			return ExtractRandomCard();
		}

		public override string ToString()
		{
			var s = new StringBuilder();

			s.Append("* ");

			for (var i = 0; i < _position; i++)
				s.Append(_cards[i].GetShortDescription() + " ");

			s.Append("\n* ");

			for (int i = _position; i < NumCards; i++)
				s.Append(_cards[i].GetShortDescription() + " ");

			return s.ToString();
		}

		public void RemoveCards(ICollection<Card> toRemove)
		{
			foreach (var card in toRemove)
				ExtractCard(card);
		}

		public void RemoveCards(params Card[] toRemove)
		{
			foreach (var card in toRemove)
				ExtractCard(card);
		}

		public int FindCard(Card c)
		{
			int i = _position;

			for (var n = c.Ordinal; i < NumCards && n != _cards[i].Ordinal; i++)
				;

			return i >= NumCards ? -1 : i;
		}

		public void ExtractCard(Card c)
		{
			var i = FindCard(c);

			if (i != -1)
			{
				var t = _cards[i];
				_cards[i] = _cards[_position];
				_cards[_position] = t;
				_position++;
			}
			else
				Debug.Assert(false, "*** ERROR: could not find card " + c);
		}

		private int RandInt(int range)
		{
			lock (_r)
			{
				return _r.Next() % range;
			}
		}

		private int RandInt2(int range)
		{
			lock (_r2)
			{
				return _r2.Next() % range;
			}
		}

		public void Reset()
		{
			_position = 0;
		}

		public Card Deal()
		{
			return _position >= 52 ? null : _cards[_position++];
		}

		public int GetTopCardIndex()
		{
			return _position;
		}

		public int CardsLeft()
		{
			return NumCards - _position;
		}

		public Card GetCard(int i)
		{
			return _cards[i];
		}
	}
}