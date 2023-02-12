using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.ActorDtos;
using WizFilmes.Infra.Data.Dtos.DirectorDtos;
using WizFilmes.Infra.Data.Repository.ActorRepository;

namespace WizFilmes.Infra.Services.ActorServices
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _repository;
        private readonly IMapper _mapper;

        public ActorService(IActorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ActorDto> CreateActor(CreateActorDto createActorDto)
        {
            var listAllActors = await _repository.GetAllActors();
            var findActor = listAllActors.Where(a => a.Name.ToLower() == createActorDto.Name.ToLower());

            if (findActor.Any())
                return null;

            var actor = _mapper.Map<Actor>(createActorDto);
            var actorCReated = await _repository.CreateActor(actor);

            var actorDto = _mapper.Map<ActorDto>(actorCReated);

            return actorDto;
        }

        public async Task<IEnumerable<ActorDto>> GetActorByName(string name)
        {
            var actor = await _repository.GetActorByName(name);

            if (!actor.Any())
                return null;

            var actorsDtos = actor.Select(a => _mapper.Map<ActorDto>(a));

            return actorsDtos;

        }

        public async Task<IEnumerable<ActorDto>> GetAllActors()
        {
            var actors = await _repository.GetAllActors();
            var actorsDtos = actors.Select(a => _mapper.Map<ActorDto>(a));

            return actorsDtos;
        }
    }
}
