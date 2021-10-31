using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pos");

            migrationBuilder.CreateTable(
                name: "Sale",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    ConsultantId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    FinPosted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPosted = table.Column<bool>(type: "bit", nullable: false),
                    PaymentPosted = table.Column<bool>(type: "bit", nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Location_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "inv",
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sale_User_ConsultantId",
                        column: x => x.ConsultantId,
                        principalSchema: "cor",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sale_User_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "cor",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalePaymentType",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePaymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleSchema",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleSchema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReturnProduct",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NominalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NominalPriceDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SchemaPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cogs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    ConsultantId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    FinPosted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPosted = table.Column<bool>(type: "bit", nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnProduct_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "inv",
                        principalTable: "Inventory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReturnProduct_Sale_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "pos",
                        principalTable: "Sale",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleProduct",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NominalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NominalPriceDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SchemaPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cogs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    ConsultantId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    FinPosted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPosted = table.Column<bool>(type: "bit", nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "inv",
                        principalTable: "Inventory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SaleProduct_Sale_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "pos",
                        principalTable: "Sale",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalePayment",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    AmountIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountOut = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalePayment_Sale_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "pos",
                        principalTable: "Sale",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalePayment_SalePaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "pos",
                        principalTable: "SalePaymentType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleSchemaDetail",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleSchemaId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleSchemaDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleSchemaDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "pro",
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SaleSchemaDetail_SaleSchema_SaleSchemaId",
                        column: x => x.SaleSchemaId,
                        principalSchema: "pos",
                        principalTable: "SaleSchema",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReturnProduct_InventoryId",
                schema: "pos",
                table: "ReturnProduct",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnProduct_SaleId",
                schema: "pos",
                table: "ReturnProduct",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ConsultantId",
                schema: "pos",
                table: "Sale",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_OwnerId",
                schema: "pos",
                table: "Sale",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ShopId",
                schema: "pos",
                table: "Sale",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayment_PaymentTypeId",
                schema: "pos",
                table: "SalePayment",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayment_SaleId",
                schema: "pos",
                table: "SalePayment",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_InventoryId",
                schema: "pos",
                table: "SaleProduct",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_SaleId",
                schema: "pos",
                table: "SaleProduct",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleSchemaDetail_ProductId",
                schema: "pos",
                table: "SaleSchemaDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleSchemaDetail_SaleSchemaId",
                schema: "pos",
                table: "SaleSchemaDetail",
                column: "SaleSchemaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReturnProduct",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "SalePayment",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "SaleProduct",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "SaleSchemaDetail",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "SalePaymentType",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "Sale",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "SaleSchema",
                schema: "pos");
        }
    }
}
