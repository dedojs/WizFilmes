using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Context;
using WizFilmes.Infra.Data.Dtos.DirectorDtos;

namespace WizFilmes.Infra.Data.Repository.DirectorRepository
{
    public class DirectorRepository : IDirectorRepository
    {
        private readonly AppDbContext _context;

        public DirectorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Director> CreateDirector(Director director)
        {
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();
            return director;
        }

        public async Task<IEnumerable<DirectorDto>> GetAllDirectors()
        {
            return await _context.Directors
                .Include(x => x.Films)
                .Select(d => new DirectorDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Films = d.Films.Select(f => f.Name).ToList()
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<DirectorDto>> GetDirectorByName(string name)
        {
            var director = await _context.Directors
                .Include(x => x.Films)
                .Where(d => d.Name.ToLower().Contains(name.ToLower()))
                .Select( d => new DirectorDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Films = d.Films.Select(f => f.Name).ToList()
                })
                .ToListAsync();

            return director;
        }
        
    }
}
