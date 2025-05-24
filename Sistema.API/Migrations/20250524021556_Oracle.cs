using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema.API.Migrations
{
    /// <inheritdoc />
    public partial class Oracle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Espacios",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Ubicacion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Capacidad = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espacios", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DocumentoIdentidad = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Ponentes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Especialidad = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Institucion = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponentes", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EspacioCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Eventos_Espacios_EspacioCodigo",
                        column: x => x.EspacioCodigo,
                        principalTable: "Espacios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventosPonentes",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EventoCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PonenteCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosPonentes", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_EventosPonentes_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventosPonentes_Ponentes_PonenteCodigo",
                        column: x => x.PonenteCodigo,
                        principalTable: "Ponentes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripciones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EventoCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ParticipanteCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripciones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripciones_Participantes_ParticipanteCodigo",
                        column: x => x.ParticipanteCodigo,
                        principalTable: "Participantes",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    HoraInicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    HoraFin = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    EventoCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EspacioCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Sesiones_Espacios_EspacioCodigo",
                        column: x => x.EspacioCodigo,
                        principalTable: "Espacios",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sesiones_Eventos_EventoCodigo",
                        column: x => x.EventoCodigo,
                        principalTable: "Eventos",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificados",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    FechaEmision = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UrlDocumento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    InscripcionCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificados", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Certificados_Inscripciones_InscripcionCodigo",
                        column: x => x.InscripcionCodigo,
                        principalTable: "Inscripciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Monto = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    MetodoPago = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    InscripcionCodigo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Pagos_Inscripciones_InscripcionCodigo",
                        column: x => x.InscripcionCodigo,
                        principalTable: "Inscripciones",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificados_InscripcionCodigo",
                table: "Certificados",
                column: "InscripcionCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_EspacioCodigo",
                table: "Eventos",
                column: "EspacioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_EventosPonentes_EventoCodigo",
                table: "EventosPonentes",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_EventosPonentes_PonenteCodigo",
                table: "EventosPonentes",
                column: "PonenteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_EventoCodigo",
                table: "Inscripciones",
                column: "EventoCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripciones_ParticipanteCodigo",
                table: "Inscripciones",
                column: "ParticipanteCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_InscripcionCodigo",
                table: "Pagos",
                column: "InscripcionCodigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_EspacioCodigo",
                table: "Sesiones",
                column: "EspacioCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_EventoCodigo",
                table: "Sesiones",
                column: "EventoCodigo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificados");

            migrationBuilder.DropTable(
                name: "EventosPonentes");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropTable(
                name: "Ponentes");

            migrationBuilder.DropTable(
                name: "Inscripciones");

            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Participantes");

            migrationBuilder.DropTable(
                name: "Espacios");
        }
    }
}
