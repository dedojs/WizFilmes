using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.LoginDtos;

namespace WizFilmes.Infra.Services.LoginServices
{
    public interface ILoginService
    {
        Task<User> LoginUser(UserLoginDto user);
    }
}
