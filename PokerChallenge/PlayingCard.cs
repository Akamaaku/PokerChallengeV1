using System;
using System.Collections.Generic;
using System.Text;

namespace PokerChallenge
{
    public class PlayingCard : IComparable<PlayingCard>
    {
        public int CardNumber { get; private set; }
        public Suits CardSuit { get; private set; }
        public int CardValue { get; private set; }
        private FaceCards Face { get;  set; }

        public PlayingCard()
        {
            CardNumber = 1;
            CardSuit = Suits.S;
            CardValue = 14;
            Face = FaceCards.A;
        }

        public PlayingCard(int cardNumber, Suits cardsuit)
        {
            NewCard(cardNumber, cardsuit);
        }

        public void NewCard(int cardNumber, Suits cardSuit)
        {
            CardNumber = checkCardNumber(cardNumber);
            CardSuit = cardSuit;
        }

        private int checkCardNumber(int cardNumber)
        {
            if (cardNumber < 1 || cardNumber > 13)
                throw new ArgumentOutOfRangeException("There is no playing card with that number");

            CardValue = cardNumber;

            if (cardNumber == 1)
            {
                Face = FaceCards.A;
                CardValue = 14;
            }
            if (cardNumber == 11)
                Face = FaceCards.J;
            if (cardNumber == 12)
                Face = FaceCards.Q;
            if (cardNumber == 13)
                Face = FaceCards.K;

            return cardNumber;
        }


        public int CompareTo(PlayingCard other)
        {
            return this.CardValue.CompareTo(other.CardValue);
        }

        public override string ToString()
        {
            if(CardNumber == 1 || CardNumber > 10)
                return String.Format("{0}{1}", Face, CardSuit);

            return String.Format("{0}{1}", CardNumber, CardSuit);
        }

    }
}
