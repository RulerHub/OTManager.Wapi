using OTManager.App.Dtos.ServiceCosts;
using OTManager.App.Mappers.Abstractions;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Interfaces;

public interface IServiceCostMapper : IMapper<ServiceCost, ReadServiceCostDto, WriteServiceCostDto, UpdateServiceCostDto>
{
}
