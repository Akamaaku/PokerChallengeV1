using NUnit.Framework;
using PokerChallenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitPokerTests
{
    [TestFixture]
    class PokerGameTests
    {
        #region Game Mechanics
        [Test]
        public void PokerGame_Test_Constructor()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player("Mark"));
            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.GamePlayers, Is.Not.Null);
            Assert.That(testGame.GamePlayers.Count, Is.EqualTo(4));
        }

        [Test]
        public void PokerGame_Test_Cards_Dealt()
        {
            int expectedDeckSizeAfterDealing = 32;
            List<Player> players = new List<Player>();
            players.Add(new Player("Mark"));
            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.GameDeck.DeckCount, Is.EqualTo(expectedDeckSizeAfterDealing));
        }

        [Test]
        public void PokerGame_Test_GameWinner()
        {
            List<Player> players = new List<Player>();
            players.Add(new Player("Mark"));
            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.GameWinners, Is.Not.Null);
        }

        [Test]
        public void PokerGame_Test_Tie_Breaker_Same_Exact_Hand_Type_And_Value()
        {
            List<PlayingCard> testHand = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(2, Suits.C), new PlayingCard(3, Suits.C), new PlayingCard(4, Suits.C), new PlayingCard(5, Suits.C) };
            List<PlayingCard> testHandTwo = new List<PlayingCard> { new PlayingCard(1, Suits.S), new PlayingCard(2, Suits.S), new PlayingCard(3, Suits.S), new PlayingCard(4, Suits.S), new PlayingCard(5, Suits.S) };
            Player testWinner = new Player("W test");
            Player testPlayer = new Player("P test");
            List<Player> players = new List<Player>();
            players.Add(new Player("Mark"));
            players.Add(new Player("Jessie"));
            PokerGame testGame = new PokerGame(players);

            foreach (PlayingCard testCard in testHand)
            {
                testWinner.SetHand(testCard);
            }

            foreach (PlayingCard testCard in testHandTwo)
            {
                testPlayer.SetHand(testCard);
            }

            testWinner.HandName = testGame.CheckHand(testWinner);
            testWinner.HandValue = testGame.CheckHandValue(testWinner);
            testPlayer.HandName = testGame.CheckHand(testPlayer);
            testPlayer.HandValue = testGame.CheckHandValue(testPlayer);

            Assert.That(() => testGame.BreakTie(testWinner, testPlayer), Is.EqualTo(testWinner));
            Assert.That(() => testGame.GameWinners.Count(), Is.EqualTo(2));
        }

        [Test]
        public void PokerGame_Test_Tie_Breaker_Same_Hand_Type_Flush()
        {
            List<PlayingCard> testHand = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(2, Suits.C), new PlayingCard(3, Suits.C), new PlayingCard(4, Suits.C), new PlayingCard(5, Suits.C) };
            List<PlayingCard> testHandTwo = new List<PlayingCard> { new PlayingCard(6, Suits.C), new PlayingCard(2, Suits.C), new PlayingCard(3, Suits.C), new PlayingCard(4, Suits.C), new PlayingCard(5, Suits.C) };
            Player testWinner = new Player("W test");
            Player testPlayer = new Player("P test");
            List<Player> players = new List<Player>();
            players.Add(new Player("Mark"));
            players.Add(new Player("Jessie"));
            PokerGame testGame = new PokerGame(players);

            foreach (PlayingCard testCard in testHand)
            {
                testWinner.SetHand(testCard);
            }

            foreach (PlayingCard testCard in testHandTwo)
            {
                testPlayer.SetHand(testCard);
            }

            testWinner.HandName = testGame.CheckHand(testWinner);
            testWinner.HandValue = testGame.CheckHandValue(testWinner);
            testPlayer.HandName = testGame.CheckHand(testPlayer);
            testPlayer.HandValue = testGame.CheckHandValue(testPlayer);

            Assert.That(() => testGame.BreakTie(testWinner, testPlayer), Is.EqualTo(testWinner));
            Assert.That(() => testGame.GameWinners.Count(), Is.EqualTo(1));
        }

        [Test]
        public void PokerGame_Test_Tie_Breaker_Same_Hand_Type_Four_Of_A_Kind()
        {
            List<PlayingCard> testHand = new List<PlayingCard> { new PlayingCard(12, Suits.C), new PlayingCard(12, Suits.D), new PlayingCard(12, Suits.H), new PlayingCard(12, Suits.S), new PlayingCard(5, Suits.C) };
            List<PlayingCard> testHandTwo = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(1, Suits.H), new PlayingCard(1, Suits.S), new PlayingCard(5, Suits.C) };
            Player testWinner = new Player("W test");
            Player testPlayer = new Player("P test");
            List<Player> players = new List<Player>();
            players.Add(new Player("Mark"));
            players.Add(new Player("Jessie"));
            PokerGame testGame = new PokerGame(players);

            foreach (PlayingCard testCard in testHand)
            {
                testWinner.SetHand(testCard);
            }

            foreach (PlayingCard testCard in testHandTwo)
            {
                testPlayer.SetHand(testCard);
            }

            testWinner.HandName = testGame.CheckHand(testWinner);
            testWinner.HandValue = testGame.CheckHandValue(testWinner);
            testPlayer.HandName = testGame.CheckHand(testPlayer);
            testPlayer.HandValue = testGame.CheckHandValue(testPlayer);

            Assert.That(() => testGame.BreakTie(testWinner, testPlayer), Is.EqualTo(testPlayer));
            Assert.That(() => testGame.GameWinners.Count(), Is.EqualTo(1));
        }

        [Test]
        public void PokerGame_Test_Tie_Breaker_Same_Hand_Type_Full_House()
        {
            List<PlayingCard> testHand = new List<PlayingCard> { new PlayingCard(12, Suits.C), new PlayingCard(12, Suits.D), new PlayingCard(12, Suits.H), new PlayingCard(5, Suits.S), new PlayingCard(5, Suits.C) };
            List<PlayingCard> testHandTwo = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(1, Suits.H), new PlayingCard(5, Suits.S), new PlayingCard(5, Suits.C) };
            Player testWinner = new Player("W test");
            Player testPlayer = new Player("P test");
            List<Player> players = new List<Player>();
            players.Add(new Player("Mark"));
            players.Add(new Player("Jessie"));
            PokerGame testGame = new PokerGame(players);

            foreach (PlayingCard testCard in testHand)
            {
                testWinner.SetHand(testCard);
            }

            foreach (PlayingCard testCard in testHandTwo)
            {
                testPlayer.SetHand(testCard);
            }

            testWinner.HandName = testGame.CheckHand(testWinner);
            testWinner.HandValue = testGame.CheckHandValue(testWinner);
            testPlayer.HandName = testGame.CheckHand(testPlayer);
            testPlayer.HandValue = testGame.CheckHandValue(testPlayer);

            Assert.That(() => testGame.BreakTie(testWinner, testPlayer), Is.EqualTo(testPlayer));
            Assert.That(() => testGame.GameWinners.Count(), Is.EqualTo(1));
        }

        [Test]
        public void PokerGame_Test_Tie_Breaker_Same_Hand_Type_Three_Of_A_Kind()
        {
            List<PlayingCard> testHand = new List<PlayingCard> { new PlayingCard(12, Suits.C), new PlayingCard(12, Suits.D), new PlayingCard(12, Suits.H), new PlayingCard(1, Suits.S), new PlayingCard(5, Suits.C) };
            List<PlayingCard> testHandTwo = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(1, Suits.H), new PlayingCard(2, Suits.S), new PlayingCard(5, Suits.C) };
            Player testWinner = new Player("W test");
            Player testPlayer = new Player("P test");
            List<Player> players = new List<Player>();
            players.Add(new Player("Mark"));
            players.Add(new Player("Jessie"));
            PokerGame testGame = new PokerGame(players);

            foreach (PlayingCard testCard in testHand)
            {
                testWinner.SetHand(testCard);
            }

            foreach (PlayingCard testCard in testHandTwo)
            {
                testPlayer.SetHand(testCard);
            }

            testWinner.HandName = testGame.CheckHand(testWinner);
            testWinner.HandValue = testGame.CheckHandValue(testWinner);
            testPlayer.HandName = testGame.CheckHand(testPlayer);
            testPlayer.HandValue = testGame.CheckHandValue(testPlayer);

            Assert.That(() => testGame.BreakTie(testWinner, testPlayer), Is.EqualTo(testPlayer));
            Assert.That(() => testGame.GameWinners.Count(), Is.EqualTo(1));
        }

        [Test]
        public void PokerGame_Test_Tie_Breaker_Same_Hand_Type_Two_Pair()
        {
            List<PlayingCard> testHand = new List<PlayingCard> { new PlayingCard(12, Suits.C), new PlayingCard(12, Suits.D), new PlayingCard(13, Suits.H), new PlayingCard(13, Suits.S), new PlayingCard(5, Suits.C) };
            List<PlayingCard> testHandTwo = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(12, Suits.H), new PlayingCard(12, Suits.S), new PlayingCard(5, Suits.C) };
            Player testWinner = new Player("W test");
            Player testPlayer = new Player("P test");
            List<Player> players = new List<Player>();
            players.Add(new Player("Mark"));
            players.Add(new Player("Jessie"));
            PokerGame testGame = new PokerGame(players);

            foreach (PlayingCard testCard in testHand)
            {
                testWinner.SetHand(testCard);
            }

            foreach (PlayingCard testCard in testHandTwo)
            {
                testPlayer.SetHand(testCard);
            }

            testWinner.HandName = testGame.CheckHand(testWinner);
            testWinner.HandValue = testGame.CheckHandValue(testWinner);
            testPlayer.HandName = testGame.CheckHand(testPlayer);
            testPlayer.HandValue = testGame.CheckHandValue(testPlayer);

            Assert.That(() => testGame.BreakTie(testWinner, testPlayer), Is.EqualTo(testPlayer));
            Assert.That(() => testGame.GameWinners.Count(), Is.EqualTo(1));
        }

        [Test]
        public void PokerGame_Test_Tie_Breaker_Same_Hand_Type_One_Pair()
        {
            List<PlayingCard> testHand = new List<PlayingCard> { new PlayingCard(12, Suits.C), new PlayingCard(12, Suits.D), new PlayingCard(1, Suits.H), new PlayingCard(13, Suits.S), new PlayingCard(5, Suits.C) };
            List<PlayingCard> testHandTwo = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(12, Suits.H), new PlayingCard(13, Suits.S), new PlayingCard(5, Suits.C) };
            Player testWinner = new Player("W test");
            Player testPlayer = new Player("P test");
            List<Player> players = new List<Player>();
            players.Add(new Player("Mark"));
            players.Add(new Player("Jessie"));
            PokerGame testGame = new PokerGame(players);

            foreach (PlayingCard testCard in testHand)
            {
                testWinner.SetHand(testCard);
            }

            foreach (PlayingCard testCard in testHandTwo)
            {
                testPlayer.SetHand(testCard);
            }

            testWinner.HandName = testGame.CheckHand(testWinner);
            testWinner.HandValue = testGame.CheckHandValue(testWinner);
            testPlayer.HandName = testGame.CheckHand(testPlayer);
            testPlayer.HandValue = testGame.CheckHandValue(testPlayer);

            Assert.That(() => testGame.BreakTie(testWinner, testPlayer), Is.EqualTo(testPlayer));
            Assert.That(() => testGame.GameWinners.Count(), Is.EqualTo(1));
        }

        [Test]
        public void PokerGame_Test_Tie_Breaker_Same_Four_Cards_But_One()
        {
            List<PlayingCard> testHand = new List<PlayingCard> { new PlayingCard(13, Suits.C), new PlayingCard(12, Suits.D), new PlayingCard(11, Suits.H), new PlayingCard(10, Suits.S), new PlayingCard(6, Suits.C) };
            List<PlayingCard> testHandTwo = new List<PlayingCard> { new PlayingCard(12, Suits.C), new PlayingCard(13, Suits.D), new PlayingCard(10, Suits.H), new PlayingCard(11, Suits.S), new PlayingCard(5, Suits.C) };
            Player testWinner = new Player("W test");
            Player testPlayer = new Player("P test");
            List<Player> players = new List<Player>();
            players.Add(new Player("Mark"));
            players.Add(new Player("Jessie"));
            PokerGame testGame = new PokerGame(players);

            foreach (PlayingCard testCard in testHand)
            {
                testWinner.SetHand(testCard);
            }

            foreach (PlayingCard testCard in testHandTwo)
            {
                testPlayer.SetHand(testCard);
            }

            testWinner.HandName = testGame.CheckHand(testWinner);
            testWinner.HandValue = testGame.CheckHandValue(testWinner);
            testPlayer.HandName = testGame.CheckHand(testPlayer);
            testPlayer.HandValue = testGame.CheckHandValue(testPlayer);

            Assert.That(() => testGame.BreakTie(testWinner, testPlayer), Is.EqualTo(testWinner));
            Assert.That(() => testGame.GameWinners.Count(), Is.EqualTo(1));
        }
        #endregion
        #region Hand Checks
        [Test]
        public void PokerGame_Test_CheckHand_For_Flush()
        {
            Hands expectedResult = Hands.Flush;
            List<Player> players = new List<Player>();
            List<PlayingCard> handTest = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(2, Suits.C), new PlayingCard(3, Suits.C), new PlayingCard(4, Suits.C), new PlayingCard(5, Suits.C) };
            Player mark = new Player("Mark");

            for(int i = 0; i < 5; i++)
            {
                mark.SetHand(handTest[i]);
            }

            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.CheckHand(mark), Is.EqualTo(expectedResult));

        }

        [Test]
        public void PokerGame_Test_CheckHand_For_Four_Of_A_Kind()
        {
            Hands expectedResult = Hands.FourOfAKind;
            List<Player> players = new List<Player>();
            List<PlayingCard> handTest = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(1, Suits.H), new PlayingCard(1, Suits.S), new PlayingCard(5, Suits.C) };
            Player mark = new Player("Mark");

            for (int i = 0; i < 5; i++)
            {
                mark.SetHand(handTest[i]);
            }

            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.CheckHand(mark), Is.EqualTo(expectedResult));
        }

        [Test]
        public void PokerGame_Test_CheckHand_For_Full_House()
        {
            Hands expectedResult = Hands.FullHouse;
            List<Player> players = new List<Player>();
            List<PlayingCard> handTest = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(1, Suits.H), new PlayingCard(13, Suits.C), new PlayingCard(13, Suits.H) };
            Player mark = new Player("Mark");

            for (int i = 0; i < 5; i++)
            {
                mark.SetHand(handTest[i]);
            }

            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.CheckHand(mark), Is.EqualTo(expectedResult));
        }

        [Test]
        public void PokerGame_Test_CheckHand_For_Three_Of_A_Kind()
        {
            Hands expectedResult = Hands.ThreeOfAKind;
            List<Player> players = new List<Player>();
            List<PlayingCard> handTest = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(1, Suits.H), new PlayingCard(4, Suits.C), new PlayingCard(5, Suits.C) };
            Player mark = new Player("Mark");

            for (int i = 0; i < 5; i++)
            {
                mark.SetHand(handTest[i]);
            }

            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.CheckHand(mark), Is.EqualTo(expectedResult));
        }

        [Test]
        public void PokerGame_Test_CheckHand_For_Two_Pair()
        {
            Hands expectedResult = Hands.TwoPair;
            List<Player> players = new List<Player>();
            List<PlayingCard> handTest = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(4, Suits.H), new PlayingCard(4, Suits.C), new PlayingCard(5, Suits.C) };
            Player mark = new Player("Mark");

            for (int i = 0; i < 5; i++)
            {
                mark.SetHand(handTest[i]);
            }

            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.CheckHand(mark), Is.EqualTo(expectedResult));

        }

        [Test]
        public void PokerGame_Test_CheckHand_For_One_Pair()
        {
            Hands expectedResult = Hands.OnePair;
            List<Player> players = new List<Player>();
            List<PlayingCard> handTest = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(2, Suits.H), new PlayingCard(4, Suits.C), new PlayingCard(5, Suits.C) };
            Player mark = new Player("Mark");

            for (int i = 0; i < 5; i++)
            {
                mark.SetHand(handTest[i]);
            }

            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.CheckHand(mark), Is.EqualTo(expectedResult));
        }

        [Test]
        public void PokerGame_Test_CheckHandValue_For_One_Pair()
        {
            int expectedResult = 14;
            List<Player> players = new List<Player>();
            List<PlayingCard> handTest = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(2, Suits.H), new PlayingCard(4, Suits.C), new PlayingCard(5, Suits.C) };
            Player mark = new Player("Mark");

            for (int i = 0; i < 5; i++)
            {
                mark.SetHand(handTest[i]);
            }

            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.CheckHandValue(mark), Is.EqualTo(expectedResult));
        }

        [Test]
        public void PokerGame_Test_CheckHandValue_For_Two_Pair()
        {
            int expectedResult = 14;
            List<Player> players = new List<Player>();
            List<PlayingCard> handTest = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(2, Suits.H), new PlayingCard(2, Suits.C), new PlayingCard(5, Suits.C) };
            Player mark = new Player("Mark");

            for (int i = 0; i < 5; i++)
            {
                mark.SetHand(handTest[i]);
            }

            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.CheckHandValue(mark), Is.EqualTo(expectedResult));
        }

        [Test]
        public void PokerGame_Test_CheckHandValue_For_Three_Of_A_Kind()
        {
            int expectedResult = 14;
            List<Player> players = new List<Player>();
            List<PlayingCard> handTest = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(1, Suits.H), new PlayingCard(2, Suits.C), new PlayingCard(5, Suits.C) };
            Player mark = new Player("Mark");

            for (int i = 0; i < 5; i++)
            {
                mark.SetHand(handTest[i]);
            }

            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.CheckHandValue(mark), Is.EqualTo(expectedResult));
        }

        [Test]
        public void PokerGame_Test_CheckHandValue_For_Full_House()
        {
            int expectedResult = 14;
            List<Player> players = new List<Player>();
            List<PlayingCard> handTest = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(1, Suits.H), new PlayingCard(5, Suits.C), new PlayingCard(5, Suits.D) };
            Player mark = new Player("Mark");

            for (int i = 0; i < 5; i++)
            {
                mark.SetHand(handTest[i]);
            }

            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.CheckHandValue(mark), Is.EqualTo(expectedResult));
        }

        [Test]
        public void PokerGame_Test_CheckHandValue_For_Four_Of_A_Kind()
        {
            int expectedResult = 14;
            List<Player> players = new List<Player>();
            List<PlayingCard> handTest = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(1, Suits.D), new PlayingCard(1, Suits.H), new PlayingCard(1, Suits.S), new PlayingCard(5, Suits.C) };
            Player mark = new Player("Mark");

            for (int i = 0; i < 5; i++)
            {
                mark.SetHand(handTest[i]);
            }

            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.CheckHandValue(mark), Is.EqualTo(expectedResult));
        }

        [Test]
        public void PokerGame_Test_CheckHandValue_For_High_Card()
        {
            int expectedResult = 14;
            List<Player> players = new List<Player>();
            List<PlayingCard> handTest = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(3, Suits.D), new PlayingCard(2, Suits.H), new PlayingCard(4, Suits.C), new PlayingCard(5, Suits.C) };
            Player mark = new Player("Mark");

            for (int i = 0; i < 5; i++)
            {
                mark.SetHand(handTest[i]);
            }

            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.CheckHandValue(mark), Is.EqualTo(expectedResult));
        }

        [Test]
        public void PokerGame_Test_CheckHandValue_For_High_Card_2nd_attempt()
        {
            int expectedResult = 5;
            List<Player> players = new List<Player>();
            List<PlayingCard> handTest = new List<PlayingCard> { new PlayingCard(1, Suits.C), new PlayingCard(3, Suits.D), new PlayingCard(2, Suits.H), new PlayingCard(4, Suits.C), new PlayingCard(5, Suits.C) };
            Player mark = new Player("Mark");

            for (int i = 0; i < 5; i++)
            {
                mark.SetHand(handTest[i]);
            }

            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame testGame = new PokerGame(players);

            Assert.That(testGame.CheckHandValue(mark, 1), Is.EqualTo(expectedResult));
        }
        #endregion
    }
}
