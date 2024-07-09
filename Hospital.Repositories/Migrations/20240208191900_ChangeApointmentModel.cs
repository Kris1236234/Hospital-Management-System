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
  //[Migration("20240208191900_ChangeApointmentModel")]
  public partial class _20240208191900_ChangeApointmentModel : Migration
  {
    protected override void Up([NotNullAttribute] MigrationBuilder migrationBuilder)
    {
      //migrationBuilder.AddColumn<int>("RoomId", "Appointments");
      //migrationBuilder.AddColumn<DateTime>("AppointmentEndTime", "Appointments", type: "datetime2");
      //migrationBuilder.AddForeignKey("FK_Appointments_RoomId_Room_Id", "Appointments", "RoomId", "Rooms", "dbo", "dbo", "Id");
    }
  }
}
