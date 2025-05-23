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
    public class SesionesEventos
    {
        [Key] public int Id { get; set; }
        [ForeignKey("EventosUniversidad")]
        public int EventoId { get; set; }
        [JsonIgnore]
        public EventosUniversidad? Evento { get; set; }
        public String Lugar { get; set; }

        public DateTime FechaHoraInicio { get; set; }

        public DateTime FechaHoraFin { get; set; }

    }
}
