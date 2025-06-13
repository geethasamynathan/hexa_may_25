using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleWebApiDemo1.Migrations
{
    /// <inheritdoc />
    public partial class isActivecolumnsaddedincoursetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Courses");
        }
    }
}
