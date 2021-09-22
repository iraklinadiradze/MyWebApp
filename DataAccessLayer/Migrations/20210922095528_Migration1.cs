using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductProcessor",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    IdentifyProducts = table.Column<bool>(type: "bit", nullable: false),
                    RegisterBrandProps = table.Column<bool>(type: "bit", nullable: false),
                    RegisterProducts = table.Column<bool>(type: "bit", nullable: false),
                    IdentifyProductsAfterRegistration = table.Column<bool>(type: "bit", nullable: false),
                    RegisterSalesPrices = table.Column<bool>(type: "bit", nullable: false),
                    RegisterPurchaseDetails = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProcessor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductProcessorDetail",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductProcessorId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    BrandIdDictionary = table.Column<int>(type: "int", nullable: true),
                    ProductGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductGroupId = table.Column<int>(type: "int", nullable: true),
                    ProductGroupIdDictionary = table.Column<int>(type: "int", nullable: true),
                    ProductLabelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductLabelId = table.Column<int>(type: "int", nullable: true),
                    ProductLabelIdDictionary = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProcessorDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProcessorDetail_ProductProcessor_ProductProcessorId",
                        column: x => x.ProductProcessorId,
                        principalSchema: "pro",
                        principalTable: "ProductProcessor",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProcessorDetail_ProductProcessorId",
                schema: "pro",
                table: "ProductProcessorDetail",
                column: "ProductProcessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProcessorDetail",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "ProductProcessor",
                schema: "pro");
        }
    }
}
