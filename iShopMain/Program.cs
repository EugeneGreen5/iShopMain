using Duende.IdentityServer.Models;
using iShopMain.Data;
using iShopMain.Models.Entity.UserInfo;
using iShopMain.Repositories;
using iShopMain.Repositories.User;
using iShopMain.Services;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString)); // ������ ��

builder.Services.AddDatabaseDeveloperPageExceptionFilter(); // ��������� ����������, ��������� � ��, ������� ����� ������ � ������� ��������

builder.Services.AddControllers();

builder.Services.AddScoped<ApplicationDbContext>();


builder.Services.AddScoped<IRepository<AppUser>, UserRepository>();
builder.Services.AddScoped<IRepository<Account>, AccountRepository>();
builder.Services.AddScoped<IRepository<Information>, InformationRepository>();
builder.Services.AddScoped<IService, UserService>();




var app = builder.Build();

app.MapControllers();


app.MapGet("/", () => "Hello World!");

app.UseStaticFiles();


app.Run();