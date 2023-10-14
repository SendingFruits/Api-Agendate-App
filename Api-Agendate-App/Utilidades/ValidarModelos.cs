﻿using Api_Agendate_App.Models;
using System.Text.RegularExpressions;

namespace Api_Agendate_App.Utilidades
{
    public class ValidarModelos
    {


        public void Usuario(UsuarioDTO Usu)
        {
            try
            {
                if (Usu.NombreUsuario.Trim().Length != 20 || Usu.NombreUsuario.Trim().Length == 0)
                {
                    throw new Exception("No puede colocar el nombreUsuario vacio, o mayor a 20 caracteres");
                }
                if (!Regex.IsMatch(Usu.Contrasenia.Trim(), @"^[A-Za-z]{4}[0-9]{4}$"))
                {
                    throw new Exception("Error en contraseña, debe cumplir 4 letras y 4 numeros. ");
                }

                if (!Regex.IsMatch(Usu.Celular.Trim(), @"^[0-9]{9}"))
                {
                    throw new Exception("Sólo puede ingresar números");
                }
                if (!Regex.IsMatch(Usu.Correo.Trim(), "%[A-z0-9][@][A-z]%[.][A-z]%"))
                {
                    throw new Exception("Error en el correo, no cumple con las caracteristicas de un correo valido ");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void Cliente(ClienteDTO Cliente)
        {
            if (Cliente.documento.ToString().Length != 8)
            { throw new Exception("El documento debe tener un largo de 8 caracteres"); }

        }

        public void Empresa(EmpresaDTO Empresa) 
        {
            if (Empresa.RutDocumento.ToString().Length != 12)
            { throw new Exception("Error!! el rut debe ter un largo maxiomo de 12 caracteres"); }
            if (Empresa.RutDocumento.ToString()=="000000000000")
            { throw new Exception("Error en rut "); }
        }

        public void Promociones(PromocionDTO promociones) 
        { 
            if (promociones.fechaInicio != DateTime.Now) { throw new Exception("La fecha de creación debe ser del día de Hoy "); }
        }

        public void Reserva(ReservaDTO Reserva)
        { 
            if (Reserva.cliente == null) { throw new Exception("No se puede generar una reserva sin un Cliente"); }

            if(Reserva.servicio== null) { throw new Exception("No se puede generar una reserva sin un servicio"); }
        }

        public void Servicio(ServicioDTO Servicio) 
        { 
            if (Servicio.FechaInicio.ToString()=="") 
            { throw new Exception("Debe colocar una fecha válida"); }

            if (Servicio.FechaFin.ToString()=="")
            { throw new Exception("Debe colocar una fecha válida"); }

            
        }

        public void Agenda(AgendaDTO Agenda) { }



    }
}
