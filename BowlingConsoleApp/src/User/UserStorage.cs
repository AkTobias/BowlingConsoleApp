using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BowlingConsoleApp.src.User
{

     public class User
        {
            public int Id {get; set;}
            public string Name {get; set;}
        }

    public class UserStorage
    {

        private const string FilePath = "users.json";

        public List<User> LoadUsers()
        {
            if(!File.Exists(FilePath))
            {
                return new List<User>();
            }

            string json = File.ReadAllText(FilePath);
            return JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();

        }

        public void SaveUsers(List<User> users)
        {
            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions {WriteIndented =true});//maybe chage 
            File.WriteAllText(FilePath, json);
        }

        public List<User> GetAllUsers()
        {
            return LoadUsers();
        }

        public int GiveUsersId()
        {
            List<User> users = LoadUsers();
            return users.Count == 0 ? 1 : users.Max(u => u.Id) + 1;
        }

        public bool DeleteUser(string userName)
        {
            List<User> users = LoadUsers();

            var deleteUser = users.FirstOrDefault(u => u.Name.Equals(userName, StringComparison.OrdinalIgnoreCase));

            if(deleteUser != null)
            {
                users.Remove(deleteUser);

                SaveUsers(users);

                return true;

            }
            return false;
        }
    }
}