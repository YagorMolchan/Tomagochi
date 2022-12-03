using Tomagochi.DAL.EFCore;
using Tomagochi.DAL.Interfaces;
using Tomagochi.DAL.Repositories;
using Tomagochi.BLL.Profiles;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tomagochi.DAL.Entities;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<TomagochiDbContext>(
    options => options.UseSqlServer(connectionString)
);

builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", options => options
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddTransient<IRepositoryBase<Pet>, RepositoryBase<Pet>>();
builder.Services.AddTransient<IRepositoryBase<User>, RepositoryBase<User>>();
builder.Services.AddTransient<IPetRepository, PetRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile<PetProfile>();
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
