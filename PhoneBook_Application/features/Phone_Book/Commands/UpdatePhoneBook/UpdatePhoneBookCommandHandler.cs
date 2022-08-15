using AutoMapper;
using MediatR;
using PhoneBook_Api;
using PhoneBook_Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Commands.UpdatePhoneBook
{
                                                                 //input
    public class UpdatePhoneBookCommandHandler : IRequestHandler<UpdatePhoneBookCommand>
    {
        private readonly IAsyncRepository<PhoneBook> _phoneBookRepository;
        private readonly IMapper _mapper;

        public UpdatePhoneBookCommandHandler(IAsyncRepository<PhoneBook> phoneBookRepository, IMapper mapper)
        {
            _phoneBookRepository = phoneBookRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePhoneBookCommand request, CancellationToken cancellationToken)
        {
            PhoneBook phoneBook = _mapper.Map<PhoneBook>(request);
            await _phoneBookRepository.UpdateAsync(phoneBook);
            return Unit.Value;
        }
    }
}
