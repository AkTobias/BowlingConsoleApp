using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingConsoleApp.src.Strategies
{
    public class HardAiStrategy : IAiStrategy
    {
        public int PlayTurn() => 10; //Always strike
    }
}