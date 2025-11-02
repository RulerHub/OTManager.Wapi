using Microsoft.EntityFrameworkCore;

using OTManager.Core.Entities.OT;
using OTManager.Core.QueryParams;
using OTManager.Data.Context;
using OTManager.Data.Repositories.Interface;

namespace OTManager.Data.Repositories.Implements;

public class ClientRepository(ApplicationDbContext context) : IClientRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task AddAsync(Client entity)
    {
        await _context.Clients.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null) return;
        _context.Clients.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Client>> GetAllAsync()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<Client?> GetByIdAsync(Guid id)
        => await _context.Clients.FirstOrDefaultAsync(p => p.Id == id);

    public async Task<(IEnumerable<Client> Items, int TotalCount)> GetFilteredAsync(ClientQueryParams query)
    {
        var q = _context.Clients.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Search))
            q = q.Where(p => p.Name.Contains(query.Search));

        // Mejorar ordenamiento soportando más campos
        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            switch (query.SortBy.ToLower())
            {
                case "name":
                    q = query.Descending ? q.OrderByDescending(p => p.Name) : q.OrderBy(p => p.Name);
                    break;
                case "code":
                    q = query.Descending ? q.OrderByDescending(p => p.Code) : q.OrderBy(p => p.Code);
                    break;
                default:
                    q = q.OrderBy(p => p.Name);
                    break;
            }
        }
        else
        {
            q = q.OrderBy(p => p.Name);
        }

        var total = await q.CountAsync();

        // Paginación
        if (query.Page > 0 && query.PageSize > 0)
            q = q.Skip((query.Page - 1) * query.PageSize).Take(query.PageSize);

        var items = await q.ToListAsync();
        return (items, total);
    }

    public async Task UpdateAsync(Client entity)
    {
        _context.Clients.Update(entity);
        await _context.SaveChangesAsync();
    }
}
