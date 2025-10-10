using Microsoft.EntityFrameworkCore;
using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Context;
using OTManager.Data.Repositories.Interface;

namespace OTManager.Data.Repositories.Implements;

public class OrderRepository(ApplicationDbContext context) : IOrderRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(Order entity)
    {
        await _context.Orders.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null) return;
        _context.Orders.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
        => await _context.Orders.ToListAsync();

    public async Task<Order?> GetByIdAsync(Guid id)
        => await _context.Orders.FirstOrDefaultAsync(f => f.Id == id);

    public async Task<(IEnumerable<Order> Items, int TotalCount)> GetFilteredAsync(OrderQueryParams query)
    {
        var q = _context.Orders.AsQueryable();
        if (!string.IsNullOrWhiteSpace(query.Search))
            q = q.Where(o => o.OrderNumber.Contains(query.Search));
        if (!string.IsNullOrWhiteSpace(query.OrderNumber))
            q = q.Where(o => o.OrderNumber == query.OrderNumber);
        if (query.CreatedAt.HasValue)
            q = q.Where(o => o.CreatedAt == query.CreatedAt);
        var total = await q.CountAsync();
        if (query.Page > 0 && query.PageSize > 0)
            q = q.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);
        var items = await q.ToListAsync();
        return (items, total);
    }

    public async Task UpdateAsync(Order entity)
    {
        _context.Orders.Update(entity);
        await _context.SaveChangesAsync();
    }
}
