using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Newslify.Languages;
using Newslify.ReadingLists;
using Newslify.Keywords;
using Newslify.SavedNews;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Newslify.Alerts;
using Newslify.Notifications;
using Newslify.APILogs;

namespace Newslify.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class NewslifyDbContext :
    AbpDbContext<NewslifyDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    #region Entidades de dominio  
    /* Domain Entities */
    public DbSet<Language> Languages { get; set; }
    public DbSet<ReadingList> ReadingLists { get; set; }
    public DbSet<Keyword> Keywords { get; set; }
    public DbSet<SavedNew> SavedNews { get; set; }
    public DbSet<Alert> Alerts { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<APILog> APILogs { get; set; }

    #endregion

    public NewslifyDbContext(DbContextOptions<NewslifyDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

    /* Configure your own tables/entities inside here */
    //builder.Entity<YourEntity>(b =>
    //{
    //    b.ToTable(NewslifyConsts.DbTablePrefix + "YourEntities", NewslifyConsts.DbSchema);
    //    b.ConfigureByConvention(); //auto configure for the base class props
    //    //...
    //});

    /* Language Entity*/
    builder.Entity<Language>(b =>
        {
            b.ToTable(NewslifyConsts.DbTablePrefix + "Languages", NewslifyConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            b.Property(x => x.InternationalCode).HasConversion<string>().HasMaxLength(2).IsRequired();
        });

        /* Keyword Entity*/
        builder.Entity<Keyword>(b =>
        {
            b.ToTable(NewslifyConsts.DbTablePrefix + "Keywords", NewslifyConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.KeyWord).IsRequired().HasMaxLength(128);
        });

        /* New Entity*/
        builder.Entity<SavedNew>(b =>
        {
            b.ToTable(NewslifyConsts.DbTablePrefix + "SavedNews", NewslifyConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Description).IsRequired().HasMaxLength(256);
            b.Property(x => x.Author).IsRequired().HasMaxLength(128);
            b.Property(x => x.Title).IsRequired().HasMaxLength(256);
            b.Property(x => x.Url).IsRequired().HasMaxLength(256);
        });

        /* ReadingList Entity*/
        builder.Entity<ReadingList>(b =>
        {
            b.ToTable(NewslifyConsts.DbTablePrefix + "ReadingLists", NewslifyConsts.DbSchema);
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(128);
        });

        // Alert Entity
        builder.Entity<Alert>(b =>
        {
            b.ToTable(NewslifyConsts.DbTablePrefix + "Alerts", NewslifyConsts.DbSchema);
            b.ConfigureByConvention();
        });

        // Notification entity
        builder.Entity<Notification>(b =>
        {
            b.ToTable(NewslifyConsts.DbTablePrefix + "Notifications",
                NewslifyConsts.DbSchema);
            b.ConfigureByConvention();

            // evitar problemas con foreign key
            b.HasOne<Alert>(s => s.Alert)
                .WithMany(g => g.Notifications)
                .HasForeignKey(s => s.AlertId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        // APILog Entity
        builder.Entity<APILog>(b =>
        {
            b.ToTable(NewslifyConsts.DbTablePrefix + "APILogs", NewslifyConsts.DbSchema);
            b.ConfigureByConvention();
        });
    }
}
