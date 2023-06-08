using Microsoft.EntityFrameworkCore;
using Logic.Data;

var builder = WebApplication.CreateBuilder(args);

//Configuracion servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Injeccion de servicios
///Aca va el apartado de la carpeta Services

//Configurar el contexto de la base de datos
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BdConnectionString")));

var app = builder.Build();

//Para migrar los cambios a una base de datos, la primera vez que se ejecute la API.
using (var scope = app.Services.CreateScope())
{
    var Context = scope.ServiceProvider.GetRequiredService<DataContext>();
    Context.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
