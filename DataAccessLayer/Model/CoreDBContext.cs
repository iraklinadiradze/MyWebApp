using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;

using DataAccessLayer.Model.Client;
using DataAccessLayer.Model.Core;
using DataAccessLayer.Model.Inventory;
using DataAccessLayer.Model.Product;



namespace DataAccessLayer
{
    public class CoreDBContext : DbContext
    {

        ///*
        public CoreDBContext() : base()
        {
//         return null;
        }
        //*/

       public CoreDBContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }
    
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
        public virtual DbSet<Movement> Movement { get; set; }
        public virtual DbSet<MovementDetail> MovementDetail { get; set; }

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


            //   WithMany
            // General Schema
            modelBuilder.Entity<Country>().ToTable("Country", "cor");
            modelBuilder.Entity<Currency>().ToTable("Currency", "cor");
            modelBuilder.Entity<User>().ToTable("User", "cor");


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
            modelBuilder.Entity<Movement>().ToTable("Movement", "inv");
            modelBuilder.Entity<MovementDetail>().ToTable("MovementDetail", "inv");

            foreach (var e in modelBuilder.Model.GetEntityTypes() )
            {
                foreach (var r in e.GetReferencingForeignKeys() )
                {
                    r.DeleteBehavior = DeleteBehavior.NoAction;
                }

                var p = e.AddProperty("Version", typeof(int));
                p.ValueGenerated = ValueGenerated.OnAddOrUpdate;
//                p.SetDefaultValue(0);

            }

        }

    }
}
