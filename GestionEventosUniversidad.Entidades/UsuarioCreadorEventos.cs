using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GestionEventosUniversidad.Entidades
{
    public class UsuarioCreadorEventos
    {

        [Key] public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        
        public List<EventosUniversidad>? Eventos { get; set; }
    }
}
