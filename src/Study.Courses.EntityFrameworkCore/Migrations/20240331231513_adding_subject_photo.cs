using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Study.Courses.Migrations
{
    /// <inheritdoc />
    public partial class adding_subject_photo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Subjects");
        }
    }
}
