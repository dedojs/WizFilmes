using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Context;
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

        public async Task<Film> CreateFilm(Film createfilm)
        {
            _context.Films.Add(createfilm);
            await _context.SaveChangesAsync();
            
            return createfilm;
        }

        public async Task DeleteFilm(Film film)
        {
            _context.Films.Remove(film);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Film>> GetAll()
        {
            var list = await _context.Films.ToListAsync();
            return list;
        }

        public async Task<FilmResultDto> GetAllFilms(int? row, int? page, string? name, string? category, string? director)
        {
            if (page == null)
                page = 1;

            if (row == null)
                row = 10;

            if (row > 20)
                row = 20;

            double count = _context.Films.Count();

            double pages = Math.Ceiling(count / row.Value);

            var query = _context.Films.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(f => f.Name.ToLower().Contains(name.ToLower()));
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(f => f.Category.Name.ToLower() == category);
            }

            if (!string.IsNullOrEmpty(director))
            {
                query = query.Where(f => f.Director.Name.ToLower().Contains(director.ToLower()));
            }

            var listFilms = await query
                .Skip((page.Value - 1) * row.Value)
                .Take(row.Value)
                .ToListAsync();

            var newList = listFilms.Select(f => new FilmeReturnDtoWithActors
            {
                Id = f.Id,
                Name = f.Name,
                Description = f.Description,
                Reviews = f.Reviews,
                Category = f.Category,
                Director = f.Director,
                Year = f.Year,
                Rating = f.Rating,
                Cast = f.Cast.Select(fa => new FilmDtoActorCharacter
                {
                    Name = fa.Actor.Name,
                    Character = fa.Character
                }).ToList(),
            }).ToList();

            var newFilmResutDto = new FilmResultDto
            { 
                Film = newList,
                TotalFilms = count,
                TotalPages = pages
            };

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
                Category = film.Category,
                Director = film.Director,
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
