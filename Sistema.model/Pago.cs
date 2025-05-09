using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.model
{
    public class Pago
    {
        [Key] public int Codigo { get; set; }
        public double Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; } // Ej: Tarjeta, Transferencia
        [ForeignKey("InscripcionCodigo")]
        public int InscripcionCodigo { get; set; }

        public Inscripcion? Inscripcion { get; set; }

    }
}
