using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductProcessorProductFeature",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductProcessorDetailId = table.Column<int>(type: "int", nullable: false),
                    FeatureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    FeatureValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatureValueId = table.Column<int>(type: "int", nullable: false),
                    FeatureValueIdDictionary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProcessorProductFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProcessorProductFeature_ProductProcessorDetail_ProductProcessorDetailId",
                        column: x => x.ProductProcessorDetailId,
                        principalSchema: "pro",
                        principalTable: "ProductProcessorDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductProcessorSalePrice",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductProcessorDetailId = table.Column<int>(type: "int", nullable: false),
                    SaleSchemaId = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProcessorSalePrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProcessorSalePrice_ProductProcessorDetail_ProductProcessorDetailId",
                        column: x => x.ProductProcessorDetailId,
                        principalSchema: "pro",
                        principalTable: "ProductProcessorDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductProcessorProductFeature_ProductProcessorDetailId",
                schema: "pro",
                table: "ProductProcessorProductFeature",
                column: "ProductProcessorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProcessorSalePrice_ProductProcessorDetailId",
                schema: "pro",
                table: "ProductProcessorSalePrice",
                column: "ProductProcessorDetailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductProcessorProductFeature",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "ProductProcessorSalePrice",
                schema: "pro");
        }
    }
}
