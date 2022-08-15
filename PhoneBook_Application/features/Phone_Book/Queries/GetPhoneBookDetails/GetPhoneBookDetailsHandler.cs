using AutoMapper;
using MediatR;
using PhoneBook_Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookDetails
{
                                                               //input                        output
    public class GetPhoneBookDetailsHandler : IRequestHandler<GetPhoneBookDetailsQuery, GetPhoneBookDetailsViewModel>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;
        private readonly IMapper _mapper;

        public GetPhoneBookDetailsHandler(IPhoneBookRepository phoneBookRepository, IMapper mapper)
        {
            _phoneBookRepository = phoneBookRepository;
            _mapper = mapper;
        }

        public async Task<GetPhoneBookDetailsViewModel> Handle(GetPhoneBookDetailsQuery request, CancellationToken cancellationToken)
        {
            //true to get PhoneBook
            var allPhoneBook = await _phoneBookRepository.GetPhoneBookByIdAsync(request.PhoneBookId/*, true*/);
            return _mapper.Map<GetPhoneBookDetailsViewModel>(allPhoneBook);
        }
    }
}
