using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class CreateCoreDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "acc");

            migrationBuilder.EnsureSchema(
                name: "pro");

            migrationBuilder.EnsureSchema(
                name: "cli");

            migrationBuilder.EnsureSchema(
                name: "cor");

            migrationBuilder.EnsureSchema(
                name: "gl");

            migrationBuilder.EnsureSchema(
                name: "inv");

            migrationBuilder.EnsureSchema(
                name: "prc");

            migrationBuilder.EnsureSchema(
                name: "pos");

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
                name: "Entity",
                schema: "cor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntityDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feature",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ts = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinAccount",
                schema: "gl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FinAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlTransaction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                schema: "inv",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InventoryCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProcInInventory = table.Column<bool>(type: "bit", nullable: true),
                    IsSingle = table.Column<bool>(type: "bit", nullable: true),
                    IsWholeQuantity = table.Column<bool>(type: "bit", nullable: true),
                    ProductUnitId = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EntityId = table.Column<int>(type: "int", nullable: true),
                    EntityForeignId = table.Column<long>(type: "bigint", nullable: true),
                    EntityProcCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryChangeType",
                schema: "inv",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChangeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ChangeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsQtyRelated = table.Column<bool>(type: "bit", nullable: false),
                    IsFinRelated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryChangeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "inv",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
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
                name: "ProductProcessor",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<int>(type: "int", nullable: false),
                    IdentifyProducts = table.Column<bool>(type: "bit", nullable: false),
                    RegisterBrandProps = table.Column<bool>(type: "bit", nullable: false),
                    RegisterProducts = table.Column<bool>(type: "bit", nullable: false),
                    IdentifyProductsAfterRegistration = table.Column<bool>(type: "bit", nullable: false),
                    RegisterSalesPrices = table.Column<bool>(type: "bit", nullable: false),
                    RegisterPurchaseDetails = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProcessor", x => x.Id);
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
                name: "Purchase",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
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
                    CostPosted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPosted = table.Column<bool>(type: "bit", nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseAllocationSchema",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseAllocationSchema", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseAllocationSourceType",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseAllocationSourceType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseDetailPostType",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetailPostType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalePaymentType",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePaymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SaleSchema",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleSchema", x => x.Id);
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
                    EntityId6 = table.Column<int>(type: "int", nullable: true)
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
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "FeatureValue",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    FeatureValueName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
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
                name: "GlAccount",
                schema: "gl",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinAccountId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "InventoryChange",
                schema: "inv",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryChangeTypeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    QtyIncrease = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtyDecrease = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtyBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostIncrease = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostDecrease = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDayLastChange = table.Column<bool>(type: "bit", nullable: false),
                    EntityId = table.Column<int>(type: "int", nullable: true),
                    EntityForeignId = table.Column<long>(type: "bigint", nullable: true),
                    EntityProcCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentInventoryChangeId = table.Column<long>(type: "bigint", nullable: true),
                    TimeSequence = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryChange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryChange_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "inv",
                        principalTable: "Inventory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryChange_InventoryChangeType_InventoryChangeTypeId",
                        column: x => x.InventoryChangeTypeId,
                        principalSchema: "inv",
                        principalTable: "InventoryChangeType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryChange_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "inv",
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movement",
                schema: "inv",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceiveDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SendLocationId = table.Column<int>(type: "int", nullable: false),
                    ReceiveLocationId = table.Column<int>(type: "int", nullable: false),
                    SendQtyPostStarted = table.Column<bool>(type: "bit", nullable: true),
                    SendFinPostStarted = table.Column<bool>(type: "bit", nullable: true),
                    ReceiveQtyPostStarted = table.Column<bool>(type: "bit", nullable: true),
                    ReceiveFinPostStarted = table.Column<bool>(type: "bit", nullable: true),
                    SendQtyPosted = table.Column<bool>(type: "bit", nullable: true),
                    SendFinPosted = table.Column<bool>(type: "bit", nullable: true),
                    ReceiveQtyPosted = table.Column<bool>(type: "bit", nullable: true),
                    ReceiveFinPosted = table.Column<bool>(type: "bit", nullable: true),
                    SendPosted = table.Column<bool>(type: "bit", nullable: true),
                    ReceivePosted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movement_Location_ReceiveLocationId",
                        column: x => x.ReceiveLocationId,
                        principalSchema: "inv",
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movement_Location_SendLocationId",
                        column: x => x.SendLocationId,
                        principalSchema: "inv",
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductProcessorDetail",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductProcessorId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BrandName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<int>(type: "int", nullable: true),
                    BrandIdDictionary = table.Column<int>(type: "int", nullable: true),
                    ProductGroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductGroupId = table.Column<int>(type: "int", nullable: true),
                    ProductGroupIdDictionary = table.Column<int>(type: "int", nullable: true),
                    ProductLabelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductLabelId = table.Column<int>(type: "int", nullable: true),
                    ProductLabelIdDictionary = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProcessorDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProcessorDetail_ProductProcessor_ProductProcessorId",
                        column: x => x.ProductProcessorId,
                        principalSchema: "pro",
                        principalTable: "ProductProcessor",
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
                name: "Sale",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShopId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    ConsultantId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    FinPosted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPosted = table.Column<bool>(type: "bit", nullable: false),
                    PaymentPosted = table.Column<bool>(type: "bit", nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sale_Location_ShopId",
                        column: x => x.ShopId,
                        principalSchema: "inv",
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sale_User_ConsultantId",
                        column: x => x.ConsultantId,
                        principalSchema: "cor",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Sale_User_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "cor",
                        principalTable: "User",
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
                    EntityForeignId6 = table.Column<int>(type: "int", nullable: true)
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
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "MovementDetail",
                schema: "inv",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovementId = table.Column<long>(type: "bigint", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    SendQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SendValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReceiveQty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ReceiveValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SendQtyPosted = table.Column<bool>(type: "bit", nullable: true),
                    SendFinPosted = table.Column<bool>(type: "bit", nullable: true),
                    ReceiveQtyPosted = table.Column<bool>(type: "bit", nullable: true),
                    ReceiveFinPosted = table.Column<bool>(type: "bit", nullable: true),
                    SendPosted = table.Column<bool>(type: "bit", nullable: true),
                    ReceivePosted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovementDetail_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "inv",
                        principalTable: "Inventory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MovementDetail_Movement_MovementId",
                        column: x => x.MovementId,
                        principalSchema: "inv",
                        principalTable: "Movement",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductProcessorProductFeature",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductProcessorDetailId = table.Column<int>(type: "int", nullable: false),
                    FeatureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FeatureId = table.Column<int>(type: "int", nullable: false),
                    FeatureValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeatureValueId = table.Column<int>(type: "int", nullable: false),
                    FeatureValueIdDictionary = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProcessorProductFeature", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProcessorProductFeature_ProductProcessorDetail_ProductProcessorDetailId",
                        column: x => x.ProductProcessorDetailId,
                        principalSchema: "pro",
                        principalTable: "ProductProcessorDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductProcessorSalePrice",
                schema: "pro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductProcessorDetailId = table.Column<int>(type: "int", nullable: false),
                    SaleSchemaId = table.Column<int>(type: "int", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductProcessorSalePrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductProcessorSalePrice_ProductProcessorDetail_ProductProcessorDetailId",
                        column: x => x.ProductProcessorDetailId,
                        principalSchema: "pro",
                        principalTable: "ProductProcessorDetail",
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
                name: "ReturnProduct",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NominalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NominalPriceDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SchemaPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cogs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    ConsultantId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    FinPosted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPosted = table.Column<bool>(type: "bit", nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReturnProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReturnProduct_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "inv",
                        principalTable: "Inventory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReturnProduct_Sale_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "pos",
                        principalTable: "Sale",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalePayment",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    PaymentTypeId = table.Column<int>(type: "int", nullable: false),
                    AmountIn = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AmountOut = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalePayment_Sale_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "pos",
                        principalTable: "Sale",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalePayment_SalePaymentType_PaymentTypeId",
                        column: x => x.PaymentTypeId,
                        principalSchema: "pos",
                        principalTable: "SalePaymentType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleProduct",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NominalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NominalPriceDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SchemaPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cogs = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Revenue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    ConsultantId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPostStarted = table.Column<bool>(type: "bit", nullable: false),
                    FinPosted = table.Column<bool>(type: "bit", nullable: false),
                    QtyPosted = table.Column<bool>(type: "bit", nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleProduct_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "inv",
                        principalTable: "Inventory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SaleProduct_Sale_SaleId",
                        column: x => x.SaleId,
                        principalSchema: "pos",
                        principalTable: "Sale",
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
                    BalanceTransactionId = table.Column<int>(type: "int", nullable: false)
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
                    PostTime = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_Transaction_TransactionOrder_PostOrderRefId",
                        column: x => x.PostOrderRefId,
                        principalSchema: "acc",
                        principalTable: "TransactionOrder",
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

            migrationBuilder.CreateTable(
                name: "PurchaseDetail",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InventoryCode = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    PurchaseDraftVersion = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    PurchaseDraftId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    QtyInvoiced = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostInvoiced = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VatInvoiced = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostInvoicedWithoutVat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostInvoicedEqu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QtyCalculated = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostCalculated = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostCalculatedEqu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PurchaseDetailPostTypeId = table.Column<int>(type: "int", nullable: false),
                    QtyPosted = table.Column<bool>(type: "bit", nullable: false),
                    CostPosted = table.Column<bool>(type: "bit", nullable: false),
                    Posted = table.Column<bool>(type: "bit", nullable: false),
                    InventoryId = table.Column<long>(type: "bigint", nullable: false),
                    GlAccountId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    AddCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FinalQty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Allocated = table.Column<bool>(type: "bit", nullable: false),
                    StockProductPerProcess = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalSchema: "inv",
                        principalTable: "Inventory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Location_LocationId",
                        column: x => x.LocationId,
                        principalSchema: "inv",
                        principalTable: "Location",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "pro",
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "prc",
                        principalTable: "Purchase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseDetail_PurchaseDetailPostType_PurchaseDetailPostTypeId",
                        column: x => x.PurchaseDetailPostTypeId,
                        principalSchema: "prc",
                        principalTable: "PurchaseDetailPostType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SaleSchemaDetail",
                schema: "pos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleSchemaId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleSchemaDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SaleSchemaDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "pro",
                        principalTable: "Product",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SaleSchemaDetail_SaleSchema_SaleSchemaId",
                        column: x => x.SaleSchemaId,
                        principalSchema: "pos",
                        principalTable: "SaleSchema",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseAllocationSource",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseId = table.Column<long>(type: "bigint", nullable: false),
                    PurchaseAllocationSourceTypeId = table.Column<int>(type: "int", nullable: false),
                    AllocPurchaseDetailId = table.Column<long>(type: "bigint", nullable: false),
                    GlAccountId = table.Column<int>(type: "int", nullable: false),
                    PurchaseAllocSchemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseAllocationSource", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseAllocationSource_Purchase_PurchaseId",
                        column: x => x.PurchaseId,
                        principalSchema: "prc",
                        principalTable: "Purchase",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseAllocationSource_PurchaseAllocationSchema_PurchaseAllocSchemaId",
                        column: x => x.PurchaseAllocSchemaId,
                        principalSchema: "prc",
                        principalTable: "PurchaseAllocationSchema",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseAllocationSource_PurchaseAllocationSourceType_PurchaseAllocationSourceTypeId",
                        column: x => x.PurchaseAllocationSourceTypeId,
                        principalSchema: "prc",
                        principalTable: "PurchaseAllocationSourceType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseAllocationSource_PurchaseDetail_AllocPurchaseDetailId",
                        column: x => x.AllocPurchaseDetailId,
                        principalSchema: "prc",
                        principalTable: "PurchaseDetail",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PurchaseAllocationResult",
                schema: "prc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaseAllocationSourceId = table.Column<int>(type: "int", nullable: false),
                    PurchaseDetailId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseAllocationResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseAllocationResult_PurchaseAllocationSource_PurchaseAllocationSourceId",
                        column: x => x.PurchaseAllocationSourceId,
                        principalSchema: "prc",
                        principalTable: "PurchaseAllocationSource",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PurchaseAllocationResult_PurchaseDetail_PurchaseDetailId",
                        column: x => x.PurchaseDetailId,
                        principalSchema: "prc",
                        principalTable: "PurchaseDetail",
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
                name: "IX_FeatureValue_FeatureId",
                schema: "pro",
                table: "FeatureValue",
                column: "FeatureId");

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

            migrationBuilder.CreateIndex(
                name: "IX_InventoryChange_InventoryChangeTypeId",
                schema: "inv",
                table: "InventoryChange",
                column: "InventoryChangeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryChange_InventoryId",
                schema: "inv",
                table: "InventoryChange",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryChange_LocationId",
                schema: "inv",
                table: "InventoryChange",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LegalEntity_RegistrationCountryID",
                schema: "cli",
                table: "LegalEntity",
                column: "RegistrationCountryID");

            migrationBuilder.CreateIndex(
                name: "IX_Movement_ReceiveLocationId",
                schema: "inv",
                table: "Movement",
                column: "ReceiveLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Movement_SendLocationId",
                schema: "inv",
                table: "Movement",
                column: "SendLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementDetail_InventoryId",
                schema: "inv",
                table: "MovementDetail",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementDetail_MovementId",
                schema: "inv",
                table: "MovementDetail",
                column: "MovementId");

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductProcessorDetail_ProductProcessorId",
                schema: "pro",
                table: "ProductProcessorDetail",
                column: "ProductProcessorId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProcessorProductFeature_ProductProcessorDetailId",
                schema: "pro",
                table: "ProductProcessorProductFeature",
                column: "ProductProcessorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductProcessorSalePrice_ProductProcessorDetailId",
                schema: "pro",
                table: "ProductProcessorSalePrice",
                column: "ProductProcessorDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocationResult_PurchaseAllocationSourceId",
                schema: "prc",
                table: "PurchaseAllocationResult",
                column: "PurchaseAllocationSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocationResult_PurchaseDetailId",
                schema: "prc",
                table: "PurchaseAllocationResult",
                column: "PurchaseDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocationSource_AllocPurchaseDetailId",
                schema: "prc",
                table: "PurchaseAllocationSource",
                column: "AllocPurchaseDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocationSource_PurchaseAllocationSourceTypeId",
                schema: "prc",
                table: "PurchaseAllocationSource",
                column: "PurchaseAllocationSourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocationSource_PurchaseAllocSchemaId",
                schema: "prc",
                table: "PurchaseAllocationSource",
                column: "PurchaseAllocSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseAllocationSource_PurchaseId",
                schema: "prc",
                table: "PurchaseAllocationSource",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_InventoryId",
                schema: "prc",
                table: "PurchaseDetail",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_LocationId",
                schema: "prc",
                table: "PurchaseDetail",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_ProductId",
                schema: "prc",
                table: "PurchaseDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_PurchaseDetailPostTypeId",
                schema: "prc",
                table: "PurchaseDetail",
                column: "PurchaseDetailPostTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseDetail_PurchaseId",
                schema: "prc",
                table: "PurchaseDetail",
                column: "PurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnProduct_InventoryId",
                schema: "pos",
                table: "ReturnProduct",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ReturnProduct_SaleId",
                schema: "pos",
                table: "ReturnProduct",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ConsultantId",
                schema: "pos",
                table: "Sale",
                column: "ConsultantId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_OwnerId",
                schema: "pos",
                table: "Sale",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sale_ShopId",
                schema: "pos",
                table: "Sale",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayment_PaymentTypeId",
                schema: "pos",
                table: "SalePayment",
                column: "PaymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePayment_SaleId",
                schema: "pos",
                table: "SalePayment",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_InventoryId",
                schema: "pos",
                table: "SaleProduct",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleProduct_SaleId",
                schema: "pos",
                table: "SaleProduct",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleSchemaDetail_ProductId",
                schema: "pos",
                table: "SaleSchemaDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleSchemaDetail_SaleSchemaId",
                schema: "pos",
                table: "SaleSchemaDetail",
                column: "SaleSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountId",
                schema: "acc",
                table: "Transaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_PostOrderRefId",
                schema: "acc",
                table: "Transaction",
                column: "PostOrderRefId");

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
                name: "Currency",
                schema: "cor");

            migrationBuilder.DropTable(
                name: "GlTransactionDetail",
                schema: "gl");

            migrationBuilder.DropTable(
                name: "InventoryChange",
                schema: "inv");

            migrationBuilder.DropTable(
                name: "LegalEntity",
                schema: "cli");

            migrationBuilder.DropTable(
                name: "MovementDetail",
                schema: "inv");

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
                name: "ProductProcessorProductFeature",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "ProductProcessorSalePrice",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "PurchaseAllocationResult",
                schema: "prc");

            migrationBuilder.DropTable(
                name: "ReturnProduct",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "SalePayment",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "SaleProduct",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "SaleSchemaDetail",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "Transaction",
                schema: "acc");

            migrationBuilder.DropTable(
                name: "GlAccount",
                schema: "gl");

            migrationBuilder.DropTable(
                name: "GlTransaction",
                schema: "gl");

            migrationBuilder.DropTable(
                name: "InventoryChangeType",
                schema: "inv");

            migrationBuilder.DropTable(
                name: "Movement",
                schema: "inv");

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
                name: "ProductProcessorDetail",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "PurchaseAllocationSource",
                schema: "prc");

            migrationBuilder.DropTable(
                name: "SalePaymentType",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "Sale",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "SaleSchema",
                schema: "pos");

            migrationBuilder.DropTable(
                name: "Account ",
                schema: "acc");

            migrationBuilder.DropTable(
                name: "TransactionOrder",
                schema: "acc");

            migrationBuilder.DropTable(
                name: "FinAccount",
                schema: "gl");

            migrationBuilder.DropTable(
                name: "Feature",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "ProductProcessor",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "PurchaseAllocationSchema",
                schema: "prc");

            migrationBuilder.DropTable(
                name: "PurchaseAllocationSourceType",
                schema: "prc");

            migrationBuilder.DropTable(
                name: "PurchaseDetail",
                schema: "prc");

            migrationBuilder.DropTable(
                name: "User",
                schema: "cor");

            migrationBuilder.DropTable(
                name: "AccountDimension",
                schema: "acc");

            migrationBuilder.DropTable(
                name: "Inventory",
                schema: "inv");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "inv");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "pro");

            migrationBuilder.DropTable(
                name: "Purchase",
                schema: "prc");

            migrationBuilder.DropTable(
                name: "PurchaseDetailPostType",
                schema: "prc");

            migrationBuilder.DropTable(
                name: "Entity",
                schema: "cor");

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
