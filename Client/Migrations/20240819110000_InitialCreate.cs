using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PoverkaWinForms.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StateRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegisterNumber = table.Column<string>(nullable: false),
                    InstrumentName = table.Column<string>(nullable: false),
                    VerificationDocument = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateRegisters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParameterSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RegisterNumber = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    InstrumentName = table.Column<string>(nullable: true),
                    VerificationDocument = table.Column<string>(nullable: true),
                    Modification = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerificationPointSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Diameter = table.Column<string>(nullable: true),
                    MaxFlow = table.Column<decimal>(nullable: true),
                    FlowPercentOfMax = table.Column<decimal>(nullable: true),
                    TestFlow = table.Column<decimal>(nullable: true),
                    TestTime = table.Column<int>(nullable: true),
                    ImpulseWeightImpPerL = table.Column<decimal>(nullable: true),
                    ImpulseWeightLPerImp = table.Column<decimal>(nullable: true),
                    ImpulseWeightM3PerImp = table.Column<decimal>(nullable: true),
                    RelativeError = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationPointSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestRuns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp", nullable: false),
                    VolumeLiters = table.Column<double>(nullable: false),
                    TimeSeconds = table.Column<double>(nullable: false),
                    IndicatedFlow = table.Column<double>(nullable: false),
                    TemperatureC = table.Column<double>(nullable: false),
                    PressureKPa = table.Column<double>(nullable: false),
                    ActualFlow = table.Column<double>(nullable: false),
                    ErrorPercent = table.Column<double>(nullable: false),
                    MeterSerial = table.Column<string>(maxLength: 128, nullable: true),
                    MeterModel = table.Column<string>(maxLength: 128, nullable: true),
                    MeterDiameterMm = table.Column<double>(nullable: false),
                    MeterUnit = table.Column<string>(maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestRuns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StateRegisterId = table.Column<int>(nullable: true),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diameters_StateRegisters_StateRegisterId",
                        column: x => x.StateRegisterId,
                        principalTable: "StateRegisters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FlowmeterModifications",
                columns: table => new
                {
                    Modification = table.Column<string>(nullable: false),
                    StateRegisterId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlowmeterModifications", x => x.Modification);
                    table.ForeignKey(
                        name: "FK_FlowmeterModifications_StateRegisters_StateRegisterId",
                        column: x => x.StateRegisterId,
                        principalTable: "StateRegisters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diameters_StateRegisterId",
                table: "Diameters",
                column: "StateRegisterId");

            migrationBuilder.CreateIndex(
                name: "IX_FlowmeterModifications_StateRegisterId",
                table: "FlowmeterModifications",
                column: "StateRegisterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Diameters");
            migrationBuilder.DropTable(name: "FlowmeterModifications");
            migrationBuilder.DropTable(name: "ParameterSettings");
            migrationBuilder.DropTable(name: "VerificationPointSettings");
            migrationBuilder.DropTable(name: "TestRuns");
            migrationBuilder.DropTable(name: "StateRegisters");
        }
    }
}
