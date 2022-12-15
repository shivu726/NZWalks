using Microsoft.AspNetCore.Mvc;
using NZWalks.Models.DTO;
using NZWalks.Repository;

namespace NZWalks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository _repository;
        private readonly ITokenHandler _tokenHandler;

        public AuthController(IUserRepository repository, ITokenHandler tokenHandler)
        {
            _repository = repository;
            _tokenHandler = tokenHandler;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginUser(LoginRequest login)
        {
            var user = await _repository.UserAuthenticationAsync(login.Username, login.Password);

            if (user != null)
            {
                var token = await _tokenHandler.CreateTokenAsync(user);
                return Ok(token);

            }

            return BadRequest("Username or Password is Incorrect..");
        }
    }
}
