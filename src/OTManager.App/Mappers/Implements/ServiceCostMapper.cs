using OTManager.App.Dtos.ServiceCosts;
using OTManager.App.Mappers.Interfaces;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Implements;

public class ServiceCostMapper : IServiceCostMapper
{
    public void FromUpdateDto(ServiceCost entity, UpdateServiceCostDto dto)
    {
        entity.Name = dto.Name;
        entity.Description = dto.Description;
        entity.Price = dto.Price;
        entity.Quantity = dto.Quantity;
        entity.OrderId = dto.OrderId;
    }

    public ServiceCost FromWriteDto(WriteServiceCostDto dto)
        => new()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price,
            Quantity = dto.Quantity,
            OrderId = dto.OrderId
        };

    public ReadServiceCostDto ToEntityDto(ServiceCost entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            Description = entity.Description,
            Price = entity.Price,
            Quantity = entity.Quantity,
            TotalPrice = entity.TotalPrice,
            OrderId = entity.OrderId
        };
}
