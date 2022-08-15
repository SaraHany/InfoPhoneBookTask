using AutoMapper;
using MediatR;
using PhoneBook_Api;
using PhoneBook_Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Commands.DeletePhoneBook
{
    public class DeletePhoneBookCommandHandler : IRequestHandler<DeletePhoneBookCommand>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;

        public DeletePhoneBookCommandHandler(IPhoneBookRepository phoneBookRepository)
        {
            _phoneBookRepository = phoneBookRepository;
        }

        public async Task<Unit> Handle(DeletePhoneBookCommand request, CancellationToken cancellationToken)
        {
            var phoneBook = await _phoneBookRepository.GetByIdAsync(request.PhoneBookId);
            await _phoneBookRepository.DeleteAsync(phoneBook);
            return Unit.Value;
        }
    }
}
