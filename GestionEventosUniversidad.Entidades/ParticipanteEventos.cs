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
    public class ParticipanteEventos
    {

        [Key] public int Id { get; set; }
        [ForeignKey("Participante")]

        public int ParticipanteId { get; set; }
        [JsonIgnore]
        public Participante? Participante { get; set; }
        [ForeignKey("EventosUniversidad")]
        public int EventoId { get; set; }
        [JsonIgnore]
        public EventosUniversidad? Evento { get; set; }
    }
}
