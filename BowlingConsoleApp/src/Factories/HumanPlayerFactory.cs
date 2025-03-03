using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BowlingConsoleApp.src.Players;

namespace BowlingConsoleApp.src.Factories
{
    public class HumanPlayerFactory : PlayerFactory
    {
        public override Player CreatePlayer(string name) => new HumanPlayer(name);
        
    }
}