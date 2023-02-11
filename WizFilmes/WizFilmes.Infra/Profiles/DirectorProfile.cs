using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.DirectorDtos;
using WizFilmes.Infra.Data.Dtos.LoginDtos;

namespace WizFilmes.Infra.Profiles
{
    public class DirectorProfile : Profile
    {
        public DirectorProfile()
        {
            CreateMap<CreateDirectorDto, Director>();
            CreateMap<DirectorDto, Director>();
            CreateMap<Director, DirectorDto>();
        }
    }
}
