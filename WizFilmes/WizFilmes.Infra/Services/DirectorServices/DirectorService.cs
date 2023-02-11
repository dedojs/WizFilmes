using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.DirectorDtos;
using WizFilmes.Infra.Data.Repository.DirectorRepository;

namespace WizFilmes.Infra.Services.DirectorServices
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _repository;
        private readonly IMapper _mapper;
        public DirectorService(IDirectorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DirectorDto> CreateDirector(CreateDirectorDto createDirectorDto)
        {
            var directors = await _repository.GetAllDirectors();
            var verifyDirectorName = directors.Where(d => d.Name.ToLower() == createDirectorDto.Name.ToLower());

            if (verifyDirectorName.Any())
            {
                return null;
            }

            var director = _mapper.Map<Director>(createDirectorDto);
            var directorCreated = await _repository.CreateDirector(director);

            var directorDto = _mapper.Map<DirectorDto>(directorCreated);

            return directorDto;
        }

        public async Task<IEnumerable<DirectorDto>> GetAllDirectors()
        {
            var directors = await _repository.GetAllDirectors();

            return directors;
        }

        public async Task<IEnumerable<DirectorDto>> GetDirectorByName(string name)
        {
            var director = await _repository.GetDirectorByName(name);

            var directorDto = director.Select(d => _mapper.Map<DirectorDto>(d));

            if (director == null)
                return null;

            return directorDto;
        }

    }
}
