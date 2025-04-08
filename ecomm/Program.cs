using ecomm.Data.Functions.UserFunctions;
using ecomm.Data.Repositories;
using ecomm.Domain.Interfaces;
using ecomm.Domain.IServices;
using ecomm.Domain.Models;
using ecomm.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IRepositoryGeneric<UserModel>, RepositoryGeneric<UserModel>>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserServices>();
builder.Services.AddScoped<IUserFunctions<UserModel>, UserFunctions>();

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

app.Run();
