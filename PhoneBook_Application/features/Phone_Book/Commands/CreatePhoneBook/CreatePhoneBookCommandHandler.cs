using AutoMapper;
using MediatR;
using PhoneBook_Api;
using PhoneBook_Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Commands.CreatePhoneBook
{
                                                                  //input               output:added phoneBook id
    public class CreatePhoneBookCommandHandler : IRequestHandler<CreatePhoneBookCommand, Guid>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;
        private readonly IMapper _mapper;

        public CreatePhoneBookCommandHandler(IPhoneBookRepository phoneBookRepository, IMapper mapper)
        {
            _phoneBookRepository = phoneBookRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreatePhoneBookCommand request, CancellationToken cancellationToken)
        {
            //true to get users
            PhoneBook phoneBook = _mapper.Map<PhoneBook>(request);
            CreatePhoneBookCommandValidator validator = new CreatePhoneBookCommandValidator();
            var result = await validator.ValidateAsync(request);

            if(result.Errors.Any())
            {
                throw new Exception("Not Valid");
            }

            phoneBook = await _phoneBookRepository.AddAsync(phoneBook);
            return phoneBook.PhoneBookId;
        }
    }
}
