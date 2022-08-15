using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneBook_Persistence.Migrations
{
    public partial class Initialseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "phoneBook",
            //    keyColumn: "Id",
            //    keyValue: new Guid("724a4e43-9ab2-48bb-aa3f-7969ec168c19"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: new Guid("232cbdee-71e5-4bd3-b0dc-16572921f765"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { Guid.NewGuid().ToString(), 0, Guid.NewGuid().ToString(), "User@email.com", false, false, null, null, "User".ToUpper(), "123", null, null, false, Guid.NewGuid().ToString(), false, "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { Guid.NewGuid().ToString(), 0, Guid.NewGuid().ToString(), "Admin@email.com", false, false, null, null, "Admin".ToUpper(), "123", null, null, false, Guid.NewGuid().ToString(), false, "Admin" });

            //migrationBuilder.InsertData(
            //    table: "phoneBook",
            //    columns: new[] { "Id", "Name", "PhoneNumber", "UserId" },
            //    values: new object[] { new Guid("f636c143-0241-4bf9-9103-90fc7e046d06"), "test1", "01023456789", new Guid("09b1296f-4b1f-46d1-bd91-a57c01fe12dd") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Users]");
            //migrationBuilder.DeleteData(
            //    table: "phoneBook",
            //    keyColumn: "Id",
            //    keyValue: new Guid("f636c143-0241-4bf9-9103-90fc7e046d06"));

            //migrationBuilder.DeleteData(
            //    table: "Users",
            //    keyColumn: "Id",
            //    keyValue: new Guid("09b1296f-4b1f-46d1-bd91-a57c01fe12dd"));

            //migrationBuilder.InsertData(
            //    table: "Users",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
            //    values: new object[] { new Guid("232cbdee-71e5-4bd3-b0dc-16572921f765"), 0, "2e8a0edc-e72a-4bba-a916-622bd312a0f1", "User@email.com", false, false, null, null, null, "123", null, null, false, "31f5ff7b-5d54-436b-b816-5d402f36edb5", false, "User" });

            //migrationBuilder.InsertData(
            //    table: "phoneBook",
            //    columns: new[] { "Id", "Name", "PhoneNumber", "UserId" },
            //    values: new object[] { new Guid("724a4e43-9ab2-48bb-aa3f-7969ec168c19"), "test1", "01023456789", new Guid("232cbdee-71e5-4bd3-b0dc-16572921f765") });
        }
    }
}
