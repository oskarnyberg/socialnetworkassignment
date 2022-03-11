using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Helpers.Exceptions
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {
        }
    }

    public class UserNotFound : UserException
    {
        public UserNotFound(string message = "Couldn't find the user") : base(message)
        {
        }
    }

    public class NonUniqueUsername : UserException
    {
        public NonUniqueUsername(string message = "Username already exists") : base(message)
        { 
        }
    }

    public class NonUniqueUserId : UserException
    {
        public NonUniqueUserId(string message = "UserId already exists") : base(message)
        {
        }
    }
}
