using SocialNetworkAPI.Dtos;
using SocialNetworkAPI.Helpers.Exceptions;
using SocialNetworkAPI.Models;
using SocialNetworkAPI.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkAPI.Repositories.Posts
{
    public class PostDictionary : IPostRepository
    {
        private readonly Dictionary<int, Post> _posts = new Dictionary<int, Post>();
        private readonly IUserRepository _userRepository;

        public PostDictionary(IUserRepository userDictionary)
        {
            _userRepository = userDictionary;
            var testuser1 = userDictionary.GetUser(1);
            var testpost1 = new Post
            {
                PostId = 1,
                PostText = "hello my first post",
                UserId = 1
            };
            var testuser2 = userDictionary.GetUser(2);
            var testpost2 = new Post
            {
                PostId = 2,
                PostText = "brrpp brrrpp brrppp",
                UserId = 2
            };

            _posts.Add(1, testpost1);
            _posts.Add(2, testpost2);
        }
        public List<Post> GetPosts()
        {
            var posts = new List<Post>();
            foreach(var post in _posts)
            {
                posts.Add(post.Value);
            }
            return posts;
        }

        public Post GetPost(int id)
        {
            return _posts[id];
        }

        public void CreatePost(PostDto postDto)
        {
            var id = _posts.Count + 1;
            var post = new Post(id, postDto);
            _posts.Add(id, post);
        }

        public Post UpdatePost(int postId, PostDto postDto)
        {
            if(!CheckUser(postId, postDto.UserId))
            {
                throw new WrongUser();
            }
            var post = GetPost(postId);
            post.PostText = postDto.PostText;
            post.LastUpdated = DateTime.Now;
            return post;
        }

        public void DeletePost(int userId, int postId)
        {
            if(!CheckUser(userId, postId))
            {
                throw new WrongUser();
            }
            _posts.Remove(postId);
        }

        public Post LikeUnlikePost(int postId, int userId)
        {
            Post post = GetPost(postId);
            User user = _userRepository.GetUser(userId);
            if (!post.Likes.Contains(user))
            {
                post.Likes.Add(user);
            }
            else
            {
                post.Likes.Remove(user);
            }
            return post;
        }

        public bool CheckUser(int postId, int userId)
        {
            Post post = GetPost(postId);
            User user = _userRepository.GetUser(userId);
            if(post.UserId == user.UserId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
