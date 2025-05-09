using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.model
{
    public class Ponente
    {
        [Key] public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string Institucion { get; set; }

        public List<EventoPonente>? Eventos { get; set; }
    }
}
