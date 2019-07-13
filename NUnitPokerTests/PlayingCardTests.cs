using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PokerChallenge;

namespace NUnitPokerTests
{
    [TestFixture]
    public class PlayingCardTests
    {
        [Test]
        public void PlayingCard_Constructor_Test()
        {
            PlayingCard playingcard = new PlayingCard();

            Assert.That(playingcard.CardNumber, Is.Not.Null);
            Assert.That(playingcard.CardSuit, Is.Not.Null);
            Assert.That(playingcard.CardValue, Is.Not.Null);
            Assert.That(playingcard.CardSuit, Is.EqualTo(Suits.S));
        }

        [Test]
        public void PlayingCard_Constructor_Test_NewCard()
        {
            int cardNumber = 10;
            int expectedCardValue = 10;

            PlayingCard playingcard = new PlayingCard();


            playingcard.NewCard(cardNumber, Suits.H);
            Assert.That(playingcard.CardNumber, Is.EqualTo(cardNumber));
            Assert.That(playingcard.CardSuit, Is.EqualTo(Suits.H));
            Assert.That(playingcard.CardValue, Is.EqualTo(expectedCardValue));
        }


        [Test]
        public void PlayingCard_Test_OutOfRangeException()
        {
            int cardNumber = 0;
            int cardNumberTwo = 14;
            PlayingCard playingcardOne = new PlayingCard();
            PlayingCard playingcardTwo = new PlayingCard();

            Assert.That(() => playingcardOne.NewCard(cardNumber, Suits.D), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
            Assert.That(() => playingcardTwo.NewCard(cardNumberTwo, Suits.H), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());

        }

        [Test]
        public void PlayingCard_Test_Face_ToString()
        {
            string expectedAce = "AS";
            string expectedJack = "JC";
            string expectedQueen = "QH";
            string expectedKing = "KD";

            PlayingCard playingCard = new PlayingCard();
            playingCard.NewCard(1, Suits.S);
            Assert.That(playingCard.ToString(), Is.EqualTo(expectedAce));
            playingCard.NewCard(11, Suits.C);
            Assert.That(playingCard.ToString(), Is.EqualTo(expectedJack));
            playingCard.NewCard(12, Suits.H);
            Assert.That(playingCard.ToString(), Is.EqualTo(expectedQueen));
            playingCard.NewCard(13, Suits.D);
            Assert.That(playingCard.ToString(), Is.EqualTo(expectedKing));
        }

        [Test]
        public void PlayingCard_Test_Compare_Value_Equal()
        {
            PlayingCard cardOne = new PlayingCard(1, Suits.S);
            PlayingCard cardTwo = new PlayingCard(1, Suits.D);

            Assert.That(cardOne.CompareTo(cardTwo), Is.EqualTo(0));
        }

        [Test]
        public void PlayingCard_Test_Compare_Value_Not_Equal()
        {
            PlayingCard cardOne = new PlayingCard(1, Suits.S);
            PlayingCard cardTwo = new PlayingCard(2, Suits.D);

            Assert.That(cardOne.CompareTo(cardTwo), Is.EqualTo(1));
        }

    }
}
