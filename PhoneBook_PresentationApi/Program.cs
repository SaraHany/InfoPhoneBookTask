using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PhoneBook_Api;
using PhoneBook_Application;
using PhoneBook_Application.features.Phone_Book.Commands.CreatePhoneBook;
using PhoneBook_Application.features.Phone_Book.Commands.UpdatePhoneBook;
using PhoneBook_Application.features.Registration_User.Command;
using PhoneBook_Persistence;
using PhoneBook_PresentationApi.Endpoint.PhoneBook.Queries;
using PhoneBook_PresentationApi.Helpers;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<PhoneBookDbContext>()/*.AddDefaultTokenProviders()*/;

builder.Services.AddApplicationServices();

//map data of jwt from appsetting to class jwt
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        //ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        //ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});


builder.Services.AddDbContext<DbContext>();
builder.Services.AddIdentityCore<Users>();
builder.Services.AddHttpContextAccessor();
builder.Services.Configure<ClaimsIdentityOptions>(x => x.UserIdClaimType = ClaimTypes.NameIdentifier);

builder.Services.AddAuthorization();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();

var app = builder.Build();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.MapGet("/GetPhoneBook", () => { });
//app.MapGet("/GetByIdPhoneBook/{id}", (Guid id) => { });
//app.MapGet("/GetByUserIdPhoneBook/{id}", (Guid id) => { });
//app.MapPost("/CreatePhoneBook", ([FromBody] CreatePhoneBookCommand createPhoneBookCommand) => { });
//app.MapPut("/UpdatePhoneBook", ([FromBody] UpdatePhoneBookCommand updatePhoneBookCommand) => { });
//app.MapDelete("/DeletePhoneBook/{id}", (Guid id) => { });
//app.MapPost("/Register", ([FromBody] RegisterUserDto registerUserDTO) => { });
//app.MapPost("/Login", ([FromBody] LoginUserDto loginUserDTO) => { });



//app.MapGet("/api/home", (Func<string>)(() => "Hello"));


//var summaries = new[]
//{
//    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//};

//app.MapGet("/weatherforecast", () =>
//{
//    var forecast = Enumerable.Range(1, 5).Select(index =>
//        new WeatherForecast
//        (
//            DateTime.Now.AddDays(index),
//            Random.Shared.Next(-20, 55),
//            summaries[Random.Shared.Next(summaries.Length)]
//        ))
//        .ToArray();
//    return forecast;
//})
//.WithName("GetWeatherForecast");

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//});

app.MapControllers();
app.UseHttpsRedirection();

app.Run();

//internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
//{
//    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
//}