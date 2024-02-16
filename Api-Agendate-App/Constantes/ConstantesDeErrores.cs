using Microsoft.Identity.Client;
using System.ComponentModel;

namespace Api_Agendate_App.Constantes
{
    public class ConstantesDeErrores
    {   
        public const int ErrorEntidadExistente = 1001;
        public const int ErrorInsertandoEntidad = 1002;
        public const int ErrorEntidadInexistente = 1003;

        #region Clientes 1101 al 1200 -> ...
        public const int ErrorClienteConDocumentoExistente = 1101;
        public const int ErrorClienteConUsuarioExistente = 1102;
        public const int ErrorInesperadoActualizarCliente = 1103;
        public const int ErrorInesperadoRegistrarCliente = 1104;
        public const int ErrorInesperadoEliminarCliente = 1105;
        public const int ErrorClienteConIdNoEncontrado = 1106;
        #endregion

        #region Empresas 1201 al 1300 -> ...
        public const int ErrorEmpresaConDocumentoExistente = 1201;
        public const int ErrorEmpresaConUsuarioExistente = 1202;
        public const int ErrorInesperadoActualizarEmpresa = 1203;
        public const int ErrorInesperadoRegistrarEmpresa = 1204;
        public const int ErrorInesperadoEliminarEmpresa = 1205;
        public const int ErrorEmpresaNoEncontrada = 1206;
        #endregion

        #region Usuarios 1301 al 1400 -> ...
        public const int ErrorInesperadoActualizarUsuario = 1301;
        public const int ErrorInesperadoRegistrarUsuario = 1302;
        public const int ErrorInesperadoEliminarUsuario = 1303;
        public const int ErrorInesperadoActualizarContrasenia = 1304;
        public const int ErrorContraseniaViejaNoCoincide = 1305;
        #endregion

        #region Servicios 1401 al 1500 -> ...
        public const int ErrorYaExisteElNombreDelServicio = 1401;
        public const int ErrorServicioNoEncontrado = 1402;
        public const int ErrorDiasDefinidosServicioNoMatcheaFechaReserva = 1403;
        public const int ErrorServicioConIdNoEncontrado = 1404;
        #endregion

        #region Horarios y Reservas 1501 al 1600 -> ...
        public const int ErrorYaExisteTurnoReservado = 1501;
        public const int ErrorInesperadoAlObtenerHorariosSegunFecha = 1502;
        public const int ErrorNoExistenReservasParaLaFechaDada = 1503;
        public const int ErrorNoExistenReservasParaElIdCliente = 1504;
        public const int ErrorNoHayHorariosDisponiblesParaLaFecha = 1505;
        public const int ErrorNoExisteReservaSegunId = 1506;
        public const int ErrorLaReservaYaEstaCancelada = 1507;
        public const int ErrorLaReservaYaEstaRealizada = 1508;
        public const int ErrorLaReservaYaEstaRechazada = 1509;
        public const int ErrorLaReservaYaTieneEseEstado = 1510;
        public const int ErrorEmpresasNoPuedenCancelarReservas = 1511;
        public const int ErrorEstadoIngresadoNoEsCorrecto = 1512;
        public const int ErrorTurnoReservaAntiguoAlCancelar = 1513;
        public const int ErrorInesperadoAlCancelarReserva = 1514;
        public const int ErrorInesperadoAlCambiarEstadoReserva = 1515;
        public const int ErrorCrearReservaTurnoSeleccionadoVencido = 1516;
        public const int ErrorHorarioTurnoNoEstaDentroDelRangoHorarioServicio = 1517;
        #endregion\

        #region Mensajeria 1601 al 1700 -> ...
        public const int ErrorInesperadoEnviarMensaje = 1601;
        #endregion

        #region Favoritos 1701 al 1800 -> ...
        public const int ErrorFavoritoYaExistente = 1701;
        public const int ErrorFavoritoConIdInexistente = 1702;
        #endregion

        #region Promociones 1801 al 1900
        public const int ErrorInesperadoAlCrearPromocion = 1801;
        public const int ErrorInesperadoAlEliminarPromocion = 1802;
        public const int ErrorInesperadoAlModificarPromocion = 1803;
        public const int ErrorInesperadoAlEnviarPromocion = 1804;
        public const int ErrorPromocionConIdNoEncontrada = 1805;
        public const int ErrorYaExisteElNombreDelaPromocion = 1806;
        #endregion

        #region Errores Generales 2000 al 3000 -> ...
        public const int ErrorClaveViejaIngresadaConfirmarVacia = 2001;
        public const int ErrorClaveNuevaIngresadaConfirmarVacia = 2002;
        public const int ErrorCredencialesIncorrectas = 2003;
        public const int ErrorInesperadoAlGenerarContraseniaRecuperacion = 2004;
        #endregion

        public const int ErrorEntidadesInexistentes = 5000;
        public const int ErrorInsertandoEntidades = 50001;

