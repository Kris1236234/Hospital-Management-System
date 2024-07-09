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
  [DbContext(typeof(ApplicationDbContext))]
  [Migration("20240208192700_AddPatientsData")]
  public partial class _20240208192700_AddPatientsData : Migration
  {
    protected override void Up([NotNullAttribute] MigrationBuilder migrationBuilder)
    {

      migrationBuilder.InsertData("Patients",
        columns: new[] { "Name", "Address", "City" },
        values: new[] { "Ala Kot", "Paderewskiego 10", "Kielce" },
        schema: "dbo",
        columnTypes: new string[] { "string", "string", "string" });

      migrationBuilder.InsertData("Patients",
        columns: new[] { "Name", "Address", "City" },
        values: new[] { "Jan Kowalski", "Jeziorańskiego 50", "Włoszczowa" },
        schema: "dbo",
        columnTypes: new string[] { "string", "string", "string" });

      migrationBuilder.InsertData("Patients",
        columns: new[] { "Name", "Address", "City" },
        values: new[] { "Tomasz Nowakowski", "Ogrodowa 21", "Pińczów" },
        schema: "dbo",
        columnTypes: new string[] { "string", "string", "string" });
    }
  }
}
