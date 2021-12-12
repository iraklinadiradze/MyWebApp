using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;

using Application.Model.Client;
using Application.Model.Core;
using Application.Model.Inventory;
using Application.Model.Product;
using Application.Model.Procurment;
using Application.Model.Sale;
using Application.Model.Account;
using Application.Model.GeneralLedger;

using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ICoreDBContext
    {

        public List<InventoryChange> AffectedInventoryChangeList { get; set; }

        public InventoryChange[] CostAffectedInventoryChangeList { get; set; }
//        public List<InventoryChange> CostAffectedInventoryChangeList { get; set; }
        
        // General Schema
        public  DbSet<Currency> Currency { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Country> Country { get; set; }

        // Clients Schema
        public DbSet<Client> Client { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<LegalEntity> LegalEntity { get; set; }
        //        public DbSet<ClientType> ClientType { get; set; }


        // Products Schema
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Feature> Feature { get; set; }
        public DbSet<FeatureValue> FeatureValue { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }
        public DbSet<ProductGroup> ProductGroup { get; set; }
        public DbSet<ProductGroupTemplate> ProductGroupTemplate { get; set; }
        public DbSet<ProductGroupTemplateFeature> ProductGroupTemplateFeature { get; set; }
        public DbSet<ProductLabel> ProductLabel { get; set; }
        public DbSet<ProductUnit> ProductUnit { get; set; }
        public DbSet<ProductProcessor> ProductProcessor { get; set; }
        public DbSet<ProductProcessorDetail> ProductProcessorDetail { get; set; }
        public DbSet<ProductProcessorProductFeature> ProductProcessorProductFeature { get; set; }
        public DbSet<ProductProcessorSalePrice> ProductProcessorSalePrice { get; set; }

        // Inventory Schema
        public DbSet<Location> Location { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<InventoryChangeType> InventoryChangeType { get; set; }
        public DbSet<InventoryChange> InventoryChange { get; set; }
        public DbSet<Movement> Movement { get; set; }
        public DbSet<MovementDetail> MovementDetail { get; set; }

        // Procurement Schema
        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<PurchaseDetail> PurchaseDetail { get; set; }
        public DbSet<PurchaseAllocationSource> PurchaseAllocationSource { get; set; }
        public DbSet<PurchaseAllocationSourceType> PurchaseAllocationSourceType { get; set; }
        public DbSet<PurchaseAllocationSchema> PurchaseAllocationSchema { get; set; }
        public DbSet<PurchaseAllocationResult> PurchaseAllocationResult { get; set; }
        public DbSet<PurchaseDetailPostType> PurchaseDetailPostType { get; set; }

        // POS         
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SalePayment> SalePayment { get; set; }
        public DbSet<SalePaymentType> SalePaymentType { get; set; }
        public DbSet<SaleProduct> SaleProduct { get; set; }
        public DbSet<ReturnProduct> ReturnProduct { get; set; }
        public DbSet<SaleSchema> SaleSchema { get; set; }
        public DbSet<SaleSchemaDetail> SaleSchemaDetail { get; set; }


        // Account
        public DbSet<Account> Account { get; set; }
        public DbSet<AccountDimension> AccountDimension { get; set; }
        public DbSet<AccountBalance> AccountBalance { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<TransactionOrder> TransactionOrder { get; set; }


        // General Ledger
        public DbSet<GlAccount> GlAccount { get; set; }
        public DbSet<GlTransaction> GlTransaction { get; set; }
        public DbSet<GlTransactionDetail> GlTransactionDetail { get; set; }
        public DbSet<FinAccount> FinAccount { get; set; }

       // object ChangeTracker { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
