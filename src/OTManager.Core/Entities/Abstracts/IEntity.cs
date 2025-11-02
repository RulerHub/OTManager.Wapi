namespace OTManager.Core.Entities.Abstracts;

public interface IEntity<TKey> where TKey : IEquatable<TKey>
{
    TKey Id { get; set; }
}
