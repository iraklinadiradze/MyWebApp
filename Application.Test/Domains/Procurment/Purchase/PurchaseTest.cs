using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

using Xunit;
using DataAccessLayer;
using MediatR;
using Serilog;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit.Abstractions;
using Application.Domains.Procurment.Purchase.Commands.UpdatePurchaseStatusCommand;
using Application.Domains.Procurment.Purchase;
using Application.Common.Interfaces;
using System.Threading;

namespace Application.Test.Domains.Procurment.Purchase
{
    [Collection("Sequential")]
    public class PurchaseTest
    {

        public ICoreDBContext _dbContext { get; set; }
        public IMediator _mediator { get; set; }

        public ILogger _Logger;
        ITestOutputHelper _testOutputHelper;


        public PurchaseTest(ICoreDBContext __dbContext, IMediator __mediator, ITestOutputHelper testOutputHelper,
            ILogger __logger)
        {
            _dbContext = __dbContext;
            _mediator = __mediator;
            _Logger = __logger;
            _testOutputHelper = testOutputHelper;

            //            ((Serilog.ILogger) _Logger)


            /*
            var outtemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] [{SourceContext}] {Message}{NewLine}{Exception}";

            _Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.TestOutput(_testOutputHelper, Serilog.Events.LogEventLevel.Verbose, outputTemplate: outtemplate)
                .CreateLogger();
            */


            //            SetupProvider(_Logger);

            doMakeSeeding();


        }

        private void SetupProvider(ILogger logger)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().Build();
            IServiceCollection _services = new ServiceCollection();
            _services.AddSingleton(configuration);
 //           _services.AddScoped(x => dbContext);
//            _services.AddSingleton(ICoreDBContext,  dbContext);
            _services.AddSingleton(logger);
            _services.AddMediatR(Assembly.Load("Application").GetTypes().Union(Assembly.Load("DataAccessLayer").GetTypes()).ToArray());
            //            _services.AddMediatR();
            //            _services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggerBehaviour<,>));
            _mediator = _services.BuildServiceProvider().GetService<IMediator>();
            //            _dbContext = _services.BuildServiceProvider().GetService<ICoreDBContext>();


            var builder = new DbContextOptionsBuilder<CoreDBContext>();
            builder.UseInMemoryDatabase(databaseName: "LibraryDbInMemory");
//            _services.AddDbContext<CoreDBContext>(options => options.UseInMemoryDatabase(databaseName: "LibraryDbInMemory"));
//            _dbContext = _services.BuildServiceProvider().GetService<CoreDBContext>();

            _dbContext = new CoreDBContext(builder.Options);
            ((CoreDBContext)_dbContext).Database.EnsureDeleted();
            ((CoreDBContext)_dbContext).Database.EnsureCreated();

//            _services.AddScoped(x => _dbContext);
//            _services.AddSingleton<ICoreDBContext, CoreDBContext>(x => _dbContext);
            //            _services.AddSingleton<ICoreDBContext>(provider => provider.GetRequiredService<CoreDBContext>());
            //            _services.AddSingleton<ICoreDBContext>(_dbContext);

            //            _services.AddSingleton<ICoreDBContext>(_dbContext);


            //            _services.AddScoped(CoreDBContext, _dbContext);
            //            _services.AddDbContext<CoreDBContext>(_dbContext);
        }

