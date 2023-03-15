using Aplicacion.Caracteristicas;
using Aplicacion.Persistencia;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Contexto>(options =>
{
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexion3"),
        (a) => a.MigrationsAssembly("APIREST"));
},
ServiceLifetime.Transient);
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => {
    builder.AllowAnyOrigin()
           .AllowAnyHeader()
           .AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
