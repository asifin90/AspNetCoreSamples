using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileApplication.Migrations
{
    public partial class MobileDetailsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    MobileBrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productDetails_Brand_MobileBrandId",
                        column: x => x.MobileBrandId,
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_productDetails_MobileBrandId",
                table: "productDetails",
                column: "MobileBrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "productDetails");
        }
    }
}
