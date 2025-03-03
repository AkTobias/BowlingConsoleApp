using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Tasks;
using BowlingConsoleApp.src.Logger;
using BowlingConsoleApp.src.Players;

namespace BowlingConsoleApp.src.Game
{
    public class Match
    {
        SingletonLogger logger = SingletonLogger.Instance;
        private List<Player> _players;

        private int _rounds;
        

        public Match(List<Player> players , int rounds)
        {
            _players = players ?? new List<Player>();
            _rounds = rounds;
        }

        public void Start()
        {
            System.Console.WriteLine("---Match starting---");

            for(int round = 1; round <= _rounds; round++)
            {
                System.Console.WriteLine($"--Round {round} ---");
                Console.WriteLine("Press enter to Bowl!");
                Console.ReadLine();
                
                foreach (var player in _players)
                {
                    player.Play();
                }
            }
            
            Player winner = _players.OrderByDescending(p => p.Score).First();
            Player looser = _players.OrderByDescending(p => p.Score).Last();

            System.Console.WriteLine($"---Score---");
            foreach (var player in _players)
            {
                System.Console.WriteLine($"{player.Name}: {player.Score} points");
            }
            
            int scoreDiff = winner.Score - looser.Score;
            System.Console.WriteLine($"Winner is {winner} with {winner.Score}");
            System.Console.WriteLine($"Looser is {looser} with {looser.Score}");
            System.Console.WriteLine($"Score difference: {scoreDiff} points");

            logger.Log($"Match result: {winner.Name} vs {looser.Name}");
            logger.Log($"Scores: {winner.Name}: {winner.Score}, {looser.Name}: {looser.Score}");
            logger.Log($"{winner.Name} wins with a score difference of {scoreDiff} points!");
      
            
        }
    }
}