using Api_Agendate_App.Constantes;
using Api_Agendate_App.Models;
using Api_Agendate_App.Utilidades;

namespace Api_Agendate_App.Services
{
    public class EmpresasService
    {
        private readonly Logic.Data.DataContext dataContext;

        public EmpresasService(Logic.Data.DataContext p_dataContext)
        {
            dataContext = p_dataContext;
        }

        public Empresa Login(string username, string password)
        {
            var empresas = dataContext.Empresas.Where(empe => empe.NombreUsuario == username && empe.Contrasenia == password).FirstOrDefault();

            if (empresas == null)
            {
                return null;
            }
            return empresas;

        }

        public APIRespuestas Create(EmpresaDTO nuevaEmpresa)
        {
            APIRespuestas respuestas = new APIRespuestas();
            var empresas = dataContext.Empresas.Where(emp => emp.RutDocumento == nuevaEmpresa.RutDocumento).FirstOrDefault();
            if (empresas != null)
            {
                respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                return respuestas;
            }
            //IRepositorio.Create(nuevaEmpresa);


            // dataContext.Empresas.Add(nuevaEmpresa);
            //dataContext.SaveChanges();

            return respuestas;
        }

        public APIRespuestas Update(EmpresaDTO UpdateEmpresa)
        {

            APIRespuestas respuesta = new APIRespuestas();
            var empresa = IEmpresa.Actualizar(UpdateEmpresa);
            if (empresa != null)
            {
                respuesta.codigo = ConstantesDeErrores.Exito;
                return respuesta;
            }
            return respuesta;

        }
        public APIRespuestas Obtener(decimal LongitudCli, decimal latituCli)
        {
            APIRespuestas respuesta= new APIRespuestas();
            var listaEmpresas= IRepositorio obtener(where)

        }



    }
}
