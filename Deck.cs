using System;
using System.Collections.Generic;

namespace GameOfWar
{
    public class Deck
    {
        public static string[] RankNames =
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10",
            "Jack", "Queen", "King", "Ace"
        };

        public static string[] Suits =
        {
            "Hearts", "Diamonds", "Clubs", "Spades"
        };

        private List<Card> _cards;

        public int Count
        {
            get { return _cards.Count; }
        }

        public Deck(List<Card>? cards = null, bool isEmptyDeck = false)
        {
            if (cards != null && cards.Count > 0)
            {
                _cards = cards;
                return;
            }

            _cards = new List<Card>();

            if (!isEmptyDeck)
            {
                InitializeDeck();
            }
        }

        private void InitializeDeck()
        {
            foreach (string suit in Suits)
            {
                for (int rank = 0; rank < RankNames.Length; rank++)
                {
                    _cards.Add(new Card(suit, rank));
                }
            }
        }

        public void Shuffle()
        {
            Random random = new Random();

            for (int i = _cards.Count - 1; i > 0; i--)
            {
                int randomIndex = random.Next(i + 1);

                Card temp = _cards[i];
                _cards[i] = _cards[randomIndex];
                _cards[randomIndex] = temp;
            }
        }

        public Card CardAtIndex(int index)
        {
            if (index < 0 || index >= _cards.Count)
            {
                throw new IndexOutOfRangeException();
            }

            return _cards[index];
        }

        public Card PullCardAtIndex(int index)
        {
            Card card = CardAtIndex(index);
            _cards.RemoveAt(index);

            return card;
        }

        public List<Card> PullAllCards()
        {
            List<Card> cards = new List<Card>(_cards);
            _cards.Clear();

            return cards;
        }

        public void PushCard(Card card)
        {
            _cards.Add(card);
        }

        public void PushCards(List<Card> cards)
        {
            _cards.AddRange(cards);
        }

        public List<Card> Deal(int numberOfCards)
        {
            if (numberOfCards > _cards.Count)
            {
                numberOfCards = _cards.Count;
            }

            List<Card> dealtCards = new List<Card>();

            for (int i = 0; i < numberOfCards; i++)
            {
                dealtCards.Add(PullCardAtIndex(0));
            }

            return dealtCards;
        }
    }
}
