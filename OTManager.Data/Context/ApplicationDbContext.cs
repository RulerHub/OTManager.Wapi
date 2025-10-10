using Microsoft.EntityFrameworkCore;
using OTManager.Data.Audites;

using OTManager.Core.Entities.OT;

namespace OTManager.Data.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Facture> Features => Set<Facture>();
    public DbSet<Material> Materials => Set<Material>();
    public DbSet<MaterialCost> MaterialCosts => Set<MaterialCost>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<ServiceOrder> Services => Set<ServiceOrder>();
    public DbSet<ServiceCost> ServiceCosts => Set<ServiceCost>();
    public DbSet<Worker> Workers => Set<Worker>();
    public DbSet<WorkerCost> WorkerCosts => Set<WorkerCost>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
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
