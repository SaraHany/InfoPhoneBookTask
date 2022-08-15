using AutoMapper;
using MediatR;
using PhoneBook_Api;
using PhoneBook_Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Registration_User.Command
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserDto, Unit>
    {
        private readonly IUsersRepository _UsersRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUsersRepository UsersRepository, IMapper mapper)
        {
            _UsersRepository = UsersRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(RegisterUserDto request, CancellationToken cancellationToken)
        {
            //true to get phoneBook in include function
            //Users user = _mapper.Map<Users>(request);
            await _UsersRepository.Register(request);
            return Unit.Value;
        }
    }
}
