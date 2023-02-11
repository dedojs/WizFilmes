using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WizFilmes.Infra.Data.Dtos.DirectorDtos;
using WizFilmes.Infra.Services.DirectorServices;

namespace WizFilmes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _service;

        public DirectorController(IDirectorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDirectors()
        {
            var directors = await _service.GetAllDirectors();
            return Ok(directors);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetDirectorByName(string name)
        {
            var director = await _service.GetDirectorByName(name);
            if (director == null) 
                return NotFound("Diretor não localizado");

            return Ok(director);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDirector([FromBody] CreateDirectorDto createDirectorDto)
        {
            if (createDirectorDto == null)
                return BadRequest("Dados Inválidos");

            var director = await _service.CreateDirector(createDirectorDto);

            if (director == null)
                return BadRequest("Diretor já existe");

            return Ok(director);
        }


    }
}
