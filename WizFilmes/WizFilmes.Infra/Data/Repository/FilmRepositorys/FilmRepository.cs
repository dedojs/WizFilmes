using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Film>> GetAllFilms(string? name)
        {
            var listFilms = await _context.Films
                .ToListAsync();

            if (!string.IsNullOrEmpty(name))
                listFilms = await _context.Films
                    .Where(f => f.Name.ToLower().Contains(name.ToLower())).ToListAsync();

            return listFilms;
        }

        public async Task<Film> GetFilmById(int id)
        {
            var film = await _context.Films.FindAsync(id);
            return film;
        }

        public async Task UpdateFilm(Film film)
        {
            _context.Films.Update(film);
            await _context.SaveChangesAsync();
        }
    }
}
