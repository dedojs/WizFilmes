using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.UserDtos;

namespace WizFilmes.Infra.Services.UserServices
{
    public interface IUserService
    {
        Task<IEnumerable<ReadUserDto>> GetUsers();
        Task<ReadUserDto> CreateUser(CreateUserDto userDto);
        Task<ReadUserDto> GetUserById(int id);
        Task<ReadUserDto> GetUserByEmail(string email);
        Task<bool> UpdateUser(int id, CreateUserDto userDto);
        Task DeleteUser(ReadUserDto userDto);
    }
}
