using OTManager.App.Dtos.Orders;
using OTManager.App.Services.Interfaces;
using OTManager.Core.QueryParams;
using OTManager.Data.UoW;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Services.Implements;

/// <summary>
/// Implementación del servicio de aplicación para la gestión de servicios de orden.
/// </summary>
public class OrderServiceAppService : IOrderServiceAppService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderServiceAppService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ReadOrderServiceDto>> GetAllAsync()
    {
        var services = await _unitOfWork.OrderServices.GetAllAsync();
        return services.Select(s => new ReadOrderServiceDto
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Price = s.Price
        });
    }

    public async Task<(IEnumerable<ReadOrderServiceDto> Items, int TotalCount)> GetFilteredAsync(OrderServiceQueryParams query)
    {
        var (items, total) = await _unitOfWork.OrderServices.GetFilteredAsync(query);
        return (items.Select(s => new ReadOrderServiceDto
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Price = s.Price
        }), total);
    }

    public async Task<ReadOrderServiceDto?> GetByIdAsync(Guid id)
    {
        var s = await _unitOfWork.OrderServices.GetByIdAsync(id);
        return s is null ? null : new ReadOrderServiceDto
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Price = s.Price
        };
    }

    public async Task<ReadOrderServiceDto> CreateAsync(ReadOrderServiceDto dto)
    {
        var entity = new OTManager.Core.Entities.OT.OrderService
        {
            Id = Guid.NewGuid(),
            Name = dto.Name ?? string.Empty,
            Description = dto.Description ?? string.Empty,
            Price = dto.Price
        };
        await _unitOfWork.OrderServices.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return new ReadOrderServiceDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price
        };
    }

    public async Task<bool> UpdateAsync(Guid id, ReadOrderServiceDto dto)
    {
        var entity = await _unitOfWork.OrderServices.GetByIdAsync(id);
        if (entity is null) return false;
        entity.Name = dto.Name ?? entity.Name;
        entity.Description = dto.Description ?? entity.Description;
        entity.Price = dto.Price;
        await _unitOfWork.OrderServices.UpdateAsync(entity);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        await _unitOfWork.OrderServices.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
