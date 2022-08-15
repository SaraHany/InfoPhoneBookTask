﻿using AutoMapper;
using MediatR;
using PhoneBook_Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookByUserID
{
    public class GetPhoneBookByUserHandler : IRequestHandler<GetPhoneBookByUserQuery, List<GetPhoneBookByUserViewModel>>
    {
        private readonly IPhoneBookRepository _phoneBookRepository;
        private readonly IMapper _mapper;

        public GetPhoneBookByUserHandler(IPhoneBookRepository phoneBookRepository, IMapper mapper)
        {
            _phoneBookRepository = phoneBookRepository;
            _mapper = mapper;
        }

        public async Task<List<GetPhoneBookByUserViewModel>> Handle(GetPhoneBookByUserQuery request, CancellationToken cancellationToken)
        {
            //true to get PhoneBook
            var allPhoneBook = await _phoneBookRepository.GetPhoneBookByUserIdAsync(request.UserId/*, true*/);
            return _mapper.Map<List<GetPhoneBookByUserViewModel>>(allPhoneBook);
        }
    }
}
