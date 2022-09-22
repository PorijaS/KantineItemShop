using IdentityServer4.Models;
using IdentityServer4.Validation;
using KantineAPIv2.DataModels;
using KantineAPIv2.Entities;
using KantineAPIv2.Entities.DataRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KantineAPIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;

        public LoginController(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (loginModel == null)
            {
                return BadRequest("User is null");
            }

            var userPass = _loginRepository.Login(loginModel);

            if (userPass == null)
            {
                return Unauthorized();
            }

            var hashedPass = loginModel.Password.Sha256();

            if (hashedPass == userPass.Password)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
