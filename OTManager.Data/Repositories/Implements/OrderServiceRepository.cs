using Microsoft.EntityFrameworkCore;
using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Context;
using OTManager.Data.Repositories.Interface;

namespace OTManager.Data.Repositories.Implements;

public class OrderServiceRepository(ApplicationDbContext context) : IOrderServiceRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(OrderService entity)
    {
        await _context.Services.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null) return;
        _context.Services.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<OrderService>> GetAllAsync()
        => await _context.Services.ToListAsync();

    public async Task<OrderService?> GetByIdAsync(Guid id)
        => await _context.Services.FirstOrDefaultAsync(f => f.Id == id);

    public async Task<(IEnumerable<OrderService> Items, int TotalCount)> GetFilteredAsync(OrderServiceQueryParams query)
    {
        var q = _context.Services.AsQueryable();
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

    public async Task UpdateAsync(OrderService entity)
    {
        _context.Services.Update(entity);
        await _context.SaveChangesAsync();
    }
}
