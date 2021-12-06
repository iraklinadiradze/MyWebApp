using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Test.SeedData
{
    public class SeedData
    {
        CoreDBContext _dbConext;

        public SeedData(CoreDBContext dbConext)
        {
            _dbConext = dbConext;
        }

        void doMakeSeeding()
        {

            // Location Seeding
            DataAccessLayer.Model.Inventory.Location location1 =
                new DataAccessLayer.Model.Inventory.Location
                {
                    Name = "Location 1"
                };

            DataAccessLayer.Model.Inventory.Location location2 =
                new DataAccessLayer.Model.Inventory.Location
                {
                    Name = "Location 2"
                };

            DataAccessLayer.Model.Inventory.Location location3 =
                new DataAccessLayer.Model.Inventory.Location
                {
                    Name = "Location 3"
                };

            _dbConext.Location.AddRange(location1, location2, location3 );



            // Product Category Seeding
            DataAccessLayer.Model.Product.ProductCategory productCategory1 = new DataAccessLayer.Model.Product.ProductCategory
            {
                ProductCategoryName = "ProductCategory1"
            };

            DataAccessLayer.Model.Product.ProductCategory productCategory2 = new DataAccessLayer.Model.Product.ProductCategory
            {
                ProductCategoryName = "ProductCategory2"
            };

            DataAccessLayer.Model.Product.ProductCategory productCategory3 = new DataAccessLayer.Model.Product.ProductCategory
            {
                ProductCategoryName = "ProductCategory3"
            };

            _dbConext.ProductCategory.AddRange(productCategory1, productCategory2, productCategory3);



            // Product Group Seeding
            DataAccessLayer.Model.Product.ProductGroup productGroup1_1 = new DataAccessLayer.Model.Product.ProductGroup
            {
                ProductGroupName = "ProductGroup1_1",
                ProductCategoryId = productCategory1.Id
            };

            DataAccessLayer.Model.Product.ProductGroup productGroup1_2 = new DataAccessLayer.Model.Product.ProductGroup
            {
                ProductGroupName = "ProductGroup1_2",
                ProductCategoryId = productCategory1.Id
            };

            DataAccessLayer.Model.Product.ProductGroup productGroup1_3 = new DataAccessLayer.Model.Product.ProductGroup
            {
                ProductGroupName = "ProductGroup1_3",
                ProductCategoryId = productCategory1.Id
            };

            DataAccessLayer.Model.Product.ProductGroup productGroup2_1 = new DataAccessLayer.Model.Product.ProductGroup
            {
                ProductGroupName = "ProductGroup2_1",
                ProductCategoryId = productCategory2.Id
            };

            DataAccessLayer.Model.Product.ProductGroup productGroup2_2 = new DataAccessLayer.Model.Product.ProductGroup
            {
                ProductGroupName = "ProductGroup2_2",
                ProductCategoryId = productCategory2.Id
            };

            DataAccessLayer.Model.Product.ProductGroup productGroup3_1 = new DataAccessLayer.Model.Product.ProductGroup
            {
                ProductGroupName = "ProductGroup3_1",
                ProductCategoryId = productCategory3.Id
            };

            _dbConext.ProductGroup.AddRange(productGroup1_1, productGroup1_2, productGroup1_3, productGroup2_1, productGroup2_2, productGroup3_1);



            // Product Brand Seeding
            DataAccessLayer.Model.Product.Brand brand1 = new DataAccessLayer.Model.Product.Brand
            {
                BrandName ="Brand1"
            };

            DataAccessLayer.Model.Product.Brand brand2 = new DataAccessLayer.Model.Product.Brand
            {
                BrandName = "Brand2"
            };

            _dbConext.Brand.AddRange(brand1, brand2);



            // Product Label Seeding
            DataAccessLayer.Model.Product.ProductLabel productlabel1 = new DataAccessLayer.Model.Product.ProductLabel
            {
                ProductLabelName = "ProductLabel1",
                BrandId =  brand1.Id
            };

            DataAccessLayer.Model.Product.ProductLabel productlabel2 = new DataAccessLayer.Model.Product.ProductLabel
            {
                ProductLabelName = "ProductLabel2",
                BrandId = brand1.Id
            };

            DataAccessLayer.Model.Product.ProductLabel productlabel3 = new DataAccessLayer.Model.Product.ProductLabel
            {
                ProductLabelName = "ProductLabel3",
                BrandId = brand1.Id
            };

            DataAccessLayer.Model.Product.ProductLabel productlabel4 = new DataAccessLayer.Model.Product.ProductLabel
            {
                ProductLabelName = "ProductLabel4",
                BrandId = brand2.Id
            };

            _dbConext.ProductLabel.AddRange(productlabel1, productlabel2, productlabel3, productlabel4);



            // Product Seeding
            DataAccessLayer.Model.Product.Product product1 =
                new DataAccessLayer.Model.Product.Product
                {
                     ProductCode = "13245654654",
                     ProductUnitId = _dbConext.ProductUnit.Where(x=>x.ProductUnitName=="ცალი").FirstOrDefault().Id,
                     IsSingle = false,
                     IsTangible = true,
                     IsWholeQuantity = true ,
                     ProductLabelId =  productlabel1.Id,
                     ProductName ="Product 1",
                     ProductGroupId = productGroup1_1.Id
                 };

            DataAccessLayer.Model.Product.Product product2 =
                new DataAccessLayer.Model.Product.Product
                {
                    ProductCode = "783457438834",
                    ProductUnitId = _dbConext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 2",
                    ProductGroupId = productGroup1_1.Id
                };

            DataAccessLayer.Model.Product.Product product3 =
                new DataAccessLayer.Model.Product.Product
                {
                    ProductCode = "798734234232" ,
                    ProductUnitId = _dbConext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 3",
                    ProductGroupId = productGroup1_2.Id
                };

            DataAccessLayer.Model.Product.Product product4 =
                new DataAccessLayer.Model.Product.Product
                {
                    ProductCode = "25632342322",
                    ProductUnitId = _dbConext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 4",
                    ProductGroupId = productGroup1_2.Id
                };

            DataAccessLayer.Model.Product.Product product5 =
                new DataAccessLayer.Model.Product.Product
                {
                    ProductCode = "2344447890",
                    ProductUnitId = _dbConext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 5",
                    ProductGroupId = productGroup1_2.Id
                };


            DataAccessLayer.Model.Product.Product product6 =
                new DataAccessLayer.Model.Product.Product
                {
                    ProductCode = "23444473433",
                    ProductUnitId = _dbConext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 6",
                    ProductGroupId = productGroup1_2.Id
                };

            DataAccessLayer.Model.Product.Product product7 =
                new DataAccessLayer.Model.Product.Product
                {
                    ProductCode = "23443435345",
                    ProductUnitId = _dbConext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 7",
                    ProductGroupId = productGroup1_3.Id
                };

            DataAccessLayer.Model.Product.Product product8 =
                new DataAccessLayer.Model.Product.Product
                {
                    ProductCode = "7420029999333",
                    ProductUnitId = _dbConext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 8",
                    ProductGroupId = productGroup1_3.Id
                };

            DataAccessLayer.Model.Product.Product product9 =
                new DataAccessLayer.Model.Product.Product
                {
                    ProductCode = "234566544344",
                    ProductUnitId = _dbConext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 9",
                    ProductGroupId = productGroup1_3.Id
                };

            DataAccessLayer.Model.Product.Product product10 =
                new DataAccessLayer.Model.Product.Product
                {
                    ProductCode = "57753222233",
                    ProductUnitId = _dbConext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 10",
                    ProductGroupId = productGroup2_2.Id
                };

            DataAccessLayer.Model.Product.Product product11 =
                new DataAccessLayer.Model.Product.Product
                {
                    ProductCode = "3485858543",
                    ProductUnitId = _dbConext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 11",
                    ProductGroupId = productGroup2_2.Id
                };

            DataAccessLayer.Model.Product.Product product12 =
                new DataAccessLayer.Model.Product.Product
                {
                    ProductCode = "2348838383",
                    ProductUnitId = _dbConext.ProductUnit.Where(x => x.ProductUnitName == "ცალი").FirstOrDefault().Id,
                    IsSingle = false,
                    IsTangible = true,
                    IsWholeQuantity = true,
                    ProductLabelId = productlabel1.Id,
                    ProductName = "Product 12",
                    ProductGroupId = productGroup2_2.Id
                };

            _dbConext.Product.AddRange(product1, product2, product3, product4, product5, product6, product7, 
                product8, product9, product10, product11, product12);



            // Legal Entity 

            DataAccessLayer.Model.Client.LegalEntity legal_entity1 =
                new DataAccessLayer.Model.Client.LegalEntity
                {
                    LegalEntityName ="LTD vendor1",
                    Email = "info@vendro1.com",
                    LegalAddress = "1 downingstreet , TownCity",
                    OfficeAddress = "1 downingstreet , TownCity",
                    Mobile = "+1-321-232-344",
                    RegistrationCountryID = _dbConext.Country.Where(x=> x.Code == "GEO").FirstOrDefault().Id,
                    TaxCode = "1235563313",
                    TaxRegDate = new DateTime(2017,05, 27)
                };

            _dbConext.LegalEntity.Add(legal_entity1);



            // Client Seeding
            DataAccessLayer.Model.Client.Client client1 =
                new DataAccessLayer.Model.Client.Client
                {
                    IsCustomer = false,
                    IsBank = false,
                    IsPerson = false,
                    IsEmployee = false,
                    IsSupplier = true,

                    Name = "Vendro 1"
                 };

            _dbConext.Client.Add(client1);


            // Purchase Seeding
            DataAccessLayer.Model.Procurment.Purchase purchase1 =
                new DataAccessLayer.Model.Procurment.Purchase
                {
                    TransDate = new DateTime(2021, 5, 1),
                    CurrencyId = _dbConext.Currency.Where(x => x.CurrencyCode == "GEL").FirstOrDefault().Id,
                    ClientId = client1.Id,
                    InvoiceNumber = "INV-001",
                    Note = $"Purchase 1 from vendor:{client1.Name} ",
                    PurchaseName = $"Delivery of Ordered Purchase: Order Number1",
                    xrate =1 ,
                    FinPosted = false,
                    QtyPosted = false ,
                    Allocated = false,
                    FinPostStarted = false,
                    QtyPostStarted =  false,
                    ProcInInventory =  false,
                    Posted = false
                };

            // Purchase Detail Seeding
            DataAccessLayer.Model.Procurment.PurchaseDetail purchaseDetail1 =
                new DataAccessLayer.Model.Procurment.PurchaseDetail
                {
                    PurchaseId = purchase1.Id,
                    LocationId =  location1.Id,
                    InventoryCode = "",
                    ProjectId = 0,
                    AddCost = 0,
                    ProductId = product1.Id,

                    QtyInvoiced = 10 ,
                    QtyCalculated = 10,
                    FinalQty = 10 ,

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
                    VatInvoiced = 0 ,

                    PurchaseDetailPostTypeId = 1,
                    PurchaseDraftId  = 0
                    
                };

            DataAccessLayer.Model.Procurment.PurchaseDetail purchaseDetail2 =
                new DataAccessLayer.Model.Procurment.PurchaseDetail
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

            DataAccessLayer.Model.Procurment.PurchaseDetail purchaseDetail3 =
                new DataAccessLayer.Model.Procurment.PurchaseDetail
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

            DataAccessLayer.Model.Procurment.PurchaseDetail purchaseDetail4 =
                new DataAccessLayer.Model.Procurment.PurchaseDetail
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

            DataAccessLayer.Model.Procurment.PurchaseDetail purchaseDetail5 =
                new DataAccessLayer.Model.Procurment.PurchaseDetail
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

            DataAccessLayer.Model.Procurment.PurchaseDetail purchaseDetail6 =
                new DataAccessLayer.Model.Procurment.PurchaseDetail
                {
                    PurchaseId = purchase1.Id,
                    LocationId = location1.Id,
                    InventoryCode = "",
                    ProjectId = 0,
                    AddCost = 0,
                    ProductId = product5.Id,

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

        }

    }
}
