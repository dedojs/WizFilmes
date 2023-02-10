using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.LoginDtos;
using WizFilmes.Infra.Data.Dtos.UserDtos;

namespace WizFilmes.Infra.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, ReadUserDto>();
            CreateMap<ReadUserDto, User>();
        }
    }
}
