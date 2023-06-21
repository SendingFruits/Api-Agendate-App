using Logic.Data;
using Logic.Entities;

namespace Api_Agendate_App.Services
{
    public class ClientesService
    {
        private readonly Logic.Data.DataContext dataContext;
        public ClientesService(Logic.Data.DataContext p_dataContext)
        {
            dataContext = p_dataContext;
        }


        public Cliente Login (string username, string password) 
        {
            var clientes = dataContext.Clientes.Where(cli=> cli.NombreUsuario== username&& cli.Contrasenia== password).FirstOrDefault();
            if (clientes == null)
            {
                return null;
            }
            return clientes;
        }

    }
}
