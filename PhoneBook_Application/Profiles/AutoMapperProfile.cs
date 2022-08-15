using AutoMapper;
using PhoneBook_Api;
using PhoneBook_Application.features.Phone_Book.Commands.CreatePhoneBook;
using PhoneBook_Application.features.Phone_Book.Commands.DeletePhoneBook;
using PhoneBook_Application.features.Phone_Book.Commands.UpdatePhoneBook;
using PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookDetails;
using PhoneBook_Application.features.Phone_Book.Queries.GetPhoneBookList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PhoneBook, GetPhoneBookListViewModel>().ReverseMap();
            CreateMap<PhoneBook, GetPhoneBookDetailsViewModel>().ReverseMap();
            CreateMap<Users, UsersDTO>().ReverseMap();
            CreateMap<PhoneBook, CreatePhoneBookCommand>().ReverseMap();
            CreateMap<PhoneBook, UpdatePhoneBookCommand>().ReverseMap();
            CreateMap<PhoneBook, DeletePhoneBookCommand>().ReverseMap();
        }
    }
}
