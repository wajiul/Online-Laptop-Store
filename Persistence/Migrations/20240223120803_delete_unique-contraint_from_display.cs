using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class deleteuniquecontraintfromdisplay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_displays_Type_Size_Resolution",
                table: "displays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_displays_Type_Size_Resolution",
                table: "displays",
                columns: new[] { "Type", "Size", "Resolution" });
        }
    }
}
