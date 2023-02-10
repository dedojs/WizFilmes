using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WizFilmes.Domain.Models;
using WizFilmes.Infra.Data.Dtos.LoginDtos;
using WizFilmes.Infra.Data.Repository.UserRepository;

namespace WizFilmes.Infra.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _repository;
        private readonly IMapper _mapper;
        public LoginService(ILoginRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<User> LoginUser(UserLoginDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            var userValidade = await _repository.LoginUser(user);

            if (userValidade == null)
                return null;

            return userValidade;
        }
    }
}
