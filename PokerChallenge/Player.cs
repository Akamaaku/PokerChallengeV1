using System;
using System.Collections.Generic;
using System.Text;

namespace PokerChallenge
{
    public class Player
    {
        public string Name { get; private set; }
        public Hands HandName { get; set; }
        public int HandSum { get; private set; }
        public int HandValue { get; set; }
        public List<PlayingCard> SortedHand { get; private set; }
        public List<PlayingCard> PlayerHand { get; private set; }

        public Player(string name)
        {
            Name = name;
            HandValue = 0;
            PlayerHand = new List<PlayingCard>();
            HandName = Hands.HighCard;
        }

        public void SetHand(PlayingCard card)
        {
            if (PlayerHand.Count == 5)
                throw new ApplicationException("Hand is full. Cannot receive more cards.");

            if (PlayerHand == null || PlayerHand.Count < 5)
            {
                PlayerHand.Add(card);
                HandSum += card.CardValue;
            }
        }

        public List<PlayingCard> GetHand()
        {
            if (PlayerHand == null || PlayerHand.Count < 5)
                throw new ApplicationException("Improper Handsize. Player must have 5 cards to play Poker.");

            return PlayerHand;
        }

        public void SortHand()
        {
            if (PlayerHand == null || PlayerHand.Count < 5)
                throw new ApplicationException("Improper Handsize. Player must have 5 cards to play Poker.");

            SortedHand = PlayerHand;
            SortedHand.Sort();
            SortedHand.Reverse();
        }

        public override string ToString()
        {
            if(PlayerHand.Count == 5)
                return String.Format("{0}\n{1}, {2}, {3}, {4}, {5}\n", Name, PlayerHand[0], PlayerHand[1], PlayerHand[2], PlayerHand[3], PlayerHand[4]);
            

            return Name;
        }
    }
}
