using Logic.Data;
using Api_Agendate_App.Constantes;
using Api_Agendate_App.Utilidades;
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
            var clientes = dataContext.Clientes.Where(cli => cli.NombreUsuario == username && cli.Contrasenia == password).FirstOrDefault();
            if (clientes == null)
            {
                return null;
            }
            return clientes;
        }
        public APIRespuestas Create(Cliente p_nuevoCliente)
        {
            APIRespuestas respuestas = new APIRespuestas();
            var cliente = dataContext.Clientes.Where(cli => cli.Documento == p_nuevoCliente.Documento).FirstOrDefault();
            if (cliente != null)
            {
                respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                return respuestas;
            }

            dataContext.Clientes.Add(p_nuevoCliente);
            dataContext.SaveChanges();

            return respuestas;
        }

    }
}
