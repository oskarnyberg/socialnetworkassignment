using SocialNetworkAPI.Dtos;
using SocialNetworkAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Repositories.Users
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUser(int userId);
        void CreateUser(UserDto userDto);
        //bool IsUniqueName(string username);
    }
}
