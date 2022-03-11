using Microsoft.AspNetCore.Mvc;
using SocialNetworkAPI.Dtos;
using SocialNetworkAPI.Helpers.Exceptions;
using SocialNetworkAPI.Models;
using SocialNetworkAPI.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetworkAPI.Controllers.v1
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/user
        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            try
            {
                var users = _userRepository.GetUsers();
                return StatusCode(200,users);
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/user/ID
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            try
            {
                var user = _userRepository.GetUser(id);
                return StatusCode(200,user);
            }
            catch (UserException e)
            {
                return BadRequest(e.Message);
            }
        }

        // Create User, POST api/user
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] UserDto userDto)
        {
            try
            {
                _userRepository.CreateUser(userDto);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
