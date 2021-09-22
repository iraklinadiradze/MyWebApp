using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class Migration9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "cor",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductUnit",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorSalePrice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorProductFeature",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessorDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductProcessor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductLabel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductGroupTemplateFeature",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductGroupTemplate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductGroup",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductFeature",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "ProductCategory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "cli",
                table: "Person",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "cli",
                table: "LegalEntity",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "FeatureValue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "Feature",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "cor",
                table: "Currency",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "cor",
                table: "Country",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "cli",
                table: "Client",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "pro",
                table: "Brand",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
