using Microsoft.EntityFrameworkCore;
using Repositeries;
using Repositeries.Models;
using Service;
using WebApiShop.Controllers;
var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped<IUserRipository, UserRipository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserPasswordService, UserPasswordService>();
builder.Services.AddDbContext<Store_215962135Context>(options => options.UseSqlServer
("Data Source=localhost;Initial Catalog=MySiteDB; Integrated Security= True; Pooling=False"));




builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
