using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebApiPatternOptions.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly UserApiOptions _userOptions;

        public UserController(IHttpClientFactory httpClientFactory, IOptionsSnapshot<UserApiOptions> userOptions)
        {
            _httpClientFactory = httpClientFactory;
            _userOptions = userOptions.Value;
        }

        [HttpGet("GreetingUser", Name = "GreetingUser")]
        public string GreetingUser()
        {
            if (_userOptions.Admin)
                return $"Bem vindo(a), gerente {_userOptions.Name}!";
            return $"Bem vindo(a), funcionário {_userOptions.Name}!";
        }

        [HttpGet("IsAdmin", Name = "IsAdmin")]
        public string IsAdmin()
        {
            if (_userOptions.Admin)
                return $"{_userOptions.Name} é gerente e tem acesso premium à plataforma.";
            return $"{_userOptions.Name} é funcionário e tem acesso comum à plataforma.";
        }

        [HttpGet("IsUserUnderage", Name = "IsUserUnderage")]
        public string IsUserUnderage()
        {
            if (_userOptions.Age >= 18)
                return $"{_userOptions.Name} é maior de idade.";
            return $"{_userOptions.Name} é menor de idade.";
        }

        [HttpGet("IsEmailValid", Name = "IsEmailValid")]
        public bool IsEmailValid()
        {
            return _userOptions.Email.Contains('@');
        }
    }
}
