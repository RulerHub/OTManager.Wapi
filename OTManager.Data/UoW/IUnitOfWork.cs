using OTManager.Data.Repositories.Interface;

namespace OTManager.Data.UoW;

/// <summary>
/// Define el contrato para la unidad de trabajo (Unit of Work) que coordina la persistencia y transacciones de los repositorios.
/// </summary>
public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Repositorio para operaciones sobre entidades de clientes.
    /// </summary>
    IClientRepository Clients { get; }
    IOrderRepository Orders { get; }
    IFactureRepository Factures { get; }
    IMaterialRepository Materials { get; }
    IWorkerRepository Workers { get; }
    IOrderServiceRepository OrderServices { get; }

    /// <summary>
    /// Persiste los cambios realizados en el contexto de datos de manera asíncrona.
    /// </summary>
    /// <returns>Número de entidades afectadas.</returns>
    Task<int> SaveChangesAsync();

    /// <summary>
    /// Inicia una transacción de base de datos de manera asíncrona.
    /// </summary>
    Task BeginTransactionAsync();

    /// <summary>
    /// Confirma la transacción actual de manera asíncrona.
    /// </summary>
    Task CommitTransactionAsync();

    /// <summary>
    /// Revierte la transacción actual de manera asíncrona.
    /// </summary>
    Task RollbackTransactionAsync();
}
