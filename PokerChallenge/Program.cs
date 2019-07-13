using System;
using System.Collections.Generic;

namespace PokerChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mark's Poker Challenge!\n");

            Console.Write("Please enter Player Name: ");
            string consolePlayer = Console.ReadLine();
            string confirmation = "y";

            Player newPlayer = new Player(consolePlayer);
            List<Player> players = new List<Player>();
            players.Add(newPlayer);
            players.Add(new Player("Mark"));
            players.Add(new Player("Jessie"));
            players.Add(new Player("Allison"));
            players.Add(new Player("Mahesh"));

            PokerGame newGame = new PokerGame(players);

            Console.WriteLine(newGame.ToString());
            


            Console.ReadKey();
        }
    }
}
