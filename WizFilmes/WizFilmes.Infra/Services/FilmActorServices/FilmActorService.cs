using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.FilmActorDtos;
using WizFilmes.Infra.Data.Repository.FilmActorRepository;

namespace WizFilmes.Infra.Services.FilmActorServices
{
    public class FilmActorService : IFilmActorService
    {
        private readonly IFilmActorRepository _repository;
        private readonly IMapper _mapper;
        public FilmActorService(IFilmActorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FilmActorDto> CreateFilmActor(CreateFilmActorDto createFilmActorDto)
        {
            var listAllFilmActor = await _repository.GetAllFilmsActor();

            var verifyFilmsActor = listAllFilmActor
                .Where(x => x.ActorId == createFilmActorDto.ActorId && x.FilmId == createFilmActorDto.FilmId)
                .ToList();

            if (verifyFilmsActor.Any())
                return null;

            var filmActor = _mapper.Map<FilmActor>(createFilmActorDto);
            //Console.WriteLine($"Verificando filmActor- {filmActor.Id} - {filmActor.ActorId} - {filmActor.FilmId}");
            var filmActorCreated = await _repository.CreateFilmActor(filmActor);
            var filmActorDto = _mapper.Map<FilmActorDto>(filmActorCreated);

            return filmActorDto;
        }

        public async Task<IEnumerable<FilmActorDto>> GetAllFilmsActor()
        {
            var listFilmActor = await _repository.GetAllFilmsActor();
            var listFADto = listFilmActor.Select(fa => _mapper.Map<FilmActorDto>(fa)).ToList();
            return listFADto;
        }

        public async Task<FilmActorDto> GetFilmActorById(int id)
        {
            var filmActor = await _repository.GetFilmActorById(id);
            if (filmActor == null)
                return null;

            var filmActorDtor = _mapper.Map<FilmActorDto>(filmActor);
            return filmActorDtor;
        }
    }
}
