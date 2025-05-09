using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sistema.model
{
    public class Evento
    {
        [Key] public int Codigo { get; set; }
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; } // Taller, Conferencia, Webinar, etc.

        [ForeignKey("EspacioCodigo")]
        public int EspacioCodigo { get; set; }

        // Navegación
        public Espacio? Espacios { get; set; }
        public List<Sesion>? Sesiones { get; set; }
        public List<Inscripcion>? Inscripciones { get; set; }
        public List<EventoPonente>? Ponentes { get; set; }
    }
}
