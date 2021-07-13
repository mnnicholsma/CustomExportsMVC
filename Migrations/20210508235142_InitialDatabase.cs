using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomExports.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfAccounts = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExportFormatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false),
                    AdmitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accounts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExportConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ExportType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Delimiter = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportConfigs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportConfigs_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ExportFormatId", "Name" },
                values: new object[] { 1, 1, "General Hospital" });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "ExportFormatId", "Name" },
                values: new object[] { 2, 2, "Veteran Hospital" });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "AdmitDate", "Balance", "ClientId", "DischargeDate", "FacilityId", "PatientId" },
                values: new object[,]
                {
                    { 1, "5000", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.12, 1, new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 200 },
                    { 4, "5003", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.439999999999998, 1, new DateTime(2005, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 201 },
                    { 5, "5004", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0, 1, new DateTime(2005, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 201 },
                    { 2, "5001", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 566.22000000000003, 2, new DateTime(2005, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 200 },
                    { 3, "5002", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1921.0, 2, new DateTime(2005, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 200 },
                    { 6, "5005", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 875.22000000000003, 2, new DateTime(2005, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 202 },
                    { 7, "5006", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 44.329999999999998, 2, new DateTime(2005, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 202 },
                    { 8, "5007", new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.949999999999999, 2, new DateTime(2005, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 202 }
                });

            migrationBuilder.InsertData(
                table: "ExportConfigs",
                columns: new[] { "Id", "ClientId", "Delimiter", "ExportType" },
                values: new object[,]
                {
                    { 1, 1, "|", "Pipe Delimited Format" },
                    { 2, 2, ",", "Comma Delimited Format" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClientId",
                table: "Accounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportConfigs_ClientId",
                table: "ExportConfigs",
                column: "ClientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AppLogs");

            migrationBuilder.DropTable(
                name: "ExportConfigs");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
