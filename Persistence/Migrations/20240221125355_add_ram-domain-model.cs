using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class addramdomainmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_processors_Model_Brand",
                table: "processors");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "processors",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "rams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FrequencyMHz = table.Column<float>(type: "real", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Slot = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rams", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_processors_Model",
                table: "processors",
                column: "Model",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_rams_Model",
                table: "rams",
                column: "Model",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rams");

            migrationBuilder.DropIndex(
                name: "IX_processors_Model",
                table: "processors");

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "processors",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_processors_Model_Brand",
                table: "processors",
                columns: new[] { "Model", "Brand" },
                unique: true);
        }
    }
}
