using KantineAPIv2.DataModels;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KantineAPIv2.Controllers
{
    //API Controller for Order

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //Creating a _dataRepository reference
        private readonly IUserRepository _userRepository;

        //Creating Constructor
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/user
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<User> users = _userRepository.GetAll();
            return Ok(users);
        }

        // GET: api/user/1
        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(long id)
        {
            User user = _userRepository.Get(id);
            if (user == null)
            {
                return NotFound("The User was not found");
            }
            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public IActionResult Post([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest("User is null");
            }

            var userId = _userRepository.Add(user);

            var result = _userRepository.Get(userId);
            return Ok(result);
        }
        // PUT: api/user
        [HttpPut]
        public IActionResult Put(long id, [FromBody] UpdateUserModel user)
        {
            if (user == null)
            {
                return BadRequest("User is null");
            }

            User userToUpdate = _userRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("The User was not found ");
            }

            _userRepository.Update(userToUpdate, user);
            return Ok(user);
        }
        //Delete: api/user/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            User user = _userRepository.Get(id);

            if (user == null)
            {
                return NotFound("The User was not found");
            }
            _userRepository.Delete(user);
            return Ok("The User was deleted");
        }
    }
}
