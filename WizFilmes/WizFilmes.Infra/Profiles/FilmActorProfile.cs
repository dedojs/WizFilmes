using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.ActorDtos;
using WizFilmes.Infra.Data.Dtos.FilmActorDtos;

namespace WizFilmes.Infra.Profiles
{
    public class FilmActorProfile : Profile
    {
        public FilmActorProfile()
        {
            CreateMap<CreateFilmActorDto, FilmActor>();
            CreateMap<FilmActorDto, FilmActor>();
            CreateMap<FilmActor, FilmActorDto>();
        }
    }
}
