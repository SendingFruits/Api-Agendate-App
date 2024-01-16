﻿using Api_Agendate_App.DTOs.Servicio;

namespace Api_Agendate_App.DTOs.Reservas
{
    public class ReservaDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaHoraTurno { get; set; }
        public string Estado { get; set; }
    }

    public class ReservasDeEmpresasDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaHoraTurno { get; set; }
        public string Estado { get; set; }
        public string NombreCliente { get; set; }

        public string ApellidoCliente { get; set; }

        public string CorreoCliente { get; set; }

        public string CelularCliente { get; set; }
    }

    public class ReservasDeClientesDTO
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdServicio { get; set; }
        public DateTime FechaHoraTurno { get; set; }
        public string Estado { get; set; }
        public string NombreServicio { get; set; }

        public string NombreEmpresa { get; set; }
    }
}