        private async void doMakeSeeding()
        {

            _dbContext.Currency.AddRange(
                new[]
                {
                    new Application.Model.Core.Currency{ CurrencyCode="GEL", CurrencyDescrip ="Georgian Lari" } ,
                    new Application.Model.Core.Currency{ CurrencyCode="USD", CurrencyDescrip ="US Dollar" } ,
                    new Application.Model.Core.Currency{ CurrencyCode="EUR", CurrencyDescrip ="Euro" } ,
                    new Application.Model.Core.Currency{ CurrencyCode="GBP", CurrencyDescrip ="British Pound" }
                }
             );

            _dbContext.Country.AddRange(
                new[]
                {
                    new Application.Model.Core.Country{ Code="GEO", Name="Republic of Georgia"} ,
                    new Application.Model.Core.Country{ Code="USA", Name="United States Of America"},
                    new Application.Model.Core.Country{ Code="GER", Name="Germany"},
                    new Application.Model.Core.Country{ Code="AZE", Name="Azerbaijan"},
                    new Application.Model.Core.Country{ Code="ARM", Name="Armenia"},
                    new Application.Model.Core.Country{ Code="TUR", Name="Turkey"}
                }
             );

            /*
            _dbContext.User.AddRange(
                new[]
                {
                    new Core.User{ Username="inadir", Password="123", Firstname="Irakli", Lastname="Nadiradze"} 
                }
             );
            */

            // Clients Schema

            // Products Schema
            _dbContext.ProductUnit.AddRange(
                new[]
                {
                    new Application.Model.Product.ProductUnit{ ProductUnitName ="ცალი" } ,
                    new Application.Model.Product.ProductUnit{ ProductUnitName ="კილოგრამი" } ,
                    new Application.Model.Product.ProductUnit{ ProductUnitName ="გრამი" } ,
                    new Application.Model.Product.ProductUnit{ ProductUnitName ="მეტრი" } ,
                    new Application.Model.Product.ProductUnit{ ProductUnitName ="სანტიმეტრი" },
                    new Application.Model.Product.ProductUnit{ ProductUnitName ="მილიმეტრი" }

                }
             );


            // Inventory Schema
            _dbContext.InventoryChangeType.AddRange(
                new[]
                {
                    new Application.Model.Inventory.InventoryChangeType{ ChangeCode="PRC", ChangeName="შესყიდვა" , IsFinRelated= true, IsQtyRelated=false} ,
                    new Application.Model.Inventory.InventoryChangeType{ ChangeCode="MVM", ChangeName="გადაზიდვა" , IsFinRelated= true, IsQtyRelated=false} ,
                    new Application.Model.Inventory.InventoryChangeType{ ChangeCode="SAL", ChangeName="გაყიდვა" , IsFinRelated= true, IsQtyRelated=false} ,
                    new Application.Model.Inventory.InventoryChangeType{ ChangeCode="WRO", ChangeName="ჩამოწერა" , IsFinRelated= true, IsQtyRelated=false} ,
                    new Application.Model.Inventory.InventoryChangeType{ ChangeCode="PRD", ChangeName="ტრანსფორმაცია" , IsFinRelated= true, IsQtyRelated=false}
                }
             );

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            // Location Seeding
            Application.Model.Inventory.Location location1 =
                new Application.Model.Inventory.Location
                {
                    Name = "Location 1"
                };

            Application.Model.Inventory.Location location2 =
                new Application.Model.Inventory.Location
                {
                    Name = "Location 2"
                };

            Application.Model.Inventory.Location location3 =
                new Application.Model.Inventory.Location
                {
                    Name = "Location 3"
                };

            _dbContext.Location.AddRange(location1, location2, location3);


                        await _dbContext.SaveChangesAsync(CancellationToken.None);;

            // Product Category Seeding
            Application.Model.Product.ProductCategory productCategory1 = new Application.Model.Product.ProductCategory
            {
                ProductCategoryName = "ProductCategory1"
            };

            Application.Model.Product.ProductCategory productCategory2 = new Application.Model.Product.ProductCategory
            {
                ProductCategoryName = "ProductCategory2"
            };

            Application.Model.Product.ProductCategory productCategory3 = new Application.Model.Product.ProductCategory
            {
                ProductCategoryName = "ProductCategory3"
            };

            _dbContext.ProductCategory.AddRange(productCategory1, productCategory2, productCategory3);
                        await _dbContext.SaveChangesAsync(CancellationToken.None);;



            // Product Group Seeding
            Application.Model.Product.ProductGroup productGroup1_1 = new Application.Model.Product.ProductGroup
            {
                ProductGroupName = "ProductGroup1_1",
                ProductCategoryId = productCategory1.Id
            };

            Application.Model.Product.ProductGroup productGroup1_2 = new Application.Model.Product.ProductGroup
            {
                ProductGroupName = "ProductGroup1_2",
                ProductCategoryId = productCategory1.Id
            };

            Application.Model.Product.ProductGroup productGroup1_3 = new Application.Model.Product.ProductGroup
            {
                ProductGroupName = "ProductGroup1_3",
                ProductCategoryId = productCategory1.Id
            };

            Application.Model.Product.ProductGroup productGroup2_1 = new Application.Model.Product.ProductGroup
            {
                ProductGroupName = "ProductGroup2_1",
                ProductCategoryId = productCategory2.Id
            };

            Application.Model.Product.ProductGroup productGroup2_2 = new Application.Model.Product.ProductGroup
            {
                ProductGroupName = "ProductGroup2_2",
                ProductCategoryId = productCategory2.Id
            };

            Application.Model.Product.ProductGroup productGroup3_1 = new Application.Model.Product.ProductGroup
            {
                ProductGroupName = "ProductGroup3_1",
                ProductCategoryId = productCategory3.Id
            };

            _dbContext.ProductGroup.AddRange(productGroup1_1, productGroup1_2, productGroup1_3, productGroup2_1, productGroup2_2, productGroup3_1);
                        await _dbContext.SaveChangesAsync(CancellationToken.None);;



            // Product Brand Seeding
            Application.Model.Product.Brand brand1 = new Application.Model.Product.Brand
            {
                BrandName = "Brand1"
            };

            Application.Model.Product.Brand brand2 = new Application.Model.Product.Brand
            {
                BrandName = "Brand2"
            };

            _dbContext.Brand.AddRange(brand1, brand2);
                        await _dbContext.SaveChangesAsync(CancellationToken.None);;



            // Product Label Seeding
            Application.Model.Product.ProductLabel productlabel1 = new Application.Model.Product.ProductLabel
            {
                ProductLabelName = "ProductLabel1",
                BrandId = brand1.Id
            };

            Application.Model.Product.ProductLabel productlabel2 = new Application.Model.Product.ProductLabel
            {
                ProductLabelName = "ProductLabel2",
                BrandId = brand1.Id
            };

            Application.Model.Product.ProductLabel productlabel3 = new Application.Model.Product.ProductLabel
            {
                ProductLabelName = "ProductLabel3",
                BrandId = brand1.Id
            };

            Application.Model.Product.ProductLabel productlabel4 = new Application.Model.Product.ProductLabel
            {
                ProductLabelName = "ProductLabel4",
                BrandId = brand2.Id
            };

            _dbContext.ProductLabel.AddRange(productlabel1, productlabel2, productlabel3, productlabel4);
                        await _dbContext.SaveChangesAsync(CancellationToken.None);;



            // Product Seeding
            Application.Model.Product.Product product1 =
                new Application.Model.Product.Product
                {
                    ProductCode = "13245654654",
                    ProductUnitId = _dbContext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 1",
                    ProductGroupId = productGroup1_1.Id
                };

            Application.Model.Product.Product product2 =
                new Application.Model.Product.Product
                {
                    ProductCode = "783457438834",
                    ProductUnitId = _dbContext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 2",
                    ProductGroupId = productGroup1_1.Id
                };

            Application.Model.Product.Product product3 =
                new Application.Model.Product.Product
                {
                    ProductCode = "798734234232",
                    ProductUnitId = _dbContext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 3",
                    ProductGroupId = productGroup1_2.Id
                };

            Application.Model.Product.Product product4 =
                new Application.Model.Product.Product
                {
                    ProductCode = "25632342322",
                    ProductUnitId = _dbContext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 4",
                    ProductGroupId = productGroup1_2.Id
                };

            Application.Model.Product.Product product5 =
                new Application.Model.Product.Product
                {
                    ProductCode = "2344447890",
                    ProductUnitId = _dbContext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 5",
                    ProductGroupId = productGroup1_2.Id
                };


            Application.Model.Product.Product product6 =
                new Application.Model.Product.Product
                {
                    ProductCode = "23444473433",
                    ProductUnitId = _dbContext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 6",
                    ProductGroupId = productGroup1_2.Id
                };

            Application.Model.Product.Product product7 =
                new Application.Model.Product.Product
                {
                    ProductCode = "23443435345",
                    ProductUnitId = _dbContext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 7",
                    ProductGroupId = productGroup1_3.Id
                };

            Application.Model.Product.Product product8 =
                new Application.Model.Product.Product
                {
                    ProductCode = "7420029999333",
                    ProductUnitId = _dbContext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 8",
                    ProductGroupId = productGroup1_3.Id
                };

            Application.Model.Product.Product product9 =
                new Application.Model.Product.Product
                {
                    ProductCode = "234566544344",
                    ProductUnitId = _dbContext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 9",
                    ProductGroupId = productGroup1_3.Id
                };

            Application.Model.Product.Product product10 =
                new Application.Model.Product.Product
                {
                    ProductCode = "57753222233",
                    ProductUnitId = _dbContext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 10",
                    ProductGroupId = productGroup2_2.Id
                };

            Application.Model.Product.Product product11 =
                new Application.Model.Product.Product
                {
                    ProductCode = "3485858543",
                    ProductUnitId = _dbContext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 11",
                    ProductGroupId = productGroup2_2.Id
                };

            Application.Model.Product.Product product12 =
                new Application.Model.Product.Product
                {
                    ProductCode = "2348838383",
                    ProductUnitId = _dbContext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 12",
                    ProductGroupId = productGroup2_2.Id
                };

            _dbContext.Product.AddRange(product1, product2, product3, product4, product5, product6, product7,
                product8, product9, product10, product11, product12);

                        await _dbContext.SaveChangesAsync(CancellationToken.None);;


            // Client Seeding
            Application.Model.Client.Client client1 =
                new Application.Model.Client.Client
                {
                    IsCustomer = false,
                    IsBank = false,
                    IsPerson = false,
                    IsEmployee = false,
                    IsSupplier = true,

                    Name = "Vendro 1"
                };

            _dbContext.Client.Add(client1);
                        await _dbContext.SaveChangesAsync(CancellationToken.None);;


            // Legal Entity 

            Application.Model.Client.LegalEntity legal_entity1 =
                new Application.Model.Client.LegalEntity
                {
                    Id = client1.Id,
                    LegalEntityName = "LTD vendor1",
                    Email = "info@vendro1.com",
                    LegalAddress = "1 downingstreet , TownCity",
                    OfficeAddress = "1 downingstreet , TownCity",
                    Mobile = "+1-321-232-344",
                    RegistrationCountryID = _dbContext.Country.Where(x => x.Code == "GEO").FirstOrDefault().Id,
                    TaxCode = "1235563313",
                    TaxRegDate = new DateTime(2017, 05, 27)
                };

            _dbContext.LegalEntity.Add(legal_entity1);
                        await _dbContext.SaveChangesAsync(CancellationToken.None);;


            // Purchase Seeding
            Application.Model.Procurment.Purchase purchase1 =
                new Application.Model.Procurment.Purchase
                {
                    TransDate = new DateTime(2021, 5, 1),
                    CurrencyId = _dbContext.Currency.Where(x => x.CurrencyCode == "GEL").FirstOrDefault().Id,
                    ClientId = client1.Id,
                    InvoiceNumber = "INV-001",
                    Note = $"Purchase 1 from vendor:{client1.Name} ",
                    PurchaseName = $"Delivery of Ordered Purchase: Order Number1",
                    xrate = 1,
                    FinPosted = false,
                    QtyPosted = false,
                    Allocated = false,
                    FinPostStarted = false,
                    QtyPostStarted = false,
                    ProcInInventory = false,
                    Posted = false
                };

            _dbContext.Purchase.AddRange(purchase1);
                        await _dbContext.SaveChangesAsync(CancellationToken.None);;

            // Purchase Detail Seeding
            Application.Model.Procurment.PurchaseDetail purchaseDetail1 =
                new Application.Model.Procurment.PurchaseDetail
                {
                    PurchaseId = purchase1.Id,
                    LocationId = location1.Id,
                    InventoryCode = "",
                    ProjectId = 0,
                    AddCost = 0,
                    ProductId = product1.Id,

                    QtyInvoiced = 10,
                    QtyCalculated = 10,
                    FinalQty = 10,

                    CostInvoiced = 2000,
                    CostCalculated = 2000,
                    FinalCost = 2000,
                    CostCalculatedEqu = 2000,
                    CostInvoicedEqu = 2000,
                    CostInvoicedWithoutVat = 2000,

                    QtyPosted = false,
                    FinPosted = false,

                    Allocated = false,

                    Posted = false,
                    VatInvoiced = 0,

                    PurchaseDetailPostTypeId = 1,
                    PurchaseDraftId = 0

                };

            Application.Model.Procurment.PurchaseDetail purchaseDetail2 =
                new Application.Model.Procurment.PurchaseDetail
                {
                    PurchaseId = purchase1.Id,
                    LocationId = location1.Id,
                    InventoryCode = "",
                    ProjectId = 0,
                    AddCost = 0,
                    ProductId = product2.Id,

                    QtyInvoiced = 21,
                    QtyCalculated = 21,
                    FinalQty = 21,

                    CostInvoiced = 3200,
                    CostCalculated = 3200,
                    FinalCost = 3200,
                    CostCalculatedEqu = 3200,
                    CostInvoicedEqu = 3200,
                    CostInvoicedWithoutVat = 3200,

                    QtyPosted = false,
                    FinPosted = false,

                    Allocated = false,

                    Posted = false,
                    VatInvoiced = 0,

                    PurchaseDetailPostTypeId = 1,
                    PurchaseDraftId = 0

                };

            Application.Model.Procurment.PurchaseDetail purchaseDetail3 =
                new Application.Model.Procurment.PurchaseDetail
                {
                    PurchaseId = purchase1.Id,
                    LocationId = location1.Id,
                    InventoryCode = "",
                    ProjectId = 0,
                    AddCost = 0,
                    ProductId = product3.Id,

                    QtyInvoiced = 15,
                    QtyCalculated = 15,
                    FinalQty = 15,

                    CostInvoiced = 2200,
                    CostCalculated = 2200,
                    FinalCost = 2200,
                    CostCalculatedEqu = 2200,
                    CostInvoicedEqu = 2200,
                    CostInvoicedWithoutVat = 2200,

                    QtyPosted = false,
                    FinPosted = false,

                    Allocated = false,

                    Posted = false,
                    VatInvoiced = 0,

                    PurchaseDetailPostTypeId = 1,
                    PurchaseDraftId = 0

                };

            Application.Model.Procurment.PurchaseDetail purchaseDetail4 =
                new Application.Model.Procurment.PurchaseDetail
                {
                    PurchaseId = purchase1.Id,
                    LocationId = location1.Id,
                    InventoryCode = "",
                    ProjectId = 0,
                    AddCost = 0,
                    ProductId = product4.Id,

                    QtyInvoiced = 33,
                    QtyCalculated = 33,
                    FinalQty = 33,

                    CostInvoiced = 6600,
                    CostCalculated = 6600,
                    FinalCost = 6600,
                    CostCalculatedEqu = 6600,
                    CostInvoicedEqu = 6600,
                    CostInvoicedWithoutVat = 6600,

                    QtyPosted = false,
                    FinPosted = false,

                    Allocated = false,

                    Posted = false,
                    VatInvoiced = 0,

                    PurchaseDetailPostTypeId = 1,
                    PurchaseDraftId = 0

                };

            Application.Model.Procurment.PurchaseDetail purchaseDetail5 =
                new Application.Model.Procurment.PurchaseDetail
                {
                    PurchaseId = purchase1.Id,
                    LocationId = location1.Id,
                    InventoryCode = "",
                    ProjectId = 0,
                    AddCost = 0,
                    ProductId = product5.Id,

                    QtyInvoiced = 14,
                    QtyCalculated = 14,
                    FinalQty = 14,

                    CostInvoiced = 28000,
                    CostCalculated = 28000,
                    FinalCost = 28000,
                    CostCalculatedEqu = 28000,
                    CostInvoicedEqu = 28000,
                    CostInvoicedWithoutVat = 28000,

                    QtyPosted = false,
                    FinPosted = false,

                    Allocated = false,

                    Posted = false,
                    VatInvoiced = 0,

                    PurchaseDetailPostTypeId = 1,
                    PurchaseDraftId = 0

                };

            Application.Model.Procurment.PurchaseDetail purchaseDetail6 =
                new Application.Model.Procurment.PurchaseDetail
                {
                    PurchaseId = purchase1.Id,
                    LocationId = location1.Id,
                    InventoryCode = "",
                    ProjectId = 0,
                    AddCost = 0,
                    ProductId = product6.Id,

                    QtyInvoiced = 25,
                    QtyCalculated = 25,
                    FinalQty = 25,

                    CostInvoiced = 13700,
                    CostCalculated = 13700,
                    FinalCost = 13700,
                    CostCalculatedEqu = 13700,
                    CostInvoicedEqu = 13700,
                    CostInvoicedWithoutVat = 13700,

                    QtyPosted = false,
                    FinPosted = false,

                    Allocated = false,

                    Posted = false,
                    VatInvoiced = 0,

                    PurchaseDetailPostTypeId = 1,
                    PurchaseDraftId = 0

                };

            _dbContext.PurchaseDetail.AddRange(purchaseDetail1, purchaseDetail2, purchaseDetail3, purchaseDetail4, purchaseDetail5, purchaseDetail6);
                        await _dbContext.SaveChangesAsync(CancellationToken.None);;

        }


