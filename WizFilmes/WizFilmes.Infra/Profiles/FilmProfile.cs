using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.ActorDtos;
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
        }
    }
}
