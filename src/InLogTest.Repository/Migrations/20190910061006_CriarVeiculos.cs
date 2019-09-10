using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InLogTest.Repository.Migrations
{
    public partial class CriarVeiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    varchar250 = table.Column<string>(name: "varchar(250)", nullable: false),
                    varchar50 = table.Column<string>(name: "varchar(50)", nullable: false),
                    typeVehicle = table.Column<int>(nullable: false),
                    numberPassagers = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("id", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
