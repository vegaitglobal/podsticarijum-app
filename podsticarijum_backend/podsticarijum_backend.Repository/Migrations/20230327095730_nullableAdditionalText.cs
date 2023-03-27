using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace podsticarijum_backend.Repository.Migrations
{
    public partial class nullableAdditionalText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalText",
                table: "Content",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalText",
                table: "Content");
        }
    }
}
