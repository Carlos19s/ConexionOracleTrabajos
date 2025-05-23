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
    public class Pagos
    {
        [Key] public int Id { get; set; }
        [ForeignKey("Inscripcion")]
        public int InscripcionId { get; set; }
        public double Monto { get; set; }
        public string MedioPago { get; set; } //  Tarjeta, Transferencia
        public DateTime FechaPago { get; set; }
        [JsonIgnore]
        public Inscripcion? Inscripcion { get; set; }


    }
}
