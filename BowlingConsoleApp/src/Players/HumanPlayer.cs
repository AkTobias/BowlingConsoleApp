using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BowlingConsoleApp.src.Players
{
    public class HumanPlayer : Player
    {

        private Random _random = new Random();
        public HumanPlayer(string name) : base(name){}
        public override void Play()
        {
            int points = _random.Next(0,11);

            Score += points;
            System.Console.WriteLine($"{Name} din tur att köra: {points} poäng");
            
        }
    }
}