        [Fact]
        public async void  DDDTest()
        {

            var outtemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] [{SourceContext}] {Message}{NewLine}{Exception}";

            /*
            _Logger = new LoggerConfiguration()
             .MinimumLevel.Verbose()
             .WriteTo.
                TestOutput(_testOutputHelper, Serilog.Events.LogEventLevel.Verbose, outputTemplate: outtemplate)
                .CreateLogger();
            */

            _Logger.Information("Start DDDTest");

            Application.Model.Procurment.Purchase _purchase = _dbContext.Purchase.FirstOrDefault();

            UpdatePurchaseStatusCommand _updatePurchaseStatusCommand = new UpdatePurchaseStatusCommand
            {
                Id = _purchase.Id,
                SenderId = 0,
                PurchaseDetailId = null,
                PurchaseAction = PurchaseAction.paFullPost
            };

            var result = await _mediator.Send(_updatePurchaseStatusCommand);

            _Logger.Information("");

            await _dbContext.SaveChangesAsync(CancellationToken.None);

            _Logger.Information("End DDDTest");
            _Logger.Information("");

            var i = await _dbContext.Inventory.ToListAsync();
            var ic = await _dbContext.InventoryChange.ToListAsync();

            Assert.Equal(6, i.Count());

        }



    }
}
