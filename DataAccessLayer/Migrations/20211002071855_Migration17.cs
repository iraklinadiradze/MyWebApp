using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "acc");

            migrationBuilder.CreateTable(
                name: "Entity",
                schema: "cor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountDimension",
                schema: "acc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityId1 = table.Column<int>(type: "int", nullable: true),
                    EntityId2 = table.Column<int>(type: "int", nullable: true),
                    EntityId3 = table.Column<int>(type: "int", nullable: true),
                    EntityId4 = table.Column<int>(type: "int", nullable: true),
                    EntityId5 = table.Column<int>(type: "int", nullable: true),
                    EntityId6 = table.Column<int>(type: "int", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountDimension", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountDimension_Entity_EntityId1",
                        column: x => x.EntityId1,
                        principalSchema: "cor",
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountDimension_Entity_EntityId2",
                        column: x => x.EntityId2,
                        principalSchema: "cor",
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountDimension_Entity_EntityId3",
                        column: x => x.EntityId3,
                        principalSchema: "cor",
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountDimension_Entity_EntityId4",
                        column: x => x.EntityId4,
                        principalSchema: "cor",
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountDimension_Entity_EntityId5",
                        column: x => x.EntityId5,
                        principalSchema: "cor",
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountDimension_Entity_EntityId6",
                        column: x => x.EntityId6,
                        principalSchema: "cor",
                        principalTable: "Entity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TransactionOrder",
                schema: "acc",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReferenceEntityId = table.Column<int>(type: "int", nullable: true),
                    ReferenceId = table.Column<long>(type: "bigint", nullable: true),
                    SubReferenceEntityId = table.Column<int>(type: "int", nullable: true),
                    SubReferenceId = table.Column<long>(type: "bigint", nullable: true),
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransactionOrder_Entity_ReferenceEntityId",
                        column: x => x.ReferenceEntityId,
                        principalSchema: "cor",
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TransactionOrder_Entity_SubReferenceEntityId",
                        column: x => x.SubReferenceEntityId,
                        principalSchema: "cor",
                        principalTable: "Entity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Account ",
                schema: "acc",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountDimensionId = table.Column<int>(type: "int", nullable: false),
                    EntityForeignId1 = table.Column<int>(type: "int", nullable: true),
                    EntityForeignId2 = table.Column<int>(type: "int", nullable: true),
                    EntityForeignId3 = table.Column<int>(type: "int", nullable: true),
                    EntityForeignId4 = table.Column<int>(type: "int", nullable: true),
                    EntityForeignId5 = table.Column<int>(type: "int", nullable: true),
                    EntityForeignId6 = table.Column<int>(type: "int", nullable: true),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account _AccountDimension_AccountDimensionId",
                        column: x => x.AccountDimensionId,
                        principalSchema: "acc",
                        principalTable: "AccountDimension",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AccountBalance",
                schema: "acc",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    increase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    decrease = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountBalanceCount = table.Column<int>(type: "int", nullable: false),
                    MaxPostTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BalanceTransactionId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBalance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountBalance_Account _AccountId",
                        column: x => x.AccountId,
                        principalSchema: "acc",
                        principalTable: "Account ",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                schema: "acc",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostOrderRefId = table.Column<long>(type: "bigint", nullable: true),
                    ReferenceEntityId = table.Column<int>(type: "int", nullable: true),
                    ReferenceId = table.Column<long>(type: "bigint", nullable: true),
                    SubReferenceEntityId = table.Column<int>(type: "int", nullable: true),
                    SubReferenceId = table.Column<long>(type: "bigint", nullable: true),
                    RefVersion = table.Column<int>(type: "int", nullable: true),
                    AccountId = table.Column<long>(type: "bigint", nullable: false),
                    increase = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    decrease = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Eod = table.Column<bool>(type: "bit", nullable: false),
                    AccountTranSeq = table.Column<long>(type: "bigint", nullable: false),
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Account _AccountId",
                        column: x => x.AccountId,
                        principalSchema: "acc",
                        principalTable: "Account ",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transaction_Entity_ReferenceEntityId",
                        column: x => x.ReferenceEntityId,
                        principalSchema: "cor",
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transaction_Entity_SubReferenceEntityId",
                        column: x => x.SubReferenceEntityId,
                        principalSchema: "cor",
                        principalTable: "Entity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account _AccountDimensionId",
                schema: "acc",
                table: "Account ",
                column: "AccountDimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBalance_AccountId",
                schema: "acc",
                table: "AccountBalance",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDimension_EntityId1",
                schema: "acc",
                table: "AccountDimension",
                column: "EntityId1");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDimension_EntityId2",
                schema: "acc",
                table: "AccountDimension",
                column: "EntityId2");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDimension_EntityId3",
                schema: "acc",
                table: "AccountDimension",
                column: "EntityId3");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDimension_EntityId4",
                schema: "acc",
                table: "AccountDimension",
                column: "EntityId4");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDimension_EntityId5",
                schema: "acc",
                table: "AccountDimension",
                column: "EntityId5");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDimension_EntityId6",
                schema: "acc",
                table: "AccountDimension",
                column: "EntityId6");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountId",
                schema: "acc",
                table: "Transaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ReferenceEntityId",
                schema: "acc",
                table: "Transaction",
                column: "ReferenceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_SubReferenceEntityId",
                schema: "acc",
                table: "Transaction",
                column: "SubReferenceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionOrder_ReferenceEntityId",
                schema: "acc",
                table: "TransactionOrder",
                column: "ReferenceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionOrder_SubReferenceEntityId",
                schema: "acc",
                table: "TransactionOrder",
                column: "SubReferenceEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountBalance",
                schema: "acc");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "acc");

            migrationBuilder.DropTable(
                name: "TransactionOrder",
                schema: "acc");

            migrationBuilder.DropTable(
                name: "Account ",
                schema: "acc");

            migrationBuilder.DropTable(
                name: "AccountDimension",
                schema: "acc");

            migrationBuilder.DropTable(
                name: "Entity",
                schema: "cor");
        }
    }
}
