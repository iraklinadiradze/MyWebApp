using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                schema: "cor",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "ProductUnit");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorSalePrice");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorProductFeature");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorDetail");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "ProductProcessor");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "ProductLabel");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "ProductGroupTemplateFeature");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "ProductGroupTemplate");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "ProductGroup");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "ProductFeature");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "cli",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "cli",
                table: "LegalEntity");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "FeatureValue");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "cor",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "cor",
                table: "Country");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "cli",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "pro",
                table: "Brand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "cor",
                table: "User",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductUnit",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorSalePrice",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorProductFeature",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorDetail",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessor",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductLabel",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductGroupTemplateFeature",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductGroupTemplate",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductGroup",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductFeature",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "ProductCategory",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "Product",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "cli",
                table: "Person",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "cli",
                table: "LegalEntity",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "FeatureValue",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "Feature",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "cor",
                table: "Currency",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "cor",
                table: "Country",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "cli",
                table: "Client",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                schema: "pro",
                table: "Brand",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
