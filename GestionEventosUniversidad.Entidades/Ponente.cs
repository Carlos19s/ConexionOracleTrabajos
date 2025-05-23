using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionEventosUniversidad.Entidades
{
    public class Ponente
    {
        [Key] public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public List<PonenteEventos>? Sesiones { get; set; }
        [JsonIgnore]
        public List<Certificado>? Certificados { get; set; }
    }
}
