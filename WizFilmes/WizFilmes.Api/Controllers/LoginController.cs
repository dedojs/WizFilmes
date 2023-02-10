using Microsoft.AspNetCore.Mvc;
using WizFilmes.Infra.Data.Dtos.LoginDtos;
using WizFilmes.Infra.Services.LoginServices;
using WizFilmes.Infra.Utils;

namespace WizFilmes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
        {
            var user = await _service.LoginUser(userLogin);

            if (user == null)
                return BadRequest("Email ou Senha inválidos!");

            var token = new TokenGenerator().Generate(user);
            return Ok(token);   
        }
    }
}
