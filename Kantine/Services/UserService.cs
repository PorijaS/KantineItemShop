using System;
using Kantine.Model;

namespace Kantine.Services
{
    public class UserService
    {
        static UserService _instance;

        public static UserService instance
        {
            get
            {
                _instance ??= new UserService();

                return _instance;
            }
        }

        public readonly User User1 = new User
        {
            Email = "porijashiraz@live.dk"
        };

        public List<User> GetUsers()
        {
            return new List<User>
            {
                User1
            };
        }
    }


}

