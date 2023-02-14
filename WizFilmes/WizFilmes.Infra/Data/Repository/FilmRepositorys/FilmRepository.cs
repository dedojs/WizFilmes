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

            var count = _context.Films.Count();
            var pages = count / row.Value;

            var listFilms = await _context.Films
                .Include(f => f.Cast)
                .ThenInclude(fa => fa.Actor)
                .Skip((page.Value - 1) * row.Value)
                .Take(row.Value)
                .ToListAsync();

            if (!string.IsNullOrEmpty(name))
                listFilms = await _context.Films
                    .Include(f => f.Cast)
                    .ThenInclude(fa => fa.Actor)
                    .Where(f => f.Name.ToLower().Contains(name.ToLower()))
                    .Skip((page.Value - 1) * row.Value)
                    .Take(row.Value)
                    .ToListAsync();

            var newFilmResutDto = new FilmResultDto { Film = listFilms, Count = count, Pages = pages };

            return newFilmResutDto;

            //return listFilms.Select(f => new FilmDto
            //{
            //    Id = f.Id,
            //    Name = f.Name,
            //    Description = f.Description,
            //    Reviews= f.Reviews,
            //    Category= f.Category,
            //    Director= f.Director,
            //    Year= f.Year,
            //    Rating = f.Rating,
            //    Cast = f.Cast.Select(fa => new FilmDtoActorCharacter
            //    {
            //        Name = fa.Actor.Name,
            //        Character = fa.Character
            //    }),
            //});
        }

        public async Task<Film> GetFilmById(int id)
        {
            var film = await _context.Films
                    .Include(f => f.Cast)
                    .ThenInclude(fa => fa.Actor)
                    .FirstOrDefaultAsync(i => i.Id == id);

            if (film == null)
                return null;


            return film;
        }

        public async Task UpdateFilm(Film film)
        {
            _context.Films.Update(film);
            await _context.SaveChangesAsync();
        }
    }
}
