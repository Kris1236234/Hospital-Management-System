using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Repositories.Migrations
{
  //[DbContext(typeof(ApplicationDbContext))]
  //[Migration("20240207210121_ChangeTimingReference")]
  public partial class _20240207210121_ChangeTimingReference : Migration
  {
    protected override void Up([NotNullAttribute] MigrationBuilder migrationBuilder)
    {
      migrationBuilder.Sql("DELETE FROM Timings"); //usunięcie danych z Timings
      migrationBuilder.DropForeignKey("FK_Timings_AspNetUsers_DoctorId", "Timings"); //usunięcie klucza obcego do AspNetUsers
      migrationBuilder.DropColumn("DoctorId", "Timings"); //Usunięcie kolumny
      migrationBuilder.AddColumn<int>("DoctorId", "Timings", type: "int"); //dodanie nowej kolumny
      migrationBuilder.AddForeignKey("FK_Timings_Doctors_DoctorId", "Timings", "DoctorId", "Doctors", "dbo", "dbo", "Id"); //dodanie klucza obcego
    }
  }
}
