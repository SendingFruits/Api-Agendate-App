using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Logic.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


//Configuracion servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injeccion de servicios
///Aca va el apartado de la carpeta Services
///

//Configurar el contexto de la base de datos
builder.Services.AddScoped<DataContext>();


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(DataContext.GetConnectionString());
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
