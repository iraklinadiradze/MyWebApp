using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration8 : Migration
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
            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "cor",
                table: "User",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "ProductUnit",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorSalePrice",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorProductFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorDetail",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessor",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "ProductLabel",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "ProductGroupTemplateFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "ProductGroupTemplate",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "ProductGroup",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "ProductFeature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "ProductCategory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "cli",
                table: "Person",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "cli",
                table: "LegalEntity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "FeatureValue",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "Feature",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "cor",
                table: "Currency",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "cor",
                table: "Country",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "cli",
                table: "Client",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Version",
                schema: "pro",
                table: "Brand",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
