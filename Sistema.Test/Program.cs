using Sistema.model;
using Sistema.APIConsumer;

namespace Sistema.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProbarPonentes();
            ProbarParticipantes();
            ProbarEspacios();
            ProbarEventos();
            ProbarInscripciones();
            ProbarSesiones();
            ProbarEventosPonentes();
            ProbarCertificados();
            ProbarPagos();

            Console.ReadLine();
        }

        private static void ProbarPonentes()
        {
            Crud<Ponente>.EndPoint = "https://localhost:7025/api/Ponentes";

            // crear un objeto de la clase libro
            var ponente = Crud<Ponente>.Create(new Ponente
            {
                Codigo = 0,
                Nombre = "Diana",
                Especialidad = "Biotecnología",
                Institucion = "UTPL"
            });

            // actualizar el libro
            //libro.Titulo = "El Principito Actualizado";
            //Crud<Libro>.Update(libro.Codigo, libro);

            var ponentes = Crud<Ponente>.GetAll();

            foreach (var p in ponentes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Especialidad: {p.Especialidad}, Institucion: {p.Institucion}");
            }
        }

        private static void ProbarParticipantes()
        {
            Crud<Participante>.EndPoint = "https://localhost:7025/api/Participantes";

            var participante = Crud<Participante>.Create(new Participante
            {
                Codigo = 0,
                Nombre = "Carlos Ruiz",
                Email = "carlosruiz@example.com",
                DocumentoIdentidad = "0102030404"
            });

            //Crud<Pais>.Update(pais.Codigo, pais);

            var participantes = Crud<Participante>.GetAll();

            foreach (var p in participantes)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Nombre: {p.Nombre}, Email: {p.Email}, DocumentoIdentidad: {p.DocumentoIdentidad}");
            }
        }

        private static void ProbarEventos()
        {
            Crud<Evento>.EndPoint = "https://localhost:7025/api/Eventos";

            var evento = Crud<Evento>.Create(new Evento
            {
                Codigo = 0,
                Nombre = "Expo Innovación 2025",
                Fecha = new DateTime(2025, 10, 10),
                Tipo = "Exposición",
                EspacioCodigo = 21
            });

            //Crud<Autor>.Update(autor.Codigo, autor);

            var eventos = Crud<Evento>.GetAll();
            foreach (var e in eventos)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, Nombre: {e.Nombre}, Fecha: {e.Fecha.ToUniversalTime()}, Tipo: {e.Tipo}");
            }
        }

        private static void ProbarEventosPonentes()
        {
            Crud<EventoPonente>.EndPoint = "https://localhost:7025/api/EventosPonentes";

            var eventoponente = Crud<EventoPonente>.Create(new EventoPonente
            {
                Codigo = 0,
                EventoCodigo = 1,
                PonenteCodigo = 22
            });

            //Crud<Autor>.Update(autor.Codigo, autor);

            var eventosponentes = Crud<EventoPonente>.GetAll();
            foreach (var e in eventosponentes)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, EventoCodigo: {e.EventoCodigo}, PonenteCodigo: {e.PonenteCodigo}");
            }
        }

        private static void ProbarEspacios()
        {
            Crud<Espacio>.EndPoint = "https://localhost:7025/api/Espacios";

            var espacio = Crud<Espacio>.Create(new Espacio
            {
                Codigo = 0,
                Nombre = "Aula Magna Sur",
                Ubicacion = "Campus Central",
                Capacidad = 300
            });

            //Crud<Autor>.Update(autor.Codigo, autor);

            var espacios = Crud<Espacio>.GetAll();
            foreach (var e in espacios)
            {
                Console.WriteLine($"Codigo: {e.Codigo}, Nombre: {e.Nombre}, Ubicacion: {e.Ubicacion}, Capacidad: {e.Capacidad}");
            }
        }

        private static void ProbarInscripciones()
        {
            Crud<Inscripcion>.EndPoint = "https://localhost:7025/api/Inscripciones";

            var inscripcion = Crud<Inscripcion>.Create(new Inscripcion
            {
                Codigo = 0,
                Estado = "Confirmada",
                FechaInscripcion = new DateTime(2025, 7, 20),
                EventoCodigo = 1,
                ParticipanteCodigo = 21
            });

            //Crud<Autor>.Update(autor.Codigo, autor);

            var inscripciones = Crud<Inscripcion>.GetAll();
            foreach (var i in inscripciones)
            {
                Console.WriteLine($"Codigo: {i.Codigo}, Estado: {i.Estado}, FechaInscripcion: {i.FechaInscripcion.ToUniversalTime()}, EventoCodigo: {i.EventoCodigo}, ParticipanteCodigo: {i.ParticipanteCodigo}");
            }
        }

        private static void ProbarSesiones()
        {
            Crud<Sesion>.EndPoint = "https://localhost:7025/api/Sesiones";

            var sesion = Crud<Sesion>.Create(new Sesion
            {
                Codigo = 0,
                HoraInicio = new DateTime(2025, 10, 10, 9, 0, 0),
                HoraFin = new DateTime(2025, 10, 10, 12, 30, 0),
                EventoCodigo = 1,
                EspacioCodigo = 21
            });

            //Crud<Autor>.Update(autor.Codigo, autor);

            var sesiones = Crud<Sesion>.GetAll();
            foreach (var s in sesiones)
            {
                Console.WriteLine($"Codigo: {s.Codigo}, HoraInicio: {s.HoraInicio.ToUniversalTime()}, HoraFin: {s.HoraFin.ToUniversalTime()}, EventoCodigo: {s.EventoCodigo}, EspacioCodigo: {s.EspacioCodigo}");
            }
        }

        private static void ProbarCertificados()
        {
            Crud<Certificado>.EndPoint = "https://localhost:7025/api/Certificados";

            var certificado = Crud<Certificado>.Create(new Certificado
            {
                Codigo = 0,
                FechaEmision = new DateTime(2023, 9, 18),
                UrlDocumento = "https://certificados.utpl.edu/cert004",
                InscripcionCodigo = 21
            });

            //Crud<Editorial>.Update(santillana.Codigo, santillana);

            var certificados = Crud<Certificado>.GetAll();
            foreach (var c in certificados)
            {
                Console.WriteLine($"Codigo: {c.Codigo}, FechaEmision: {c.FechaEmision.ToUniversalTime()}, UrlDocumento: {c.UrlDocumento}, InscripcionCodigo: {c.InscripcionCodigo}");
            }
        }

        private static void ProbarPagos()
        {
            Crud<Pago>.EndPoint = "https://localhost:7025/api/Pagos";

            var pago = Crud<Pago>.Create(new Pago
            {
                Codigo = 0,
                Monto = 310,
                FechaPago = new DateTime(2024, 4, 2),
                MetodoPago = "Transferencia",
                InscripcionCodigo = 21
            });

            //Crud<Autor>.Update(autor.Codigo, autor);

            var pagos = Crud<Pago>.GetAll();
            foreach (var p in pagos)
            {
                Console.WriteLine($"Codigo: {p.Codigo}, Monto: {p.Monto}, FechaPago: {p.FechaPago.ToUniversalTime()}, MetodoPago: {p.MetodoPago}, InscripcionCodigo: {p.InscripcionCodigo}");
            }
        }
    }
}
