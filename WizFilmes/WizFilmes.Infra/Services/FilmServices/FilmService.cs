using AutoMapper;
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
            var listFilms = await _repository.GetAllFilms(string.Empty);
            var findFime = listFilms.Where(f => f.Name.ToLower() == createFilmDto.Name.ToLower());

            if (findFime.Any())
                return null;

            var film = _mapper.Map<Film>(createFilmDto);
            var filmCreated = await _repository.CreateFilm(film);
            var filmDto = _mapper.Map<FilmDto>(filmCreated);

            return filmDto;
        }

        public async Task<bool> DeleteFilm(int id)
        {
            var film = await _repository.GetFilmById(id);
            if (film == null)
                return false;

            await _repository.DeleteFilm(film);
            return true;
        }

        public async Task<IEnumerable<FilmDto>> GetAllFilms(string? name)
        {
            var listFilms = await _repository.GetAllFilms(name);

            var listFilmsDto = listFilms.Select(f => _mapper.Map<FilmDto>(f)).ToList();
            return listFilmsDto;
        }

        public async Task<FilmDto> GetFilmById(int id)
        {
            var film = await _repository.GetFilmById(id);
            var filmDto = _mapper.Map<FilmDto>(film);
            return filmDto;
        }

        public async Task<bool> UpdateFilm(int id, CreateFilmDto createFilmDto)
        {
            var film = await _repository.GetFilmById(id);

            if (film == null)
                return false;

            var filmUpdate = _mapper.Map(createFilmDto, film);
            await _repository.UpdateFilm(filmUpdate);

            return true;
        }
    }
}
