using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Repository.FilmActorRepository
{
    public interface IFilmActorRepository
    {
        Task<IEnumerable<FilmActor>> GetAllFilmsActor();
        Task<FilmActor> CreateFilmActor(FilmActor filmActor);
        Task<FilmActor> GetFilmActorById(int id);
    }
}
