using Microsoft.EntityFrameworkCore;

using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Context;
using OTManager.Data.Repositories.Interface;

namespace OTManager.Data.Repositories.Implements;

public class MaterialCostRepository(ApplicationDbContext context) : IMaterialCostRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(MaterialCost entity)
    {
        await _context.MaterialCosts.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null) return;
        _context.MaterialCosts.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<MaterialCost>> GetAllAsync()
        => await _context.MaterialCosts.ToListAsync();

    public async Task<MaterialCost?> GetByIdAsync(Guid id)
        => await _context.MaterialCosts.FirstOrDefaultAsync(f => f.Id == id);

    public async Task<(IEnumerable<MaterialCost> Items, int TotalCount)> GetFilteredAsync(MaterialCostQueryParams query)
    {
        var q = _context.MaterialCosts.AsQueryable();
        if (!string.IsNullOrWhiteSpace(query.Search))
            q = q.Where(m => m.Name.Contains(query.Search) || m.Code.Contains(query.Search));
        if (!string.IsNullOrWhiteSpace(query.Code))
            q = q.Where(m => m.Code == query.Code);
        if (!string.IsNullOrWhiteSpace(query.Name))
            q = q.Where(m => m.Name == query.Name);
        if (query.CreatedAt.HasValue)
            q = q.Where(m => m.CreatedAt == query.CreatedAt);
        var total = await q.CountAsync();
        if (query.Page > 0 && query.PageSize > 0)
            q = q.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);
        var items = await q.ToListAsync();
        return (items, total);
    }

    public async Task UpdateAsync(MaterialCost entity)
    {
        _context.MaterialCosts.Update(entity);
        await _context.SaveChangesAsync();
    }
}
