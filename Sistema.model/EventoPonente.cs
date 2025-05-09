using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.model
{
    public class EventoPonente
    {
        [Key] public int Codigo { get; set; }

        [ForeignKey("EventoCodigo")]
        public int EventoCodigo { get; set; }

        [ForeignKey("PonenteCodigo")]
        public int PonenteCodigo { get; set; }

        // Navegación
        public Evento? Eventos { get; set; }
        public Ponente? Ponentes { get; set; }
    }
}
