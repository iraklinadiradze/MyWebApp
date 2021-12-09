using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Migrations
{
    public partial class CreateCoreDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pro");

            migrationBuilder.EnsureSchema(
                name: "cli");

            migrationBuilder.EnsureSchema(
                name: "cor");

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "cli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsPerson = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsSupplier = table.Column<bool>(type: "bit", nullable: true),
                    IsCustomer = table.Column<bool>(type: "bit", nullable: true),
                    IsBank = table.Column<bool>(type: "bit", nullable: true),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                schema: "cor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                schema: "cor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyCode = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    CurrencyDescrip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feature",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductUnit",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductUnitName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUnit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "cor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductLabel",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    ProductLabelName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLabel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductLabel_Brand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "pro",
                        principalTable: "Brand",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LegalEntity",
                schema: "cli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    LegalEntityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    RegistrationCountryID = table.Column<int>(type: "int", nullable: false),
                    TaxCode = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TaxRegDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LegalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OfficeAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LegalEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LegalEntity_Client_Id",
                        column: x => x.Id,
                        principalSchema: "cli",
                        principalTable: "Client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LegalEntity_Country_RegistrationCountryID",
                        column: x => x.RegistrationCountryID,
                        principalSchema: "cor",
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Person",
                schema: "cli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CitizenShipId = table.Column<int>(type: "int", nullable: false),
                    PersonalId = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Client_Id",
                        column: x => x.Id,
                        principalSchema: "cli",
                        principalTable: "Client",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Person_Country_CitizenShipId",
                        column: x => x.CitizenShipId,
                        principalSchema: "cor",
                        principalTable: "Country",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FeatureValue",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    FeatureValueName = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureValue_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "pro",
                        principalTable: "Feature",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductGroupTemplate",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductGroupTemplateName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ProductUnitId = table.Column<int>(type: "int", nullable: false),
                    IsTangible = table.Column<bool>(type: "bit", nullable: true),
                    IsSingle = table.Column<bool>(type: "bit", nullable: true),
                    IsWholeQuantity = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroupTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGroupTemplate_ProductUnit_ProductUnitId",
                        column: x => x.ProductUnitId,
                        principalSchema: "pro",
                        principalTable: "ProductUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductGroup",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductGroupName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductCategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductGroupTemplateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGroup_ProductCategory_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalSchema: "pro",
                        principalTable: "ProductCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductGroup_ProductGroupTemplate_ProductGroupTemplateId",
                        column: x => x.ProductGroupTemplateId,
                        principalSchema: "pro",
                        principalTable: "ProductGroupTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductGroupTemplateFeature",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductGroupTemplateId = table.Column<int>(type: "int", nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    IsMandatory = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroupTemplateFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGroupTemplateFeature_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "pro",
                        principalTable: "Feature",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductGroupTemplateFeature_ProductGroupTemplate_ProductGroupTemplateId",
                        column: x => x.ProductGroupTemplateId,
                        principalSchema: "pro",
                        principalTable: "ProductGroupTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ProductGroupId = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    IsTangible = table.Column<bool>(type: "bit", nullable: true),
                    IsSingle = table.Column<bool>(type: "bit", nullable: true),
                    IsWholeQuantity = table.Column<bool>(type: "bit", nullable: true),
                    ProductUnitId = table.Column<int>(type: "int", nullable: false),
                    ProductLabelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductGroup_ProductGroupId",
                        column: x => x.ProductGroupId,
                        principalSchema: "pro",
                        principalTable: "ProductGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_ProductLabel_ProductLabelId",
                        column: x => x.ProductLabelId,
                        principalSchema: "pro",
                        principalTable: "ProductLabel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_ProductUnit_ProductUnitId",
                        column: x => x.ProductUnitId,
                        principalSchema: "pro",
                        principalTable: "ProductUnit",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductFeature",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    FeatureValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeature_FeatureValue_FeatureValueId",
                        column: x => x.FeatureValueId,
                        principalSchema: "pro",
                        principalTable: "FeatureValue",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductFeature_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "pro",
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatureValue_FeatureId",
                schema: "pro",
                table: "FeatureValue",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntity_RegistrationCountryID",
                schema: "cli",
                table: "LegalEntity",
                column: "RegistrationCountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CitizenShipId",
                schema: "cli",
                table: "Person",
                column: "CitizenShipId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductGroupId",
                schema: "pro",
                table: "Product",
                column: "ProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductLabelId",
                schema: "pro",
                table: "Product",
                column: "ProductLabelId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductUnitId",
                schema: "pro",
                table: "Product",
                column: "ProductUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeature_FeatureValueId",
                schema: "pro",
                table: "ProductFeature",
                column: "FeatureValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeature_ProductId",
                schema: "pro",
                table: "ProductFeature",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_ProductCategoryId",
                schema: "pro",
                table: "ProductGroup",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroup_ProductGroupTemplateId",
                schema: "pro",
                table: "ProductGroup",
                column: "ProductGroupTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroupTemplate_ProductUnitId",
                schema: "pro",
                table: "ProductGroupTemplate",
                column: "ProductUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroupTemplateFeature_FeatureId",
                schema: "pro",
                table: "ProductGroupTemplateFeature",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGroupTemplateFeature_ProductGroupTemplateId",
                schema: "pro",
                table: "ProductGroupTemplateFeature",
                column: "ProductGroupTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLabel_BrandId",
                schema: "pro",
                table: "ProductLabel",
                column: "BrandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Currency",
                schema: "cor");

            migrationBuilder.DropTable(
                name: "LegalEntity",
                schema: "cli");

            migrationBuilder.DropTable(
                name: "Person",
                schema: "cli");

            migrationBuilder.DropTable(
                name: "ProductFeature",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "ProductGroupTemplateFeature",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "User",
                schema: "cor");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "cli");

            migrationBuilder.DropTable(
                name: "Country",
                schema: "cor");

            migrationBuilder.DropTable(
                name: "FeatureValue",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "Feature",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "ProductGroup",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "ProductLabel",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "ProductCategory",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "ProductGroupTemplate",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "ProductUnit",
                schema: "pro");
        }
    }
}
