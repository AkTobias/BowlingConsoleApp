using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingConsoleApp.src.Players;

namespace BowlingConsoleApp.src.Factories
{
    public abstract class PlayerFactory
    {
        public abstract Player CreatePlayer(string name);
    }
}