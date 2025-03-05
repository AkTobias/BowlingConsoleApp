using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BowlingConsoleApp.src.Players;
using BowlingConsoleApp.src.User;

namespace BowlingConsoleApp.src.Factories
{
    public class HumanPlayerFactory : PlayerFactory
    {

        private readonly UserManager _userManager;

        public HumanPlayerFactory()
        {
            _userManager = new UserManager();
        }


        //Added so it donset create a human object if the user donset exist.
        public override Player CreatePlayer(string name)
        {
            if(!_userManager.UserExists(name))
            {
                System.Console.WriteLine($"User '{name}' is not registerd. Please register or enter valid user name before playing");
                return null; 
            }
            return new HumanPlayer(name);
        }
        
    }
}