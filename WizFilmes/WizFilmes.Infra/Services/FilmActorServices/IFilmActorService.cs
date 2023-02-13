using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.FilmActorDtos;

namespace WizFilmes.Infra.Services.FilmActorServices
{
    public interface IFilmActorService
    {
        Task<IEnumerable<FilmActorDto>> GetAllFilmsActor();
        Task<FilmActorDto> CreateFilmActor(CreateFilmActorDto createFilmActorDto);
        Task<FilmActorDto> GetFilmActorById(int id);
    }
}
