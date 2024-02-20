using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "processors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    FrequencyGHz = table.Column<float>(type: "real", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Core = table.Column<int>(type: "int", nullable: false),
                    Thread = table.Column<int>(type: "int", nullable: false),
                    Cache = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_processors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_processors_Model_Brand",
                table: "processors",
                columns: new[] { "Model", "Brand" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "processors");
        }
    }
}
