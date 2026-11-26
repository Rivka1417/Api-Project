using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Org.BouncyCastle.Security;
using repository;
using repository.Entity;
using Service;
var builder = WebApplication.CreateBuilder(args);

//private readonly ILogger<Program> _logger;
//public Program(ILogger<Program> logger)
//{
//    _logger= logger;
//}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddScoped<IPasswordService, PasswordService>();


builder.Services.AddDbContext<MyStoreContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("home")),ServiceLifetime.Transient);

builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseStaticFiles();

app.Run();
