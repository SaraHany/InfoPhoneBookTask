using AutoMapper;
using MediatR;
using PhoneBook_Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Registration_User.Command
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserDto, object>
    {
        private readonly IUsersRepository _UsersRepository;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUsersRepository UsersRepository, IMapper mapper)
        {
            _UsersRepository = UsersRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(LoginUserDto request, CancellationToken cancellationToken)
        {
            //Users user = _mapper.Map<Users>(request);
            var token = await _UsersRepository.Login(request);
            return token;
        }
    }
}
