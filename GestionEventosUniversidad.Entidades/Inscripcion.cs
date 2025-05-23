using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace GestionEventosUniversidad.Entidades
{
    public class Inscripcion
    {
        [Key] public int InscripcionId { get; set; }
        [ForeignKey("Ponente")]
        public int PonenteId { get; set; }
        [JsonIgnore]
        public Ponente? Ponente { get; set; }
        [ForeignKey("Participante")]
        public int ParticipanteId { get; set; }
        [JsonIgnore]
        public Participante? Participante { get; set; }
        [ForeignKey("Evento")]
        public int EventoId { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string Estado { get; set; } // Inscrito, Cancelado, etc.
        public int PagoRealizado { get; set; } = 0;
        [JsonIgnore]
        public Pagos? Pagos { get; set; } // Relación con la entidad Pagos
        [JsonIgnore]
        public EventosUniversidad? Evento { get; set; }
    }
}
