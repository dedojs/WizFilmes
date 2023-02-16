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
            var listFilms = await _repository.GetAll();
            
            var findFime = listFilms.FirstOrDefault(f => f.Name.ToLower() == createFilmDto.Name.ToLower());

            if (findFime != null)
                return null;

            var film = _mapper.Map<Film>(createFilmDto);

            var filmCreated = await _repository.CreateFilm(film);

            var filmDto = _mapper.Map<FilmDto>(filmCreated);
            
            return filmDto;
        }

        public async Task<bool> DeleteFilm(int id)
        {
            var listFilms = await _repository.GetAll();
            var film = listFilms.FirstOrDefault(f => f.Id == id);

            if (film == null)
                return false;

            await _repository.DeleteFilm(film);
            return true;
        }

        public async Task<FilmResultDtoCountPages> GetAllFilms(int? row, int? page, string? name, string? category, string? director)
        {
            var listFilms = await _repository.GetAllFilms(row, page, name, category, director);

            var newListResultDto = new FilmResultDtoCountPages() { Films = listFilms.Film, TotalFilms = listFilms.TotalFilms, TotalPages = listFilms.TotalPages };

            return newListResultDto;
        }

        public async Task<FilmeReturnDtoWithActors> GetFilmById(int id)
        {
            var film = await _repository.GetFilmById(id);
            
            return film;
        }

        public async Task<bool> UpdateFilm(int id, CreateFilmDto createFilmDto)
        {
            var listFilms = await _repository.GetAll();
            var film = listFilms.FirstOrDefault(f => f.Id == id);

            if (film == null)
                return false;

            var filmUpdate = _mapper.Map(createFilmDto, film);
            
            await _repository.UpdateFilm(filmUpdate);

            return true;
        }

    }
}
