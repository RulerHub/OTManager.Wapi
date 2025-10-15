using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

using OTManager.Data.Context;
using OTManager.Data.Repositories.Implements;
using OTManager.Data.Repositories.Interface;

namespace OTManager.Data.UoW
{
    /// <summary>
    /// Implementación de la unidad de trabajo (Unit of Work) que coordina la persistencia y transacciones de los repositorios.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction? _transaction;
        private bool _disposed;

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="UnitOfWork"/>.
        /// </summary>
        /// <param name="context">Contexto de base de datos a utilizar.</param>
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <inheritdoc/>
        public IClientRepository Clients => new ClientRepository(_context);
        /// <inheritdoc/>
        public IOrderRepository Orders => new OrderRepository(_context);
        /// <inheritdoc/>
        public IFactureRepository Factures => new FactureRepository(_context);
        /// <inheritdoc/>
        public IServiceCostRepository ServiceCosts => new ServiceCostRepository(_context);
        /// <inheritdoc/>
        public IMaterialCostRepository MaterialCosts => new MaterialCostRepository(_context);
        /// <inheritdoc/>
        public IWorkerCostRepository WorkerCosts => new WorkerCostRepository(_context);
        /// <inheritdoc/>
        public IMaterialRepository Materials => new MaterialRepository(_context);
        /// <inheritdoc/>
        public IWorkerRepository Workers => new WorkerRepository(_context);
        /// <inheritdoc/>
        public IOrderServiceRepository OrderServices => new OrderServiceRepository(_context);

        /// <inheritdoc/>
        public async Task BeginTransactionAsync()
        {
            if (_transaction is null)
                _transaction = await _context.Database.BeginTransactionAsync();
        }

        /// <inheritdoc/>
        public async Task CommitTransactionAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <inheritdoc/>
        public async Task RollbackTransactionAsync()
        {
            if (_transaction is not null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        /// <inheritdoc/>
        public async Task<int> SaveChangesAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ApplicationException("Conflicto en concurrencia detectado.", ex);
            }
            catch (DbUpdateException ex)
            {
                throw new ApplicationException("Error al actualizar la base de datos.", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error inesperado en operación de persistencia.", ex);
            }
        }

        /// <summary>
        /// Libera los recursos utilizados por la instancia de manera sincrónica.
        /// </summary>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Libera los recursos utilizados por la instancia de manera asíncrona.
        /// </summary>
        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore();
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction?.Dispose();
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        protected virtual async ValueTask DisposeAsyncCore()
        {
            if (!_disposed)
            {
                if (_transaction is not null)
                {
                    await _transaction.DisposeAsync();
                }
                await _context.DisposeAsync();
                _disposed = true;
            }
        }
    }
}
