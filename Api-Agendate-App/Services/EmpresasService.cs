﻿using Api_Agendate_App.Constantes;
using Api_Agendate_App.Utilidades;
using Logic.Entities;

namespace Api_Agendate_App.Services
{
    public class EmpresasService
    {
        private readonly Logic.Data.DataContext dataContext;

        public EmpresasService(Logic.Data.DataContext p_dataContext)
        {
            dataContext = p_dataContext;
        }

        public APIRespuestas Create(Empresa nuevaEmpresa)
        {
            APIRespuestas respuestas = new APIRespuestas();
            var empresas = dataContext.Empresas.Where(emp => emp.RutDocumento == nuevaEmpresa.RutDocumento).FirstOrDefault();
            if (empresas != null)
            {
                respuestas.codigo = ConstantesDeErrores.ErrorEntidadExistente;
                return respuestas;
            }

            dataContext.Empresas.Add(nuevaEmpresa);
            dataContext.SaveChanges();

            return respuestas;
        }
    }
}
