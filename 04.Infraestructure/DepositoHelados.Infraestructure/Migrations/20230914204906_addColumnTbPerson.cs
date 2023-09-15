using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepositoHelados.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class addColumnTbPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateBirthday",
                table: "Person",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBirthday",
                table: "Person");
        }
    }
}
