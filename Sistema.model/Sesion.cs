using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.model
{
    public class Sesion
    {
        [Key] public int Codigo { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }

        [ForeignKey("EventoCodigo")]
        public int EventoCodigo { get; set; }
        [ForeignKey("EspacioCodigo")]
        public int EspacioCodigo { get; set; }

        // Navegación
        public Evento? Eventos { get; set; }
        public Espacio? Espacios { get; set; }
    }
}
