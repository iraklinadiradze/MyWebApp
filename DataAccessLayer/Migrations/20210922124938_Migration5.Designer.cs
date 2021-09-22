﻿// <auto-generated />
using System;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(CoreDBContext))]
    [Migration("20210922124938_Migration5")]
    partial class Migration5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DataAccessLayer.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsBank")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsCustomer")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsEmployee")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPerson")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsSupplier")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Client", "cli");
                });

            modelBuilder.Entity("DataAccessLayer.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Country", "cor");
                });

            modelBuilder.Entity("DataAccessLayer.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CurrencyCode")
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CurrencyDescrip")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Currency", "cor");
                });

            modelBuilder.Entity("DataAccessLayer.LegalEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("LegalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegalEntityName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("OfficeAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("RegistrationCountryID")
                        .HasColumnType("int");

                    b.Property<string>("TaxCode")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<DateTime?>("TaxRegDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("RegistrationCountryID");

                    b.ToTable("LegalEntity", "cli");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Brand", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.Feature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FeatureName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("ts")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.ToTable("Feature", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.FeatureValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<int>("FeatureValueName")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId");

                    b.ToTable("FeatureValue", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsSingle")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsTangible")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsWholeQuantity")
                        .HasColumnType("bit");

                    b.Property<string>("ProductCode")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("ProductGroupId")
                        .HasColumnType("int");

                    b.Property<int>("ProductLabelId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProductUnitId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductGroupId");

                    b.HasIndex("ProductLabelId");

                    b.HasIndex("ProductUnitId");

                    b.ToTable("Product", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductCategoryName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FeatureValueId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeatureValueId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductFeature", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductGroupName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ProductGroupTemplateId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductCategoryId");

                    b.HasIndex("ProductGroupTemplateId");

                    b.ToTable("ProductGroup", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductGroupTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("IsSingle")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsTangible")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsWholeQuantity")
                        .HasColumnType("bit");

                    b.Property<string>("ProductGroupTemplateName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("ProductUnitId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductUnitId");

                    b.ToTable("ProductGroupTemplate", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductGroupTemplateFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsMandatory")
                        .HasColumnType("bit");

                    b.Property<int>("ProductGroupTemplateId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("FeatureId");

                    b.HasIndex("ProductGroupTemplateId");

                    b.ToTable("ProductGroupTemplateFeature", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductLabel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("ProductLabelName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("ProductLabel", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductProcessor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IdentifyProducts")
                        .HasColumnType("bit");

                    b.Property<bool>("IdentifyProductsAfterRegistration")
                        .HasColumnType("bit");

                    b.Property<int>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<bool>("RegisterBrandProps")
                        .HasColumnType("bit");

                    b.Property<bool>("RegisterProducts")
                        .HasColumnType("bit");

                    b.Property<bool>("RegisterPurchaseDetails")
                        .HasColumnType("bit");

                    b.Property<bool>("RegisterSalesPrices")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductProcessor", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductProcessorDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("BrandIdDictionary")
                        .HasColumnType("int");

                    b.Property<string>("BrandName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductGroupId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductGroupIdDictionary")
                        .HasColumnType("int");

                    b.Property<string>("ProductGroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductLabelId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductLabelIdDictionary")
                        .HasColumnType("int");

                    b.Property<string>("ProductLabelName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductProcessorId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Qty")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductProcessorId");

                    b.ToTable("ProductProcessorDetail", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductProcessorProductFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FeatureId")
                        .HasColumnType("int");

                    b.Property<string>("FeatureName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FeatureValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FeatureValueId")
                        .HasColumnType("int");

                    b.Property<int>("FeatureValueIdDictionary")
                        .HasColumnType("int");

                    b.Property<int>("ProductProcessorDetailId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductProcessorDetailId");

                    b.ToTable("ProductProcessorProductFeature", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductProcessorSalePrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductProcessorDetailId")
                        .HasColumnType("int");

                    b.Property<decimal>("SalePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SaleSchemaId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductProcessorDetailId");

                    b.ToTable("ProductProcessorSalePrice", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductUnitName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductUnit", "pro");
                });

            modelBuilder.Entity("DataAccessLayer.Person", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CitizenShipId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PersonalId")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("CitizenShipId");

                    b.ToTable("Person", "cli");
                });

            modelBuilder.Entity("DataAccessLayer.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Firstname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Lastname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte[]>("Version")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("User", "cor");
                });

            modelBuilder.Entity("DataAccessLayer.LegalEntity", b =>
                {
                    b.HasOne("DataAccessLayer.Client", "Client")
                        .WithOne("LegalEntity")
                        .HasForeignKey("DataAccessLayer.LegalEntity", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Country", "Country")
                        .WithMany("LegalEntity")
                        .HasForeignKey("RegistrationCountryID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.FeatureValue", b =>
                {
                    b.HasOne("DataAccessLayer.Model.Product.Feature", "Feature")
                        .WithMany("FeatureValue")
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Feature");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.Product", b =>
                {
                    b.HasOne("DataAccessLayer.Model.Product.ProductGroup", "ProductGroup")
                        .WithMany("Product")
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Model.Product.ProductLabel", "ProductLabel")
                        .WithMany("Product")
                        .HasForeignKey("ProductLabelId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Model.Product.ProductUnit", "ProductUnit")
                        .WithMany("Product")
                        .HasForeignKey("ProductUnitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProductGroup");

                    b.Navigation("ProductLabel");

                    b.Navigation("ProductUnit");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductFeature", b =>
                {
                    b.HasOne("DataAccessLayer.Model.Product.FeatureValue", "FeatureValue")
                        .WithMany()
                        .HasForeignKey("FeatureValueId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Model.Product.Product", "Product")
                        .WithMany("ProductFeature")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("FeatureValue");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductGroup", b =>
                {
                    b.HasOne("DataAccessLayer.Model.Product.ProductCategory", "ProductCategory")
                        .WithMany("ProductGroup")
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Model.Product.ProductGroupTemplate", null)
                        .WithMany("ProductGroup")
                        .HasForeignKey("ProductGroupTemplateId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductGroupTemplate", b =>
                {
                    b.HasOne("DataAccessLayer.Model.Product.ProductUnit", "ProductUnit")
                        .WithMany("ProductGroupTemplate")
                        .HasForeignKey("ProductUnitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProductUnit");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductGroupTemplateFeature", b =>
                {
                    b.HasOne("DataAccessLayer.Model.Product.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Model.Product.ProductGroupTemplate", "ProductGroupTemplate")
                        .WithMany("ProductGroupTemplateFeature")
                        .HasForeignKey("ProductGroupTemplateId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("ProductGroupTemplate");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductLabel", b =>
                {
                    b.HasOne("DataAccessLayer.Model.Product.Brand", "Brand")
                        .WithMany("ProductLabel")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductProcessorDetail", b =>
                {
                    b.HasOne("DataAccessLayer.Model.Product.ProductProcessor", "ProductProcessor")
                        .WithMany("ProductProcessorDetail")
                        .HasForeignKey("ProductProcessorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProductProcessor");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductProcessorProductFeature", b =>
                {
                    b.HasOne("DataAccessLayer.Model.Product.ProductProcessorDetail", "ProductProcessorDetail")
                        .WithMany("ProductProcessorProductFeature")
                        .HasForeignKey("ProductProcessorDetailId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProductProcessorDetail");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductProcessorSalePrice", b =>
                {
                    b.HasOne("DataAccessLayer.Model.Product.ProductProcessorDetail", "ProductProcessorDetail")
                        .WithMany("ProductProcessorSalePrice")
                        .HasForeignKey("ProductProcessorDetailId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProductProcessorDetail");
                });

            modelBuilder.Entity("DataAccessLayer.Person", b =>
                {
                    b.HasOne("DataAccessLayer.Country", "Country")
                        .WithMany("Person")
                        .HasForeignKey("CitizenShipId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.Client", "Client")
                        .WithOne("Person")
                        .HasForeignKey("DataAccessLayer.Person", "Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DataAccessLayer.Client", b =>
                {
                    b.Navigation("LegalEntity");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("DataAccessLayer.Country", b =>
                {
                    b.Navigation("LegalEntity");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.Brand", b =>
                {
                    b.Navigation("ProductLabel");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.Feature", b =>
                {
                    b.Navigation("FeatureValue");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.Product", b =>
                {
                    b.Navigation("ProductFeature");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductCategory", b =>
                {
                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductGroup", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductGroupTemplate", b =>
                {
                    b.Navigation("ProductGroup");

                    b.Navigation("ProductGroupTemplateFeature");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductLabel", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductProcessor", b =>
                {
                    b.Navigation("ProductProcessorDetail");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductProcessorDetail", b =>
                {
                    b.Navigation("ProductProcessorProductFeature");

                    b.Navigation("ProductProcessorSalePrice");
                });

            modelBuilder.Entity("DataAccessLayer.Model.Product.ProductUnit", b =>
                {
                    b.Navigation("Product");

                    b.Navigation("ProductGroupTemplate");
                });
#pragma warning restore 612, 618
        }
    }
}
