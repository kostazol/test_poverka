using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PoverkaServer.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddMeterRegistry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeterTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FullName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    EditorName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeterTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MeterTypeId = table.Column<int>(type: "integer", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    VerificationInterval = table.Column<short>(type: "smallint", nullable: false),
                    VerificationMethodology = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    RelativeErrorQt1_Qmax = table.Column<byte>(type: "smallint", nullable: false),
                    RelativeErrorQt2_Qt1 = table.Column<byte>(type: "smallint", nullable: false),
                    RelativeErrorQmin_Qt2 = table.Column<byte>(type: "smallint", nullable: false),
                    RegistrationDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    HasVerificationModeByV = table.Column<bool>(type: "boolean", nullable: false),
                    HasVerificationModeByG = table.Column<bool>(type: "boolean", nullable: false),
                    EditorName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registrations_MeterTypes_MeterTypeId",
                        column: x => x.MeterTypeId,
                        principalTable: "MeterTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Modifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegistrationId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ClassName = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    ImpulseWeight = table.Column<double>(type: "double precision", nullable: false),
                    Qmin = table.Column<double>(type: "double precision", nullable: false),
                    Qt1 = table.Column<double>(type: "double precision", nullable: false),
                    Qt2 = table.Column<double>(type: "double precision", nullable: false),
                    Qmax = table.Column<double>(type: "double precision", nullable: false),
                    Checkpoint1 = table.Column<double>(type: "double precision", nullable: false),
                    Checkpoint2 = table.Column<double>(type: "double precision", nullable: false),
                    Checkpoint3 = table.Column<double>(type: "double precision", nullable: false),
                    Checkpoint4 = table.Column<double>(type: "double precision", nullable: true),
                    NumberOfMeasurements = table.Column<byte>(type: "smallint", nullable: false),
                    MinPulseCount = table.Column<short>(type: "smallint", nullable: false),
                    MeasurementDurationInSeconds = table.Column<short>(type: "smallint", nullable: false),
                    RelativeErrorWithStandartValue = table.Column<byte>(type: "smallint", nullable: false),
                    EditorName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modifications_Registrations_RegistrationId",
                        column: x => x.RegistrationId,
                        principalTable: "Registrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeterTypes_Type",
                table: "MeterTypes",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modifications_RegistrationId_Name",
                table: "Modifications",
                columns: new[] { "RegistrationId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_MeterTypeId",
                table: "Registrations",
                column: "MeterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_RegistrationNumber",
                table: "Registrations",
                column: "RegistrationNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modifications");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "MeterTypes");
        }
    }
}
