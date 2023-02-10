using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.LoginDtos;

namespace WizFilmes.Infra.Profiles
{
    public class LoginProfile : Profile
    {
        public LoginProfile()
        {
            CreateMap<UserLoginDto, User>();
            CreateMap<User, UserLoginDto>();
        }
    }
}
