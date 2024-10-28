using Microsoft.EntityFrameworkCore;
using ApiEmpresa.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Conexiones>(opt =>
opt.UseMySQL(builder.Configuration.GetConnectionString("Conexiones") ?? throw new InvalidOperationException("Connection string 'Conexiones' not found.")));
// Add services to the container.
string? cadena = builder.Configuration.GetConnectionString("DefaultConnection") ??"otracadena";
builder.Services.AddControllers();
builder.Services.AddDbContext<Conexiones>(opt =>
      opt.UseMySQL(cadena));
    //opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // Esto es para sqlserver
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

app.Run();
