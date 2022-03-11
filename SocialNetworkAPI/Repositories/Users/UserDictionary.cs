using SocialNetworkAPI.Dtos;
using SocialNetworkAPI.Helpers.Exceptions;
using SocialNetworkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Repositories.Users
{
    public class UserDictionary : IUserRepository
    {
        public Dictionary<int, User> _users = new Dictionary<int, User>();

        public UserDictionary()
        {
            var testuser1 = new User
            {
                UserId = 1,
                Username = "testboi",
                Email = "testboi@hotmail.com"
            };

            var testuser2 = new User
            {
                UserId = 2,
                Username ="bot",
                Email = "bot@bot.com"
            };
            _users.Add(1, testuser1);
            _users.Add(2, testuser2);
        }
        
        public List<User> GetUsers()
        {
            var users = new List<User>();
            foreach(var user in _users)
            {
                users.Add(user.Value);
            }
            return users;
        }

        public User GetUser(int id)
        {
            try
            {
                return _users[id];
            }
            catch (KeyNotFoundException)
            {
                throw new UserNotFound();
            }
        }

        public void CreateUser(UserDto userDto)
        {
            var id = _users.Count + 1;
            id = CheckId(id);   
            var user = new User(id, userDto.Username, userDto.Email);
            if (CheckUserName(user.Username))
            {
                throw new NonUniqueUsername();
            }
            if (_users.ContainsKey(user.UserId))
            {
                throw new NonUniqueUserId();
            }
            _users.Add(id, user);
        }

        public int CheckId(int id)
        {
            bool unique = false;
            while (!unique)
            {
                unique = true;
                if(_users.Any(x => x.Value.UserId == id))
                {
                    id += 1;
                    unique = false;
                }
            }
            return id;
        }

        public bool CheckUserName(string username)
        {
            return _users.Any(x => String.Equals(x.Value.Username, username, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
