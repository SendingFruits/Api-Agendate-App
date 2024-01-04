using Microsoft.EntityFrameworkCore;
using Logic.Data;
using Api_Agendate_App.Services;
using Api_Agendate_App.Constantes;
using Repositorio.EntidadesDeRepositorio;
using Repositorio.IRepositorio;
using Repositorio;
using Repositorio.Interfases;
using Api_Agendate_App.Utilidades;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;

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
builder.Services.AddScoped<MensajeriaService>();
builder.Services.AddScoped<PromocionesService>();
builder.Services.AddScoped<ReservasService>();
builder.Services.AddScoped<ServiciosService>();
builder.Services.AddScoped<UsuariosService>();

//Implementacion JWT
//todo esto es para obtener nuestra clave secreta y convertirla en byte
builder.Configuration.AddJsonFile("appsettings.json");
var secretKey = builder.Configuration.GetSection("settings").GetSection("secretkey").ToString();
var keyBytes= Encoding.UTF8.GetBytes(secretKey);
//hasta aca 
//aqui implementa Jwt
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        //Una validacion por usuario
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/usuarios/LoginUsuario";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

//Repositorios
builder.Services.AddScoped<IUsuario, UsuarioRepositorio>();
builder.Services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddScoped<IEmpresa, EmpresaRepositorio>();
builder.Services.AddScoped<INotificaciones, NotificacionRepositortio>();
builder.Services.AddScoped<IServicios, ServicioRepositorios>();
var app = builder.Build();


//Para migrar los cambios a una base de datos, la primera vez que se ejecute la API.
//Tambien aplica si la base de datos que tenemos creada en el motor, no tiene ninguna tabla.
//Con este Using, creara las tablas segun el DataContext y/o aplicara los cambios nuevos o los de las migrations.
//En caso que existan las mismas en la carpeta del proyecto. 


//Para iniciar una base de datos la primera vez que se ejecute el proyecto.

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



app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{contoller=Usuarios}/{action=LoginUsuario}/{NombreUsuaro?}") ;
app.MapControllers();

app.Run();
   
