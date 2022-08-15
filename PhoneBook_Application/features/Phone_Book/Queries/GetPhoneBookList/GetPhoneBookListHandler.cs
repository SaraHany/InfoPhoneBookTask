using AutoMapper;
using MediatR;
using PhoneBook_Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookList
{
                                                            //input                     output
    public class GetPhoneBookListHandler : IRequestHandler<GetPhoneBookListQuery, List<GetPhoneBookListViewModel>>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;
        private readonly IMapper _mapper;

        public GetPhoneBookListHandler(IPhoneBookRepository phoneBookRepository, IMapper mapper)
        {
            _phoneBookRepository = phoneBookRepository;
            _mapper = mapper;
        }

        public async Task<List<GetPhoneBookListViewModel>> Handle(GetPhoneBookListQuery request, CancellationToken cancellationToken)
        {
            //true to get users
            var allPhoneBook = await _phoneBookRepository.GetAllPhoneBookAsync(true);
            return _mapper.Map<List<GetPhoneBookListViewModel>>(allPhoneBook);
        }
    }
}
