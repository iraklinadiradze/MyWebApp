using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;

using Application.Model.Client;
using Application.Model.Core;
using Application.Model.Inventory;
using Application.Model.Product;
using Application.Model.Procurment;
using Application.Model.Sale;
using Application.Model.Account;
using Application.Model.GeneralLedger;
using Application.Common.Interfaces;

namespace DataAccessLayer
{
    public class CoreDBContext : DbContext, ICoreDBContext
    {

        public List<InventoryChange> AffectedInventoryChangeList { get; set; } = new List<InventoryChange>();
        public InventoryChange[] CostAffectedInventoryChangeList { get; set; } = { };
        // public List<InventoryChange> CostAffectedInventoryChangeList { get; set; } = new List<InventoryChange>();


        /*
        public CoreDBContext(DbContextOptions<CoreDBContext> dbContextOptions) : base(dbContextOptions)
        {
//         return null;
        }
        */

//       public CoreDBContext(DbContextOptions<DbContext> options)
//            : base(options)
//        {
//        }
    
        // General Schema
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Country> Country { get; set; }

        // Clients Schema
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<LegalEntity> LegalEntity { get; set; }
        //        public virtual DbSet<ClientType> ClientType { get; set; }


        // Products Schema
        public virtual DbSet<Brand> Brand{ get; set; }
        public virtual DbSet<Feature> Feature { get; set; }
        public virtual DbSet<FeatureValue> FeatureValue { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductFeature> ProductFeature { get; set; }
        public virtual DbSet<ProductGroup> ProductGroup { get; set; }
        public virtual DbSet<ProductGroupTemplate> ProductGroupTemplate { get; set; }
        public virtual DbSet<ProductGroupTemplateFeature> ProductGroupTemplateFeature { get; set; }
        public virtual DbSet<ProductLabel> ProductLabel { get; set; }
        public virtual DbSet<ProductUnit> ProductUnit { get; set; }
        public virtual DbSet<ProductProcessor> ProductProcessor { get; set; }
        public virtual DbSet<ProductProcessorDetail> ProductProcessorDetail { get; set; }
        public virtual DbSet<ProductProcessorProductFeature> ProductProcessorProductFeature { get; set; }
        public virtual DbSet<ProductProcessorSalePrice> ProductProcessorSalePrice { get; set; }

        // Inventory Schema
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<InventoryChangeType> InventoryChangeType { get; set; }
        public virtual DbSet<InventoryChange> InventoryChange { get; set; }
        public virtual DbSet<Movement> Movement { get; set; }
        public virtual DbSet<MovementDetail> MovementDetail { get; set; }

        // Procurement Schema
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetail { get; set; }
        public virtual DbSet<PurchaseAllocationSource> PurchaseAllocationSource { get; set; }
        public virtual DbSet<PurchaseAllocationSourceType> PurchaseAllocationSourceType { get; set; }
        public virtual DbSet<PurchaseAllocationSchema> PurchaseAllocationSchema { get; set; }
        public virtual DbSet<PurchaseAllocationResult> PurchaseAllocationResult { get; set; }
        public virtual DbSet<PurchaseDetailPostType> PurchaseDetailPostType { get; set; }

        // POS         
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<SalePayment> SalePayment { get; set; }
        public virtual DbSet<SalePaymentType> SalePaymentType { get; set; }
        public virtual DbSet<SaleProduct> SaleProduct { get; set; }
        public virtual DbSet<ReturnProduct> ReturnProduct { get; set; }
        public virtual DbSet<SaleSchema> SaleSchema { get; set; }
        public virtual DbSet<SaleSchemaDetail> SaleSchemaDetail { get; set; }


        // Account
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountDimension> AccountDimension { get; set; }
        public virtual DbSet<AccountBalance> AccountBalance { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<TransactionOrder> TransactionOrder { get; set; }


        // General Ledger
        public virtual DbSet<GlAccount> GlAccount { get; set; }
        public virtual DbSet<GlTransaction> GlTransaction { get; set; }
        public virtual DbSet<GlTransactionDetail> GlTransactionDetail { get; set; }
        public virtual DbSet<FinAccount> FinAccount { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if (!optionsBuilder.IsConfigured)
            {
                ///#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=CoreDB;Integrated Security=True");

            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // return;

            //   WithMany
            // General Schema
            modelBuilder.Entity<Country>().ToTable("Country", "cor");
            modelBuilder.Entity<Currency>().ToTable("Currency", "cor");
            modelBuilder.Entity<User>().ToTable("User", "cor");
            modelBuilder.Entity<Entity>().ToTable("Entity", "cor");


            // Clients Schema
            modelBuilder.Entity<Client>().ToTable("Client", "cli");
            modelBuilder.Entity<Person>().ToTable("Person", "cli");
            modelBuilder.Entity<LegalEntity>().ToTable("LegalEntity", "cli");
            //modelBuilder.Entity<ClientType>().ToTable("ClientType", "cl");


            // Products Schema
            modelBuilder.Entity<Brand>().ToTable("Brand", "pro");
            modelBuilder.Entity<Feature>().ToTable("Feature", "pro");
            modelBuilder.Entity<FeatureValue>().ToTable("FeatureValue", "pro");
            modelBuilder.Entity<Product>().ToTable("Product", "pro");
            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategory", "pro");
            modelBuilder.Entity<ProductFeature>().ToTable("ProductFeature", "pro");
            modelBuilder.Entity<ProductGroup>().ToTable("ProductGroup", "pro");
            modelBuilder.Entity<ProductGroupTemplate>().ToTable("ProductGroupTemplate", "pro");
            modelBuilder.Entity<ProductGroupTemplateFeature>().ToTable("ProductGroupTemplateFeature", "pro");
            modelBuilder.Entity<ProductLabel>().ToTable("ProductLabel", "pro");
            modelBuilder.Entity<ProductUnit>().ToTable("ProductUnit", "pro");
            modelBuilder.Entity<ProductProcessor>().ToTable("ProductProcessor", "pro");
            modelBuilder.Entity<ProductProcessorDetail>().ToTable("ProductProcessorDetail", "pro");
            modelBuilder.Entity<ProductProcessorProductFeature>().ToTable("ProductProcessorProductFeature", "pro");
            modelBuilder.Entity<ProductProcessorSalePrice>().ToTable("ProductProcessorSalePrice", "pro");

            //Inventory Schema
            modelBuilder.Entity<Location>().ToTable("Location", "inv");
            modelBuilder.Entity<Inventory>().ToTable("Inventory", "inv");
            modelBuilder.Entity<InventoryChangeType>().ToTable("InventoryChangeType", "inv");
            modelBuilder.Entity<InventoryChange>().ToTable("InventoryChange", "inv");
            modelBuilder.Entity<Movement>().ToTable("Movement", "inv");
            modelBuilder.Entity<MovementDetail>().ToTable("MovementDetail", "inv");

            // Purchase Schema
            modelBuilder.Entity<Purchase>().ToTable("Purchase", "prc");
            modelBuilder.Entity<PurchaseDetail>().ToTable("PurchaseDetail", "prc");
            modelBuilder.Entity<PurchaseAllocationSource>().ToTable("PurchaseAllocationSource", "prc");
            modelBuilder.Entity<PurchaseAllocationSourceType>().ToTable("PurchaseAllocationSourceType", "prc");
            modelBuilder.Entity<PurchaseAllocationSchema>().ToTable("PurchaseAllocationSchema", "prc");
            modelBuilder.Entity<PurchaseAllocationResult>().ToTable("PurchaseAllocationResult", "prc");
            modelBuilder.Entity<PurchaseDetailPostType>().ToTable("PurchaseDetailPostType", "prc");


            // Pos Schema
            modelBuilder.Entity<Sale>().ToTable("Sale", "pos");
            modelBuilder.Entity<SalePayment>().ToTable("SalePayment", "pos");
            modelBuilder.Entity<SalePaymentType>().ToTable("SalePaymentType", "pos");
            modelBuilder.Entity<SaleProduct>().ToTable("SaleProduct", "pos");
            modelBuilder.Entity<SaleSchema>().ToTable("SaleSchema", "pos");
            modelBuilder.Entity<SaleSchemaDetail>().ToTable("SaleSchemaDetail", "pos");
            modelBuilder.Entity<ReturnProduct>().ToTable("ReturnProduct", "pos");


            // Account Schema
            modelBuilder.Entity<Account>().ToTable("Account ", "acc");
            modelBuilder.Entity<AccountDimension>().ToTable("AccountDimension", "acc");
            modelBuilder.Entity<AccountBalance>().ToTable("AccountBalance", "acc");
            modelBuilder.Entity<Transaction>().ToTable("Transaction", "acc");
            modelBuilder.Entity<TransactionOrder>().ToTable("TransactionOrder", "acc");

            // General Ledger Schema
            modelBuilder.Entity<GlAccount>().ToTable("GlAccount", "gl");
            modelBuilder.Entity<GlTransaction>().ToTable("GlTransaction", "gl");
            modelBuilder.Entity<GlTransactionDetail>().ToTable("GlTransactionDetail", "gl");
            modelBuilder.Entity<FinAccount>().ToTable("FinAccount", "gl");


            foreach (var e in modelBuilder.Model.GetEntityTypes() )
            {
                foreach (var r in e.GetReferencingForeignKeys() )
                {
                    r.DeleteBehavior = DeleteBehavior.NoAction;
                }

//                var p = e.AddProperty("Version", typeof(int));
//                p.ValueGenerated = ValueGenerated.OnAddOrUpdate;

            }

        }

    }
}
