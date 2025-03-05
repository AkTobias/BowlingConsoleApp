using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingConsoleApp.src.Strategies
{

    //Strategy Pattern
    public interface IAiStrategy
    {
        int PlayTurn();
    }
}