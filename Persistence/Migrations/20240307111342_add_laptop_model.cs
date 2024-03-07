using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaptopStoreAPI.Migrations
{
    /// <inheritdoc />
    public partial class addlaptopmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "laptops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Battery = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Bluetooth = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Camera = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Dimension = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WeightKg = table.Column<double>(type: "float", nullable: false),
                    Wifi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Warranty = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProcessorId = table.Column<int>(type: "int", nullable: false),
                    RamId = table.Column<int>(type: "int", nullable: false),
                    DriveId = table.Column<int>(type: "int", nullable: false),
                    DisplayId = table.Column<int>(type: "int", nullable: false),
                    GraphicsCardId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_laptops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_laptops_displays_DisplayId",
                        column: x => x.DisplayId,
                        principalTable: "displays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_laptops_drives_DriveId",
                        column: x => x.DriveId,
                        principalTable: "drives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_laptops_graphicsCards_GraphicsCardId",
                        column: x => x.GraphicsCardId,
                        principalTable: "graphicsCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_laptops_processors_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "processors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_laptops_rams_RamId",
                        column: x => x.RamId,
                        principalTable: "rams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_laptops_DisplayId",
                table: "laptops",
                column: "DisplayId");

            migrationBuilder.CreateIndex(
                name: "IX_laptops_DriveId",
                table: "laptops",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_laptops_GraphicsCardId",
                table: "laptops",
                column: "GraphicsCardId");

            migrationBuilder.CreateIndex(
                name: "IX_laptops_Model",
                table: "laptops",
                column: "Model",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_laptops_ProcessorId",
                table: "laptops",
                column: "ProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_laptops_RamId",
                table: "laptops",
                column: "RamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "laptops");
        }
    }
}
