using CursosAPI.Data;
using CursosAPI.Repositories;
using CursosAPI.Repositories.Interface;
using CursosAPI.Services;
using CursosAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connString = builder.Configuration["ConnectionStrings:CursoConnection"];

builder.Services.AddDbContext<CursoContext>(opts => { opts.UseSqlServer(connString); });

builder.Services.AddAutoMapper(cfg => { }, typeof(Program).Assembly);

builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IEstudanteRepository, EstudanteRepository>();
builder.Services.AddScoped<IInscricaoRepository, InscricaoRepository>();

builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IEstudanteService, EstudanteService>();
builder.Services.AddScoped<IInscricaoService, InscricaoService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.MapOpenApi();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
