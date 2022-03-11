using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Dtos
{
    public class PostDto
    {
        private const string _validationErrorMessage = "{0} must be between {2} and {1} characters long";

        [Required]
        [StringLength(400, ErrorMessage = _validationErrorMessage, MinimumLength = 5)]
        public string PostText { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
