using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GestionEventosUniversidad.Entidades
{
    public class EventosUniversidad
    {
        [Key] public int IdEvento { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public DateTime FechaInicio { get; set; }

        [ForeignKey("UsuarioCreadorEventos")]
        public int IDUsuarioCreador { get; set; }
        [JsonIgnore]
        public UsuarioCreadorEventos? UsuarioCreadorEventos { get; set; }
        
        public List<SesionesEventos>? Sesiones { get; set; }
        
        public List<ParticipanteEventos>? Participantes { get; set; }
        
        public List<PonenteEventos>? Ponentes { get; set; } 
    }
}
