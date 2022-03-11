using Microsoft.AspNetCore.Mvc;
using SocialNetworkAPI.Dtos;
using SocialNetworkAPI.Helpers.Exceptions;
using SocialNetworkAPI.Models;
using SocialNetworkAPI.Repositories.Posts;
using SocialNetworkAPI.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetworkAPI.Controllers.v1
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;

        public PostController(IPostRepository postRepository, IUserRepository userRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
        }
        // GET all POSTS
        [HttpGet]
        public ActionResult<List<Post>> GetPosts()
        {
            try
            {
                var posts = _postRepository.GetPosts();
                return posts;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET POST
        [HttpGet("{id}")]
        public ActionResult<Post> GetPost(int id)
        {
            try
            {
                var post = _postRepository.GetPost(id);
                return post;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST post
        [HttpPost]
        public ActionResult<Post> CreatePost([FromBody] PostDto postDto)
        {
            try
            {
                var user = _userRepository.GetUser(postDto.UserId);
                _postRepository.CreatePost(postDto);
                return StatusCode(204);
            }
            catch (PostException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
        }

        // UPDATE POST
        [HttpPatch("{postId}")]
        public ActionResult UpdatePost(int postId, [FromQuery] PostDto postDto)
        {
            try
            {
                var post = _postRepository.UpdatePost(postId, postDto);
                return StatusCode(204);
            }
            catch (PostException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE POST
        [HttpDelete("{postId}")]
        public ActionResult Delete(int postId, [FromQuery] int userId)
        {
            try
            {
                var post = _postRepository.GetPost(postId);
                _postRepository.DeletePost(postId, userId);
                return StatusCode(204);
            }
            catch (PostException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
        }

        // Like or unlike POST
        [HttpPatch("likeunlike/{postId}")]
        public ActionResult LikeUnlike(int postId, [FromQuery] int userId)
        {
            try
            {
                Post post = _postRepository.LikeUnlikePost(postId, userId);
                return StatusCode(204);
            }
            catch (PostException e)
            {
                return BadRequest(e.Message);
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
