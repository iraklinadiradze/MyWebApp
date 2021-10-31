using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "gl");

            migrationBuilder.CreateTable(
                name: "FinAccount",
                schema: "gl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinAccount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlTransaction",
                schema: "gl",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlTransaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GlAccount",
                schema: "gl",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinAccountId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlAccount_FinAccount_FinAccountId",
                        column: x => x.FinAccountId,
                        principalSchema: "gl",
                        principalTable: "FinAccount",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GlTransactionDetail",
                schema: "gl",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionId = table.Column<long>(type: "bigint", nullable: false),
                    GlAccountId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDebit = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlTransactionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GlTransactionDetail_GlAccount_GlAccountId",
                        column: x => x.GlAccountId,
                        principalSchema: "gl",
                        principalTable: "GlAccount",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GlTransactionDetail_GlTransaction_TransactionId",
                        column: x => x.TransactionId,
                        principalSchema: "gl",
                        principalTable: "GlTransaction",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GlAccount_FinAccountId",
                schema: "gl",
                table: "GlAccount",
                column: "FinAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GlTransactionDetail_GlAccountId",
                schema: "gl",
                table: "GlTransactionDetail",
                column: "GlAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GlTransactionDetail_TransactionId",
                schema: "gl",
                table: "GlTransactionDetail",
                column: "TransactionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GlTransactionDetail",
                schema: "gl");

            migrationBuilder.DropTable(
                name: "GlAccount",
                schema: "gl");

            migrationBuilder.DropTable(
                name: "GlTransaction",
                schema: "gl");

            migrationBuilder.DropTable(
                name: "FinAccount",
                schema: "gl");
        }
    }
}
