using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public User(int id,string username, string email)
        {
            UserId = id;
            Username = username;
            Email = email;
        }
        
        public User()
        {
        }
    }
}
