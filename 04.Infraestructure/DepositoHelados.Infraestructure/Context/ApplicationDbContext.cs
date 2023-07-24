
using DepositoHelados.Domain.Base;
using DepositoHelados.Domain.Entities.ArchiveAggregate;
using DepositoHelados.Domain.Entities.CategoryAggregate;
using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.EmployeeProductOrderAggregate;
using DepositoHelados.Domain.Entities.MasterAggregate;
using DepositoHelados.Domain.Entities.MenuAggregate;
using DepositoHelados.Domain.Entities.OrderAggregate;
using DepositoHelados.Domain.Entities.PersonAggregate;
using DepositoHelados.Domain.Entities.ProductAggregate;
using DepositoHelados.Domain.Entities.RoleAggregate;
using DepositoHelados.Domain.Entities.UserAggregate;
using DepositoHelados.Infraestructure.Context.Configuration;
using DepositoHelados.Infraestructure.Helpers;
using Microsoft.AspNetCore.Http;

namespace DepositoHelados.Infraestructure.Context;

public class ApplicationDbContext : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private string _currentUser { get; set; } = string.Empty;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IHttpContextAccessor httpContextAccessor
    ) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
        _currentUser = _getCurrentUser();
    }

    public DbSet<Archive> Archive { get; set; }
    public DbSet<Category> Category { get; set; }
    public DbSet<Campus> Campus { get; set; }
    public DbSet<Company> Company { get; set; }
    public DbSet<EmployeeProductOrder> EmployeeProductOrder { get; set; }
    public DbSet<EmployeeProductOrderDetail> EmployeeProductOrderDetail { get; set; }
    public DbSet<Master> Master { get; set; }
    public DbSet<MasterDetail> MasterDetail { get; set; }
    public DbSet<Menu> Menu { get; set; }
    public DbSet<MenuRole> MenuRole { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderAdvanceAmount> OrderAdvanceAmount { get; set; }
    public DbSet<OrderDetail> OrderDetail { get; set; }
    public DbSet<PersonAmountAccount> AmountAccount { get; set; }
    public DbSet<Person> Person { get; set; }
    public DbSet<PersonAddress> PersonAddress { get; set; }
    public DbSet<PersonRole> PersonRole { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<ProductArchive> ProductArchive { get; set; }
    public DbSet<ProductCategory> ProductCategory { get; set; }
    public DbSet<ProductFlavor> ProductFlavor { get; set; }
    public DbSet<ProductPrice> ProductPrice { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<UserToken> UserToken { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder
            .ApplyConfiguration(new ArchiveConfig())
            .ApplyConfiguration(new CampusConfig())
            .ApplyConfiguration(new CategoryConfig())
            .ApplyConfiguration(new CompanyConfig())
            .ApplyConfiguration(new EmployeeProductOrderConfig())
            .ApplyConfiguration(new EmployeeProductOrderDetailConfig())
            .ApplyConfiguration(new MasterConfig())
            .ApplyConfiguration(new MasterDetailConfig())
            .ApplyConfiguration(new MenuConfig())
            .ApplyConfiguration(new MenuRoleConfig())
            .ApplyConfiguration(new OrderAdvanceAmountConfig())
            .ApplyConfiguration(new OrderConfig())
            .ApplyConfiguration(new OrderDetailConfig())
            .ApplyConfiguration(new PersonAddressConfig())
            .ApplyConfiguration(new PersonConfig())
            .ApplyConfiguration(new PersonRoleConfig())
            .ApplyConfiguration(new ProductArchiveConfig())
            .ApplyConfiguration(new ProductCategoryConfig())
            .ApplyConfiguration(new ProductConfig())
            .ApplyConfiguration(new ProductFlavorConfig())
            .ApplyConfiguration(new ProductPriceConfig())
            .ApplyConfiguration(new RoleConfig())
            .ApplyConfiguration(new UserConfig())
            .ApplyConfiguration(new UserRoleConfig())
            .ApplyConfiguration(new UserTokenConfig());     

            _entitiesConfiguration(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        _updateAuditEntities();
        // var auditEntries = AuditoriaAntesDeGuardarCambios();
        var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        // await AuditoriaDespuesDeGuardarCambios(auditEntries);
        return result;
    }


    private void _updateAuditEntities()
    {
        var currentDate = DateTime.UtcNow.GetDateTimePeru();
        var entityEntries = ChangeTracker.Entries().Where(e => e.Entity is IBaseAudit);

        foreach (var entityEntry in entityEntries)
        {
            if (!(entityEntry.Entity is IBaseAudit entity)) continue;
            switch (entityEntry.State)
            {
                case EntityState.Added:
                    entity.CreateDate = currentDate;
                    entity.CreateUser = _currentUser;

                    break;
                case EntityState.Unchanged:
                case EntityState.Modified:

                    entity.ModifyDate = currentDate;
                    entity.ModifyUser = _currentUser;

                    entityEntry.Property(nameof(entity.CreateDate)).IsModified = false;
                    entityEntry.Property(nameof(entity.CreateUser)).IsModified = false;

                    break;
                case EntityState.Deleted:

                    entity.DeleteDate = currentDate;
                    entity.DeleteUser = _currentUser;

                    entityEntry.Property(nameof(entity.CreateDate)).IsModified = false;
                    entityEntry.Property(nameof(entity.CreateUser)).IsModified = false;
                    entityEntry.Property(nameof(entity.ModifyDate)).IsModified = false;
                    entityEntry.Property(nameof(entity.ModifyUser)).IsModified = false;

                    entityEntry.State = EntityState.Modified;

                    break;
            }
        }
    }

    private void _entitiesConfiguration (ModelBuilder builder)
    {   
        var entityTypes = builder.Model.GetEntityTypes();

        var foreignKeysEntities = entityTypes
            .SelectMany(e => e.GetForeignKeys())
            .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

        var mutableProperties = entityTypes
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

        builder.AddQueryFilter<IBaseAudit>(e => e.IsDeleted == false);
        builder.AddQueryFilter<IBaseCompany>(e => e.CompanyId.Equals(Guid.Empty));

        
        foreach (var entityType in entityTypes)
        {
           entityType.SetTableName(entityType.DisplayName());
        }

        foreach (var property in mutableProperties)
        {
            property.SetColumnType("money");
        }

        foreach (var foreignKey in foreignKeysEntities)
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }
    }

    private string _getCurrentUser()
    {
        string currentUser = string.Empty;

        if (_httpContextAccessor.HttpContext is null)
        {
            var principalClaims = _httpContextAccessor?.HttpContext?.User;
            currentUser = principalClaims?.FindFirst(Constants.CLAIM_USERNAME)?.Value ?? Constants.CURRENT_USER_DEFAULT;
        }

        return currentUser;
    }

    public Guid? GetCompanyId()
    {
        string companyId = string.Empty;

        if (_httpContextAccessor.HttpContext is null)
        {
            var principalClaims = _httpContextAccessor?.HttpContext?.User;
            companyId = principalClaims?.FindFirst(Constants.CLAIM_COMPANY)?.Value ?? string.Empty;
        }

        return !string.IsNullOrWhiteSpace(companyId) ?  new Guid(companyId) : Guid.Empty;
    }  
}