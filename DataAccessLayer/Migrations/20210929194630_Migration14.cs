using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseAllocation",
                schema: "prc");

            migrationBuilder.CreateTable(
                name: "PurchaseAllocationSchema",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseAllocationSchema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseAllocationSourceType",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseAllocationSourceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseAllocationSource",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    PurchaseAllocationSourceTypeId = table.Column<int>(type: "int", nullable: false),
                    AllocPurchaseDetailId = table.Column<int>(type: "int", nullable: false),
                    GlAccountId = table.Column<int>(type: "int", nullable: false),
                    PurchaseAllocSchemaId = table.Column<int>(type: "int", nullable: false),
                    PurchaseAllocationSchemaId = table.Column<int>(type: "int", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseAllocationSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseAllocationSource_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "prc",
                        principalTable: "Purchase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseAllocationSource_PurchaseAllocationSchema_PurchaseAllocationSchemaId",
                        column: x => x.PurchaseAllocationSchemaId,
                        principalSchema: "prc",
                        principalTable: "PurchaseAllocationSchema",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseAllocationSource_PurchaseAllocationSourceType_PurchaseAllocationSourceTypeId",
                        column: x => x.PurchaseAllocationSourceTypeId,
                        principalSchema: "prc",
                        principalTable: "PurchaseAllocationSourceType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseAllocationSource_PurchaseDetail_AllocPurchaseDetailId",
                        column: x => x.AllocPurchaseDetailId,
                        principalSchema: "prc",
                        principalTable: "PurchaseDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseAllocationResult",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseAllocationSourceId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDetailId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseAllocationResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseAllocationResult_PurchaseAllocationSource_PurchaseAllocationSourceId",
                        column: x => x.PurchaseAllocationSourceId,
                        principalSchema: "prc",
                        principalTable: "PurchaseAllocationSource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseAllocationResult_PurchaseDetail_PurchaseDetailId",
                        column: x => x.PurchaseDetailId,
                        principalSchema: "prc",
                        principalTable: "PurchaseDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocationResult_PurchaseAllocationSourceId",
                schema: "prc",
                table: "PurchaseAllocationResult",
                column: "PurchaseAllocationSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocationResult_PurchaseDetailId",
                schema: "prc",
                table: "PurchaseAllocationResult",
                column: "PurchaseDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocationSource_AllocPurchaseDetailId",
                schema: "prc",
                table: "PurchaseAllocationSource",
                column: "AllocPurchaseDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocationSource_PurchaseAllocationSchemaId",
                schema: "prc",
                table: "PurchaseAllocationSource",
                column: "PurchaseAllocationSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocationSource_PurchaseAllocationSourceTypeId",
                schema: "prc",
                table: "PurchaseAllocationSource",
                column: "PurchaseAllocationSourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocationSource_PurchaseId",
                schema: "prc",
                table: "PurchaseAllocationSource",
                column: "PurchaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseAllocationResult",
                schema: "prc");

            migrationBuilder.DropTable(
                name: "PurchaseAllocationSource",
                schema: "prc");

            migrationBuilder.DropTable(
                name: "PurchaseAllocationSchema",
                schema: "prc");

            migrationBuilder.DropTable(
                name: "PurchaseAllocationSourceType",
                schema: "prc");

            migrationBuilder.CreateTable(
                name: "PurchaseAllocation",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostStarted = table.Column<bool>(type: "bit", nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocation_PurchaseId",
                schema: "prc",
                table: "PurchaseAllocation",
                column: "PurchaseId");
        }
    }
}
