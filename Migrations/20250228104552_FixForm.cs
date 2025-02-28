using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectMain.Migrations
{
    /// <inheritdoc />
    public partial class FixForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Topic",
                table: "Forms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Options",
                table: "FormQuestion",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "FormQuestion",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Topic",
                table: "Forms");

            migrationBuilder.DropColumn(
                name: "Options",
                table: "FormQuestion");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "FormQuestion");
        }
    }
}
