using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionEventosUniversidad.API.Migrations
{
    /// <inheritdoc />
    public partial class oracle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participante",
                columns: table => new
                {
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Apellido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participante", x => x.ParticipanteId);
                });

            migrationBuilder.CreateTable(
                name: "Ponente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Apellido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ponente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioCreadorEventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Apellido = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioCreadorEventos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventosUniversidad",
                columns: table => new
                {
                    IdEvento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nombre = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Tipo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IDUsuarioCreador = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventosUniversidad", x => x.IdEvento);
                    table.ForeignKey(
                        name: "FK_EventosUniversidad_UsuarioCreadorEventos_IDUsuarioCreador",
                        column: x => x.IDUsuarioCreador,
                        principalTable: "UsuarioCreadorEventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inscripcion",
                columns: table => new
                {
                    InscripcionId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PonenteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FechaInscripcion = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PagoRealizado = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscripcion", x => x.InscripcionId);
                    table.ForeignKey(
                        name: "FK_Inscripcion_EventosUniversidad_EventoId",
                        column: x => x.EventoId,
                        principalTable: "EventosUniversidad",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Participante_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participante",
                        principalColumn: "ParticipanteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inscripcion_Ponente_PonenteId",
                        column: x => x.PonenteId,
                        principalTable: "Ponente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParticipanteEventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipanteEventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipanteEventos_EventosUniversidad_EventoId",
                        column: x => x.EventoId,
                        principalTable: "EventosUniversidad",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipanteEventos_Participante_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participante",
                        principalColumn: "ParticipanteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PonenteEventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    PonenteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PonenteEventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PonenteEventos_EventosUniversidad_EventoId",
                        column: x => x.EventoId,
                        principalTable: "EventosUniversidad",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PonenteEventos_Ponente_PonenteId",
                        column: x => x.PonenteId,
                        principalTable: "Ponente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SesionesEventos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Lugar = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FechaHoraInicio = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    FechaHoraFin = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SesionesEventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SesionesEventos_EventosUniversidad_EventoId",
                        column: x => x.EventoId,
                        principalTable: "EventosUniversidad",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificado",
                columns: table => new
                {
                    CertificadoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PonenteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EventoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    InscripcionId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FechaEmision = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    CodigoCertificado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CumpleRequisitos = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificado", x => x.CertificadoId);
                    table.ForeignKey(
                        name: "FK_Certificado_EventosUniversidad_EventoId",
                        column: x => x.EventoId,
                        principalTable: "EventosUniversidad",
                        principalColumn: "IdEvento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificado_Inscripcion_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripcion",
                        principalColumn: "InscripcionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificado_Participante_ParticipanteId",
                        column: x => x.ParticipanteId,
                        principalTable: "Participante",
                        principalColumn: "ParticipanteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certificado_Ponente_PonenteId",
                        column: x => x.PonenteId,
                        principalTable: "Ponente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    InscripcionId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Monto = table.Column<double>(type: "BINARY_DOUBLE", nullable: false),
                    MedioPago = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FechaPago = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Inscripcion_InscripcionId",
                        column: x => x.InscripcionId,
                        principalTable: "Inscripcion",
                        principalColumn: "InscripcionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_EventoId",
                table: "Certificado",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_InscripcionId",
                table: "Certificado",
                column: "InscripcionId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_ParticipanteId",
                table: "Certificado",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Certificado_PonenteId",
                table: "Certificado",
                column: "PonenteId");

            migrationBuilder.CreateIndex(
                name: "IX_EventosUniversidad_IDUsuarioCreador",
                table: "EventosUniversidad",
                column: "IDUsuarioCreador");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_EventoId",
                table: "Inscripcion",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_ParticipanteId",
                table: "Inscripcion",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Inscripcion_PonenteId",
                table: "Inscripcion",
                column: "PonenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_InscripcionId",
                table: "Pagos",
                column: "InscripcionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParticipanteEventos_EventoId",
                table: "ParticipanteEventos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipanteEventos_ParticipanteId",
                table: "ParticipanteEventos",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_PonenteEventos_EventoId",
                table: "PonenteEventos",
                column: "EventoId");

            migrationBuilder.CreateIndex(
                name: "IX_PonenteEventos_PonenteId",
                table: "PonenteEventos",
                column: "PonenteId");

            migrationBuilder.CreateIndex(
                name: "IX_SesionesEventos_EventoId",
                table: "SesionesEventos",
                column: "EventoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificado");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "ParticipanteEventos");

            migrationBuilder.DropTable(
                name: "PonenteEventos");

            migrationBuilder.DropTable(
                name: "SesionesEventos");

            migrationBuilder.DropTable(
                name: "Inscripcion");

            migrationBuilder.DropTable(
                name: "EventosUniversidad");

            migrationBuilder.DropTable(
                name: "Participante");

            migrationBuilder.DropTable(
                name: "Ponente");

            migrationBuilder.DropTable(
                name: "UsuarioCreadorEventos");
        }
    }
}
