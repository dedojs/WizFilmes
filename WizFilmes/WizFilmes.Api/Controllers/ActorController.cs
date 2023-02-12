using Microsoft.AspNetCore.Mvc;
using WizFilmes.Infra.Data.Dtos.ActorDtos;
using WizFilmes.Infra.Data.Dtos.DirectorDtos;
using WizFilmes.Infra.Services.ActorServices;

namespace WizFilmes.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _service;

        public ActorController(IActorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActors()
        {
            var actors = await _service.GetAllActors();
            return Ok(actors);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetActorByName(string name)
        {
            var actors = await _service.GetActorByName(name);

            if (actors == null)
                return NotFound("Ator não localizado");

            return Ok(actors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateActor([FromBody] CreateActorDto createActorDto)
        {
            if (createActorDto == null)
                return BadRequest("Dados Inválidos");

            var actor = await _service.CreateActor(createActorDto);

            if (actor == null)
                return BadRequest("Ator já existe");
            
            return Ok(actor);
        }
    }
}
