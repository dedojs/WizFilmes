using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.ActorDtos;

namespace WizFilmes.Infra.Services.ActorServices
{
    public interface IActorService
    {
        Task<IEnumerable<ActorDto>> GetAllActors();
        Task<IEnumerable<ActorDto>> GetActorByName(string name);
        Task<ActorDto> CreateActor(CreateActorDto createActorDto);
    }
}
