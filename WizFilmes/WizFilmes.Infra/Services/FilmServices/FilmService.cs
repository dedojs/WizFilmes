using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.FilmDtos;
using WizFilmes.Infra.Data.Repository.FilmRepositorys;

namespace WizFilmes.Infra.Services.FilmServices
{
    public class FilmService : IFilmService
    {
        private readonly IFilmRepository _repository;
        private readonly IMapper _mapper;
        public FilmService(IFilmRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FilmDto> CreateFilm(CreateFilmDto createFilmDto)
        {
            var listFilms = await _repository.GetAllFilms(null, null, string.Empty);
            var findFime = listFilms.Film.Where(f => f.Name.ToLower() == createFilmDto.Name.ToLower());

            if (findFime.Any())
                return null;

            var film = _mapper.Map<Film>(createFilmDto);
            var filmCreated = await _repository.CreateFilm(film);
            var filmDto = _mapper.Map<FilmDto>(filmCreated);

            return filmDto;
        }

        public async Task<bool> DeleteFilm(int id)
        {
            var filmDto = await _repository.GetFilmById(id);

            if (filmDto == null)
                return false;

            var film = _mapper.Map<Film>(filmDto);

            await _repository.DeleteFilm(film);
            return true;
        }

        public async Task<FilmResultDtoCountPages> GetAllFilms(int? row, int? page, string? name)
        {
            var listFilms = await _repository.GetAllFilms(row, page, name);

            var newListResultDto = new FilmResultDtoCountPages() { Films = listFilms.Film, TotalFilms = listFilms.TotalFilms, TotalPages = listFilms.TotalPages };

            return newListResultDto;
        }

        public async Task<FilmeReturnDtoWithActors> GetFilmById(int id)
        {
            var film = await _repository.GetFilmById(id);
            //var filmDto = _mapper.Map<FilmDto>(film);
            return film;
        }

        public async Task<bool> UpdateFilm(int id, CreateFilmDto createFilmDto)
        {
            var filmDto = await _repository.GetFilmById(id);

            if (filmDto == null)
                return false;

            var film = _mapper.Map<Film>(filmDto);

            var filmUpdate = _mapper.Map(createFilmDto, film);
            
            await _repository.UpdateFilm(filmUpdate);

            return true;
        }
    }
}
