using Microsoft.EntityFrameworkCore;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Context;

namespace WizFilmes.Infra.Data.Repository.ActorRepository
{
    public class ActorRepository : IActorRepository
    {
        private readonly AppDbContext _context;

        public ActorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Actor> CreateActor(Actor actor)
        {
            _context.Actors.Add(actor);
            await _context.SaveChangesAsync();
            return actor;
        }

        public async Task<IEnumerable<Actor>> GetActorByName(string name)
        {
            var actor = await _context.Actors
                //.Include(x => x.Films)
                .Where(a => a.Name.ToLower().Contains(name.ToLower()))
                .ToListAsync();

            return actor;
        }

        public async Task<IEnumerable<Actor>> GetAllActors()
        {
            return await _context.Actors
                //.Include(f => f.Films)
                .ToListAsync();
        }
    }
}
