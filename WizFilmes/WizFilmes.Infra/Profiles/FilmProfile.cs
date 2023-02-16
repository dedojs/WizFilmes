using AutoMapper;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.FilmDtos;

namespace WizFilmes.Infra.Profiles
{
    public class FilmProfile : Profile
    {
        public FilmProfile()
        {
            CreateMap<CreateFilmDto, Film>();
            CreateMap<FilmDto, Film>();
            CreateMap<Film, FilmDto>();
            CreateMap<FilmeReturnDtoWithActors, Film>();
            CreateMap<Film, FilmeReturnDtoWithActors>();
        }
    }
}
