using System;
using System.Collections.Generic;
using System.Text;

namespace PokerChallenge
{
    public class CardDeck
    {
        private  const int DECK_SIZE = 52;
        private  Random rng = new Random();
        public  List<PlayingCard> Cards = new List<PlayingCard>();

        public CardDeck()
        {
            BuildDeck();
        }

        public int DeckCount { get; private set; }

        public void BuildDeck()
        {
            if (Cards.Count > 1)
            {
                Cards.Clear();
            }

            for(int i = 0; i < DECK_SIZE; i++)
            {
                Suits suits = (Suits)(Math.Floor((decimal)i / 13));
                int value = i % 13 + 1;
                Cards.Add(new PlayingCard(value, suits));
            }

            DeckCount = Cards.Count;

            CheckForDuplicates();
        }

        public void Shuffle()
        {
            int count = DeckCount;

            while(count > 1)
            {
                count--;
                int randomNumber = rng.Next(count + 1);
                PlayingCard currentNumber = Cards[randomNumber];
                Cards[randomNumber] = Cards[count];
                Cards[count] = currentNumber;
            }
        }

        public void CheckForDuplicates()
        {
            var set = new HashSet<PlayingCard>();
            foreach (var c in Cards)
                if (!set.Add(c))
                {
                    throw new Exception("The deck has duplicate cards");
                };
        }

        public PlayingCard Deal()
        {
            PlayingCard dealtCard = Cards[0];
            Cards.RemoveAt(0);
            DeckCount--;

            return dealtCard;
        }

        public void PrintDeck()
        {
            foreach(PlayingCard card in Cards)
            {
                Console.WriteLine(card.ToString());
            }
            Console.WriteLine(DeckCount);

        }
    }
}
