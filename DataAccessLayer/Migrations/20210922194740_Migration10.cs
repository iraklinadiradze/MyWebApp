using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "inv");

            migrationBuilder.CreateTable(
                name: "Inventory",
                schema: "inv",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InventoryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProcInInventory = table.Column<bool>(type: "bit", nullable: true),
                    IsSingle = table.Column<bool>(type: "bit", nullable: true),
                    IsWholeQuantity = table.Column<bool>(type: "bit", nullable: true),
                    ProductUnitId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityId = table.Column<int>(type: "int", nullable: true),
                    EntityForeignId = table.Column<long>(type: "bigint", nullable: true),
                    EntityProcCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "pro",
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventory_ProductUnit_ProductUnitId",
                        column: x => x.ProductUnitId,
                        principalSchema: "pro",
                        principalTable: "ProductUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "inv",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movement",
                schema: "inv",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SendLocationId = table.Column<int>(type: "int", nullable: false),
                    ReceiveLocationId = table.Column<int>(type: "int", nullable: false),
                    SendQtyPostStarted = table.Column<bool>(type: "bit", nullable: true),
                    SendFinPostStarted = table.Column<bool>(type: "bit", nullable: true),
                    ReceiveQtyPostStarted = table.Column<bool>(type: "bit", nullable: true),
                    ReceiveFinPostStarted = table.Column<bool>(type: "bit", nullable: true),
                    SendQtyPosted = table.Column<bool>(type: "bit", nullable: true),
                    SendFinPosted = table.Column<bool>(type: "bit", nullable: true),
                    ReceiveQtyPosted = table.Column<bool>(type: "bit", nullable: true),
                    ReceiveFinPosted = table.Column<bool>(type: "bit", nullable: true),
                    SendPosted = table.Column<bool>(type: "bit", nullable: true),
                    ReceivePosted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movement_Location_ReceiveLocationId",
                        column: x => x.ReceiveLocationId,
                        principalSchema: "inv",
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movement_Location_SendLocationId",
                        column: x => x.SendLocationId,
                        principalSchema: "inv",
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovementDetail",
                schema: "inv",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovementId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    SendQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SendValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReceiveQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReceiveValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SendQtyPosted = table.Column<bool>(type: "bit", nullable: true),
                    SendFinPosted = table.Column<bool>(type: "bit", nullable: true),
                    ReceiveQtyPosted = table.Column<bool>(type: "bit", nullable: true),
                    ReceiveFinPosted = table.Column<bool>(type: "bit", nullable: true),
                    SendPosted = table.Column<bool>(type: "bit", nullable: true),
                    ReceivePosted = table.Column<bool>(type: "bit", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementDetail_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "inv",
                        principalTable: "Inventory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovementDetail_Movement_MovementId",
                        column: x => x.MovementId,
                        principalSchema: "inv",
                        principalTable: "Movement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductId",
                schema: "inv",
                table: "Inventory",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ProductUnitId",
                schema: "inv",
                table: "Inventory",
                column: "ProductUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Movement_ReceiveLocationId",
                schema: "inv",
                table: "Movement",
                column: "ReceiveLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Movement_SendLocationId",
                schema: "inv",
                table: "Movement",
                column: "SendLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementDetail_InventoryId",
                schema: "inv",
                table: "MovementDetail",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementDetail_MovementId",
                schema: "inv",
                table: "MovementDetail",
                column: "MovementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovementDetail",
                schema: "inv");

            migrationBuilder.DropTable(
                name: "Inventory",
                schema: "inv");

            migrationBuilder.DropTable(
                name: "Movement",
                schema: "inv");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "inv");
        }
    }
}