        public static string DevolverMensaje(int codigoError)
        {
            string mensaje = "";

            if (codigoError == 0) return "Exito";

            #region Errores por entidad (Singular) --> ...
            if (codigoError >= 1001 && codigoError <= 1100)
            {
                switch (codigoError)
                {
                    case ErrorEntidadExistente:
                        mensaje = "La entidad a crear ya existe en el sistema";
                        break;
                    case ErrorInsertandoEntidad:
                        mensaje = "Error: insertando la entidad en el sistema";
                        break;
                    case ErrorEntidadInexistente:
                        mensaje = "La entidad no existe";
                        break;
                }
            }
            #endregion

            #region Errores de Clientes --> ...
            else if (codigoError >= 1101 && codigoError <= 1200)
            {
                switch (codigoError)
                {
                    case ErrorClienteConDocumentoExistente:
                        mensaje = "Ya existe un usuario con el documento de identidad ingresado";
                        break;
                    case ErrorClienteConUsuarioExistente:
                        mensaje = "Ya existe un Cliente con el nombre de usuario ingresado";
                        break;
                    case ErrorInesperadoActualizarCliente:
                        mensaje = "Ocurrio un error inesperado al intentar actualizar sus datos";
                        break;
                    case ErrorInesperadoRegistrarCliente:
                        mensaje = "Ocurrio un error inesperado al intentar registrarse";
                        break;
                    case ErrorInesperadoEliminarCliente:
                        mensaje = "Ocurrio un error inesperado al intentar eliminar su cuenta";
                        break;
                    case ErrorClienteConIdNoEncontrado:
                        mensaje = "No existe el cliente con el Id ingresado";
                        break;
                }
            }
            #endregion

            #region Errores de Empresas --> ...
            else if (codigoError >= 1201 && codigoError <= 1300)
            {
                switch (codigoError)
                {
                    case ErrorEmpresaConDocumentoExistente:
                        mensaje = "Ya existe una Empresa con el RUT ingresado";
                        break;
                    case ErrorEmpresaConUsuarioExistente:
                        mensaje = "Ya existe una Empresa con el nombre de usuario ingresado";
                        break;
                    case ErrorInesperadoActualizarEmpresa:
                        mensaje = "Ocurrio un error inesperado al intentar actualizar sus datos";
                        break;
                    case ErrorInesperadoRegistrarEmpresa:
                        mensaje = "Ocurrio un error inesperado al intentar registrarse";
                        break;
                    case ErrorInesperadoEliminarEmpresa:
                        mensaje = "Ocurrio un error inesperado al intentar eliminar su cuenta";
                        break;
                    case ErrorEmpresaNoEncontrada:
                        mensaje = "La empresa no existe";
                        break;
                }
            }
            #endregion

            #region Errores de Usuarios --> ...
            else if (codigoError >= 1301 && codigoError <= 1400)
            {
                switch (codigoError)
                {
                    case ErrorInesperadoActualizarUsuario:
                        mensaje = "Ocurrio un error inesperado al intentar actualizar sus datos";
                        break;
                    case ErrorInesperadoRegistrarUsuario:
                        mensaje = "Ocurrio un error inesperado al intentar registrarse";
                        break;
                    case ErrorInesperadoEliminarUsuario:
                        mensaje = "Ocurrio un error inesperado al intentar eliminar su cuenta";
                        break;
                    case ErrorContraseniaViejaNoCoincide:
                        mensaje = "La contraseña vieja ingresada no coincide con la del usuario";
                        break;
                    case ErrorInesperadoActualizarContrasenia:
                        mensaje = "Error:  inesperado al intentar actualizar la contraseña";
                        break;
                }
            }
            #endregion

            #region Errores de Servicios

            else if (codigoError >= 1401 && codigoError <= 1500)
            {
                switch(codigoError)
                {
                    case ErrorYaExisteElNombreDelServicio:
                        mensaje = "Error: ya existe un servicio creado con ese nombre";
                        break;
                    case ErrorServicioNoEncontrado:
                        mensaje = "Error: El servicio con la id asociada no fue encontrado";
                        break;
                    case ErrorDiasDefinidosServicioNoMatcheaFechaReserva:
                        mensaje = "El servicio no esta disponible para el dia en que se quiere hacer la reserva";
                        break;
                    case ErrorServicioConIdNoEncontrado:
                        mensaje = "El servicio con el ID asociado no fue encontrado.";
                        break;
                }
            }

            #endregion

            #region Errores de Horarios y reservas

            else if (codigoError >= 1501 && codigoError <= 1600)
            {
                switch (codigoError)
                {
                    case ErrorYaExisteTurnoReservado:
                        mensaje = "El turno a reservar ya existe para el servicio.";
                        break;
                    case ErrorInesperadoAlObtenerHorariosSegunFecha:
                        mensaje = "Error inesperado al obtener los horarios segun la fecha";
                        break;
                    case ErrorNoExistenReservasParaLaFechaDada:
                        mensaje = "No existen reservas para la fecha seleccionada.";
                        break;
                    case ErrorNoExistenReservasParaElIdCliente:
                        mensaje = "No existen reservas registradas.";
                        break;
                    case ErrorNoHayHorariosDisponiblesParaLaFecha:
                        mensaje = "No hay horarios disponibles para la fecha seleccionada.";
                        break;
                    case ErrorNoExisteReservaSegunId:
                        mensaje = "No existe la reserva con el Id enviado";
                        break;
                    case ErrorLaReservaYaEstaCancelada:
                        mensaje = "La reserva ya se encuentra cancelada y no se puede modificar.";
                        break;
                    case ErrorLaReservaYaEstaRealizada:
                        mensaje = "La reserva ya se encuentra realizada y no se puede modificar.";
                        break;
                    case ErrorLaReservaYaEstaRechazada:
                        mensaje = "La reserva ya se encuentra rechazada y no se puede modificar.";
                        break;
                    case ErrorLaReservaYaTieneEseEstado:
                        mensaje = "La reserva tiene el mismo estado al que se le quiere modificar";
                        break;
                    case ErrorEmpresasNoPuedenCancelarReservas:
                        mensaje = "Solo los clientes pueden cancelar reservas. Las empresas deben rechazarlas";
                        break;
                    case ErrorEstadoIngresadoNoEsCorrecto:
                        mensaje = "El estado ingresado para modificar no es correcto.";
                        break;
                    case ErrorTurnoReservaAntiguoAlCancelar:
                        mensaje = "La hora del turno ya expiró, no se puede cancelar la reserva.";
                        break;
                    case ErrorInesperadoAlCancelarReserva:
                        mensaje = "Error inesperado al cancelar la reserva.";
                        break;
                    case ErrorInesperadoAlCambiarEstadoReserva:
                        mensaje = "Error inesperado al cambiar el estado de la reserva.";
                        break;
                    case ErrorCrearReservaTurnoSeleccionadoVencido:
                        mensaje = "El turno que se desea reserva ya expiró. La fecha actual es mayor al turno.";
                        break;
                    case ErrorHorarioTurnoNoEstaDentroDelRangoHorarioServicio:
                        mensaje = "Error: El horario seleccionado para el turno no esta dentro del rango de horario del servicio.";
                        break;
                }
            }


            #endregion

            #region Errores de Mensajeria
            else if (codigoError >= 1601 && codigoError <= 1700)
            {
                switch (codigoError)
                {
                    case ErrorInesperadoEnviarMensaje:
                        mensaje = "Error inesperado al intentar enviar el mensaje";
                        break;
                }
            }
            #endregion

            #region Errores de Favoritos
            else if (codigoError >= 1701 && codigoError <= 1800)
            {
                switch (codigoError)
                {
                    case ErrorFavoritoYaExistente:
                        mensaje = "El servicio ya se encuentra en los favoritos";
                        break;
                    case ErrorFavoritoConIdInexistente:
                        mensaje = "El favorito que se intenta modificar no fue encontrado";
                        break;
                    
                }
            }
            #endregion

            #region Errores de Promociones
            else if (codigoError >= 1801 && codigoError <= 1900)
            {
                switch (codigoError)
                {
                    case ErrorInesperadoAlCrearPromocion:
                        mensaje = "Error inesperado al crear la promoción";
                        break;
                    case ErrorInesperadoAlEliminarPromocion:
                        mensaje = "Error inesperado al eliminar la promoción";
                        break;
                    case ErrorInesperadoAlModificarPromocion:
                        mensaje = "Error inesperado al modificar la promoción";
                        break;
                    case ErrorInesperadoAlEnviarPromocion:
                        mensaje = "Error inesperado al enviar la promoción";
                        break;
                    case ErrorPromocionConIdNoEncontrada:
                        mensaje = "La promoción con la ID enviada no fue encontrada.";
                        break;
                    case ErrorYaExisteElNombreDelaPromocion:
                        mensaje = "Ya existe una promoción con el nombre ingresado";
                        break;
                }
            }
            #endregion

            #region Errores generales
            else if (codigoError >= 2001 && codigoError <= 3000)
            {
                switch (codigoError)
                {
                    case ErrorClaveViejaIngresadaConfirmarVacia:
                        mensaje = "La clave vieja ingresada no puede ser vacía";
                        break;
                    case ErrorClaveNuevaIngresadaConfirmarVacia:
                        mensaje = "La clave nueva ingresada no puede ser vacía";
                        break;
                    case ErrorCredencialesIncorrectas:
                        mensaje = "Las credenciales ingresadas no son correctas";
                        break;
                    case ErrorInesperadoAlGenerarContraseniaRecuperacion:
                        mensaje = "Error inesperado al intentar generar la contraseña de recuperación";
                        break;
                }

            }
            #endregion

            else if (codigoError >= 5000 && codigoError <= 6000)
            {
                switch (codigoError)
                {
                    case ErrorEntidadesInexistentes:
                        mensaje = "Error no existen entidades en el sistema";
                        break;
                    case ErrorInsertandoEntidades:
                        mensaje = "Error insertando entidad en el sistema";
                        break;
                }

            }
            return mensaje;
        }
    }

}
