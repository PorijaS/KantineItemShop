using KantineAPIv2.DataModels;
using KantineAPIv2.Entities.DataRepository;
using KantineAPIv2.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KantineAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _dataRepository;

        public UserController(IUserRepository deviceRepository)
        {
            _dataRepository = deviceRepository;
        }

        // GET: api/user

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<User> users = _dataRepository.GetAll();
            return Ok(users);
        }

        // GET: api/user/1
        [HttpGet]
        [Route("{id}")]

        public IActionResult Get(long id)
        {
            User user = _dataRepository.Get(id);
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

            var userId = _dataRepository.Add(user);

            var result = _dataRepository.Get(userId);
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

            User userToUpdate = _dataRepository.Get(id);
            if (userToUpdate == null)
            {
                return NotFound("The User was not found ");
            }

            _dataRepository.Update(userToUpdate, user);
            return Ok(user);
        }

        //Delete: api/user/1
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(long id)
        {
            User user = _dataRepository.Get(id);

            if (user == null)
            {
                return NotFound("The User was not found");
            }
            _dataRepository.Delete(user);
            return Ok("The User was deleted");
        }
    }
}
