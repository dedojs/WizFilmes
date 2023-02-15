using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Context;
using WizFilmes.Infra.Data.Dtos.ActorDtos;
using WizFilmes.Infra.Data.Dtos.FilmDtos;

namespace WizFilmes.Infra.Data.Repository.FilmRepositorys
{
    public class FilmRepository : IFilmRepository
    {
        private readonly AppDbContext _context;

        public FilmRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Film> CreateFilm(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();
            return film;
        }

        public async Task DeleteFilm(Film film)
        {
            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
        }

        public async Task<FilmResultDto> GetAllFilms(int? row, int? page, string? name)
        {
            if (page == null)
                page = 1;

            if (row == null)
                row = 10;

            if (row > 20)
                row = 20;

            double count = _context.Films.Count();

            double pages = Math.Ceiling(count / row.Value);

            var listFilms = await _context.Films
                .Skip((page.Value - 1) * row.Value)
                .Take(row.Value)
                .ToListAsync();

            if (!string.IsNullOrEmpty(name))
                listFilms = await _context.Films
                    .Where(f => f.Name.ToLower().Contains(name.ToLower()))
                    .Skip((page.Value - 1) * row.Value)
                    .Take(row.Value)
                    .ToListAsync();

            var newList = listFilms.Select(f => new FilmeReturnDtoWithActors
            {
                Id = f.Id,
                Name = f.Name,
                Description = f.Description,
                Reviews = f.Reviews,
                Category = f.Category.Name,
                Director = f.Director.Name,
                Year = f.Year,
                Rating = f.Rating,
                Cast = f.Cast.Select(fa => new FilmDtoActorCharacter
                {
                    Name = fa.Actor.Name,
                    Character = fa.Character
                }),
            });

            var newFilmResutDto = new FilmResultDto { Film = newList, TotalFilms = count, TotalPages = pages };

            return newFilmResutDto;
            
        }

        public async Task<FilmeReturnDtoWithActors> GetFilmById(int id)
        {
            var film = await _context.Films
                    .FirstOrDefaultAsync(i => i.Id == id);

            if (film == null)
                return null;

            var filmResult = new FilmeReturnDtoWithActors()
            {
                Id = film.Id,
                Name = film.Name,
                Description = film.Description,
                Reviews = film.Reviews,
                Category = film.Category.Name,
                Director = film.Director.Name,
                Year = film.Year,
                Rating = film.Rating,
                Cast = film.Cast.Select(fa => new FilmDtoActorCharacter
                {
                    Name = fa.Actor.Name,
                    Character = fa.Character
                }),
            };


            return filmResult;
        }

        public async Task UpdateFilm(Film film)
        {
            _context.Films.Update(film);
            await _context.SaveChangesAsync();
        }
    }
}
