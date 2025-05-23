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
    public class Certificado
    {
        [Key] public int CertificadoId { get; set; }
        [ForeignKey("Participante")]
        public int ParticipanteId { get; set; }
        [JsonIgnore]
        public Participante? Participante { get; set; }
        [ForeignKey("Ponente")]
        public int PonenteId { get; set; }
        [JsonIgnore]
        public Ponente? Ponente { get; set; }
        [ForeignKey("EventosUniversidad")]
        public int EventoId { get; set; }
        [JsonIgnore]
        public EventosUniversidad? Evento { get; set; }

        [ForeignKey("Inscripcion")]
        public int InscripcionId { get; set; }
        [JsonIgnore]
        public Inscripcion? Inscripcion { get; set; }
        public DateTime FechaEmision { get; set; }
        public string CodigoCertificado { get; set; }
        public int CumpleRequisitos { get; set; } = 0;
    }
}
