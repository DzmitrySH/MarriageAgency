using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarriageAgency.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nationalities",
                columns: table => new
                {
                    NationalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nationalities", x => x.NationalID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NamePosition = table.Column<string>(maxLength: 20, nullable: true),
                    Salary = table.Column<decimal>(type: "money", nullable: false),
                    Responsibilitie = table.Column<string>(maxLength: 20, nullable: true),
                    Requirement = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "Relations",
                columns: table => new
                {
                    RelationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.RelationID);
                });

            migrationBuilder.CreateTable(
                name: "ZodiacSigns",
                columns: table => new
                {
                    ZodiacSignID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZodiacSigns", x => x.ZodiacSignID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirsLastMidName = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    Addres = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Passport = table.Column<string>(maxLength: 20, nullable: false),
                    PositionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirsLastMidName = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(maxLength: 10, nullable: false),
                    DateofBirth = table.Column<DateTime>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Children = table.Column<int>(nullable: false),
                    MaritalStatus = table.Column<string>(maxLength: 30, nullable: false),
                    BadHabits = table.Column<string>(maxLength: 30, nullable: false),
                    Hobby = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 20, nullable: false),
                    ZodiacSignID = table.Column<int>(nullable: false),
                    RelationID = table.Column<int>(nullable: false),
                    NationalID = table.Column<int>(nullable: false),
                    Addres = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Passport = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                    table.ForeignKey(
                        name: "FK_Clients_Nationalities_NationalID",
                        column: x => x.NationalID,
                        principalTable: "Nationalities",
                        principalColumn: "NationalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_Relations_RelationID",
                        column: x => x.RelationID,
                        principalTable: "Relations",
                        principalColumn: "RelationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_ZodiacSigns_ZodiacSignID",
                        column: x => x.ZodiacSignID,
                        principalTable: "ZodiacSigns",
                        principalColumn: "ZodiacSignID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    ClientID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiseID);
                    table.ForeignKey(
                        name: "FK_Services_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_NationalID",
                table: "Clients",
                column: "NationalID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_RelationID",
                table: "Clients",
                column: "RelationID");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ZodiacSignID",
                table: "Clients",
                column: "ZodiacSignID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionID",
                table: "Employees",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ClientID",
                table: "Services",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_EmployeeID",
                table: "Services",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Nationalities");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "ZodiacSigns");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
