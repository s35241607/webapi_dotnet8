using CommonLib;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.ComponentModel.DataAnnotations;

namespace webapi_dotnet8.Controllers
{
    [Route("api/[controller]")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly Libary _lib;

        public AccountController(Libary lib)
        {
            _lib = lib;
        }

        [HttpPost("Signin")]
        public async Task<IActionResult> Signin(Login login)
        {
            var temp = _lib.GetWord();
            return Ok(login.UserName.Length);
        }

        [HttpGet("Users/{id}")]
        [HttpGet("User/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            await Task.Delay(0);
            return Ok(id);
        }
    }

    public class Login
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class Token
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
