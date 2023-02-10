using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;

namespace WizFilmes.Infra.Data.Repository.UserRepository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> CreateUser(User user);
    }
}
