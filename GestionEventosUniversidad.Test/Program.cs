using GestionEventosUniversidad.Entidades;
using GestionEventosUniversidad.API.Consumer;
using System.Text;
namespace GestionEventosUniversidad.Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProbarEventos();
            ProbarInscripciones();
            ProbarPagos();
            ProbarParticipante();
            ProbarPonente();
            ProbarSesiones();
            ProbarCertificados();
            ProbarUsuarioCreadorEventos();


            Console.ReadLine();
        }
        public static void ProbarEventos()
        {
            // URL de tu endpoint API (asegúrate que sea la correcta del proyecto en ejecución)
            Crud<EventosUniversidad>.EndPoint = "https://localhost:7178/api/EventosUniversidads";

            var nuevoEvento = new EventosUniversidad
            {
                Nombre = "Evento de Prueba",
                Tipo = "Descripción del evento de prueba",
                FechaInicio = DateTime.UtcNow,
                IDUsuarioCreador = 1,
            };


            var eventoCreado = Crud<EventosUniversidad>.Create(nuevoEvento);

            eventoCreado.Nombre = "Evento de Prueba actualizado";
            Crud<EventosUniversidad>.Update(eventoCreado.IdEvento, eventoCreado);


            var eventos = Crud<EventosUniversidad>.GetAll();
            foreach (var item in eventos)
            {
                Console.WriteLine($"ID: {item.IdEvento}, Nombre: {item.Nombre}, Tipo: {item.Tipo}, FechaInicio: {item.FechaInicio}");
            }
        }
        public static void ProbarSesiones()
        {
            Crud<SesionesEventos>.EndPoint = "https://localhost:7178/api/SesionesEventos";
            var nuevaSesion = new SesionesEventos
            {
                EventoId = 1,
                Lugar = "Auditorio Principal",
                FechaHoraInicio = DateTime.UtcNow,
                FechaHoraFin = DateTime.UtcNow.AddDays(3)
            };
            var sesionCreada = Crud<SesionesEventos>.Create(nuevaSesion);
            sesionCreada.Lugar = "Sala de Conferencias";
            Crud<SesionesEventos>.Update(sesionCreada.Id, sesionCreada);
            var sesiones = Crud<SesionesEventos>.GetAll();
            foreach (var item in sesiones)
            {
                Console.WriteLine($"ID: {item.Id}, EventoId: {item.EventoId}, Lugar: {item.Lugar}, FechaHoraInicio: {item.FechaHoraInicio}, FechaHoraFin: {item.FechaHoraFin}");
            }
        }
        public static void ProbarInscripciones()
        {
            Crud<Inscripcion>.EndPoint = "https://localhost:7178/api/Inscripcions";
            var nuevaInscripcion = new Inscripcion
            {
                PonenteId = 1,
                ParticipanteId = 1,
                EventoId = 1,
                FechaInscripcion = DateTime.UtcNow,
                Estado = "Inscrito",
                PagoRealizado = 1
            };
            var inscripcionCreada = Crud<Inscripcion>.Create(nuevaInscripcion);
            inscripcionCreada.Estado = "Cancelado";
            Crud<Inscripcion>.Update(inscripcionCreada.InscripcionId, inscripcionCreada);
            var inscripciones = Crud<Inscripcion>.GetAll();
            foreach (var item in inscripciones)
            {
                Console.WriteLine($"ID: {item.InscripcionId}, PonenteId: {item.PonenteId}, ParticipanteId: {item.ParticipanteId}, EventoId: {item.EventoId}, FechaInscripcion: {item.FechaInscripcion}, Estado: {item.Estado}, PagoRealizado: {item.PagoRealizado}");
            }
        }
        public static void ProbarUsuarioCreadorEventos()
        {
            Crud<UsuarioCreadorEventos>.EndPoint = "https://localhost:7178/api/UsuarioCreadorEventos";
            var nuevoUsuario = new UsuarioCreadorEventos
            {
                Nombre = "Juan",
                Apellido = "Gómez",
                Eventos = new List<EventosUniversidad>()
            };
            var usuarioCreado = Crud<UsuarioCreadorEventos>.Create(nuevoUsuario);
            usuarioCreado.Nombre = "Juan Carlos";
            Crud<UsuarioCreadorEventos>.Update(usuarioCreado.Id, usuarioCreado);
            var usuarios = Crud<UsuarioCreadorEventos>.GetAll();
            foreach (var item in usuarios)
            {
                Console.WriteLine($"ID: {item.Id}, Nombre: {item.Nombre}, Apellido: {item.Apellido}");
            }

        }
        public static void ProbarCertificados()
        {
            Crud<Certificado>.EndPoint = "https://localhost:7178/api/Certificadoes";
            var nuevoCertificado = new Certificado
            {
                ParticipanteId = 1,
                PonenteId = 1,
                EventoId = 1,
                InscripcionId = 1,
                FechaEmision = DateTime.UtcNow,
                CodigoCertificado= "holasasad",
                CumpleRequisitos = 1,
            };
            var certificadoCreado = Crud<Certificado>.Create(nuevoCertificado);
            certificadoCreado.CodigoCertificado = "Participación";
            Crud<Certificado>.Update(certificadoCreado.CertificadoId, certificadoCreado);
            var certificados = Crud<Certificado>.GetAll();
            foreach (var item in certificados)
            {
                Console.WriteLine($"ID: {item.CertificadoId}, ParticipanteId: {item.ParticipanteId}, EventoId: {item.EventoId}, FechaEmision: {item.FechaEmision}, TipoCertificado: {item.CodigoCertificado}, CumpleRequisitos: {item.CumpleRequisitos}");
            }
        }
        public static void ProbarPagos()
        {
            Crud<Pagos>.EndPoint = "https://localhost:7178/api/Pagos";
            var nuevoPago = new Pagos
            {
                InscripcionId = 1,
                Monto = 100,
                FechaPago = DateTime.UtcNow,
                MedioPago = "Tarjeta de Crédito"
            };
            var pagoCreado = Crud<Pagos>.Create(nuevoPago);
            pagoCreado.Monto = 150;
            Crud<Pagos>.Update(pagoCreado.Id, pagoCreado);
            var pagos = Crud<Pagos>.GetAll();
            foreach (var item in pagos)
            {
                Console.WriteLine($"ID: {item.Id}, InscripcionId: {item.InscripcionId}, Monto: {item.Monto}, FechaPago: {item.FechaPago}, MetodoPago: {item.MedioPago}");
            }
        }
        public static void ProbarParticipante()
        {
            Crud<Participante>.EndPoint = "https://localhost:7178/api/Participantes";
            var nuevoParticipante = new Participante()
            {
                Nombre = "Carlos",
                Apellido = "Pérez",
                Email = "email",
            };
            var participanteCreado = Crud<Participante>.Create(nuevoParticipante);
            participanteCreado.Nombre = "Carlos Alberto";
            Crud<Participante>.Update(participanteCreado.ParticipanteId, participanteCreado);
            var participantes = Crud<Participante>.GetAll();
            foreach (var item in participantes)
            {
                Console.WriteLine($"ID: {item.ParticipanteId}, Nombre: {item.Nombre}, Apellido: {item.Apellido}, Email: {item.Email}");
            }
        }
        public static void ProbarPonente()
        {
            Crud<Ponente>.EndPoint = "https://localhost:7178/api/Ponentes";
            var nuevoPonente = new Ponente()
            {
                Nombre = "Ana",
                Apellido = "López",
                Email = "email",
            };
            var ponenteCreado = Crud<Ponente>.Create(nuevoPonente);
            ponenteCreado.Nombre = "Ana María";
            Crud<Ponente>.Update(ponenteCreado.Id, ponenteCreado);
            var ponentes = Crud<Ponente>.GetAll();
            foreach (var item in ponentes)
            {
                Console.WriteLine($"ID: {item.Id}, Nombre: {item.Nombre}, Apellido: {item.Apellido}, Email: {item.Email}");
            }
        }
    }
}