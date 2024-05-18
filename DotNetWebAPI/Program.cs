using DotNetWebAPI.Models;
using DotNetWebAPI.Models.DataManager;
using DotNetWebAPI.Models.Entites;
using DotNetWebAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Register the DbContext
builder.Services.AddDbContext<ApplicationDbContext>(
    option=>option.UseSqlServer(builder.Configuration.GetConnectionString("default"))
);

//Registering the DataManagers
builder.Services.AddScoped<IDataRepository<Product>, ProductDataManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
