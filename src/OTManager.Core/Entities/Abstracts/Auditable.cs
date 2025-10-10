namespace OTManager.Core.Entities.Abstracts
{
    /// <summary>
    /// Interfaz para entidades auditables.
    /// </summary>
    /// <typeparam name="TKey">Tipo de la clave primaria.</typeparam>
    public interface IAuditableEntity<TKey>
    {
        TKey Id { get; set; }
        DateTime? CreatedAt { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedAt { get; set; }
        string? UpdatedBy { get; set; }
        // SoftDelete opcional
        // DateTime? DeletedAt { get; set; }
        // string? DeletedBy { get; set; }
    }

    public class Auditable<TKey> : IAuditableEntity<TKey>
    {
        public required TKey Id { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        // SoftDelete opcional
        // public DateTime? DeletedAt { get; set; }
        // public string? DeletedBy { get; set; }
    }
}
