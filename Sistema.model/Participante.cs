﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.model
{
    public class Participante
    {
        [Key] public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string DocumentoIdentidad { get; set; }

        public List<Inscripcion>? Inscripciones { get; set; }
    }
}
