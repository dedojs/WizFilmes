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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();

        }

        public async Task<User> LoginUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
