using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using poc.api.cqrs.mediator.Application.CommandHandlers;
using poc.api.cqrs.mediator.Application.Services;
using poc.api.cqrs.mediator.Application.Services.Interfaces;
using poc.api.cqrs.mediator.Domain.Commands;
using poc.api.cqrs.mediator.Domain.Interfaces;
using poc.api.cqrs.mediator.Infrastructure.Contexts.DBContext;
using poc.api.cqrs.mediator.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


var services = builder.Services;
// Add services to the container.

services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


services.AddScoped<IAccountMongoRepository, AccountMongoRepository>();
services.AddScoped<IAccountRepository, AccountRepository>();

services.AddScoped<IAccountService, AccountService>();

services.AddSingleton<IMongoClient>(sp => new MongoClient("mongodb://localhost:27017/"));
services.AddScoped<IMongoDatabase>(sp =>
    sp.GetRequiredService<IMongoClient>().GetDatabase("local.accounts"));


services.AddScoped<PocMongoContext>();

services.AddDbContext<PocContext>(options =>
    options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=poc;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"));


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = Assembly.GetEntryAssembly()?.GetName()?.Name + String.Empty,
        Description = "Poc com uso de CQRS e Mediator",
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();