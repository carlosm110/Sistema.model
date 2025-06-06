﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Sistema.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250524021556_Oracle")]
    partial class Oracle
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sistema.model.Certificado", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("InscripcionCodigo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("UrlDocumento")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Codigo");

                    b.HasIndex("InscripcionCodigo")
                        .IsUnique();

                    b.ToTable("Certificados");
                });

            modelBuilder.Entity("Sistema.model.Espacio", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Codigo");

                    b.ToTable("Espacios");
                });

            modelBuilder.Entity("Sistema.model.Evento", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("EspacioCodigo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Codigo");

                    b.HasIndex("EspacioCodigo");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("Sistema.model.EventoPonente", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("EventoCodigo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("PonenteCodigo")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Codigo");

                    b.HasIndex("EventoCodigo");

                    b.HasIndex("PonenteCodigo");

                    b.ToTable("EventosPonentes");
                });

            modelBuilder.Entity("Sistema.model.Inscripcion", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("EventoCodigo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("FechaInscripcion")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("ParticipanteCodigo")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Codigo");

                    b.HasIndex("EventoCodigo");

                    b.HasIndex("ParticipanteCodigo");

                    b.ToTable("Inscripciones");
                });

            modelBuilder.Entity("Sistema.model.Pago", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("InscripcionCodigo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("MetodoPago")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Monto")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("Codigo");

                    b.HasIndex("InscripcionCodigo")
                        .IsUnique();

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Sistema.model.Participante", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("DocumentoIdentidad")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Codigo");

                    b.ToTable("Participantes");
                });

            modelBuilder.Entity("Sistema.model.Ponente", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Especialidad")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Institucion")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Codigo");

                    b.ToTable("Ponentes");
                });

            modelBuilder.Entity("Sistema.model.Sesion", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("EspacioCodigo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("EventoCodigo")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime>("HoraFin")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("Codigo");

                    b.HasIndex("EspacioCodigo");

                    b.HasIndex("EventoCodigo");

                    b.ToTable("Sesiones");
                });

            modelBuilder.Entity("Sistema.model.Certificado", b =>
                {
                    b.HasOne("Sistema.model.Inscripcion", "Inscripcion")
                        .WithOne("Certificado")
                        .HasForeignKey("Sistema.model.Certificado", "InscripcionCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inscripcion");
                });

            modelBuilder.Entity("Sistema.model.Evento", b =>
                {
                    b.HasOne("Sistema.model.Espacio", "Espacios")
                        .WithMany("Eventos")
                        .HasForeignKey("EspacioCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Espacios");
                });

            modelBuilder.Entity("Sistema.model.EventoPonente", b =>
                {
                    b.HasOne("Sistema.model.Evento", "Eventos")
                        .WithMany("Ponentes")
                        .HasForeignKey("EventoCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema.model.Ponente", "Ponentes")
                        .WithMany("Eventos")
                        .HasForeignKey("PonenteCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eventos");

                    b.Navigation("Ponentes");
                });

            modelBuilder.Entity("Sistema.model.Inscripcion", b =>
                {
                    b.HasOne("Sistema.model.Evento", "Eventos")
                        .WithMany("Inscripciones")
                        .HasForeignKey("EventoCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema.model.Participante", "Participantes")
                        .WithMany("Inscripciones")
                        .HasForeignKey("ParticipanteCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eventos");

                    b.Navigation("Participantes");
                });

            modelBuilder.Entity("Sistema.model.Pago", b =>
                {
                    b.HasOne("Sistema.model.Inscripcion", "Inscripcion")
                        .WithOne("Pago")
                        .HasForeignKey("Sistema.model.Pago", "InscripcionCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inscripcion");
                });

            modelBuilder.Entity("Sistema.model.Sesion", b =>
                {
                    b.HasOne("Sistema.model.Espacio", "Espacios")
                        .WithMany()
                        .HasForeignKey("EspacioCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sistema.model.Evento", "Eventos")
                        .WithMany("Sesiones")
                        .HasForeignKey("EventoCodigo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Espacios");

                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("Sistema.model.Espacio", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("Sistema.model.Evento", b =>
                {
                    b.Navigation("Inscripciones");

                    b.Navigation("Ponentes");

                    b.Navigation("Sesiones");
                });

            modelBuilder.Entity("Sistema.model.Inscripcion", b =>
                {
                    b.Navigation("Certificado");

                    b.Navigation("Pago");
                });

            modelBuilder.Entity("Sistema.model.Participante", b =>
                {
                    b.Navigation("Inscripciones");
                });

            modelBuilder.Entity("Sistema.model.Ponente", b =>
                {
                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
