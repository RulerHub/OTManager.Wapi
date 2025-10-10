using OTManager.App.Dtos.Orders;
using OTManager.App.Mappers.Interfaces;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Implements;

public class OrderMapper : IOrderMapper
{
    public void FromUpdateDto(Order entity, UpdateOrderDto dto)
    {
        // TODO: Map fields from UpdateOrderDto to Order
    }

    public Order FromWriteDto(WriteOrderDto dto)
        => new()
        {
            Id = Guid.NewGuid(),
            // TODO: Map fields from WriteOrderDto
        };

    public ReadOrderDto ToEntityDto(Order entity)
        => new(); // TODO: Map fields from Order to ReadOrderDto
}
