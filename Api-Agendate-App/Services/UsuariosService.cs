using Api_Agendate_App.DTOs;
using Logic.Data;
using Logic.Entities;

namespace Api_Agendate_App.Services
{
    public class UsuariosService
    {
        private readonly Logic.Data.DataContext dataContext;

        public UsuariosService(Logic.Data.DataContext p_dataContext) 
        { 
            dataContext = p_dataContext;
        }

        public Cliente Create (Cliente nuevoCliente)
        {
            dataContext.Clientes.Add(nuevoCliente);
            dataContext.SaveChanges();

            return nuevoCliente;
        }

    }
}
