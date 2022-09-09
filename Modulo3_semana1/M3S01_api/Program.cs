using Microsoft.EntityFrameworkCore;
using M3S01_api.Context;
using M3S01_api.Models;
using M3S01_api.Repositories;
using M3S01_api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ShowDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ServerConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//DI Para Services
builder.Services
    .AddScoped<IBandaService, BandaService>()
    .AddScoped<IEventoService, EventoService>();

//DI Para Repositories
builder.Services
    .AddScoped<IBandaRepository<BandaModel>, BandaRepository>()
    .AddScoped<IEventoRepository<EventoModel>, EventoRepository>();

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