using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "cor",
                table: "User",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductUnit",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorSalePrice",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorProductFeature",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorDetail",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessor",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductLabel",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductGroupTemplateFeature",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductGroupTemplate",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductGroup",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductFeature",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductCategory",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "Product",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "cli",
                table: "Person",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "cli",
                table: "LegalEntity",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "FeatureValue",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "Feature",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "cor",
                table: "Currency",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "cor",
                table: "Country",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "cli",
                table: "Client",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "Brand",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "cor",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductUnit",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorSalePrice",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorProductFeature",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorDetail",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductLabel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductGroupTemplateFeature",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductGroupTemplate",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductGroup",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductFeature",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductCategory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "cli",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "cli",
                table: "LegalEntity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "FeatureValue",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "Feature",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "cor",
                table: "Currency",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "cor",
                table: "Country",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "cli",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Version",
                schema: "pro",
                table: "Brand",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }
    }
}
