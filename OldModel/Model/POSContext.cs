using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OldModel.Model
{
    public partial class POSContext : DbContext
    {
        public POSContext()
        {
        }

        public POSContext(DbContextOptions<POSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Account1> Accounts1 { get; set; }
        public virtual DbSet<Account2> Accounts2 { get; set; }
        public virtual DbSet<AccountBalance> AccountBalances { get; set; }
        public virtual DbSet<AccountDimension> AccountDimensions { get; set; }
        public virtual DbSet<AccountStatement> AccountStatements { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<AllocSource> AllocSources { get; set; }
        public virtual DbSet<AllocSourceType> AllocSourceTypes { get; set; }
        public virtual DbSet<B2bTransaction> B2bTransactions { get; set; }
        public virtual DbSet<B2pTransaction> B2pTransactions { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Brand1> Brands1 { get; set; }
        public virtual DbSet<BrandFeature> BrandFeatures { get; set; }
        public virtual DbSet<BrandFeatureValue> BrandFeatureValues { get; set; }
        public virtual DbSet<CashDesk1> CashDesks1 { get; set; }
        public virtual DbSet<CashOutOrder> CashOutOrders { get; set; }
        public virtual DbSet<CashTransaction> CashTransactions { get; set; }
        public virtual DbSet<Cashdesk> Cashdesks { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<ColorCode> ColorCodes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Company1> Companies1 { get; set; }
        public virtual DbSet<Company2> Companies2 { get; set; }
        public virtual DbSet<Component> Components { get; set; }
        public virtual DbSet<Component1> Components1 { get; set; }
        public virtual DbSet<ComponentType> ComponentTypes { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<CurrentContext> CurrentContexts { get; set; }
        public virtual DbSet<Ddd> Ddds { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Entity> Entities { get; set; }
        public virtual DbSet<ErrorCode> ErrorCodes { get; set; }
        public virtual DbSet<ErrorCode1> ErrorCodes1 { get; set; }
        public virtual DbSet<ErrorCodeLanguage> ErrorCodeLanguages { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<ErrorMessage> ErrorMessages { get; set; }
        public virtual DbSet<ErrorMessagesDetail> ErrorMessagesDetails { get; set; }
        public virtual DbSet<ErrorStatement> ErrorStatements { get; set; }
        public virtual DbSet<Exrate> Exrates { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<FeatureValue> FeatureValues { get; set; }
        public virtual DbSet<FinAccount> FinAccounts { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupPermission> GroupPermissions { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Location1> Locations1 { get; set; }
        public virtual DbSet<Location2> Locations2 { get; set; }
        public virtual DbSet<LogEvent> LogEvents { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Movement> Movements { get; set; }
        public virtual DbSet<Movement1> Movements1 { get; set; }
        public virtual DbSet<MovementDetail> MovementDetails { get; set; }
        public virtual DbSet<ObjectType> ObjectTypes { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionCategory> PermissionCategories { get; set; }
        public virtual DbSet<PermissionGroup> PermissionGroups { get; set; }
        public virtual DbSet<PermissionObject> PermissionObjects { get; set; }
        public virtual DbSet<Process> Processes { get; set; }
        public virtual DbSet<ProcessType> ProcessTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Product1> Products1 { get; set; }
        public virtual DbSet<ProductBrandFeature> ProductBrandFeatures { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductCode> ProductCodes { get; set; }
        public virtual DbSet<ProductFeature> ProductFeatures { get; set; }
        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<ProductLabel> ProductLabels { get; set; }
        public virtual DbSet<ProductLabel1> ProductLabels1 { get; set; }
        public virtual DbSet<ProductProcessor> ProductProcessors { get; set; }
        public virtual DbSet<ProductProcessorDetail> ProductProcessorDetails { get; set; }
        public virtual DbSet<ProductProcessorDetailBak> ProductProcessorDetailBaks { get; set; }
        public virtual DbSet<ProductProcessorProductBrandFeature> ProductProcessorProductBrandFeatures { get; set; }
        public virtual DbSet<ProductProcessorProductFeature> ProductProcessorProductFeatures { get; set; }
        public virtual DbSet<ProductTemplate> ProductTemplates { get; set; }
        public virtual DbSet<ProductTemplateBrandFeature> ProductTemplateBrandFeatures { get; set; }
        public virtual DbSet<ProductTemplateFeature> ProductTemplateFeatures { get; set; }
        public virtual DbSet<ProductUnit> ProductUnits { get; set; }
        public virtual DbSet<Production> Productions { get; set; }
        public virtual DbSet<ProductionIn> ProductionIns { get; set; }
        public virtual DbSet<ProductionInStd> ProductionInStds { get; set; }
        public virtual DbSet<ProductionOut> ProductionOuts { get; set; }
        public virtual DbSet<ProductionOutStd> ProductionOutStds { get; set; }
        public virtual DbSet<ProductionType> ProductionTypes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<PurchaseAddCost> PurchaseAddCosts { get; set; }
        public virtual DbSet<PurchaseAddCostType> PurchaseAddCostTypes { get; set; }
        public virtual DbSet<PurchaseAllocation> PurchaseAllocations { get; set; }
        public virtual DbSet<PurchaseCount> PurchaseCounts { get; set; }
        public virtual DbSet<PurchaseDetail> PurchaseDetails { get; set; }
        public virtual DbSet<PurchaseDetailPostType> PurchaseDetailPostTypes { get; set; }
        public virtual DbSet<PurchasePayment> PurchasePayments { get; set; }
        public virtual DbSet<PurchaseReturn> PurchaseReturns { get; set; }
        public virtual DbSet<PurchaseStatus> PurchaseStatuses { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SalesSchema> SalesSchemas { get; set; }
        public virtual DbSet<SalesSchema1> SalesSchemas1 { get; set; }
        public virtual DbSet<SalesSchemaDetail> SalesSchemaDetails { get; set; }
        public virtual DbSet<Sequence> Sequences { get; set; }
        public virtual DbSet<Shelf> Shelfs { get; set; }
        public virtual DbSet<ShopEmployee> ShopEmployees { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<StockCount> StockCounts { get; set; }
        public virtual DbSet<StockCountDetail> StockCountDetails { get; set; }
        public virtual DbSet<StockWriteoff> StockWriteoffs { get; set; }
        public virtual DbSet<StockWriteoffDetail> StockWriteoffDetails { get; set; }
        public virtual DbSet<Style> Styles { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Supplier1> Suppliers1 { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<TemplateIn> TemplateIns { get; set; }
        public virtual DbSet<TemplateOut> TemplateOuts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Transaction1> Transactions1 { get; set; }
        public virtual DbSet<TransactionDetail> TransactionDetails { get; set; }
        public virtual DbSet<TransactionOrder> TransactionOrders { get; set; }
        public virtual DbSet<TransactionSource> TransactionSources { get; set; }
        public virtual DbSet<TransferOrder> TransferOrders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserForm> UserForms { get; set; }
        public virtual DbSet<WatchList> WatchLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=POS;User Id=sa;Password=Alive1812");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_BIN");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts", "acc");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AccountDimensionId).HasColumnName("account_dimension_id");

                entity.Property(e => e.EntityForeignId1).HasColumnName("entity_foreign_id1");

                entity.Property(e => e.EntityForeignId2).HasColumnName("entity_foreign_id2");

                entity.Property(e => e.EntityForeignId3).HasColumnName("entity_foreign_id3");

                entity.Property(e => e.EntityForeignId4).HasColumnName("entity_foreign_id4");

                entity.Property(e => e.EntityForeignId5).HasColumnName("entity_foreign_id5");

                entity.Property(e => e.EntityForeignId6).HasColumnName("entity_foreign_id6");

                entity.HasOne(d => d.AccountDimension)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountDimensionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_accounts_account_dimensions");
            });

            modelBuilder.Entity<Account1>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK_bank_accounts");

                entity.ToTable("accounts", "bnk");

                entity.Property(e => e.AccountId)
                    .ValueGeneratedNever()
                    .HasColumnName("account_id");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(50)
                    .HasColumnName("account_code");

                entity.Property(e => e.AccountTypeId).HasColumnName("account_type_id");

                entity.Property(e => e.BankId).HasColumnName("bank_id");

                entity.Property(e => e.Currency)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("currency");

                entity.Property(e => e.Iban)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("iban");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Account1s)
                    .HasForeignKey(d => d.AccountTypeId)
                    .HasConstraintName("FK_bank_accounts_bank_account_types");

                entity.HasOne(d => d.Bank)
                    .WithMany(p => p.Account1s)
                    .HasForeignKey(d => d.BankId)
                    .HasConstraintName("FK_bank_accounts_banks");
            });

            modelBuilder.Entity<Account2>(entity =>
            {
                entity.HasKey(e => e.AccountId)
                    .HasName("PK__accounts__46A222CD6CC31A31");

                entity.ToTable("accounts", "gl");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AccountCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("account_code");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.FinAccountId).HasColumnName("fin_account_id");

                entity.HasOne(d => d.FinAccount)
                    .WithMany(p => p.Account2s)
                    .HasForeignKey(d => d.FinAccountId)
                    .HasConstraintName("FK_accounts_fin_accounts");
            });

            modelBuilder.Entity<AccountBalance>(entity =>
            {
                entity.ToTable("account_balances", "acc");

                entity.Property(e => e.AccountBalanceId).HasColumnName("account_balance_id");

                entity.Property(e => e.AccountBalanceCount).HasColumnName("account_balance_count");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("balance");

                entity.Property(e => e.BalanceTransactionId).HasColumnName("balance_transaction_id");

                entity.Property(e => e.Decrease)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("decrease");

                entity.Property(e => e.Increase)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("increase");

                entity.Property(e => e.MaxPostTime)
                    .HasColumnType("datetime")
                    .HasColumnName("max_post_time");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("timestamp");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountBalances)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_account_balances_accounts");
            });

            modelBuilder.Entity<AccountDimension>(entity =>
            {
                entity.ToTable("account_dimensions", "acc");

                entity.Property(e => e.AccountDimensionId)
                    .ValueGeneratedNever()
                    .HasColumnName("account_dimension_id");

                entity.Property(e => e.AccountDimension1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("account_dimension")
                    .UseCollation("Latin1_General_100_BIN");

                entity.Property(e => e.Descrip)
                    .HasMaxLength(50)
                    .HasColumnName("descrip")
                    .UseCollation("Latin1_General_100_BIN");

                entity.Property(e => e.EntityId1).HasColumnName("entity_id1");

                entity.Property(e => e.EntityId2).HasColumnName("entity_id2");

                entity.Property(e => e.EntityId3).HasColumnName("entity_id3");

                entity.Property(e => e.EntityId4).HasColumnName("entity_id4");

                entity.Property(e => e.EntityId5).HasColumnName("entity_id5");

                entity.Property(e => e.EntityId6).HasColumnName("entity_id6");

                entity.HasOne(d => d.EntityId1Navigation)
                    .WithMany(p => p.AccountDimensionEntityId1Navigations)
                    .HasForeignKey(d => d.EntityId1)
                    .HasConstraintName("FK_account_dimensions_entities");

                entity.HasOne(d => d.EntityId2Navigation)
                    .WithMany(p => p.AccountDimensionEntityId2Navigations)
                    .HasForeignKey(d => d.EntityId2)
                    .HasConstraintName("FK_account_dimensions_entities1");

                entity.HasOne(d => d.EntityId3Navigation)
                    .WithMany(p => p.AccountDimensionEntityId3Navigations)
                    .HasForeignKey(d => d.EntityId3)
                    .HasConstraintName("FK_account_dimensions_entities2");

                entity.HasOne(d => d.EntityId4Navigation)
                    .WithMany(p => p.AccountDimensionEntityId4Navigations)
                    .HasForeignKey(d => d.EntityId4)
                    .HasConstraintName("FK_account_dimensions_entities3");

                entity.HasOne(d => d.EntityId5Navigation)
                    .WithMany(p => p.AccountDimensionEntityId5Navigations)
                    .HasForeignKey(d => d.EntityId5)
                    .HasConstraintName("FK_account_dimensions_entities4");

                entity.HasOne(d => d.EntityId6Navigation)
                    .WithMany(p => p.AccountDimensionEntityId6Navigations)
                    .HasForeignKey(d => d.EntityId6)
                    .HasConstraintName("FK_account_dimensions_entities5");
            });

            modelBuilder.Entity<AccountStatement>(entity =>
            {
                entity.ToTable("account_statement", "bnk");

                entity.Property(e => e.AccountStatementId)
                    .ValueGeneratedNever()
                    .HasColumnName("account_statement_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.BankTransactionId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bank_transaction_id");

                entity.Property(e => e.CorrAccount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("corr_account");

                entity.Property(e => e.Credit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("credit");

                entity.Property(e => e.Debit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("debit");

                entity.Property(e => e.Note)
                    .HasMaxLength(1000)
                    .HasColumnName("note");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountStatements)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_account_statement_accounts");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("account_types", "bnk");

                entity.Property(e => e.AccountTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("account_type_id");

                entity.Property(e => e.AccountType1)
                    .HasMaxLength(50)
                    .HasColumnName("account_type");
            });

            modelBuilder.Entity<AllocSource>(entity =>
            {
                entity.ToTable("alloc_sources", "prc");

                entity.Property(e => e.AllocSourceId).HasColumnName("alloc_source_id");

                entity.Property(e => e.AllocPurchaseDetailId).HasColumnName("alloc_purchase_detail_id");

                entity.Property(e => e.AllocSourceTypeId).HasColumnName("alloc_source_type_id");

                entity.Property(e => e.Allocate).HasColumnName("allocate");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.GlAccountFinAccountJd)
                    .HasMaxLength(10)
                    .HasColumnName("gl_account_fin_account_jd")
                    .IsFixedLength(true);

                entity.Property(e => e.GlAccountId).HasColumnName("gl_account_id");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.PurchaseAddCostTypeId).HasColumnName("purchase_add_cost_type_id");

                entity.Property(e => e.PurchaseAllocationId).HasColumnName("purchase_allocation_id");

                entity.Property(e => e.PurchaseDetailFinAccountId).HasColumnName("purchase_detail_fin_account_id");

                entity.HasOne(d => d.AllocSourceType)
                    .WithMany(p => p.AllocSources)
                    .HasForeignKey(d => d.AllocSourceTypeId)
                    .HasConstraintName("FK_alloc_sources_alloc_source_types");

                entity.HasOne(d => d.PurchaseAddCostType)
                    .WithMany(p => p.AllocSources)
                    .HasForeignKey(d => d.PurchaseAddCostTypeId)
                    .HasConstraintName("FK_alloc_sources_purchase_add_cost_types");
            });

            modelBuilder.Entity<AllocSourceType>(entity =>
            {
                entity.ToTable("alloc_source_types", "prc");

                entity.Property(e => e.AllocSourceTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("alloc_source_type_id");

                entity.Property(e => e.AllocSourceType1)
                    .HasMaxLength(50)
                    .HasColumnName("alloc_source_type");
            });

            modelBuilder.Entity<B2bTransaction>(entity =>
            {
                entity.ToTable("b2b_transactions", "bnk");

                entity.Property(e => e.B2bTransactionId).HasColumnName("b2b_transaction_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.CreditAccountId).HasColumnName("credit_account_id");

                entity.Property(e => e.CreditAccountStatementId).HasColumnName("credit_account_statement_id");

                entity.Property(e => e.DebitAccountId).HasColumnName("debit_account_id");

                entity.Property(e => e.DebitAccountStatementId).HasColumnName("debit_account_statement_id");

                entity.Property(e => e.DocumentId).HasColumnName("document_id");

                entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");

                entity.Property(e => e.Note)
                    .HasMaxLength(250)
                    .HasColumnName("note");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");

                entity.HasOne(d => d.CreditAccount)
                    .WithMany(p => p.B2bTransactionCreditAccounts)
                    .HasForeignKey(d => d.CreditAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b2b_transactions_accounts1");

                entity.HasOne(d => d.DebitAccount)
                    .WithMany(p => p.B2bTransactionDebitAccounts)
                    .HasForeignKey(d => d.DebitAccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b2b_transactions_accounts");
            });

            modelBuilder.Entity<B2pTransaction>(entity =>
            {
                entity.ToTable("b2p_transactions", "bnk");

                entity.Property(e => e.B2pTransactionId).HasColumnName("b2p_transaction_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AccountStatementId).HasColumnName("account_statement_id");

                entity.Property(e => e.Credit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("credit");

                entity.Property(e => e.Debit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("debit");

                entity.Property(e => e.DocumentId).HasColumnName("document_id");

                entity.Property(e => e.DocumentTypeId).HasColumnName("document_type_id");

                entity.Property(e => e.EntityForeignId).HasColumnName("entity_foreign_id");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.B2pTransactions)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_transaction_details_accounts");

                entity.HasOne(d => d.AccountStatement)
                    .WithMany(p => p.B2pTransactions)
                    .HasForeignKey(d => d.AccountStatementId)
                    .HasConstraintName("FK_transaction_details_account_statement");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.B2pTransactions)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .HasConstraintName("FK_b2p_transactions_document_types");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.ToTable("banks", "bnk");

                entity.Property(e => e.BankId)
                    .ValueGeneratedNever()
                    .HasColumnName("bank_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(10)
                    .HasColumnName("address")
                    .IsFixedLength(true);

                entity.Property(e => e.Bankcode)
                    .HasMaxLength(50)
                    .HasColumnName("bankcode");

                entity.Property(e => e.Bankname)
                    .HasMaxLength(50)
                    .HasColumnName("bankname");

                entity.Property(e => e.SwiftCode)
                    .HasMaxLength(50)
                    .HasColumnName("swift_code");

                entity.Property(e => e.Swiftcode1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("swiftcode");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brands", "pos");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(50)
                    .HasColumnName("brand_name");
            });

            modelBuilder.Entity<Brand1>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK_brands_1");

                entity.ToTable("brands", "pro");

                entity.Property(e => e.BrandId)
                    .ValueGeneratedNever()
                    .HasColumnName("brand_id");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("brand_name");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");
            });

            modelBuilder.Entity<BrandFeature>(entity =>
            {
                entity.ToTable("brand_features", "pro");

                entity.Property(e => e.BrandFeatureId)
                    .ValueGeneratedNever()
                    .HasColumnName("brand_feature_id");

                entity.Property(e => e.BrandFeatureCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brand_feature_code");

                entity.Property(e => e.BrandFeatureName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("brand_feature_name");
            });

            modelBuilder.Entity<BrandFeatureValue>(entity =>
            {
                entity.ToTable("brand_feature_values", "pro");

                entity.Property(e => e.BrandFeatureValueId)
                    .ValueGeneratedNever()
                    .HasColumnName("brand_feature_value_id");

                entity.Property(e => e.BrandFeatureId).HasColumnName("brand_feature_id");

                entity.Property(e => e.BrandFeatureValue1)
                    .HasMaxLength(1000)
                    .HasColumnName("brand_feature_value");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.HasOne(d => d.BrandFeature)
                    .WithMany(p => p.BrandFeatureValues)
                    .HasForeignKey(d => d.BrandFeatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_brand_feature_values_brand_features");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.BrandFeatureValues)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_brand_feature_values_brands");
            });

            modelBuilder.Entity<CashDesk1>(entity =>
            {
                entity.HasKey(e => e.CashDeskId)
                    .HasName("PK__cash_des__B19908B030E33A54");

                entity.ToTable("cash_desks", "pos");

                entity.Property(e => e.CashDeskId).HasColumnName("cash_desk_id");

                entity.Property(e => e.CashDeskCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cash_desk_code");

                entity.Property(e => e.Descrip)
                    .HasMaxLength(200)
                    .HasColumnName("descrip");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.CashDesk1s)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cash_desks_locations");
            });

            modelBuilder.Entity<CashOutOrder>(entity =>
            {
                entity.ToTable("cash_out_orders", "bnk");

                entity.Property(e => e.CashOutOrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("cash_out_order_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.EntityForeignId).HasColumnName("entity_foreign_id");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");
            });

            modelBuilder.Entity<CashTransaction>(entity =>
            {
                entity.ToTable("cash_transactions");

                entity.Property(e => e.CashTransactionId)
                    .ValueGeneratedNever()
                    .HasColumnName("cash_transaction_id");

                entity.Property(e => e.CashdeskId).HasColumnName("cashdesk_id");

                entity.Property(e => e.Credit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("credit");

                entity.Property(e => e.Debit)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("debit");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");

                entity.HasOne(d => d.Cashdesk)
                    .WithMany(p => p.CashTransactions)
                    .HasForeignKey(d => d.CashdeskId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_cash_transactions_cashdesks");
            });

            modelBuilder.Entity<Cashdesk>(entity =>
            {
                entity.ToTable("cashdesks");

                entity.Property(e => e.CashdeskId)
                    .ValueGeneratedNever()
                    .HasColumnName("cashdesk_id");

                entity.Property(e => e.CashdeskName)
                    .HasMaxLength(50)
                    .HasColumnName("cashdesk_name");

                entity.Property(e => e.LocationId).HasColumnName("location_id");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients", "cl");

                entity.Property(e => e.ClientId)
                    .ValueGeneratedNever()
                    .HasColumnName("client_id");

                entity.Property(e => e.ActualAddress)
                    .HasMaxLength(2000)
                    .HasColumnName("actual_address");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.ClientName)
                    .HasMaxLength(200)
                    .HasColumnName("client_name");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(200)
                    .HasColumnName("first_name");

                entity.Property(e => e.FullName)
                    .HasMaxLength(400)
                    .HasColumnName("full_name");

                entity.Property(e => e.HomePhone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("home_phone");

                entity.Property(e => e.IsBank).HasColumnName("is_bank");

                entity.Property(e => e.IsCustomer).HasColumnName("is_customer");

                entity.Property(e => e.IsEmployee).HasColumnName("is_employee");

                entity.Property(e => e.IsPerson).HasColumnName("is_person");

                entity.Property(e => e.IsSupplier).HasColumnName("is_supplier");

                entity.Property(e => e.LegalAddress)
                    .HasMaxLength(2000)
                    .HasColumnName("legal_address");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.PresonalId)
                    .HasMaxLength(100)
                    .HasColumnName("presonal_id");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(100)
                    .HasColumnName("tax_code");

                entity.Property(e => e.TaxRegDate)
                    .HasColumnType("datetime")
                    .HasColumnName("tax_reg_date");

                entity.Property(e => e.WorkPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("work_phone");
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.ToTable("colors", "pos");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.Color1)
                    .HasMaxLength(50)
                    .HasColumnName("color");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Colors)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_colors_brands");
            });

            modelBuilder.Entity<ColorCode>(entity =>
            {
                entity.ToTable("color_codes", "pos");

                entity.Property(e => e.ColorCodeId).HasColumnName("color_code_id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.ColorCode1)
                    .HasMaxLength(50)
                    .HasColumnName("color_code");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ColorCodes)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_color_codes_brands");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("company", "ERP");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.OldCompanyId).HasColumnName("old_company_id");
            });

            modelBuilder.Entity<Company1>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK_companies_1");

                entity.ToTable("companies", "cr");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address")
                    .UseCollation("Latin1_General_100_BIN");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .HasColumnName("company_name")
                    .UseCollation("Latin1_General_100_BIN");

                entity.Property(e => e.Director)
                    .HasMaxLength(50)
                    .HasColumnName("director")
                    .UseCollation("Latin1_General_100_BIN");

                entity.Property(e => e.TaxCode)
                    .HasMaxLength(50)
                    .HasColumnName("tax_code")
                    .UseCollation("Latin1_General_100_BIN");
            });

            modelBuilder.Entity<Company2>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("companies", "pos");

                entity.Property(e => e.CompanyId)
                    .ValueGeneratedNever()
                    .HasColumnName("company_id");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(50)
                    .HasColumnName("company_name")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<Component>(entity =>
            {
                entity.ToTable("components", "app");

                entity.Property(e => e.ComponentId)
                    .ValueGeneratedNever()
                    .HasColumnName("component_id");

                entity.Property(e => e.ComponentName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("component_name");

                entity.Property(e => e.ComponentTypeId).HasColumnName("component_type_id");

                entity.HasOne(d => d.ComponentType)
                    .WithMany(p => p.Components)
                    .HasForeignKey(d => d.ComponentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_components_component_types");
            });

            modelBuilder.Entity<Component1>(entity =>
            {
                entity.HasKey(e => e.ComponentId)
                    .HasName("PK__componen__AEB1DA59EDA52790");

                entity.ToTable("components", "log");

                entity.Property(e => e.ComponentId).HasColumnName("component_id");

                entity.Property(e => e.Component)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("component");
            });

            modelBuilder.Entity<ComponentType>(entity =>
            {
                entity.ToTable("component_types", "app");

                entity.Property(e => e.ComponentTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("component_type_id");

                entity.Property(e => e.ComponentType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("component_type");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("currencies", "cr");

                entity.Property(e => e.CurrencyId)
                    .ValueGeneratedNever()
                    .HasColumnName("currency_id");

                entity.Property(e => e.Currency1)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("currency");

                entity.Property(e => e.CurrencyDescrip)
                    .HasMaxLength(1000)
                    .HasColumnName("currency_descrip");
            });

            modelBuilder.Entity<CurrentContext>(entity =>
            {
                entity.ToTable("current_context", "cr");

                entity.Property(e => e.CurrentContextId).HasColumnName("current_context_id");

                entity.Property(e => e.AppName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("app_name");

                entity.Property(e => e.EntryTime)
                    .HasColumnType("datetime")
                    .HasColumnName("entry_time");

                entity.Property(e => e.HostAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("host_address");

                entity.Property(e => e.OtherContextInfo)
                    .HasColumnType("xml")
                    .HasColumnName("other_context_info");

                entity.Property(e => e.Spid).HasColumnName("spid");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("user_name");
            });

            modelBuilder.Entity<Ddd>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ddd");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.ToTable("document_types", "bnk");

                entity.Property(e => e.DocumentTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("document_type_id");

                entity.Property(e => e.DocumentType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("document_type");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employees", "pos");

                entity.Property(e => e.EmployeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("employee_id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.UserRoleId).HasColumnName("user_role_id");
            });

            modelBuilder.Entity<Entity>(entity =>
            {
                entity.ToTable("entities", "cr");

                entity.Property(e => e.EntityId)
                    .ValueGeneratedNever()
                    .HasColumnName("entity_id");

                entity.Property(e => e.EntityCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("entity_code")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.EntityDescrip)
                    .HasMaxLength(50)
                    .HasColumnName("entity_descrip")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.EntityName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("entity_name")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<ErrorCode>(entity =>
            {
                entity.ToTable("error_codes", "cr");

                entity.Property(e => e.ErrorCodeId).HasColumnName("error_code_id");

                entity.Property(e => e.ErrorArea)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("error_area");

                entity.Property(e => e.ErrorAreaType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("error_area_type");

                entity.Property(e => e.ErrorCode1)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("error_code");

                entity.Property(e => e.ErrorSubarea)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("error_subarea");

                entity.Property(e => e.ErrorSubareaType)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("error_subarea_type");
            });

            modelBuilder.Entity<ErrorCode1>(entity =>
            {
                entity.HasKey(e => e.ErrorCodeId)
                    .HasName("PK__error_co__7F7C31D9EB223B32");

                entity.ToTable("error_codes", "log");

                entity.Property(e => e.ErrorCodeId).HasColumnName("error_code_id");

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("error_code");

                entity.Property(e => e.ErrorMsg)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("error_msg");
            });

            modelBuilder.Entity<ErrorCodeLanguage>(entity =>
            {
                entity.ToTable("error_code_languages", "cr");

                entity.Property(e => e.ErrorCodeLanguageId).HasColumnName("error_code_language_id");

                entity.Property(e => e.ErrorCodeId).HasColumnName("error_code_id");

                entity.Property(e => e.LanguageId).HasColumnName("language_id");

                entity.Property(e => e.Message)
                    .HasMaxLength(4000)
                    .HasColumnName("message");

                entity.HasOne(d => d.ErrorCode)
                    .WithMany(p => p.ErrorCodeLanguages)
                    .HasForeignKey(d => d.ErrorCodeId)
                    .HasConstraintName("FK_error_code_languages_error_codes");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.ErrorCodeLanguages)
                    .HasForeignKey(d => d.LanguageId)
                    .HasConstraintName("FK_error_code_languages_languages");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.ToTable("error_log", "cr");

                entity.Property(e => e.ErrorLogId).HasColumnName("error_log_id");

                entity.Property(e => e.CurrentContextId).HasColumnName("current_context_id");

                entity.Property(e => e.ErrorArea)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("error_area");

                entity.Property(e => e.ErrorAreaType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("error_area_type");

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("error_code");

                entity.Property(e => e.ErrorParams)
                    .HasColumnType("xml")
                    .HasColumnName("error_params");

                entity.Property(e => e.ErrorSubarea)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("error_subarea");

                entity.Property(e => e.ErrorSubareaType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("error_subarea_type");

                entity.Property(e => e.ErrorTime)
                    .HasColumnType("datetime")
                    .HasColumnName("error_time");

                entity.Property(e => e.UserContext)
                    .HasColumnType("xml")
                    .HasColumnName("user_context");
            });

            modelBuilder.Entity<ErrorMessage>(entity =>
            {
                entity.ToTable("error_messages");

                entity.Property(e => e.ErrorMessageId).HasColumnName("error_message_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("entry_date");

                entity.Property(e => e.ErrorCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("error_code");

                entity.Property(e => e.ErrorMessageDescrip)
                    .HasMaxLength(1000)
                    .HasColumnName("error_message_descrip");

                entity.Property(e => e.ErrorStatementId1).HasColumnName("error_statement_id1");

                entity.Property(e => e.ErrorStatementId10).HasColumnName("error_statement_id10");

                entity.Property(e => e.ErrorStatementId2).HasColumnName("error_statement_id2");

                entity.Property(e => e.ErrorStatementId3).HasColumnName("error_statement_id3");

                entity.Property(e => e.ErrorStatementId4).HasColumnName("error_statement_id4");

                entity.Property(e => e.ErrorStatementId5).HasColumnName("error_statement_id5");

                entity.Property(e => e.ErrorStatementId6).HasColumnName("error_statement_id6");

                entity.Property(e => e.ErrorStatementId7).HasColumnName("error_statement_id7");

                entity.Property(e => e.ErrorStatementId8).HasColumnName("error_statement_id8");

                entity.Property(e => e.ErrorStatementId9).HasColumnName("error_statement_id9");

                entity.Property(e => e.Posted).HasColumnName("posted");
            });

            modelBuilder.Entity<ErrorMessagesDetail>(entity =>
            {
                entity.ToTable("error_messages_details");

                entity.Property(e => e.ErrorMessagesDetailId).HasColumnName("error_messages_detail_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("entry_date");

                entity.Property(e => e.ErrorMessage)
                    .HasMaxLength(1000)
                    .HasColumnName("error_message");

                entity.Property(e => e.ErrorMessageId).HasColumnName("error_message_id");

                entity.Property(e => e.LanguageId)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("language_id");

                entity.Property(e => e.Posted).HasColumnName("posted");
            });

            modelBuilder.Entity<ErrorStatement>(entity =>
            {
                entity.ToTable("error_statements");

                entity.Property(e => e.ErrorStatementId).HasColumnName("error_statement_id");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .HasColumnName("created_by");

                entity.Property(e => e.Descrip)
                    .HasMaxLength(50)
                    .HasColumnName("descrip");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("entry_date");

                entity.Property(e => e.ErrorStatementCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("error_statement_code");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.SqlStatement)
                    .HasMaxLength(4000)
                    .HasColumnName("sql_statement");

                entity.Property(e => e.TestInPar)
                    .HasMaxLength(50)
                    .HasColumnName("test_in_par");
            });

            modelBuilder.Entity<Exrate>(entity =>
            {
                entity.ToTable("exrates", "cr");

                entity.Property(e => e.ExrateId)
                    .ValueGeneratedNever()
                    .HasColumnName("exrate_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 10)")
                    .HasColumnName("amount");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Exrates)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_exrates_currencies");
            });

            modelBuilder.Entity<Feature>(entity =>
            {
                entity.ToTable("features", "pro");

                entity.Property(e => e.FeatureId)
                    .ValueGeneratedNever()
                    .HasColumnName("feature_id");

                entity.Property(e => e.Feature1)
                    .HasMaxLength(50)
                    .HasColumnName("feature");

                entity.Property(e => e.FeatureCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("feature_code");
            });

            modelBuilder.Entity<FeatureValue>(entity =>
            {
                entity.ToTable("feature_values", "pro");

                entity.Property(e => e.FeatureValueId)
                    .ValueGeneratedNever()
                    .HasColumnName("feature_value_id");

                entity.Property(e => e.FeatureId).HasColumnName("feature_id");

                entity.Property(e => e.FeatureValue1)
                    .HasMaxLength(50)
                    .HasColumnName("feature_value");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.FeatureValues)
                    .HasForeignKey(d => d.FeatureId)
                    .HasConstraintName("FK_feature_values_features");
            });

            modelBuilder.Entity<FinAccount>(entity =>
            {
                entity.ToTable("fin_accounts", "gl");

                entity.Property(e => e.FinAccountId).HasColumnName("fin_account_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.FinAccountCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("fin_account_code");
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.ToTable("forms", "ui");

                entity.Property(e => e.FormId)
                    .ValueGeneratedNever()
                    .HasColumnName("form_id");

                entity.Property(e => e.ControlDefaults)
                    .HasColumnType("ntext")
                    .HasColumnName("control_defaults");

                entity.Property(e => e.Descrip)
                    .HasMaxLength(50)
                    .HasColumnName("descrip");

                entity.Property(e => e.FormLayout)
                    .HasColumnType("ntext")
                    .HasColumnName("form_layout");

                entity.Property(e => e.FormName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("form_name");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("groups", "usr");

                entity.Property(e => e.GroupId)
                    .ValueGeneratedNever()
                    .HasColumnName("group_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("group_name");
            });

            modelBuilder.Entity<GroupPermission>(entity =>
            {
                entity.ToTable("group_permissions", "usr");

                entity.Property(e => e.GroupPermissionId)
                    .ValueGeneratedNever()
                    .HasColumnName("group_permission_id");

                entity.Property(e => e.Enabled).HasColumnName("enabled");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.GroupPermissions)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_group_permissions_groups");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.GroupPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_group_permissions_permissions");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory", "inv");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.EntityForeignId).HasColumnName("entity_foreign_id");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.EntityProcCode)
                    .HasMaxLength(10)
                    .HasColumnName("entity_proc_code")
                    .IsFixedLength(true);

                entity.Property(e => e.ExpDate)
                    .HasColumnType("date")
                    .HasColumnName("exp_date");

                entity.Property(e => e.InventoryCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("inventory_code");

                entity.Property(e => e.IsSingle).HasColumnName("is_single");

                entity.Property(e => e.IsWholeQuantity).HasColumnName("is_whole_quantity");

                entity.Property(e => e.ProcInInventory).HasColumnName("proc_in_inventory");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductUnitId).HasColumnName("product_unit_id");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("languages", "cr");

                entity.Property(e => e.LanguageId)
                    .ValueGeneratedNever()
                    .HasColumnName("language_id");

                entity.Property(e => e.Lang)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("lang");

                entity.Property(e => e.Language1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("language");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("location", "ERP");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.OldLocationId).HasColumnName("old_location_id");
            });

            modelBuilder.Entity<Location1>(entity =>
            {
                entity.HasKey(e => e.LocationId);

                entity.ToTable("locations", "cr");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.IsShop).HasColumnName("is_shop");

                entity.Property(e => e.IsWarehouse).HasColumnName("is_warehouse");

                entity.Property(e => e.LocationName)
                    .HasMaxLength(50)
                    .HasColumnName("location_name")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.SalesSchemaId).HasColumnName("sales_schema_id");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Location1s)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK_locations_companies");

                entity.HasOne(d => d.SalesSchema)
                    .WithMany(p => p.Location1s)
                    .HasForeignKey(d => d.SalesSchemaId)
                    .HasConstraintName("FK_locations_sales_schemas");
            });

            modelBuilder.Entity<Location2>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__location__771831EA15840A7D");

                entity.ToTable("locations", "log");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Location)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("location");
            });

            modelBuilder.Entity<LogEvent>(entity =>
            {
                entity.ToTable("log_events", "log");

                entity.Property(e => e.LogEventId).HasColumnName("log_event_id");

                entity.Property(e => e.ComponentId).HasColumnName("component_id");

                entity.Property(e => e.ContextObj)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("context_obj");

                entity.Property(e => e.ErrorCodeId).HasColumnName("error_code_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("models", "pos");

                entity.Property(e => e.ModelId).HasColumnName("model_id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.Model1)
                    .HasMaxLength(50)
                    .HasColumnName("model");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_models_brands");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("modules", "app");

                entity.Property(e => e.ModuleId)
                    .ValueGeneratedNever()
                    .HasColumnName("module_id");

                entity.Property(e => e.ModuleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("module_name");
            });

            modelBuilder.Entity<Movement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("movement", "ERP");

                entity.Property(e => e.MovementId).HasColumnName("movement_id");

                entity.Property(e => e.OldMovementId).HasColumnName("old_movement_id");
            });

            modelBuilder.Entity<Movement1>(entity =>
            {
                entity.HasKey(e => e.MovementId);

                entity.ToTable("movements", "inv");

                entity.Property(e => e.MovementId).HasColumnName("movement_id");

                entity.Property(e => e.FromFinPosted).HasColumnName("from_fin_posted");

                entity.Property(e => e.FromFinPostedStarted).HasColumnName("from_fin_posted_started");

                entity.Property(e => e.FromLocationId).HasColumnName("from_location_id");

                entity.Property(e => e.FromPosted)
                    .HasColumnName("from_posted")
                    .HasComputedColumnSql("(case when [from_qty_posted]=(1) AND [from_fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.FromQtyPosted).HasColumnName("from_qty_posted");

                entity.Property(e => e.FromQtyPostedStarted).HasColumnName("from_qty_posted_started");

                entity.Property(e => e.FromTransDate)
                    .HasColumnType("date")
                    .HasColumnName("from_trans_date");

                entity.Property(e => e.ToFinPosted).HasColumnName("to_fin_posted");

                entity.Property(e => e.ToFinPostedStarted).HasColumnName("to_fin_posted_started");

                entity.Property(e => e.ToLocationId).HasColumnName("to_location_id");

                entity.Property(e => e.ToPosted)
                    .HasColumnName("to_posted")
                    .HasComputedColumnSql("(case when [to_qty_posted]=(1) AND [to_fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.ToQtyPosted).HasColumnName("to_qty_posted");

                entity.Property(e => e.ToQtyPostedStarted).HasColumnName("to_qty_posted_started");

                entity.Property(e => e.ToTransDate)
                    .HasColumnType("date")
                    .HasColumnName("to_trans_date");
            });

            modelBuilder.Entity<MovementDetail>(entity =>
            {
                entity.ToTable("movement_details", "inv");

                entity.Property(e => e.MovementDetailId).HasColumnName("movement_detail_id");

                entity.Property(e => e.FromFinPosted).HasColumnName("from_fin_posted");

                entity.Property(e => e.FromPosted)
                    .HasColumnName("from_posted")
                    .HasComputedColumnSql("(case when [from_qty_posted]=(1) AND [from_fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.FromQtyPosted).HasColumnName("from_qty_posted");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.MovementId).HasColumnName("movement_id");

                entity.Property(e => e.QtyFrom)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty_from");

                entity.Property(e => e.QtyTo)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty_to");

                entity.Property(e => e.QtyTransactionId).HasColumnName("qty_transaction_id");

                entity.Property(e => e.ToFinPosted).HasColumnName("to_fin_posted");

                entity.Property(e => e.ToPosted)
                    .HasColumnName("to_posted")
                    .HasComputedColumnSql("(case when [to_qty_posted]=(1) AND [to_fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.ToQtyPosted).HasColumnName("to_qty_posted");

                entity.Property(e => e.ValueFrom)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("value_from");

                entity.Property(e => e.ValueTo)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("value_to");

                entity.Property(e => e.ValueTransactionId).HasColumnName("value_transaction_id");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.MovementDetails)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_movement_details_inventory");

                entity.HasOne(d => d.Movement)
                    .WithMany(p => p.MovementDetails)
                    .HasForeignKey(d => d.MovementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_movement_items_movements");
            });

            modelBuilder.Entity<ObjectType>(entity =>
            {
                entity.ToTable("object_types", "app");

                entity.Property(e => e.ObjectTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("object_type_id");

                entity.Property(e => e.ObjectType1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("object_type");
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.ToTable("operations", "pos");

                entity.Property(e => e.OperationId)
                    .ValueGeneratedNever()
                    .HasColumnName("operation_id");

                entity.Property(e => e.ConsultantId).HasColumnName("consultant_id");

                entity.Property(e => e.FinPostedStarted)
                    .HasColumnName("fin_posted_started")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.OwnerId).HasColumnName("owner_id");

                entity.Property(e => e.PmtFinPosted)
                    .HasColumnName("pmt_fin_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Posted)
                    .HasColumnName("posted")
                    .HasComputedColumnSql("(case when [qty_posted]=(1) AND [stock_fin_posted]=(1) AND [sales_fin_posted]=(1) AND [pmt_fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.QtyPosted)
                    .HasColumnName("qty_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyPostedStarted)
                    .HasColumnName("qty_posted_started")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesFinPosted)
                    .HasColumnName("sales_fin_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ShopId).HasColumnName("shop_id");

                entity.Property(e => e.StockFinPosted)
                    .HasColumnName("stock_fin_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_operations_locations");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payments", "pos");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("payment_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.AmountIn)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("amount_in");

                entity.Property(e => e.AmountOut)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("amount_out");

                entity.Property(e => e.OperationId).HasColumnName("operation_id");

                entity.Property(e => e.PaymentTypeId).HasColumnName("payment_type_id");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.OperationId)
                    .HasConstraintName("FK_payments_operations");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK_payments_payment_types");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("payment_types", "pos");

                entity.Property(e => e.PaymentTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("payment_type_id");

                entity.Property(e => e.PaymentTypeName)
                    .HasMaxLength(50)
                    .HasColumnName("payment_type_name")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permissions", "usr");

                entity.Property(e => e.PermissionId)
                    .ValueGeneratedNever()
                    .HasColumnName("permission_id");

                entity.Property(e => e.PermissionCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("permission_code");

                entity.Property(e => e.PermissionGroupId).HasColumnName("permission_group_id");

                entity.Property(e => e.PermissionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("permission_name");

                entity.HasOne(d => d.PermissionGroup)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.PermissionGroupId)
                    .HasConstraintName("FK_permissions_permission_groups");
            });

            modelBuilder.Entity<PermissionCategory>(entity =>
            {
                entity.ToTable("permission_categories", "usr");

                entity.Property(e => e.PermissionCategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("permission_category_id");

                entity.Property(e => e.ModuleId).HasColumnName("module_id");

                entity.Property(e => e.PermissionCategory1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("permission_category");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.PermissionCategories)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK_permission_categories_modules");
            });

            modelBuilder.Entity<PermissionGroup>(entity =>
            {
                entity.ToTable("permission_groups", "usr");

                entity.Property(e => e.PermissionGroupId)
                    .ValueGeneratedNever()
                    .HasColumnName("permission_group_id");

                entity.Property(e => e.PermissionCategoryId).HasColumnName("permission_category_id");

                entity.Property(e => e.PermissionGroupCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("permission_group_code");

                entity.HasOne(d => d.PermissionCategory)
                    .WithMany(p => p.PermissionGroups)
                    .HasForeignKey(d => d.PermissionCategoryId)
                    .HasConstraintName("FK_permission_groups_permission_categories");
            });

            modelBuilder.Entity<PermissionObject>(entity =>
            {
                entity.ToTable("permission_objects", "app");

                entity.Property(e => e.PermissionObjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("permission_object_id");

                entity.Property(e => e.ComponentId).HasColumnName("component_id");

                entity.Property(e => e.ObjectName)
                    .HasMaxLength(10)
                    .HasColumnName("object_name")
                    .IsFixedLength(true);

                entity.Property(e => e.ObjectTypeId).HasColumnName("object_type_id");

                entity.Property(e => e.PermissionActionCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("permission_action_code");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.HasOne(d => d.Component)
                    .WithMany(p => p.PermissionObjects)
                    .HasForeignKey(d => d.ComponentId)
                    .HasConstraintName("FK_permission_objects_components");

                entity.HasOne(d => d.ObjectType)
                    .WithMany(p => p.PermissionObjects)
                    .HasForeignKey(d => d.ObjectTypeId)
                    .HasConstraintName("FK_permission_objects_object_types");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionObjects)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_permission_objects_permissions");
            });

            modelBuilder.Entity<Process>(entity =>
            {
                entity.ToTable("processes", "prd");

                entity.Property(e => e.ProcessId).HasColumnName("process_id");

                entity.Property(e => e.ProcessTypeId).HasColumnName("process_type_id");

                entity.HasOne(d => d.ProcessType)
                    .WithMany(p => p.Processes)
                    .HasForeignKey(d => d.ProcessTypeId)
                    .HasConstraintName("FK_processes_process_types");
            });

            modelBuilder.Entity<ProcessType>(entity =>
            {
                entity.ToTable("process_types", "prd");

                entity.Property(e => e.ProcessTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("process_type_id");

                entity.Property(e => e.ProcessType1)
                    .HasMaxLength(250)
                    .HasColumnName("process_type");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products", "pos");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.BarCode)
                    .HasMaxLength(50)
                    .HasColumnName("bar_code");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.ColorCodeId).HasColumnName("color_code_id");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.IsSingle).HasColumnName("is_single");

                entity.Property(e => e.IsWholeQuantity).HasColumnName("is_whole_quantity");

                entity.Property(e => e.ModelId).HasColumnName("model_id");

                entity.Property(e => e.ProductGroupId).HasColumnName("product_group_id");

                entity.Property(e => e.ProductLabelId).HasColumnName("product_label_id");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");

                entity.Property(e => e.ProductUnitId).HasColumnName("product_unit_id");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.StyleId).HasColumnName("style_id");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_products_brands");

                entity.HasOne(d => d.ColorCode)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ColorCodeId)
                    .HasConstraintName("FK_products_color_codes");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_products_colors");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_products_models");

                entity.HasOne(d => d.ProductGroup)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductGroupId)
                    .HasConstraintName("FK_products_product_groups");

                entity.HasOne(d => d.ProductLabel)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductLabelId)
                    .HasConstraintName("FK_products_product_labels");

                entity.HasOne(d => d.ProductUnit)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductUnitId)
                    .HasConstraintName("FK_products_product_units");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK_products_sizes");

                entity.HasOne(d => d.Style)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.StyleId)
                    .HasConstraintName("FK_products_styles");
            });

            modelBuilder.Entity<Product1>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_products_1");

                entity.ToTable("products", "pro");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.BarCode)
                    .HasMaxLength(50)
                    .HasColumnName("bar_code");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.IsSingle).HasColumnName("is_single");

                entity.Property(e => e.IsTangible).HasColumnName("is_tangible");

                entity.Property(e => e.IsWholeQuantity).HasColumnName("is_whole_quantity");

                entity.Property(e => e.ProductGroupId).HasColumnName("product_group_id");

                entity.Property(e => e.ProductLabelId).HasColumnName("product_label_id");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("product_name");

                entity.Property(e => e.ProductTemplateId).HasColumnName("product_template_id");

                entity.Property(e => e.ProductUnitId).HasColumnName("product_unit_id");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Product1s)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_products_brands");

                entity.HasOne(d => d.ProductGroup)
                    .WithMany(p => p.Product1s)
                    .HasForeignKey(d => d.ProductGroupId)
                    .HasConstraintName("FK_products_product_groups");

                entity.HasOne(d => d.ProductTemplate)
                    .WithMany(p => p.Product1s)
                    .HasForeignKey(d => d.ProductTemplateId)
                    .HasConstraintName("FK_products_product_template");

                entity.HasOne(d => d.ProductUnit)
                    .WithMany(p => p.Product1s)
                    .HasForeignKey(d => d.ProductUnitId)
                    .HasConstraintName("FK_products_product_units");
            });

            modelBuilder.Entity<ProductBrandFeature>(entity =>
            {
                entity.ToTable("product_brand_features", "pro");

                entity.Property(e => e.ProductBrandFeatureId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_brand_feature_id");

                entity.Property(e => e.BrandFeatureId).HasColumnName("brand_feature_id");

                entity.Property(e => e.BrandFeatureValueId)
                    .HasMaxLength(10)
                    .HasColumnName("brand_feature_value_id")
                    .IsFixedLength(true);

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductBrandFeatures)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_product_brand_features_products");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("product_categories", "pro");

                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");

                entity.Property(e => e.ProductCategory1)
                    .HasMaxLength(100)
                    .HasColumnName("product_category");

                entity.Property(e => e.ProductCategoryCode)
                    .HasMaxLength(100)
                    .HasColumnName("product_category_code");
            });

            modelBuilder.Entity<ProductCode>(entity =>
            {
                entity.ToTable("product_codes");

                entity.Property(e => e.ProductCodeId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_code_id");

                entity.Property(e => e.ProductCode1)
                    .HasMaxLength(50)
                    .HasColumnName("product_code");

                entity.Property(e => e.ProductId).HasColumnName("product_id");
            });

            modelBuilder.Entity<ProductFeature>(entity =>
            {
                entity.ToTable("product_features", "pro");

                entity.Property(e => e.ProductFeatureId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_feature_id");

                entity.Property(e => e.FeatureId).HasColumnName("feature_id");

                entity.Property(e => e.FeatureValueId).HasColumnName("feature_value_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.HasOne(d => d.FeatureValue)
                    .WithMany(p => p.ProductFeatures)
                    .HasForeignKey(d => d.FeatureValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_features_feature_values");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductFeatures)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_features_products");
            });

            modelBuilder.Entity<ProductGroup>(entity =>
            {
                entity.ToTable("product_groups", "pro");

                entity.Property(e => e.ProductGroupId).HasColumnName("product_group_id");

                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");

                entity.Property(e => e.ProductGroup1)
                    .HasMaxLength(50)
                    .HasColumnName("product_group");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.ProductGroups)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .HasConstraintName("FK_product_groups_product_categories");
            });

            modelBuilder.Entity<ProductLabel>(entity =>
            {
                entity.ToTable("product_labels", "pos");

                entity.Property(e => e.ProductLabelId).HasColumnName("product_label_id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.ProductLabel1)
                    .HasMaxLength(50)
                    .HasColumnName("product_label");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ProductLabels)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_product_labels_brands");
            });

            modelBuilder.Entity<ProductLabel1>(entity =>
            {
                entity.HasKey(e => e.ProductLabelId);

                entity.ToTable("product_labels", "pro");

                entity.Property(e => e.ProductLabelId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_label_id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductLabel)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("product_label");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductLabel1s)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_labels_products");
            });

            modelBuilder.Entity<ProductProcessor>(entity =>
            {
                entity.ToTable("product_processor", "pro");

                entity.Property(e => e.ProductProcessorId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_processor_id");

                entity.Property(e => e.IdentifyProducts).HasColumnName("identify_products");

                entity.Property(e => e.IdentifyProductsAfterRegistration).HasColumnName("identify_products_after_registration");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.Property(e => e.RegisterBrandProps).HasColumnName("register_brand_props");

                entity.Property(e => e.RegisterProducts).HasColumnName("register_products");

                entity.Property(e => e.RegisterPurchaseDetails).HasColumnName("register_purchase_details");

                entity.Property(e => e.RegisterSalesPrices).HasColumnName("register_sales_prices");
            });

            modelBuilder.Entity<ProductProcessorDetail>(entity =>
            {
                entity.ToTable("product_processor_details", "pro");

                entity.Property(e => e.ProductProcessorDetailId).HasColumnName("product_processor_detail_id");

                entity.Property(e => e.BarCode)
                    .HasMaxLength(50)
                    .HasColumnName("bar_code");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.BrandIdDictionary)
                    .HasMaxLength(10)
                    .HasColumnName("brand_id_dictionary")
                    .IsFixedLength(true);

                entity.Property(e => e.BrandName)
                    .HasMaxLength(50)
                    .HasColumnName("brand_name");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cost");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.ProductGroup)
                    .HasMaxLength(50)
                    .HasColumnName("product_group");

                entity.Property(e => e.ProductGroupId).HasColumnName("product_group_id");

                entity.Property(e => e.ProductGroupIdDictionary).HasColumnName("product_group_id_dictionary");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductLabel)
                    .HasMaxLength(200)
                    .HasColumnName("product_label");

                entity.Property(e => e.ProductLabelId).HasColumnName("product_label_id");

                entity.Property(e => e.ProductLabelIdDictionary).HasColumnName("product_label_id_dictionary");

                entity.Property(e => e.ProductProcessorId).HasColumnName("product_processor_id");

                entity.Property(e => e.ProductTemplateCode)
                    .HasMaxLength(50)
                    .HasColumnName("product_template_code");

                entity.Property(e => e.ProductTemplateId).HasColumnName("product_template_id");

                entity.Property(e => e.ProductTemplateIdDictionary).HasColumnName("product_template_id_dictionary");

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("qty");

                entity.Property(e => e.SalesPrice1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("sales_price1");

                entity.Property(e => e.SalesPrice2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("sales_price2");

                entity.Property(e => e.SalesPrice3)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("sales_price3");

                entity.Property(e => e.SalesPrice4)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("sales_price4");

                entity.Property(e => e.SalesPrice5)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("sales_price5");

                entity.Property(e => e.SalesSchemaId1).HasColumnName("sales_schema_id1");

                entity.Property(e => e.SalesSchemaId2).HasColumnName("sales_schema_id2");

                entity.Property(e => e.SalesSchemaId3).HasColumnName("sales_schema_id3");

                entity.Property(e => e.SalesSchemaId4).HasColumnName("sales_schema_id4");

                entity.Property(e => e.SalesSchemaId5).HasColumnName("sales_schema_id5");

                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("version");

                entity.HasOne(d => d.ProductProcessor)
                    .WithMany(p => p.ProductProcessorDetails)
                    .HasForeignKey(d => d.ProductProcessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_processor_details_product_processor");
            });

            modelBuilder.Entity<ProductProcessorDetailBak>(entity =>
            {
                entity.ToTable("product_processor_detail_BAK", "pro");

                entity.Property(e => e.ProductProcessorDetailBakId).HasColumnName("product_processor_detail_BAK_id");

                entity.Property(e => e.BarCode)
                    .HasMaxLength(50)
                    .HasColumnName("bar_code");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.BrandIdDictionary)
                    .HasMaxLength(10)
                    .HasColumnName("brand_id_dictionary")
                    .IsFixedLength(true);

                entity.Property(e => e.BrandName)
                    .HasMaxLength(50)
                    .HasColumnName("brand_name");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .HasColumnName("color");

                entity.Property(e => e.ColorCode)
                    .HasMaxLength(50)
                    .HasColumnName("color_code");

                entity.Property(e => e.ColorCodeId).HasColumnName("color_code_id");

                entity.Property(e => e.ColorCodeIdDictionary).HasColumnName("color_code_id_dictionary");

                entity.Property(e => e.ColorId).HasColumnName("color_id");

                entity.Property(e => e.ColorIdDictionary).HasColumnName("color_id_dictionary");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cost");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .HasColumnName("model");

                entity.Property(e => e.ModelId).HasColumnName("model_id");

                entity.Property(e => e.ModelIdDictionary).HasColumnName("model_id_dictionary");

                entity.Property(e => e.ProductGroup)
                    .HasMaxLength(50)
                    .HasColumnName("product_group");

                entity.Property(e => e.ProductGroupId).HasColumnName("product_group_id");

                entity.Property(e => e.ProductGroupIdDictionary).HasColumnName("product_group_id_dictionary");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductLabel)
                    .HasMaxLength(50)
                    .HasColumnName("product_label");

                entity.Property(e => e.ProductLabelId).HasColumnName("product_label_id");

                entity.Property(e => e.ProductLabelIdDictionary).HasColumnName("product_label_id_dictionary");

                entity.Property(e => e.ProductProcessorId).HasColumnName("product_processor_id");

                entity.Property(e => e.ProductUnit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product_unit");

                entity.Property(e => e.ProductUnitId).HasColumnName("product_unit_id");

                entity.Property(e => e.ProductUnitIdDictionary).HasColumnName("product_unit_id_dictionary");

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("qty");

                entity.Property(e => e.SalesPrice1)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("sales_price1");

                entity.Property(e => e.SalesPrice2)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("sales_price2");

                entity.Property(e => e.SalesPrice3)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("sales_price3");

                entity.Property(e => e.SalesPrice4)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("sales_price4");

                entity.Property(e => e.SalesPrice5)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("sales_price5");

                entity.Property(e => e.Size)
                    .HasMaxLength(50)
                    .HasColumnName("size");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.SizeIdDictionary).HasColumnName("size_id_dictionary");

                entity.Property(e => e.Style)
                    .HasMaxLength(50)
                    .HasColumnName("style");

                entity.Property(e => e.StyleId).HasColumnName("style_id");

                entity.Property(e => e.StyleIdDictionary).HasColumnName("style_id_dictionary");

                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("version");
            });

            modelBuilder.Entity<ProductProcessorProductBrandFeature>(entity =>
            {
                entity.ToTable("product_processor_product_brand_features", "pro");

                entity.Property(e => e.ProductProcessorProductBrandFeatureId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_processor_product_brand_feature_id");

                entity.Property(e => e.BrandFeatureCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("brand_feature_code");

                entity.Property(e => e.BrandFeatureId).HasColumnName("brand_feature_id");

                entity.Property(e => e.BrandFeatureValue)
                    .HasMaxLength(1000)
                    .HasColumnName("brand_feature_value");

                entity.Property(e => e.BrandFeatureValueId).HasColumnName("brand_feature_value_id");

                entity.Property(e => e.BrandFeatureValueIdDictionary).HasColumnName("brand_feature_value_id_dictionary");

                entity.Property(e => e.ProductProcessorDetailId).HasColumnName("product_processor_detail_id");

                entity.HasOne(d => d.ProductProcessorDetail)
                    .WithMany(p => p.ProductProcessorProductBrandFeatures)
                    .HasForeignKey(d => d.ProductProcessorDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchase_draft_product_brand_features_product_processor_details");
            });

            modelBuilder.Entity<ProductProcessorProductFeature>(entity =>
            {
                entity.ToTable("product_processor_product_features", "pro");

                entity.Property(e => e.ProductProcessorProductFeatureId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_processor_product_feature_id");

                entity.Property(e => e.FeatureCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("feature_code");

                entity.Property(e => e.FeatureId).HasColumnName("feature_id");

                entity.Property(e => e.FeatureValue)
                    .HasMaxLength(1000)
                    .HasColumnName("feature_value");

                entity.Property(e => e.FeatureValueId).HasColumnName("feature_value_id");

                entity.Property(e => e.FeatureValueIdDictionary).HasColumnName("feature_value_id_dictionary");

                entity.Property(e => e.ProductProcessorDetailId).HasColumnName("product_processor_detail_id");

                entity.HasOne(d => d.ProductProcessorDetail)
                    .WithMany(p => p.ProductProcessorProductFeatures)
                    .HasForeignKey(d => d.ProductProcessorDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchase_draft_product_features_product_processor_details");
            });

            modelBuilder.Entity<ProductTemplate>(entity =>
            {
                entity.ToTable("product_templates", "pro");

                entity.Property(e => e.ProductTemplateId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_template_id");

                entity.Property(e => e.IsSingle).HasColumnName("is_single");

                entity.Property(e => e.IsTangible).HasColumnName("is_tangible");

                entity.Property(e => e.IsWholeQuantity).HasColumnName("is_whole_quantity");

                entity.Property(e => e.ProductTemplateCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product_template_code");

                entity.Property(e => e.ProductTemplateName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("product_template_name");

                entity.Property(e => e.ProductUnitId).HasColumnName("product_unit_id");

                entity.HasOne(d => d.ProductUnit)
                    .WithMany(p => p.ProductTemplates)
                    .HasForeignKey(d => d.ProductUnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_template_product_units");
            });

            modelBuilder.Entity<ProductTemplateBrandFeature>(entity =>
            {
                entity.ToTable("product_template_brand_features", "pro");

                entity.Property(e => e.ProductTemplateBrandFeatureId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_template_brand_feature_id");

                entity.Property(e => e.BrandFeatureId).HasColumnName("brand_feature_id");

                entity.Property(e => e.IsMandatory).HasColumnName("is_mandatory");

                entity.Property(e => e.ProductTemplateId).HasColumnName("product_template_id");

                entity.HasOne(d => d.ProductTemplate)
                    .WithMany(p => p.ProductTemplateBrandFeatures)
                    .HasForeignKey(d => d.ProductTemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_template_brand_features_product_template");
            });

            modelBuilder.Entity<ProductTemplateFeature>(entity =>
            {
                entity.ToTable("product_template_features", "pro");

                entity.Property(e => e.ProductTemplateFeatureId)
                    .ValueGeneratedNever()
                    .HasColumnName("product_template_feature_id");

                entity.Property(e => e.FeatureId).HasColumnName("feature_id");

                entity.Property(e => e.IsMandatory).HasColumnName("is_mandatory");

                entity.Property(e => e.ProductTemplateId).HasColumnName("product_template_id");

                entity.HasOne(d => d.Feature)
                    .WithMany(p => p.ProductTemplateFeatures)
                    .HasForeignKey(d => d.FeatureId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_template_features_features");

                entity.HasOne(d => d.ProductTemplate)
                    .WithMany(p => p.ProductTemplateFeatures)
                    .HasForeignKey(d => d.ProductTemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_product_template_features_product_template");
            });

            modelBuilder.Entity<ProductUnit>(entity =>
            {
                entity.ToTable("product_units", "pro");

                entity.Property(e => e.ProductUnitId).HasColumnName("product_unit_id");

                entity.Property(e => e.ProductUnit1)
                    .HasMaxLength(50)
                    .HasColumnName("product_unit");
            });

            modelBuilder.Entity<Production>(entity =>
            {
                entity.ToTable("production", "prd");

                entity.Property(e => e.ProductionId).HasColumnName("production_id");

                entity.Property(e => e.Decsrip)
                    .HasMaxLength(50)
                    .HasColumnName("decsrip");

                entity.Property(e => e.FinPosted).HasColumnName("fin_posted");

                entity.Property(e => e.InFinPosted).HasColumnName("in_fin_posted");

                entity.Property(e => e.InFinPostedStarted).HasColumnName("in_fin_posted_started");

                entity.Property(e => e.InPosted)
                    .HasColumnName("in_posted")
                    .HasComputedColumnSql("(case when [in_qty_posted]=(1) AND [in_fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.InQtyPosted).HasColumnName("in_qty_posted");

                entity.Property(e => e.InQtyPostedStarted).HasColumnName("in_qty_posted_started");

                entity.Property(e => e.InTransDate)
                    .HasColumnType("date")
                    .HasColumnName("in_trans_date");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.OutFinPosted).HasColumnName("out_fin_posted");

                entity.Property(e => e.OutFinPostedStarted).HasColumnName("out_fin_posted_started");

                entity.Property(e => e.OutPosted)
                    .HasColumnName("out_posted")
                    .HasComputedColumnSql("(case when [out_qty_posted]=(1) AND [out_fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.OutQtyPosted).HasColumnName("out_qty_posted");

                entity.Property(e => e.OutQtyPostedStarted).HasColumnName("out_qty_posted_started");

                entity.Property(e => e.OutTransDate)
                    .HasColumnType("date")
                    .HasColumnName("out_trans_date");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.ProcessId).HasColumnName("process_id");

                entity.Property(e => e.ProductionTypeId).HasColumnName("production_type_id");

                entity.Property(e => e.QtyPosted).HasColumnName("qty_posted");

                entity.Property(e => e.TemplateId).HasColumnName("template_id");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");

                entity.HasOne(d => d.Process)
                    .WithMany(p => p.Productions)
                    .HasForeignKey(d => d.ProcessId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_production_processes");

                entity.HasOne(d => d.ProductionType)
                    .WithMany(p => p.Productions)
                    .HasForeignKey(d => d.ProductionTypeId)
                    .HasConstraintName("FK_production_production_type");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.Productions)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_production_template");
            });

            modelBuilder.Entity<ProductionIn>(entity =>
            {
                entity.ToTable("production_in", "prd");

                entity.Property(e => e.ProductionInId)
                    .ValueGeneratedNever()
                    .HasColumnName("production_in_id");

                entity.Property(e => e.FinPosted).HasColumnName("fin_posted");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.ProductionId).HasColumnName("production_id");

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty");

                entity.Property(e => e.QtyPosted).HasColumnName("qty_posted");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("value");

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.ProductionIns)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_production_in_production");
            });

            modelBuilder.Entity<ProductionInStd>(entity =>
            {
                entity.ToTable("production_in_std", "prd");

                entity.Property(e => e.ProductionInStdId)
                    .ValueGeneratedNever()
                    .HasColumnName("production_in_std_id");

                entity.Property(e => e.DateShift).HasColumnName("date_shift");

                entity.Property(e => e.FinPosted).HasColumnName("fin_posted");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductionId).HasColumnName("production_id");

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty");

                entity.Property(e => e.QtyPosted).HasColumnName("qty_posted");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("value");

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.ProductionInStds)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_production_in_std_production");
            });

            modelBuilder.Entity<ProductionOut>(entity =>
            {
                entity.ToTable("production_out", "prd");

                entity.Property(e => e.ProductionOutId)
                    .ValueGeneratedNever()
                    .HasColumnName("production_out_id");

                entity.Property(e => e.FinPosted).HasColumnName("fin_posted");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.ProductionId).HasColumnName("production_id");

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty");

                entity.Property(e => e.QtyPosted).HasColumnName("qty_posted");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("value");

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.ProductionOuts)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_production_out_production");
            });

            modelBuilder.Entity<ProductionOutStd>(entity =>
            {
                entity.ToTable("production_out_std", "prd");

                entity.Property(e => e.ProductionOutStdId)
                    .ValueGeneratedNever()
                    .HasColumnName("production_out_std_id");

                entity.Property(e => e.DateShift).HasColumnName("date_shift");

                entity.Property(e => e.FinPosted).HasColumnName("fin_posted");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProductionId).HasColumnName("production_id");

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty");

                entity.Property(e => e.QtyPosted).HasColumnName("qty_posted");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("value");

                entity.Property(e => e.ValuePercentage)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("value_percentage");

                entity.HasOne(d => d.Production)
                    .WithMany(p => p.ProductionOutStds)
                    .HasForeignKey(d => d.ProductionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_production_out_std_production");
            });

            modelBuilder.Entity<ProductionType>(entity =>
            {
                entity.ToTable("production_type", "prd");

                entity.Property(e => e.ProductionTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("production_type_id");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.ProductionTypeName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("production_type_name");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("projects", "cr");

                entity.Property(e => e.ProjectId)
                    .ValueGeneratedNever()
                    .HasColumnName("project_id");

                entity.Property(e => e.ProjectCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("project_code");

                entity.Property(e => e.ProjectDescrip)
                    .HasMaxLength(4000)
                    .HasColumnName("project_descrip");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(200)
                    .HasColumnName("project_name");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("purchases", "prc");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.Property(e => e.AllocStarted).HasColumnName("alloc_started");

                entity.Property(e => e.Allocated).HasColumnName("allocated");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");

                entity.Property(e => e.EntryDate)
                    .HasColumnType("datetime")
                    .HasColumnName("entry_date");

                entity.Property(e => e.FinPosted)
                    .HasColumnName("fin_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FinPostedStarted)
                    .HasColumnName("fin_posted_started")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoiceNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("invoice_number")
                    .UseCollation("Latin1_General_100_BIN");

                entity.Property(e => e.Note)
                    .HasMaxLength(2000)
                    .HasColumnName("note");

                entity.Property(e => e.Posted)
                    .HasColumnName("posted")
                    .HasComputedColumnSql("(case when [qty_posted]=(1) AND [fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.ProcInInventory).HasColumnName("proc_in_inventory");

                entity.Property(e => e.PurchaseName)
                    .HasMaxLength(50)
                    .HasColumnName("purchase_name");

                entity.Property(e => e.PurchaseStatusId)
                    .HasColumnName("purchase_status_id")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyPosted)
                    .HasColumnName("qty_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyPostedStarted)
                    .HasColumnName("qty_posted_started")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TotalAllocCost)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("total_alloc_cost");

                entity.Property(e => e.TotalCostInvoiced)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total_cost_invoiced");

                entity.Property(e => e.TotalCostInvoicedEqu)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total_cost_invoiced_equ");

                entity.Property(e => e.TotalFinalCostEqu)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total_final_cost_equ");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");

                entity.Property(e => e.Xrate)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("xrate");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchases_suppliers");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchases_companies");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchases_currencies");

                entity.HasOne(d => d.PurchaseStatus)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.PurchaseStatusId)
                    .HasConstraintName("FK_purchases_purchase_statuses");
            });

            modelBuilder.Entity<PurchaseAddCost>(entity =>
            {
                entity.ToTable("purchase_add_costs", "prc");

                entity.Property(e => e.PurchaseAddCostId).HasColumnName("purchase_add_cost_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.Currency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("currency")
                    .UseCollation("Latin1_General_100_BIN");

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(50)
                    .HasColumnName("invoice_number")
                    .UseCollation("Latin1_General_100_BIN");

                entity.Property(e => e.PurchaseAddCostTypeId).HasColumnName("purchase_add_cost_type_id");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("version");

                entity.Property(e => e.Xrate)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("xrate");

                entity.HasOne(d => d.PurchaseAddCostType)
                    .WithMany(p => p.PurchaseAddCosts)
                    .HasForeignKey(d => d.PurchaseAddCostTypeId)
                    .HasConstraintName("FK_purchase_add_costs_purchase_add_cost_types");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseAddCosts)
                    .HasForeignKey(d => d.PurchaseId)
                    .HasConstraintName("FK_purchase_add_costs_purchases");
            });

            modelBuilder.Entity<PurchaseAddCostType>(entity =>
            {
                entity.ToTable("purchase_add_cost_types", "prc");

                entity.Property(e => e.PurchaseAddCostTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("purchase_add_cost_type_id");

                entity.Property(e => e.Allocate).HasColumnName("allocate");

                entity.Property(e => e.PurchaseAddCostType1)
                    .HasMaxLength(50)
                    .HasColumnName("purchase_add_cost_type")
                    .UseCollation("Latin1_General_100_BIN");
            });

            modelBuilder.Entity<PurchaseAllocation>(entity =>
            {
                entity.ToTable("purchase_allocation", "prc");

                entity.Property(e => e.PurchaseAllocationId).HasColumnName("purchase_allocation_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.PostedStarted).HasColumnName("posted_started");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");
            });

            modelBuilder.Entity<PurchaseCount>(entity =>
            {
                entity.ToTable("purchase_count", "prc");

                entity.Property(e => e.PurchaseCountId)
                    .ValueGeneratedNever()
                    .HasColumnName("purchase_count_id");

                entity.Property(e => e.BarCode)
                    .HasMaxLength(50)
                    .HasColumnName("bar_code")
                    .UseCollation("Latin1_General_100_BIN");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty");

                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("version");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseCounts)
                    .HasForeignKey(d => d.PurchaseId)
                    .HasConstraintName("FK_purchase_count_purchases");
            });

            modelBuilder.Entity<PurchaseDetail>(entity =>
            {
                entity.ToTable("purchase_details", "prc");

                entity.Property(e => e.PurchaseDetailId).HasColumnName("purchase_detail_id");

                entity.Property(e => e.AddCost)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("add_cost");

                entity.Property(e => e.Allocated).HasColumnName("allocated");

                entity.Property(e => e.CostCalced)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cost_calced");

                entity.Property(e => e.CostCalcedEqu)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cost_calced_equ");

                entity.Property(e => e.CostInvoiced)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cost_invoiced");

                entity.Property(e => e.CostInvoicedEqu)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cost_invoiced_equ");

                entity.Property(e => e.CostInvoicedWoVat)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cost_invoiced_wo_vat");

                entity.Property(e => e.FinPosted).HasColumnName("fin_posted");

                entity.Property(e => e.FinalCost)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("final_cost");

                entity.Property(e => e.GlAccountId).HasColumnName("gl_account_id");

                entity.Property(e => e.InventoryCode)
                    .HasMaxLength(30)
                    .HasColumnName("inventory_code");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Posted)
                    .HasColumnName("posted")
                    .HasComputedColumnSql("(case when [qty_posted]=(1) AND [fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.PurchaseAllocationId).HasColumnName("purchase_allocation_id");

                entity.Property(e => e.PurchaseDetailPostTypeId).HasColumnName("purchase_detail_post_type_id");

                entity.Property(e => e.PurchaseDraftId).HasColumnName("purchase_draft_id");

                entity.Property(e => e.PurchaseDraftVersion)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("purchase_draft_version")
                    .UseCollation("Latin1_General_100_BIN");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.Property(e => e.QtyCalced)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty_calced");

                entity.Property(e => e.QtyInvoiced)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty_invoiced");

                entity.Property(e => e.QtyPosted).HasColumnName("qty_posted");

                entity.Property(e => e.VatInvoiced)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vat_invoiced");

                entity.Property(e => e.Version)
                    .IsRowVersion()
                    .IsConcurrencyToken()
                    .HasColumnName("version");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_purchase_details_inventory");

                entity.HasOne(d => d.PurchaseAllocation)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.PurchaseAllocationId)
                    .HasConstraintName("FK_purchase_details_purchase_allocation");

                entity.HasOne(d => d.PurchaseDetailPostType)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.PurchaseDetailPostTypeId)
                    .HasConstraintName("FK_purchase_details_purchase_detail_post_types");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchaseDetails)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchase_details_purchases");
            });

            modelBuilder.Entity<PurchaseDetailPostType>(entity =>
            {
                entity.ToTable("purchase_detail_post_types", "prc");

                entity.Property(e => e.PurchaseDetailPostTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("purchase_detail_post_type_id");

                entity.Property(e => e.PurchaseDetailPostType1)
                    .HasMaxLength(50)
                    .HasColumnName("purchase_detail_post_type");
            });

            modelBuilder.Entity<PurchasePayment>(entity =>
            {
                entity.ToTable("purchase_payments", "prc");

                entity.Property(e => e.PurchasePaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("purchase_payment_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.BankTransactionId).HasColumnName("bank_transaction_id");

                entity.Property(e => e.CashTransactionId).HasColumnName("cash_transaction_id");

                entity.Property(e => e.FinAccountId).HasColumnName("fin_account_id");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.PurchaseId).HasColumnName("purchase_id");

                entity.Property(e => e.PurchasePaymentTypeId).HasColumnName("purchase_payment_type_id");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");

                entity.HasOne(d => d.Purchase)
                    .WithMany(p => p.PurchasePayments)
                    .HasForeignKey(d => d.PurchaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_purchase_payments_purchases");
            });

            modelBuilder.Entity<PurchaseReturn>(entity =>
            {
                entity.ToTable("purchase_returns");

                entity.Property(e => e.PurchaseReturnId).HasColumnName("purchase_return_id");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");
            });

            modelBuilder.Entity<PurchaseStatus>(entity =>
            {
                entity.ToTable("purchase_statuses", "prc");

                entity.Property(e => e.PurchaseStatusId).HasColumnName("purchase_status_id");

                entity.Property(e => e.PurchaseStatus1)
                    .HasMaxLength(50)
                    .HasColumnName("purchase_status")
                    .UseCollation("Latin1_General_100_BIN");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sales", "pos");

                entity.Property(e => e.SaleId)
                    .ValueGeneratedNever()
                    .HasColumnName("sale_id");

                entity.Property(e => e.AccountBalanceId).HasColumnName("account_balance_id");

                entity.Property(e => e.AccountBalanceIdTimestamp)
                    .HasMaxLength(8)
                    .HasColumnName("account_balance_id_timestamp");

                entity.Property(e => e.CogsPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("cogs_price");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.NominalPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("nominal_price");

                entity.Property(e => e.NominalPriceDiscount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("nominal_price_discount");

                entity.Property(e => e.OperationId).HasColumnName("operation_id");

                entity.Property(e => e.ParentSalesId).HasColumnName("parent_sales_id");

                entity.Property(e => e.Posted)
                    .HasColumnName("posted")
                    .HasComputedColumnSql("(case when [qty_posted]=(1) AND [sales_fin_posted]=(1) AND [stock_fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty");

                entity.Property(e => e.QtyPosted).HasColumnName("qty_posted");

                entity.Property(e => e.QtyTransactionId).HasColumnName("qty_transaction_id");

                entity.Property(e => e.Revenue)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("revenue");

                entity.Property(e => e.SalesFinPosted)
                    .HasColumnName("sales_fin_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.SalesPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("sales_price");

                entity.Property(e => e.SchemaPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("schema_price");

                entity.Property(e => e.StockFinPosted).HasColumnName("stock_fin_posted");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("total_price");

                entity.Property(e => e.UndefinedLocation).HasColumnName("undefined_location");

                entity.Property(e => e.ValueTransactionId).HasColumnName("value_transaction_id");

                entity.Property(e => e.VatAmount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("vat_amount");

                entity.Property(e => e.VatRate)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("vat_rate");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_sales_inventory");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.OperationId)
                    .HasConstraintName("FK_sales_operations");
            });

            modelBuilder.Entity<SalesSchema>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sales_schema", "ERP");

                entity.Property(e => e.OldSalesSchemaId).HasColumnName("old_sales_schema_id");

                entity.Property(e => e.SalesSchemaId).HasColumnName("sales_schema_id");
            });

            modelBuilder.Entity<SalesSchema1>(entity =>
            {
                entity.HasKey(e => e.SalesSchemaId);

                entity.ToTable("sales_schemas", "pos");

                entity.Property(e => e.SalesSchemaId)
                    .ValueGeneratedNever()
                    .HasColumnName("sales_schema_id");

                entity.Property(e => e.SalesSchemaName)
                    .HasMaxLength(50)
                    .HasColumnName("sales_schema_name")
                    .UseCollation("Latin1_General_100_BIN");
            });

            modelBuilder.Entity<SalesSchemaDetail>(entity =>
            {
                entity.ToTable("sales_schema_details", "pos");

                entity.Property(e => e.SalesSchemaDetailId)
                    .ValueGeneratedNever()
                    .HasColumnName("sales_schema_detail_id");

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("change_date");

                entity.Property(e => e.Discount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("discount");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.SalesSchemaId).HasColumnName("sales_schema_id");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("unit_price");

                entity.Property(e => e.UnitPriceAd)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("unit_price_ad");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SalesSchemaDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_sales_schema_details_products");

                entity.HasOne(d => d.SalesSchema)
                    .WithMany(p => p.SalesSchemaDetails)
                    .HasForeignKey(d => d.SalesSchemaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sales_schema_details_sales_schemas");
            });

            modelBuilder.Entity<Sequence>(entity =>
            {
                entity.HasKey(e => e.SequenceCode)
                    .HasName("PK__sequence__E14D0FD70E071B8B");

                entity.ToTable("sequences", "test");

                entity.Property(e => e.SequenceCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sequence_code");

                entity.Property(e => e.Sequence1).HasColumnName("sequence");
            });

            modelBuilder.Entity<Shelf>(entity =>
            {
                entity.ToTable("shelfs", "pos");

                entity.Property(e => e.ShelfId)
                    .ValueGeneratedNever()
                    .HasColumnName("shelf_id");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.ShelfCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("shelf_code")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ShelfDescription)
                    .HasMaxLength(50)
                    .HasColumnName("shelf_description")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Shelves)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_shelfs_locations");
            });

            modelBuilder.Entity<ShopEmployee>(entity =>
            {
                entity.HasKey(e => e.ShopEmpoyeeId);

                entity.ToTable("shop_employees", "pos");

                entity.Property(e => e.ShopEmpoyeeId)
                    .ValueGeneratedNever()
                    .HasColumnName("shop_empoyee_id");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");

                entity.Property(e => e.ShopId).HasColumnName("shop_id");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ShopEmployees)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_shop_employees_employees");

                entity.HasOne(d => d.Shop)
                    .WithMany(p => p.ShopEmployees)
                    .HasForeignKey(d => d.ShopId)
                    .HasConstraintName("FK_shop_employees_locations");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("sizes", "pos");

                entity.Property(e => e.SizeId).HasColumnName("size_id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.Size1)
                    .HasMaxLength(50)
                    .HasColumnName("size");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Sizes)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_sizes_brands");
            });

            modelBuilder.Entity<StockCount>(entity =>
            {
                entity.ToTable("stock_count", "inv");

                entity.Property(e => e.StockCountId).HasColumnName("stock_count_id");

                entity.Property(e => e.FinPosted)
                    .HasColumnName("fin_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FinPostedStarted).HasColumnName("fin_posted_started");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Posted)
                    .HasColumnName("posted")
                    .HasComputedColumnSql("(case when [qty_posted]=(1) AND [fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.QtyPosted)
                    .HasColumnName("qty_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyPostedStarted).HasColumnName("qty_posted_started");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");
            });

            modelBuilder.Entity<StockCountDetail>(entity =>
            {
                entity.ToTable("stock_count_details", "inv");

                entity.Property(e => e.StockCountDetailId).HasColumnName("stock_count_detail_id");

                entity.Property(e => e.FinPosted)
                    .HasColumnName("fin_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.Posted)
                    .HasColumnName("posted")
                    .HasComputedColumnSql("(case when [qty_posted]=(1) AND [fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty");

                entity.Property(e => e.QtyPosted)
                    .HasColumnName("qty_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyTransactionId).HasColumnName("qty_transaction_id");

                entity.Property(e => e.StockCountId).HasColumnName("stock_count_id");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("value");

                entity.Property(e => e.ValueTransactionId).HasColumnName("value_transaction_id");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.StockCountDetails)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_stock_count_details_inventory");

                entity.HasOne(d => d.StockCount)
                    .WithMany(p => p.StockCountDetails)
                    .HasForeignKey(d => d.StockCountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stock_count_details_stock_count");
            });

            modelBuilder.Entity<StockWriteoff>(entity =>
            {
                entity.ToTable("stock_writeoff", "inv");

                entity.Property(e => e.StockWriteoffId).HasColumnName("stock_writeoff_id");

                entity.Property(e => e.FinPosted)
                    .HasColumnName("fin_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FinPostedStarted).HasColumnName("fin_posted_started");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.Posted)
                    .HasColumnName("posted")
                    .HasComputedColumnSql("(case when [qty_posted]=(1) AND [fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.QtyPosted)
                    .HasColumnName("qty_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyPostedStarted).HasColumnName("qty_posted_started");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");
            });

            modelBuilder.Entity<StockWriteoffDetail>(entity =>
            {
                entity.ToTable("stock_writeoff_details", "inv");

                entity.Property(e => e.StockWriteoffDetailId).HasColumnName("stock_writeoff_detail_id");

                entity.Property(e => e.FinPosted)
                    .HasColumnName("fin_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InventoryId).HasColumnName("inventory_id");

                entity.Property(e => e.Posted)
                    .HasColumnName("posted")
                    .HasComputedColumnSql("(case when [qty_posted]=(1) AND [fin_posted]=(1) then (1) else (0) end)", false);

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty");

                entity.Property(e => e.QtyPosted)
                    .HasColumnName("qty_posted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QtyTransactionId).HasColumnName("qty_transaction_id");

                entity.Property(e => e.StockWriteoffId).HasColumnName("stock_writeoff_id");

                entity.Property(e => e.Value)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("value");

                entity.Property(e => e.ValueTransactionId).HasColumnName("value_transaction_id");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.StockWriteoffDetails)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("FK_stock_writeoff_details_inventory");

                entity.HasOne(d => d.StockWriteoff)
                    .WithMany(p => p.StockWriteoffDetails)
                    .HasForeignKey(d => d.StockWriteoffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_stock_writeoff_details_stock_writeoff");
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.ToTable("styles", "pos");

                entity.Property(e => e.StyleId).HasColumnName("style_id");

                entity.Property(e => e.BrandId).HasColumnName("brand_id");

                entity.Property(e => e.Style1)
                    .HasMaxLength(50)
                    .HasColumnName("style");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Styles)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_styles_brands");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("supplier", "ERP");

                entity.Property(e => e.OldSupplierId).HasColumnName("old_supplier_id");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            });

            modelBuilder.Entity<Supplier1>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.ToTable("suppliers", "pos");

                entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(50)
                    .HasColumnName("contact_person")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.DefaultBrandId).HasColumnName("default_brand_id");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(50)
                    .HasColumnName("supplier_name")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.ToTable("template", "prd");

                entity.Property(e => e.TemplateId)
                    .ValueGeneratedNever()
                    .HasColumnName("template_id");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.ProductionTypeId).HasColumnName("production_type_id");

                entity.Property(e => e.TemplateName)
                    .HasMaxLength(50)
                    .HasColumnName("template_name");
            });

            modelBuilder.Entity<TemplateIn>(entity =>
            {
                entity.ToTable("template_in", "prd");

                entity.Property(e => e.TemplateInId)
                    .ValueGeneratedNever()
                    .HasColumnName("template_in_id");

                entity.Property(e => e.FinPosted).HasColumnName("fin_posted");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty");

                entity.Property(e => e.QtyPosted).HasColumnName("qty_posted");

                entity.Property(e => e.TemplateId).HasColumnName("template_id");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.TemplateIns)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_template_in_template");
            });

            modelBuilder.Entity<TemplateOut>(entity =>
            {
                entity.ToTable("template_out", "prd");

                entity.Property(e => e.TemplateOutId)
                    .ValueGeneratedNever()
                    .HasColumnName("template_out_id");

                entity.Property(e => e.DateShift).HasColumnName("date_shift");

                entity.Property(e => e.FinPosted).HasColumnName("fin_posted");

                entity.Property(e => e.Posted).HasColumnName("posted");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Qty)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("qty");

                entity.Property(e => e.QtyPosted).HasColumnName("qty_posted");

                entity.Property(e => e.TemplateId).HasColumnName("template_id");

                entity.Property(e => e.ValuePercentage)
                    .HasColumnType("decimal(18, 6)")
                    .HasColumnName("value_percentage");

                entity.HasOne(d => d.Template)
                    .WithMany(p => p.TemplateOuts)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_template_out_template");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transactions", "acc");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.AccountTranSeq).HasColumnName("account_tran_seq");

                entity.Property(e => e.Balance)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("balance")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Decrease)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("decrease");

                entity.Property(e => e.Eod).HasColumnName("eod");

                entity.Property(e => e.Increase)
                    .HasColumnType("decimal(18, 8)")
                    .HasColumnName("increase");

                entity.Property(e => e.PostOrderRefId).HasColumnName("post_order_ref_id");

                entity.Property(e => e.PostTime)
                    .HasColumnType("datetime")
                    .HasColumnName("post_time")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RefVersion)
                    .HasMaxLength(8)
                    .HasColumnName("ref_version");

                entity.Property(e => e.ReferenceEntityId).HasColumnName("reference_entity_id");

                entity.Property(e => e.ReferenceId).HasColumnName("reference_id");

                entity.Property(e => e.SubReferenceEntityId).HasColumnName("sub_reference_entity_id");

                entity.Property(e => e.SubReferenceId).HasColumnName("sub_reference_id");

                entity.Property(e => e.TransDate)
                    .HasColumnType("datetime")
                    .HasColumnName("trans_date");

                entity.HasOne(d => d.PostOrderRef)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.PostOrderRefId)
                    .HasConstraintName("FK_transactions_transaction_orders");
            });

            modelBuilder.Entity<Transaction1>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("PK__transact__85C600AF7187CF4E");

                entity.ToTable("transactions", "gl");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .HasColumnName("description");

                entity.Property(e => e.TransDate)
                    .HasColumnType("datetime")
                    .HasColumnName("trans_date");
            });

            modelBuilder.Entity<TransactionDetail>(entity =>
            {
                entity.HasKey(e => e.TransactionDetail1)
                    .HasName("PK__transact__2C6DCA3475586032");

                entity.ToTable("transaction_details", "gl");

                entity.Property(e => e.TransactionDetail1).HasColumnName("transaction_detail");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.IsDebit).HasColumnName("is_debit");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.TransactionDetails)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_transaction_details_accounts");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.TransactionDetails)
                    .HasForeignKey(d => d.TransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_transaction_details_transactions");
            });

            modelBuilder.Entity<TransactionOrder>(entity =>
            {
                entity.HasKey(e => e.OrderRefId);

                entity.ToTable("transaction_orders", "acc");

                entity.Property(e => e.OrderRefId).HasColumnName("order_ref_id");

                entity.Property(e => e.PostTime)
                    .HasColumnType("datetime")
                    .HasColumnName("post_time")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReferenceEntityId).HasColumnName("reference_entity_id");

                entity.Property(e => e.ReferenceId).HasColumnName("reference_id");

                entity.Property(e => e.SubReferenceEntityId).HasColumnName("sub_reference_entity_id");

                entity.Property(e => e.SubReferenceId).HasColumnName("sub_reference_id");

                entity.Property(e => e.TransDate)
                    .HasColumnType("date")
                    .HasColumnName("trans_date");
            });

            modelBuilder.Entity<TransactionSource>(entity =>
            {
                entity.ToTable("transaction_sources", "acc");

                entity.Property(e => e.TransactionSourceId)
                    .ValueGeneratedNever()
                    .HasColumnName("transaction_source_id");

                entity.Property(e => e.SourceCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("source_code")
                    .UseCollation("Latin1_General_100_BIN");

                entity.Property(e => e.TransactionSource1)
                    .HasMaxLength(50)
                    .HasColumnName("transaction_source")
                    .UseCollation("Latin1_General_100_BIN");
            });

            modelBuilder.Entity<TransferOrder>(entity =>
            {
                entity.ToTable("transfer_orders", "bnk");

                entity.Property(e => e.TransferOrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("transfer_order_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.EntityForeignId).HasColumnName("entity_foreign_id");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.ReceiverAccount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("receiver_account");

                entity.Property(e => e.ReceiverAccountId).HasColumnName("receiver_account_id");

                entity.Property(e => e.ReceiverBankCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("receiver_bank_code");

                entity.HasOne(d => d.ReceiverAccountNavigation)
                    .WithMany(p => p.TransferOrders)
                    .HasForeignKey(d => d.ReceiverAccountId)
                    .HasConstraintName("FK_transfer_orders_accounts");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "usr");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .HasColumnName("first_name");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .HasColumnName("last_name");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.PwdLastChangeTime)
                    .HasColumnType("datetime")
                    .HasColumnName("pwd_last_change_time");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("user_name");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_users_groups");
            });

            modelBuilder.Entity<UserForm>(entity =>
            {
                entity.ToTable("user_forms", "ui");

                entity.Property(e => e.UserFormId).HasColumnName("user_form_id");

                entity.Property(e => e.ControlDefaults)
                    .HasColumnType("ntext")
                    .HasColumnName("control_defaults");

                entity.Property(e => e.FormId).HasColumnName("form_id");

                entity.Property(e => e.FormLayout)
                    .HasColumnType("ntext")
                    .HasColumnName("form_layout");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Form)
                    .WithMany(p => p.UserForms)
                    .HasForeignKey(d => d.FormId)
                    .HasConstraintName("FK_user_forms_forms");
            });

            modelBuilder.Entity<WatchList>(entity =>
            {
                entity.ToTable("watch_list", "cr");

                entity.Property(e => e.WatchListId)
                    .ValueGeneratedNever()
                    .HasColumnName("watch_list_id");

                entity.Property(e => e.EntityForeignId).HasColumnName("entity_foreign_id");

                entity.Property(e => e.EntityId).HasColumnName("entity_id");

                entity.Property(e => e.WatchedEntityForeignId).HasColumnName("watched_entity_foreign_id");

                entity.Property(e => e.WatchedEntityId).HasColumnName("watched_entity_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
