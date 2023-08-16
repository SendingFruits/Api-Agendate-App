using Microsoft.EntityFrameworkCore;
using Logic.Data;
using Api_Agendate_App.Services;
using Api_Agendate_App.Constantes;
using Repositorio.EntidadesDeRepositorio;
using Repositorio.IRepositorio;
using Repositorio;
using Repositorio.Interfases;
using Api_Agendate_App.Utilidades;

 var builder = WebApplication.CreateBuilder(args);

 //Configuracion servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();       


//Configurar el contexto de la base de datos
builder.Services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BdConnectionString")));


        //injeccion de Mapper
builder.Services.AddAutoMapper(typeof(MappingConfig));

//Injeccion de servicios
builder.Services.AddScoped<APIRespuestas>();
builder.Services.AddScoped<ClientesService>();
builder.Services.AddScoped<EmpresasService>();
builder.Services.AddScoped<NotificacionesService>();
builder.Services.AddScoped<PromocionesService>();
builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<ServiciosService>();


//Repositorios
builder.Services.AddScoped<IUsuario, UsuarioRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IEmpresa, EmpresaRepositorio>();

builder.Services.AddScoped<IServicios, ServicioRepositorios>();

var app = builder.Build();


//Para migrar los cambios a una base de datos, la primera vez que se ejecute la API.
//Tambien aplica si la base de datos que tenemos creada en el motor, no tiene ninguna tabla.
//Con este Using, creara las tablas segun el DataContext y/o aplicara los cambios nuevos o los de las migrations.
//En caso que existan las mismas en la carpeta del proyecto. 

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
   
