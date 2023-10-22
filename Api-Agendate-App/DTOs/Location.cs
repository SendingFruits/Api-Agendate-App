using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Api_Agendate_App.DTOs;

namespace Api_Agendate_App.DTOs
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public float latitude { get; set; }
        public float latitudeDelta { get; set; }
        public float longitude { get; set; }
        public float longitudeDelta { get; set; }

        [JsonIgnore]
        public virtual EmpresaDTO Empresa { get; set; }
    }
}
