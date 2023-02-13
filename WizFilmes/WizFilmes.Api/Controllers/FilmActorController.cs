using Microsoft.AspNetCore.Mvc;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.FilmActorDtos;
using WizFilmes.Infra.Services.FilmActorServices;

namespace WizFilmes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmActorController : ControllerBase
    {
        private readonly IFilmActorService _service;
        public FilmActorController(IFilmActorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilmActor()
        {
            var listFilms = await _service.GetAllFilmsActor();
            return Ok(listFilms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmActorById(int id)
        {
            var listFilms = await _service.GetFilmActorById(id);
            if (listFilms == null) 
                return NotFound("FilmeActor não localizado");

            return Ok(listFilms);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilmActor([FromBody] CreateFilmActorDto createFilmActorDto)
        {
            if (createFilmActorDto == null)
            {
                return BadRequest("Dados inválidos");
            }

            var filmActor = await _service.CreateFilmActor(createFilmActorDto);

            if (filmActor == null)
                return BadRequest("Dados duplicados. Esse ator já faz parte desse filme");

            return CreatedAtAction(nameof(GetFilmActorById), new { id = filmActor.Id }, filmActor);
        }
    }
}
