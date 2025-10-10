using OTManager.App.Dtos.Orders;
using OTManager.App.Mappers.Abstractions;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Interfaces;

public interface IOrderMapper : IMapper<Order, ReadOrderDto, WriteOrderDto, UpdateOrderDto>
{
}
