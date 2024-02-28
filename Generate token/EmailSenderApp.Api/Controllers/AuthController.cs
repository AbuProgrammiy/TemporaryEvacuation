using EmailSenderApp.Application.AuthService;
using EmailSenderApp.Domen.Entities.AuthModels;
using Microsoft.AspNetCore.Mvc;

namespace EmailSenderApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServise _authServise;

        public AuthController(IAuthServise authServise)
        {
            _authServise = authServise;
        }

        [HttpPost]
        public string Login(User user)
        {
            return _authServise.GenerateToken(user);
        }
    }
}
