using OTManager.App.Dtos.WorkerCosts;
using OTManager.App.Mappers.Abstractions;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Interfaces;

public interface IWorkerCostMapper : IMapper<WorkerCost, ReadWorkerCostDto, WriteWorkerCostDto, UpdateWorkerCostDto>
{
}
