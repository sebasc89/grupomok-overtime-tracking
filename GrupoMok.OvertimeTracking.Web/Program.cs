using AutoMapper;
using GrupoMok.OvertimeTracking.Application.Config;
using GrupoMok.OvertimeTracking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting();

// Configuración de la conexión a la base de datos
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (!string.IsNullOrEmpty(connectionString))
{
    var entorno = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
    connectionString = connectionString.Replace("__DB_CONNECTION_STRING__", Environment.GetEnvironmentVariable("DB_CONNECTION_STRING"));
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
    {
        options.UseSqlServer(connectionString);
    });
}

// Configure dependency inyection
var dependencyInjectionConfig = new DependencyInjectionConfig();
dependencyInjectionConfig.ConfigureServices(builder.Services);

// Configuración Automapper
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var configMapper = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});

var mapper = configMapper.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
}

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
