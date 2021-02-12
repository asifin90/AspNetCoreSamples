using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileApplication.Migrations
{
    public partial class NewDatabaseAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Battery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Processor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplaySize = table.Column<double>(type: "float", nullable: false),
                    OperatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SimDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    weight = table.Column<double>(type: "float", nullable: false),
                    isWIFISupport = table.Column<bool>(type: "bit", nullable: false),
                    isBluetoothSupport = table.Column<bool>(type: "bit", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productDetails_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productDetails_BrandId",
                table: "productDetails",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productDetails");

            migrationBuilder.DropTable(
                name: "Brand");
        }
    }
}
