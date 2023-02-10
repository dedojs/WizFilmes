using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.UserDtos;
using WizFilmes.Infra.Data.Repository.UserRepository;

namespace WizFilmes.Infra.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ReadUserDto> CreateUser(CreateUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            var userCreated = await _repository.CreateUser(user);

            var readUserDto = _mapper.Map<ReadUserDto>(userCreated);

            return readUserDto;

        }

        public async Task<ReadUserDto> GetUserById(int id)
        {
            var user = await _repository.GetUserById(id);

            if (user == null)
                return null;

            var userDto = _mapper.Map<ReadUserDto>(user);

            return userDto;
        }

        public async Task<ReadUserDto> GetUserByEmail(string email)
        {
            var user = await _repository.GetUserByEmail(email);

            if (user == null)
                return null;

            var userDto = _mapper.Map<ReadUserDto>(user);

            return userDto;
        }

        public async Task DeleteUser(ReadUserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            await _repository.DeleteUser(user);
        }

        public async Task<IEnumerable<ReadUserDto>> GetUsers()
        {
            var users = await _repository.GetUsers();

            var listUsers = users.Select(u => _mapper.Map<ReadUserDto>(u));

            return listUsers;
        }

        public async Task<bool> UpdateUser(int id, CreateUserDto userDto)
        {
            var findUser = await _repository.GetUserById(id);

            if (findUser == null)
                return false;

            var userUpdate = _mapper.Map(userDto, findUser);

            await _repository.UpdateUser(userUpdate);

            return true;
        }
    }
}
