using NUnit.Framework;
using PokerChallenge;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitPokerTests
{
    [TestFixture]
    class PlayerTests
    {
        [Test]
        public void Player_Test_Constructor()
        {
            Player testPlayer = new Player("Mark");

            Assert.That(testPlayer.Name, Is.EqualTo("Mark"));
            Assert.That(testPlayer.HandValue, Is.EqualTo(0));
            Assert.That(testPlayer.PlayerHand, Is.Not.Null);
            Assert.That(testPlayer.HandName, Is.EqualTo(Hands.HighCard));
        }

        [Test]
        public void Player_Test_No_Hand()
        {
            Player testPlayer = new Player("Mark");

            Assert.That(testPlayer.Name, Is.EqualTo("Mark"));
            Assert.That(() => testPlayer.GetHand(), Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void Player_Test_Full_Hand()
        {
            Player testPlayer = new Player("Mark");
            CardDeck testDeck = new CardDeck();
            
            for (int i = 0; i < 5; i++)
            {
                testPlayer.SetHand(testDeck.Deal());
            }

            Assert.That(testPlayer.GetHand, Is.Not.Null);
            List<PlayingCard> testHand = testPlayer.GetHand();
            Assert.That(testHand.Count, Is.EqualTo(5));
        }

        [Test]
        public void Player_Test_Deal_More_Than_Five()
        {
            Player testPlayer = new Player("Mark");
            CardDeck testDeck = new CardDeck();

            for (int i = 0; i < 5; i++)
            {
                testPlayer.SetHand(testDeck.Deal());
            }

            Assert.That(() => testPlayer.SetHand(testDeck.Deal()), Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void Player_Test_Deal_Less_Than_Five()
        {
            Player testPlayer = new Player("Mark");
            CardDeck testDeck = new CardDeck();

            for (int i = 0; i < 4; i++)
            {
                testPlayer.SetHand(testDeck.Deal());
            }

            Assert.That(() => testPlayer.GetHand(), Throws.Exception.TypeOf<ApplicationException>());
        }

        [Test]
        public void Player_Test_Hand_Sum()
        {
            Player testPlayer = new Player("Mark");
            PlayingCard firstCard = new PlayingCard(1, Suits.S);
            PlayingCard secondCard = new PlayingCard(3, Suits.S);
            PlayingCard thirdCard = new PlayingCard(4, Suits.S);
            PlayingCard fourtCard = new PlayingCard(5, Suits.S);
            PlayingCard fifthCard = new PlayingCard(6, Suits.S);
            int expectedValue = 32;

            testPlayer.SetHand(firstCard);
            testPlayer.SetHand(secondCard);
            testPlayer.SetHand(thirdCard);
            testPlayer.SetHand(fourtCard);
            testPlayer.SetHand(fifthCard);

            Assert.That(testPlayer.HandSum, Is.EqualTo(expectedValue));
        }
    }
}
