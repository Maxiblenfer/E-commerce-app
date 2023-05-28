using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back_End.Migrations
{
    /// <inheritdoc />
    public partial class Initial10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
