using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingConsoleApp.src.Strategies
{
    public class EasyAiStrategy : IAiStrategy
    {
        private Random _random = new Random();

        public int PlayTurn() => _random.Next(0, 11);
    }
}