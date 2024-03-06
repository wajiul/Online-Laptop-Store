using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class addgraphicscardmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "graphicsCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_graphicsCards", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_graphicsCards_Model",
                table: "graphicsCards",
                column: "Model",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "graphicsCards");
        }
    }
}
