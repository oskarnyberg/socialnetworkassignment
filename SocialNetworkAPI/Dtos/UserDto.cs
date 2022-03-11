using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Dtos
{
    public class UserDto
    {
        private const string _errorUsernameMessage = "{0} can only contain numbers and letters, no blank";
        private const string _errorEmailMessage = "{0} can only contain special characters, numbers and letters, no blank";

        [Required]
        [RegularExpression("^([A-Za-z0-9])*$", ErrorMessage = _errorUsernameMessage)]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = _errorEmailMessage)]
        public string Email { get; set; }
    }
}
