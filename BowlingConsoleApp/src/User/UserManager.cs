using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingConsoleApp.src.User
{
    public class UserManager
    {
        private readonly UserStorage _userStorage;

        public UserManager()
        {
            _userStorage = new UserStorage();
        }

        public void RegisterUser()
        {
            System.Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            List<User> users = _userStorage.LoadUsers();

            if(users.Any(u => u.Name == name))
            {
                System.Console.WriteLine("User already registerd");
                return;
            }


            int newUserId = _userStorage.GiveUsersId();
            User newUser = new User {Id = newUserId, Name = name};
            users.Add(newUser);
            _userStorage.SaveUsers(users);
            System.Console.WriteLine($"User {name} has been registed successfully");
        }

        public bool UserExists(string name)
        {
            return _userStorage.GetAllUsers().Any( u => u.Name == name);
        }

        public void DisplayAllUsers()
        {
            List<User> users = _userStorage.GetAllUsers();

            System.Console.WriteLine("\n------Registerd Users------");
            if(users.Count == 0)
            {
                System.Console.WriteLine("No users registered");
            }
            else
            {
                foreach (User user in users)
                {
                    System.Console.WriteLine($"Name - {user.Name}");
                }

            }
        }



        
        
    }
}