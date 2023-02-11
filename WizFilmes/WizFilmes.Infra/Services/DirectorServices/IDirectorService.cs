using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.DirectorDtos;

namespace WizFilmes.Infra.Services.DirectorServices
{
    public interface IDirectorService
    {
        Task<DirectorDto> CreateDirector(CreateDirectorDto createDirectorDto);
        Task<IEnumerable<DirectorDto>> GetDirectorByName(string name);
        Task<IEnumerable<DirectorDto>> GetAllDirectors();
    }
}
