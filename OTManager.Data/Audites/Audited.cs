using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OTManager.Data.Audites;

public static class Audited
{
    /// <summary>
    /// Aplica la auditoría a las entidades rastreadas por el ChangeTracker.
    /// </summary>
    /// <param name="changeTracker">El ChangeTracker del DbContext.</param>
    /// <param name="userName">El nombre del usuario que realiza la acción (opcional, por defecto 'Anonymous').</param>
    public static void AplicarAuditoria(ChangeTracker changeTracker, string userName = "Anonymous")
    {
        var now = DateTime.UtcNow;
        foreach (var entry in changeTracker.Entries())
        {
            var entityType = entry.Entity.GetType();
            var auditableInterface = entityType.GetInterface("IAuditableEntity`1");
            if (auditableInterface != null)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = now;
                    entry.Property("CreatedBy").CurrentValue = userName;
                    entry.Property("UpdatedAt").CurrentValue = null;
                    entry.Property("UpdatedBy").CurrentValue = null;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false;
                    entry.Property("CreatedBy").IsModified = false;
                    entry.Property("UpdatedAt").CurrentValue = now;
                    entry.Property("UpdatedBy").CurrentValue = userName;
                }
                else if (entry.State == EntityState.Deleted)
                {
                    entry.Property("CreatedAt").IsModified = false;
                    entry.Property("CreatedBy").IsModified = false;
                    entry.Property("UpdatedAt").IsModified = false;
                    entry.Property("UpdatedBy").IsModified = false;
                    // SoftDelete: descomentar si implementas las propiedades DeletedAt y DeletedBy
                    //entry.Property("DeletedAt").CurrentValue = now;
                    //entry.Property("DeletedBy").CurrentValue = userName;
                    //entry.State = EntityState.Modified; // Para soft delete
                }
            }
        }
    }
}

public interface IAuditableEntity<TKey> { }
