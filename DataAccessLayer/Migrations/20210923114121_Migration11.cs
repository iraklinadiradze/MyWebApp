using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "prc");

            migrationBuilder.CreateTable(
                name: "Purchase",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    xrate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProcInInventory = table.Column<bool>(type: "bit", nullable: false),
                    PurchaseStatusId = table.Column<int>(type: "int", nullable: false),
                    PurchaseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalCostInvoiced = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalCostInvoicedEqu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAllocCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalFinalCostEqu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AllocStarted = table.Column<bool>(type: "bit", nullable: false),
                    Allocated = table.Column<bool>(type: "bit", nullable: false),
                    FinPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    FinPosted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPosted = table.Column<bool>(type: "bit", nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Client_ClientId",
                        column: x => x.ClientId,
                        principalSchema: "cli",
                        principalTable: "Client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Purchase_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalSchema: "cor",
                        principalTable: "Currency",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_ClientId",
                schema: "prc",
                table: "Purchase",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_CurrencyId",
                schema: "prc",
                table: "Purchase",
                column: "CurrencyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchase",
                schema: "prc");
        }
    }
}
