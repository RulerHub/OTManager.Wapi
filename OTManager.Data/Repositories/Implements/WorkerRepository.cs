using Microsoft.EntityFrameworkCore;
using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Context;
using OTManager.Data.Repositories.Interface;

namespace OTManager.Data.Repositories.Implements;

public class WorkerRepository(ApplicationDbContext context) : IWorkerRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(Worker entity)
    {
        await _context.Workers.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null) return;
        _context.Workers.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Worker>> GetAllAsync()
        => await _context.Workers.ToListAsync();

    public async Task<Worker?> GetByIdAsync(Guid id)
        => await _context.Workers.FirstOrDefaultAsync(f => f.Id == id);

    public async Task<(IEnumerable<Worker> Items, int TotalCount)> GetFilteredAsync(WorkerQueryParams query)
    {
        var q = _context.Workers.AsQueryable();
        if (!string.IsNullOrWhiteSpace(query.Search))
            q = q.Where(w => w.Name.Contains(query.Search));
        if (!string.IsNullOrWhiteSpace(query.Name))
            q = q.Where(w => w.Name == query.Name);
        if (query.CreatedAt.HasValue)
            q = q.Where(w => w.CreatedAt == query.CreatedAt);
        var total = await q.CountAsync();
        if (query.Page > 0 && query.PageSize > 0)
            q = q.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);
        var items = await q.ToListAsync();
        return (items, total);
    }

    public async Task UpdateAsync(Worker entity)
    {
        _context.Workers.Update(entity);
        await _context.SaveChangesAsync();
    }
}
