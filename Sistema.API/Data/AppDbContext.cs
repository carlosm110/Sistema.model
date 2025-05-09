using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sistema.model;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Certificado> Certificados { get; set; } = default!;
    public DbSet<Espacio> Espacios { get; set; } = default!;
    public DbSet<Evento> Eventos { get; set; } = default!;
    public DbSet<EventoPonente> EventosPonentes { get; set; } = default!;
    public DbSet<Inscripcion> Inscripciones { get; set; } = default!;
    public DbSet<Pago> Pagos { get; set; } = default!;
    public DbSet<Participante> Participantes { get; set; } = default!;
    public DbSet<Ponente> Ponentes { get; set; } = default!;
    public DbSet<Sesion> Sesiones { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Conversión global de DateTime a UTC
        var dateTimeConverter = new ValueConverter<DateTime, DateTime>(
            v => v.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(v, DateTimeKind.Utc) : v.ToUniversalTime(),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc));

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties().Where(p => p.ClrType == typeof(DateTime)))
            {
                property.SetValueConverter(dateTimeConverter);
            }
        }

        // Relaciones
        modelBuilder.Entity<Inscripcion>()
            .HasOne(i => i.Pago)
            .WithOne(p => p.Inscripcion)
            .HasForeignKey<Pago>(p => p.InscripcionCodigo)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Inscripcion>()
            .HasOne(i => i.Certificado)
            .WithOne(c => c.Inscripcion)
            .HasForeignKey<Certificado>(c => c.InscripcionCodigo);

        modelBuilder.Entity<Evento>()
            .HasMany(e => e.Inscripciones)
            .WithOne(i => i.Eventos)
            .HasForeignKey(i => i.EventoCodigo);

        modelBuilder.Entity<Participante>()
            .HasMany(p => p.Inscripciones)
            .WithOne(i => i.Participantes)
            .HasForeignKey(i => i.ParticipanteCodigo);

        base.OnModelCreating(modelBuilder);
    }
}
