using OTManager.App.Dtos.WorkerCosts;
using OTManager.App.Mappers.Interfaces;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Implements;

public class WorkerCostMapper : IWorkerCostMapper
{
    public void FromUpdateDto(WorkerCost entity, UpdateWorkerCostDto dto)
    {
        entity.Name = dto.Name;
        entity.HourlyRate = dto.HourlyRate;
        entity.HoursWorked = dto.HoursWorked;
        entity.OrderId = dto.OrderId;
    }

    public WorkerCost FromWriteDto(WriteWorkerCostDto dto)
        => new()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            HourlyRate = dto.HourlyRate,
            HoursWorked = dto.HoursWorked,
            OrderId = dto.OrderId
        };

    public ReadWorkerCostDto ToEntityDto(WorkerCost entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            HourlyRate = entity.HourlyRate,
            HoursWorked = entity.HoursWorked,
            TotalCost = entity.TotalCost,
            OrderId = entity.OrderId
        };
}
