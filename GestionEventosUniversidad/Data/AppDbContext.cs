using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GestionEventosUniversidad.Entidades;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }


    public DbSet<GestionEventosUniversidad.Entidades.Certificado> Certificado { get; set; } = default!;

    public DbSet<GestionEventosUniversidad.Entidades.EventosUniversidad> EventosUniversidad { get; set; } = default!;

    public DbSet<GestionEventosUniversidad.Entidades.Inscripcion> Inscripcion { get; set; } = default!;

    public DbSet<GestionEventosUniversidad.Entidades.Pagos> Pagos { get; set; } = default!;

    public DbSet<GestionEventosUniversidad.Entidades.Participante> Participante { get; set; } = default!;



    public DbSet<GestionEventosUniversidad.Entidades.Ponente> Ponente { get; set; } = default!;



    public DbSet<GestionEventosUniversidad.Entidades.SesionesEventos> SesionesEventos { get; set; } = default!;

    public DbSet<GestionEventosUniversidad.Entidades.UsuarioCreadorEventos> UsuarioCreadorEventos { get; set; } = default!;

    public DbSet<GestionEventosUniversidad.Entidades.ParticipanteEventos> ParticipanteEventos { get; set; } = default!;

    public DbSet<GestionEventosUniversidad.Entidades.PonenteEventos> PonenteEventos { get; set; } = default!;



}
