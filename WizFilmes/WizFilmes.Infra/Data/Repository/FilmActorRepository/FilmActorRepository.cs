using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Context;

namespace WizFilmes.Infra.Data.Repository.FilmActorRepository
{
    public class FilmActorRepository : IFilmActorRepository
    {
        private readonly AppDbContext _context;
        public FilmActorRepository(AppDbContext context)
        {
            _context = context;        
        }

        public async Task<FilmActor> CreateFilmActor(FilmActor filmActor)
        {
            _context.FilmsActor.Add(filmActor);
            await _context.SaveChangesAsync();
            return filmActor;
        }

        public async Task<IEnumerable<FilmActor>> GetAllFilmsActor()
        {
            var filmActor = await _context.FilmsActor.ToListAsync();
            return filmActor;
        }

        public async Task<FilmActor> GetFilmActorById(int id)
        {
            var filmActor = await _context.FilmsActor.FindAsync(id);

            if (filmActor == null)
                return null;

            return filmActor;
        }
    }
}
