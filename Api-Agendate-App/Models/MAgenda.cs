namespace Api_Agendate_App.Models
{
    public class MAgenda
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public MEmpresas empresaCreadora { get; set; }

        //private MServicio servicioAsociado {get; set;}

        public DateTime fechaCreacion { get; set; }

        public int horaInicio { get; set; }

        public int horaFin { get; set; }

        /// <summary>
        /// La idea seria que sea un arreglo representando los 7 dias de la semana. Donde [0] es lunes y [6] es domingo.
        /// En caso que tenga true en una celda, es porque en ese dia se dispondra la agenda para el servicio en cuestion.
        /// </summary>
        public bool[] diasAgenda
        {
            get { return new bool[6]; }
            set { diasAgenda = value; }
        }

        public bool activa { get; set; }
    }
}
