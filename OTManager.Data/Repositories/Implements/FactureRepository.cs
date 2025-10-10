using Microsoft.EntityFrameworkCore;
using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Context;
using OTManager.Data.Repositories.Interface;

namespace OTManager.Data.Repositories.Implements;

public class FactureRepository(ApplicationDbContext context) : IFactureRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(Facture entity)
    {
        await _context.Features.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null) return;
        _context.Features.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Facture>> GetAllAsync()
        => await _context.Features.ToListAsync();

    public async Task<Facture?> GetByIdAsync(Guid id)
        => await _context.Features.FirstOrDefaultAsync(f => f.Id == id);

    public async Task<(IEnumerable<Facture> Items, int TotalCount)> GetFilteredAsync(FactureQueryParams query)
    {
        var q = _context.Features.AsQueryable();
        if (!string.IsNullOrWhiteSpace(query.Search))
            q = q.Where(f => f.Code.Contains(query.Search));
        if (!string.IsNullOrWhiteSpace(query.Code))
            q = q.Where(f => f.Code == query.Code);
        if (query.CreatedAt.HasValue)
            q = q.Where(f => f.CreatedAt == query.CreatedAt);
        var total = await q.CountAsync();
        if (query.Page > 0 && query.PageSize > 0)
            q = q.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);
        var items = await q.ToListAsync();
        return (items, total);
    }

    public async Task UpdateAsync(Facture entity)
    {
        _context.Features.Update(entity);
        await _context.SaveChangesAsync();
    }
}
