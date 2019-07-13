using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using PokerChallenge;

namespace NUnitPokerTests
{
    [TestFixture]
    class DeckTests
    {
        [Test]
        public void Deck_Test_Constructor()
        {
            CardDeck testDeck = new CardDeck();

            Assert.That(testDeck.DeckCount, Is.EqualTo(52));
        }

        [Test]
        public void Deck_Test_Size()
        {
            CardDeck testDeck = new CardDeck();

            Assert.That(testDeck.DeckCount, Is.EqualTo(52));
        }

        [Test]
        public void Deck_Test_Deal()
        {
            CardDeck testDeck = new CardDeck();
            PlayingCard expectedCard = testDeck.Cards[0];
            PlayingCard testCard = testDeck.Deal();

            Assert.That(testDeck.DeckCount, Is.EqualTo(51));
            Assert.That(expectedCard, Is.EqualTo(testCard));
        }

        [Test]
        public void Deck_Test_Deal_Five()
        {
            CardDeck testDeck = new CardDeck();

            for(int i = 0; i < 5; i++)
            {
                PlayingCard expectedCard = testDeck.Cards[0];
                PlayingCard testCard = testDeck.Deal();
                Assert.That(testDeck.DeckCount, Is.EqualTo(51 - i));
                Assert.That(expectedCard, Is.EqualTo(testCard));
            }
        }
    }
}
