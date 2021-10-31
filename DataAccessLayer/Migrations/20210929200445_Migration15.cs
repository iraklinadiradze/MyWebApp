using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PurchaseDetailPostTypeId",
                schema: "prc",
                table: "PurchaseDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateTable(
                name: "PurchaseDetailPostType",
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
                    table.PrimaryKey("PK_PurchaseDetailPostType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_PurchaseDetailPostTypeId",
                schema: "prc",
                table: "PurchaseDetail",
                column: "PurchaseDetailPostTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseDetail_PurchaseDetailPostType_PurchaseDetailPostTypeId",
                schema: "prc",
                table: "PurchaseDetail",
                column: "PurchaseDetailPostTypeId",
                principalSchema: "prc",
                principalTable: "PurchaseDetailPostType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseDetail_PurchaseDetailPostType_PurchaseDetailPostTypeId",
                schema: "prc",
                table: "PurchaseDetail");

            migrationBuilder.DropTable(
                name: "PurchaseDetailPostType",
                schema: "prc");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseDetail_PurchaseDetailPostTypeId",
                schema: "prc",
                table: "PurchaseDetail");

            migrationBuilder.AlterColumn<decimal>(
                name: "PurchaseDetailPostTypeId",
                schema: "prc",
                table: "PurchaseDetail",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
