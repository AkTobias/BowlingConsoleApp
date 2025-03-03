using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingConsoleApp.src.Strategies
{
    public interface IAiStrategy
    {
        int PlayTurn();
    }
}