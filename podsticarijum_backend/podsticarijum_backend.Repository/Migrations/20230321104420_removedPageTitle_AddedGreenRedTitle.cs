using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace podsticarijum_backend.Repository.Migrations
{
    public partial class removedPageTitle_AddedGreenRedTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PageTitle",
                table: "SubCategorySpecificContent");

            migrationBuilder.AddColumn<string>(
                name: "GreenActivityPageTitle",
                table: "SubCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RedActivityPageTitle",
                table: "SubCategory",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GreenActivityPageTitle",
                table: "SubCategory");

            migrationBuilder.DropColumn(
                name: "RedActivityPageTitle",
                table: "SubCategory");

            migrationBuilder.AddColumn<string>(
                name: "PageTitle",
                table: "SubCategorySpecificContent",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
