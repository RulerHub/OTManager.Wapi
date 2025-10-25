using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using OTManager.Core.Entities.OT;
using OTManager.Data.Account;
using OTManager.Data.Audites;

namespace OTManager.Data.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Facture> Features => Set<Facture>();
    public DbSet<Material> Materials => Set<Material>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<ServiceOrder> Services => Set<ServiceOrder>();
    public DbSet<Worker> Workers => Set<Worker>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        builder.Entity<IdentityUserLogin<Guid>>(e => {
            e.HasKey(l => new { l.LoginProvider, l.ProviderKey });
        });
        builder.Entity<IdentityUserRole<Guid>>(e => {
            e.HasKey(r => new { r.UserId, r.RoleId });
        });
        builder.Entity<IdentityUserToken<Guid>>(e => {
            e.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        });
    }

    public override int SaveChanges()
    {
        Audited.AplicarAuditoria(ChangeTracker);
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        Audited.AplicarAuditoria(ChangeTracker);
        return base.SaveChangesAsync(cancellationToken);
    }
}
