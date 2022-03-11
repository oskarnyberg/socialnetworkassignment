using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Helpers.Exceptions
{
    public class PostException : Exception
    {
        public PostException(string message) : base(message)
        {

        }
    }

    public class PostNotFound : PostException
    {
        public PostNotFound(string message = "Couldn't find the post") : base(message)
        {
        }
    }

    public class WrongUser : PostException
    {
        public WrongUser(string message = "User don't have access") : base(message)
        {
        }
    }

    public class WrongLenght : PostException
    {
        public WrongLenght(string message = "Content must be between 5-400 characters") : base(message)
        {
        }
    }
}
