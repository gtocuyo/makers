using Microsoft.EntityFrameworkCore;
using PrestamosAPI.Application.Interfaces;
using PrestamosAPI.Infrastructure.Persistence;
using PrestamosAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Agregar contexto de base de datos
builder.Services.AddDbContext<PrestamosDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection")));

// Agregar servicio de prestamos
builder.Services.AddScoped<IPrestamoRepository, PrestamoRepository>();

// Agregar controladores
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.MapControllers();

app.Run();