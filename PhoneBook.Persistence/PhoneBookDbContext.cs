using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneBook_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook_Persistence
{
    public class PhoneBookDbContext : IdentityDbContext<Users>
    {
        public PhoneBookDbContext(DbContextOptions<PhoneBookDbContext> options)
           : base(options)
        {
        }

        //create table in database with this table name(PhoneBooks)
        public DbSet<Users> users { get; set; }
        public DbSet<PhoneBook> phoneBook { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //var userGuid = Guid.NewGuid();
            //var phoneBookGuid = Guid.NewGuid();

            //modelBuilder.Entity<Users>().HasData(new Users 
            //{
            //    Id = userGuid,
            //    UserName = "User",
            //    Email = "User@email.com",
            //    Password = "123"
            //});

            //modelBuilder.Entity<PhoneBook>().HasData(new PhoneBook
            //{
            //    Id = phoneBookGuid,
            //    Name = "test1",
            //    PhoneNumber = "01023456789",
            //    UserId = userGuid
            //});

        }
    }
}
