using MediatR;
using PhoneBook_Application.features.Registration_User.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Application.Contracts
{
    public interface IUserAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<Unit> Register(RegisterUserDto registerUserDto/*, T entity*/);
        Task<object> Login(LoginUserDto loginUserDto/*T entity*/);
    }
}
