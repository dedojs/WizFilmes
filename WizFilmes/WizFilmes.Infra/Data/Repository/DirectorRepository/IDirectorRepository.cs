
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.DirectorDtos;

namespace WizFilmes.Infra.Data.Repository.DirectorRepository
{
    public interface IDirectorRepository
    {
        Task<Director> CreateDirector(Director director);
        Task<IEnumerable<DirectorDto>> GetDirectorByName(string name);
        Task<IEnumerable<DirectorDto>> GetAllDirectors();
    }
}
