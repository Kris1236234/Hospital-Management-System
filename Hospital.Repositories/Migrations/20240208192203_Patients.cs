using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repositories.Migrations
{
  public partial class Patients : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Appointments_AspNetUsers_DoctorId",
          table: "Appointments");

      migrationBuilder.DropForeignKey(
          name: "FK_Appointments_AspNetUsers_PatientId",
          table: "Appointments");

      migrationBuilder.DropForeignKey(
          name: "FK_Timings_AspNetUsers_DoctorId",
          table: "Timings");

      migrationBuilder.AlterColumn<int>(
          name: "DoctorId",
          table: "Timings",
          type: "int",
          nullable: false,
          oldClrType: typeof(string),
          oldType: "nvarchar(450)");

      migrationBuilder.AlterColumn<int>(
          name: "PatientId",
          table: "Appointments",
          type: "int",
          nullable: false,
          defaultValue: 0,
          oldClrType: typeof(string),
          oldType: "nvarchar(450)",
          oldNullable: true);

      migrationBuilder.AlterColumn<int>(
          name: "DoctorId",
          table: "Appointments",
          type: "int",
          nullable: false,
          defaultValue: 0,
          oldClrType: typeof(string),
          oldType: "nvarchar(450)",
          oldNullable: true);

      //migrationBuilder.AlterColumn<int>(
      //    name: "DoctorId",
      //    table: "Timings",
      //    type: "int",
      //    nullable: false,
      //    defaultValue: 0,
      //    oldClrType: typeof(string),
      //    oldType: "nvarchar(450)",
      //    oldNullable: true);

      migrationBuilder.AddColumn<DateTime>(
          name: "AppointmentEndTime",
          table: "Appointments",
          type: "datetime2",
          nullable: false,
          defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

      migrationBuilder.AddColumn<int>(
          name: "RoomId",
          table: "Appointments",
          type: "int",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.CreateTable(
          name: "Patients",
          columns: table => new
          {
            Id = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
            Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
            City = table.Column<string>(type: "nvarchar(max)", nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Patients", x => x.Id);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Appointments_RoomId",
          table: "Appointments",
          column: "RoomId");

      migrationBuilder.AddForeignKey(
          name: "FK_Appointments_Doctors_DoctorId",
          table: "Appointments",
          column: "DoctorId",
          principalTable: "Doctors",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
          name: "FK_Appointments_Patients_PatientId",
          table: "Appointments",
          column: "PatientId",
          principalTable: "Patients",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
          name: "FK_Appointments_Rooms_RoomId",
          table: "Appointments",
          column: "RoomId",
          principalTable: "Rooms",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
          name: "FK_Timings_Doctors_DoctorId",
          table: "Timings",
          column: "DoctorId",
          principalTable: "Doctors",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Appointments_Doctors_DoctorId",
          table: "Appointments");

      migrationBuilder.DropForeignKey(
          name: "FK_Appointments_Patients_PatientId",
          table: "Appointments");

      migrationBuilder.DropForeignKey(
          name: "FK_Appointments_Rooms_RoomId",
          table: "Appointments");

      migrationBuilder.DropForeignKey(
          name: "FK_Timings_Doctors_DoctorId",
          table: "Timings");

      migrationBuilder.DropTable(
          name: "Patients");

      migrationBuilder.DropIndex(
          name: "IX_Appointments_RoomId",
          table: "Appointments");

      migrationBuilder.DropColumn(
          name: "AppointmentEndTime",
          table: "Appointments");

      migrationBuilder.DropColumn(
          name: "RoomId",
          table: "Appointments");

      migrationBuilder.AlterColumn<string>(
          name: "DoctorId",
          table: "Timings",
          type: "nvarchar(450)",
          nullable: false,
          oldClrType: typeof(int),
          oldType: "int");

      migrationBuilder.AlterColumn<string>(
          name: "PatientId",
          table: "Appointments",
          type: "nvarchar(450)",
          nullable: true,
          oldClrType: typeof(int),
          oldType: "int");

      migrationBuilder.AlterColumn<string>(
          name: "DoctorId",
          table: "Appointments",
          type: "nvarchar(450)",
          nullable: true,
          oldClrType: typeof(int),
          oldType: "int");

      migrationBuilder.AddForeignKey(
          name: "FK_Appointments_AspNetUsers_DoctorId",
          table: "Appointments",
          column: "DoctorId",
          principalTable: "AspNetUsers",
          principalColumn: "Id");

      migrationBuilder.AddForeignKey(
          name: "FK_Appointments_AspNetUsers_PatientId",
          table: "Appointments",
          column: "PatientId",
          principalTable: "AspNetUsers",
          principalColumn: "Id");

      migrationBuilder.AddForeignKey(
          name: "FK_Timings_AspNetUsers_DoctorId",
          table: "Timings",
          column: "DoctorId",
          principalTable: "AspNetUsers",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }
  }
}
