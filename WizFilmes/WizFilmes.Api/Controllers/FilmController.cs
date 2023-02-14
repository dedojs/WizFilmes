using Microsoft.AspNetCore.Mvc;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.FilmDtos;
using WizFilmes.Infra.Services.FilmServices;

namespace WizFilmes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService _service;

        public FilmController(IFilmService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFilms(int? row, int? page, string? name)
        {
            var listFilms = await _service.GetAllFilms(row, page, name);
            return Ok(listFilms);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFilmById(int id)
        {
            var film = await _service.GetFilmById(id);

            if (film == null)
                return NotFound("Filme não encontrado");

            return Ok(film);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFilm([FromBody] CreateFilmDto createFilmDto)
        {
            if (createFilmDto == null)
                return BadRequest("Dados inválidos");

            var film = await _service.CreateFilm(createFilmDto);

            if (film == null)
                return BadRequest("Filme Já cadastrado");

            return CreatedAtAction(nameof(GetFilmById), new { id = film.Id }, film);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFilm(int id, [FromBody] CreateFilmDto createFilmDto)
        {
            if (createFilmDto == null)
                return BadRequest("Dados inválidos");

            var film = await _service.UpdateFilm(id, createFilmDto);

            if (film == false)
                return NotFound("Filme não localizado");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(int id)
        {
            var film = await _service.DeleteFilm(id);

            if (film == false)
                return NotFound("Filme não localizado");

            return NoContent();
        }
    }
}
