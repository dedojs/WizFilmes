using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Context;

namespace WizFilmes.Infra.Data.Repository.UserRepository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> LoginUser(User userLogin)
        {
            var user = await _context.Users.FirstOrDefaultAsync(t => t.Email == userLogin.Email && t.Password == userLogin.Password);

            if (user == null)
                return null;

            return user;
        }
    }
}
