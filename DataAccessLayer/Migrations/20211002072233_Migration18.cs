using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PostOrderRefId",
                schema: "acc",
                table: "Transaction",
                column: "PostOrderRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_TransactionOrder_PostOrderRefId",
                schema: "acc",
                table: "Transaction",
                column: "PostOrderRefId",
                principalSchema: "acc",
                principalTable: "TransactionOrder",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_TransactionOrder_PostOrderRefId",
                schema: "acc",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_PostOrderRefId",
                schema: "acc",
                table: "Transaction");
        }
    }
}
