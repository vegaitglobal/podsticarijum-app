using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace podsticarijum_backend.Repository.Migrations
{
    public partial class descriptionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faq_Category_CategoryId",
                table: "Faq");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Faq",
                newName: "SubCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Faq_CategoryId",
                table: "Faq",
                newName: "IX_Faq_SubCategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Expert",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Faq_SubCategory_SubCategoryId",
                table: "Faq",
                column: "SubCategoryId",
                principalTable: "SubCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faq_SubCategory_SubCategoryId",
                table: "Faq");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Expert");

            migrationBuilder.RenameColumn(
                name: "SubCategoryId",
                table: "Faq",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Faq_SubCategoryId",
                table: "Faq",
                newName: "IX_Faq_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faq_Category_CategoryId",
                table: "Faq",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
