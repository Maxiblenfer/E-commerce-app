using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back_End.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    names = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastnames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
