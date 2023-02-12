using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.ActorDtos;

namespace WizFilmes.Infra.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<CreateActorDto, Actor>();
            CreateMap<ActorDto, Actor>();
            CreateMap<Actor, ActorDto>();
        }
    }
}
