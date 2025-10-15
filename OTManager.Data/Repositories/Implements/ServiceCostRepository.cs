using Microsoft.EntityFrameworkCore;

using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Context;
using OTManager.Data.Repositories.Interface;

namespace OTManager.Data.Repositories.Implements;

public class ServiceCostRepository(ApplicationDbContext context) : IServiceCostRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(ServiceCost entity)
    {
        await _context.ServiceCosts.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null) return;
        _context.ServiceCosts.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ServiceCost>> GetAllAsync()
        => await _context.ServiceCosts.ToListAsync();

    public async Task<ServiceCost?> GetByIdAsync(Guid id)
        => await _context.ServiceCosts.FirstOrDefaultAsync(f => f.Id == id);

    public async Task<(IEnumerable<ServiceCost> Items, int TotalCount)> GetFilteredAsync(ServiceCostQueryParams query)
    {
        var q = _context.ServiceCosts.AsQueryable();
        if (!string.IsNullOrWhiteSpace(query.Search))
            q = q.Where(s => s.Name.Contains(query.Search));
        if (!string.IsNullOrWhiteSpace(query.Name))
            q = q.Where(s => s.Name == query.Name);
        if (query.CreatedAt.HasValue)
            q = q.Where(s => s.CreatedAt == query.CreatedAt);
        var total = await q.CountAsync();
        if (query.Page > 0 && query.PageSize > 0)
            q = q.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);
        var items = await q.ToListAsync();
        return (items, total);
    }

    public async Task UpdateAsync(ServiceCost entity)
    {
        _context.ServiceCosts.Update(entity);
        await _context.SaveChangesAsync();
    }
}
