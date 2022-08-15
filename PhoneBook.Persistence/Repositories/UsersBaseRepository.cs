using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PhoneBook_Api;
using PhoneBook_Application.Contracts;
using PhoneBook_Application.Contracts.Persistence;
using PhoneBook_Application.features.Registration_User.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace PhoneBook_Persistence.Repositories
{
    public partial class UsersBaseRepository<T> : IUserAsyncRepository<T> where T : class
    {
        protected readonly PhoneBookDbContext _dbContext;
        private readonly UserManager<Users> _userManager;
        private readonly IConfiguration config;

        public UsersBaseRepository(UserManager<Users> userManager, IConfiguration configuration,PhoneBookDbContext dbContext)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            config = configuration;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<Unit> Register(RegisterUserDto registerUserDto/*, T entity*/)
        {
            //if (ModelState.IsValid)
            //{
            Users user = new Users();
            user.UserName = registerUserDto.UserName;
            user.Email = registerUserDto.Email;
            //user.Password = registerUserDto.Password;
            IdentityResult result = await _userManager.CreateAsync(user, registerUserDto.Password);
            //if (!result.Succeeded)
            //{
                return Unit.Value;
            //}
            //}
        }

        public async Task<object> Login(LoginUserDto loginUserDto/*,T entity*/)
        {
            Users user = await _userManager.FindByEmailAsync(loginUserDto.Email);
            if(user != null)
            {
                bool found= await _userManager.CheckPasswordAsync(user, loginUserDto.Password);
                if(found)
                {
                    var claim = new List<Claim>();
                    claim.Add(new Claim(ClaimTypes.Email, user.Email));
                    claim.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

                    var roles= await _userManager.GetRolesAsync(user);
                    foreach(var itemrole in roles)
                    {
                        claim.Add(new Claim(ClaimTypes.Role, itemrole));
                    }

                    SecurityKey securityKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]));
                    SigningCredentials signingCredential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    JwtSecurityToken mytoken = new JwtSecurityToken(
                        issuer: config["JWT:ValidIssuer"],
                        audience: config["JWT:ValidAudience"],
                        claims: claim,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: signingCredential
                        );
                    return new {
                        token = new JwtSecurityTokenHandler().WriteToken(mytoken),
                        expiration = mytoken.ValidTo,
                    };
                }
                return null;
            }
            return null;
        }
    }
}
