using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.FilmDtos;

namespace WizFilmes.Infra.Services.FilmServices
{
    public interface IFilmService
    {
        Task<FilmDto> CreateFilm(CreateFilmDto createFilmDto);
        Task<FilmResultDtoCountPages> GetAllFilms(int? row, int? page, string? name, string? category, string? director);
        Task<FilmeReturnDtoWithActors> GetFilmById(int id);
        Task<bool> UpdateFilm(int id, CreateFilmDto createFilmDto);
        Task<bool> DeleteFilm(int id);
    }
}
