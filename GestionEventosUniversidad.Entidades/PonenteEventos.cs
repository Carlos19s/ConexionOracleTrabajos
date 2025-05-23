using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionEventosUniversidad.Entidades
{
    public class PonenteEventos
    {
        [Key] public int Id { get; set; }
        [ForeignKey("Ponente")]
        public int PonenteId { get; set; }
        [JsonIgnore]
        public Ponente? Ponente { get; set; }
        [ForeignKey("EventosUniversidad")]
        public int EventoId { get; set; }
        [JsonIgnore]
        public EventosUniversidad? Evento { get; set; }
    }
}
