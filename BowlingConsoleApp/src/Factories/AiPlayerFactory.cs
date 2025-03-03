using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingConsoleApp.src.Players;
using BowlingConsoleApp.src.Strategies;

namespace BowlingConsoleApp.src.Factories
{
    public class AiPlayerFactory : PlayerFactory
    {

        private IAiStrategy _aiStrategy;

        public AiPlayerFactory(IAiStrategy aiStrategy) => _aiStrategy = aiStrategy;
        public override Player CreatePlayer(string name) => new AiPlayer(name, _aiStrategy);
    }
}