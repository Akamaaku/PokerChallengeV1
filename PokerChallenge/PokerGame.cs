using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerChallenge
{
    public class PokerGame
    {
        public List<Player> GamePlayers { get; private set; }
        public List<Player> GameWinners { get; private set; }
        public CardDeck GameDeck { get; private set; }

        public PokerGame(List<Player> gamePlayers)
        {
            GamePlayers = gamePlayers;
            GameWinners = new List<Player>();
            DealHands();
        }

        public void DealHands()
        {
            this.GameDeck = new CardDeck();
            this.GameDeck.Shuffle();

            for(int i = 0; i < GamePlayers.Count; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    GamePlayers[i].SetHand(GameDeck.Deal());
                }
            }

            SetGameWinners();
        }

        private void SetGameWinners()
        {
            foreach(Player player in GamePlayers)
            {
                player.HandName = CheckHand(player);
                player.HandValue = CheckHandValue(player);
            }

            GameWinners.Add(GamePlayers[0]);

            for(int i = 1; i < GamePlayers.Count(); i++)
            {
                if ((int)GameWinners[0].HandName < (int)GamePlayers[i].HandName)
                    GameWinners[0] = GamePlayers[i];
                else if ((int)GameWinners[0].HandName == (int)GamePlayers[i].HandName)
                    GameWinners[0] = BreakTie(GameWinners[0], GamePlayers[i]);
            }

        }

        public Player BreakTie(Player gameWinner, Player player, int attempts = 1)
        {
            Player winner = gameWinner;
            int winnerHandSum = gameWinner.HandSum;
            int playerHandSum = player.HandSum;

            if (attempts > 4)
                throw new ApplicationException("Tie breaks can only be done with a hand of 5.");

            if (gameWinner.HandValue < player.HandValue)
                winner = player;

            if (winnerHandSum == playerHandSum)
            {
                GameWinners.Add(player);
                return winner;
            }

            if (gameWinner.HandValue == player.HandValue && attempts < 4)
            {
                gameWinner.HandValue = CheckHandValue(gameWinner, attempts);
                player.HandValue = CheckHandValue(player, attempts);
                BreakTie(gameWinner, player, attempts + 1);
            }

            return winner;
        }

        public Hands CheckHand(Player currentPlayer)
        {
            Hands handType = Hands.HighCard;
            currentPlayer.SortHand();
            List<PlayingCard> currentHand = currentPlayer.SortedHand;
            PlayingCard firstCard = currentHand[0];
            var groups = currentHand.GroupBy(c => c.CardValue).OrderByDescending(grp => grp.Count());
            var mostMatches = groups.First();

            if (currentHand.Where(c => c.CardSuit == firstCard.CardSuit).Count() == 5)
                handType = Hands.Flush;

            if (groups.Count() == 2 && mostMatches.Count() == 4)
                handType = Hands.FourOfAKind;

            if (groups.Count() == 2 && mostMatches.Count() == 3)
                handType = Hands.FullHouse;

            if (groups.Count() == 3 && mostMatches.Count() == 3)
                handType = Hands.ThreeOfAKind;

            if (groups.Count() == 3 && mostMatches.Count() == 2)
                handType = Hands.TwoPair;

            if (groups.Count() == 4 && mostMatches.Count() == 2)
                handType = Hands.OnePair;

            return handType;
        }

        public int CheckHandValue(Player currentPlayer, int attempt = 0)
        {
            currentPlayer.SortHand();
            List<PlayingCard> currentHand = currentPlayer.SortedHand;
            PlayingCard firstCard = currentHand[attempt];
            var groups = currentHand.GroupBy(c => c.CardValue).OrderByDescending(grp => grp.Count());
            var mostMatches = groups.First();
            int value = currentHand[attempt].CardValue;

            if (mostMatches.Count() >= 2 && attempt == 0)
            {
                value = mostMatches.Key;
            }

            return value;
        }

        public override string ToString()
        {
            string gameResults = "\n";

            for(int i = 0; i < GamePlayers.Count(); i++)
            {
                gameResults += String.Format("{0}\n\n", GamePlayers[i].ToString());
            }
            if(GameWinners.Count() > 1)
            {
                for (int i = 1; i < GamePlayers.Count(); i++)
                {
                    gameResults += String.Format("{0},", GameWinners[i]);
                }
                gameResults += String.Format("{0} split the pot!", GameWinners[0].Name);
            }

            gameResults += String.Format("{0} wins and takes the pot!", GameWinners[0].Name);

            return gameResults;
        }
    }
}
