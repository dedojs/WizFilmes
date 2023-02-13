using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Repository.FilmRepositorys
{
    public interface IFilmRepository
    {
        Task<Film> CreateFilm(Film film);
        Task<IEnumerable<Film>> GetAllFilms(string? name);
        Task<Film> GetFilmById(int id);
        Task UpdateFilm(Film film);
        Task DeleteFilm(Film film);
    }
}
