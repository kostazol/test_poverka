using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PoverkaServer.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class AddMeterRegistry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelativeErrorWithStandartValue",
                table: "Modifications");

            migrationBuilder.AddColumn<double>(
                name: "Checkpoint1PulseCount",
                table: "Modifications",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Checkpoint1RequiredTime",
                table: "Modifications",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Checkpoint1TimeMultiplier",
                table: "Modifications",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Checkpoint2PulseCount",
                table: "Modifications",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Checkpoint2RequiredTime",
                table: "Modifications",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Checkpoint2TimeMultiplier",
                table: "Modifications",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Checkpoint3PulseCount",
                table: "Modifications",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Checkpoint3RequiredTime",
                table: "Modifications",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Checkpoint3TimeMultiplier",
                table: "Modifications",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Checkpoint4PulseCount",
                table: "Modifications",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Checkpoint4RequiredTime",
                table: "Modifications",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Checkpoint4TimeMultiplier",
                table: "Modifications",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FlowSetpointPercent",
                table: "Modifications",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Checkpoint1PulseCount",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "Checkpoint1RequiredTime",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "Checkpoint1TimeMultiplier",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "Checkpoint2PulseCount",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "Checkpoint2RequiredTime",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "Checkpoint2TimeMultiplier",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "Checkpoint3PulseCount",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "Checkpoint3RequiredTime",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "Checkpoint3TimeMultiplier",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "Checkpoint4PulseCount",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "Checkpoint4RequiredTime",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "Checkpoint4TimeMultiplier",
                table: "Modifications");

            migrationBuilder.DropColumn(
                name: "FlowSetpointPercent",
                table: "Modifications");

            migrationBuilder.AddColumn<byte>(
                name: "RelativeErrorWithStandartValue",
                table: "Modifications",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
