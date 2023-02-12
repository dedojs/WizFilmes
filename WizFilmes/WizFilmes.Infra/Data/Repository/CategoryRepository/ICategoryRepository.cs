using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Repository.ActorRepository
{
    public interface IActorRepository
    {
        Task<IEnumerable<Actor>> GetAllActors();
        Task<IEnumerable<Actor>> GetActorByName(string name);
        Task<Actor> CreateActor(Actor actor);
    }
}
