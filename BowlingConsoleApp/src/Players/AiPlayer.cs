using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingConsoleApp.src.Strategies;

namespace BowlingConsoleApp.src.Players
{
    public class AiPlayer : Player
    {

        private IAiStrategy _aiStrategy;

        public AiPlayer(string name, IAiStrategy aiStrategy) : base(name)
        {
            _aiStrategy = aiStrategy;
        }

        public override void Play()
        {
            int points = _aiStrategy.PlayTurn();
            Score += points;
            System.Console.WriteLine($"{Name} (AI) slog {points} poäng");
        }
    }
}