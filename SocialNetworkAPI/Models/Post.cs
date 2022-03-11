using SocialNetworkAPI.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Models
{
    public class Post
    {
        private const string _validationErrorMessage = "{0} must be between {2} and {1} characters long";
        public Post()
        { 
        }
        public Post(int id, PostDto postDto)
        {
            PostId = id;
            PostText = postDto.PostText;
            UserId = postDto.UserId;
        }
        public int PostId { get; set; }
        [Required]
        [StringLength(400, ErrorMessage = _validationErrorMessage, MinimumLength = 5)]
        public string PostText { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public List<User> Likes { get; set; } = new List<User>();
        public DateTime LastUpdated { get; set; }
    }
}
