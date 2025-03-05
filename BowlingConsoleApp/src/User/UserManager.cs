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
            string name;
             List<User> users = _userStorage.LoadUsers();
             System.Console.Write("Enter your name (atlest 3 characters, no space): ");
            do
            {
                
                name = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Contains(" "))
                {
                    System.Console.WriteLine("Invalid username. Correct format => 3 letters and no spaces.");
                    continue;
                }

                if (users.Any(u => u.Name == name))
                {
                    System.Console.WriteLine("User already registerd. Choose a diffrent name");
                    continue;
                }
                break;

            } while (true);


            int newUserId = _userStorage.GiveUsersId();

            User newUser = new User { Id = newUserId, Name = name };
            users.Add(newUser);
            _userStorage.SaveUsers(users);
            System.Console.WriteLine($"User {name} has been registed successfully");
        }

        public bool UserExists(string name)
        {
            return _userStorage.GetAllUsers().Any(u => u.Name == name);
        }

        public void DisplayAllUsers()
        {
            List<User> users = _userStorage.GetAllUsers();

            System.Console.WriteLine("\n------Registerd Users------");
            if (users.Count == 0)
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

        public void DeleteUser()
        {
            List<User> users = _userStorage.GetAllUsers();

            if(users.Count == 0)
            {
                System.Console.WriteLine("No users in database");
                return;
            }
            
            System.Console.WriteLine("Enter the name of the user that you wannt to delete");
            string userName = Console.ReadLine()?.Trim();

            if(string.IsNullOrEmpty(userName))
            {
                System.Console.WriteLine("Invalid input");
                return;
            }

            User deleteUser = users.FirstOrDefault(u => u.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));

            if(deleteUser != null)
            {
                _userStorage.DeleteUser(userName);
                System.Console.WriteLine($"User deleted successfully");
                
            }

            else{
                System.Console.WriteLine("user not found");
            }
        }





    }
}