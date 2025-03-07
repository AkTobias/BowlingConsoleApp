using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingConsoleApp.src.Players
{
    //Template method pattern
    public abstract class Player
    {
        public string Name {get; set;}
        public int Score {get; set;}

        protected Player(string name) => Name = name;

        public abstract void Play();
    }
}