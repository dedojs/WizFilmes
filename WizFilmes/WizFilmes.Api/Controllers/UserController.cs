using Microsoft.AspNetCore.Mvc;
using WizFilmes.Infra.Data.Dtos.LoginDtos;
using WizFilmes.Infra.Data.Dtos.UserDtos;
using WizFilmes.Infra.Services.LoginServices;
using WizFilmes.Infra.Services.UserServices;
using WizFilmes.Infra.Utils;

namespace WizFilmes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var user = await _service.GetUsers();
            return Ok(user);

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _service.GetUserById(id);
            if (user == null)
                return NotFound("Usuário não localizado");

            return Ok(user);
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
        {
            var findUser = await _service.GetUserByEmail(userDto.Email);

            if (findUser != null)
                return BadRequest("Usuário já cadastrado");

            if (userDto == null)
                return BadRequest("Dados inválidos");
            
            var user = await _service.CreateUser(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] CreateUserDto createUserDto)
        {
            var user = await _service.UpdateUser(id, createUserDto);

            if (user == false)
                return NotFound("Usuário não localizado");

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _service.GetUserById(id);

            if (user == null)
                return NotFound("Usuário não localizado");

            await _service.DeleteUser(user);

            return NoContent();
        }
    }
}
