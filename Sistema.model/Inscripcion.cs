using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.model
{
    public class Inscripcion
    {
        [Key]public int Codigo { get; set; }

        public string Estado { get; set; }

        public DateTime FechaInscripcion { get; set; }

        public int EventoCodigo { get; set; }

        public int ParticipanteCodigo { get; set; }

        [ForeignKey("EventoCodigo")]
        public Evento? Eventos { get; set; }

        [ForeignKey("ParticipanteCodigo")]
        public Participante? Participantes { get; set; }

        public Pago? Pago { get; set; }

        public Certificado? Certificado { get; set; }
    }

}
