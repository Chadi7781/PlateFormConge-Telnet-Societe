using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API_Test.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    InitialCongeSolde = table.Column<int>(nullable: false),
                    RemainingCongeSolde = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Conges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Motif = table.Column<string>(nullable: true),
                    end_Date = table.Column<DateTime>(nullable: false),
                    start_Date = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<int>(nullable: false),
                    CongeState = table.Column<int>(nullable: false),
                    Half_Day = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conges_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sorties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SortieTime = table.Column<int>(nullable: false),
                    Sortie_Date = table.Column<DateTime>(nullable: false),
                    Motif = table.Column<string>(nullable: true),
                    Recovery_Date = table.Column<DateTime>(nullable: false),
                    SortieState = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sorties_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ManagerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "TeamEmployees",
                columns: table => new
                {
                    TeamId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamEmployees", x => new { x.EmployeeId, x.TeamId });
                    table.UniqueConstraint("AK_TeamEmployees_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_TeamEmployees_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "InitialCongeSolde", "LastName", "Login", "Password", "RemainingCongeSolde" },
                values: new object[,]
                {
                    { 1, "Tarek", 31, "ElGhali", "Tarek.ElGhali", "azerty", 29 },
                    { 2, "Sameh", 25, "Ouederni", "Sameh.Ouederni", "123aze", 25 },
                    { 3, "Test", 21, "testing", "test", "admin", 21 },
                    { 4, "Mahdi", 21, "Turki", "Mahdi.Turki", "123", 18 },
                    { 5, "5555", 21, "testing", "test", "admin", 21 },
                    { 6, "6666", 21, "testing", "test", "admin", 21 },
                    { 7, "7777", 21, "testing", "test", "admin", 21 }
                });

            migrationBuilder.InsertData(
                table: "Conges",
                columns: new[] { "Id", "CongeState", "end_Date", "start_Date", "EmployeeId", "Half_Day", "Motif", "Reason" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2019, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, "Sickness", 0 },
                    { 2, 0, new DateTime(2019, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, "Pregnancy", 2 }
                });

            migrationBuilder.InsertData(
                table: "Sorties",
                columns: new[] { "Id", "EmployeeId", "Motif", "SortieState", "SortieTime", "Recovery_Date", "Sortie_Date" },
                values: new object[,]
                {
                    { 3, 1, "personnel", 1, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, "personnel", 1, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 5, "personnel", 1, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "ManagerId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "TeamEmployees",
                columns: new[] { "EmployeeId", "TeamId", "Id" },
                values: new object[,]
                {
                    { 3, 1, 1 },
                    { 4, 1, 2 },
                    { 5, 1, 3 },
                    { 1, 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conges_EmployeeId",
                table: "Conges",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Sorties_EmployeeId",
                table: "Sorties",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamEmployees_TeamId",
                table: "TeamEmployees",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ManagerId",
                table: "Teams",
                column: "ManagerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conges");

            migrationBuilder.DropTable(
                name: "Sorties");

            migrationBuilder.DropTable(
                name: "TeamEmployees");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
