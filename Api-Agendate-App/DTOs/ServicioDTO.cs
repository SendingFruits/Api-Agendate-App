﻿namespace Api_Agendate_App.DTOs
{
    public class ServicioDTO
    {
        public string Nombre { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin { get; set; }

        public string DiasDefinidos { get; set; }

        public int DuracionTurno { get; set; }

        public string TipoServicio { get; set; }

        public decimal? Costo { get; set; }

        public string Descripcion { get; set; }

        public int FrecuenciaRealizacion { get; set; }

        public DateTime UltimaFecha { get; set; }

        public int IdEmpresa {get; set;}

    }
}
