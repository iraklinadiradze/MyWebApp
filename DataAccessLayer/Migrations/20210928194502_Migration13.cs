using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseAllocation",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostStarted = table.Column<bool>(type: "bit", nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseAllocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseAllocation_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "prc",
                        principalTable: "Purchase",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetail",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InventoryCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PurchaseDraftVersion = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    PurchaseDraftId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    QtyInvoiced = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostInvoiced = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatInvoiced = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostInvoicedWithoutVat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostInvoicedEqu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtyCalculated = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostCalculated = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostCalculatedEqu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseDetailPostTypeId = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtyPosted = table.Column<bool>(type: "bit", nullable: false),
                    FinPosted = table.Column<bool>(type: "bit", nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    GlAccountId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    AddCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Allocated = table.Column<bool>(type: "bit", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "inv",
                        principalTable: "Inventory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "inv",
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "pro",
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "prc",
                        principalTable: "Purchase",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocation_PurchaseId",
                schema: "prc",
                table: "PurchaseAllocation",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_InventoryId",
                schema: "prc",
                table: "PurchaseDetail",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_LocationId",
                schema: "prc",
                table: "PurchaseDetail",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_ProductId",
                schema: "prc",
                table: "PurchaseDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_PurchaseId",
                schema: "prc",
                table: "PurchaseDetail",
                column: "PurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseAllocation",
                schema: "prc");

            migrationBuilder.DropTable(
                name: "PurchaseDetail",
                schema: "prc");
        }
    }
}
