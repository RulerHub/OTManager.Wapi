using OTManager.App.Dtos.Workers;
using OTManager.App.Mappers.Interfaces;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Implements;

public class WorkerMapper : IWorkerMapper
{
    public void FromUpdateDto(Worker entity, UpdateWorkerDto dto)
    {
        entity.Name = dto.Name;
        entity.HourlyRate = dto.HourlyRate;
    }

    public Worker FromWriteDto(WriteWorkerDto dto)
        => new()
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            HourlyRate = dto.HourlyRate
        };

    public ReadWorkerDto ToEntityDto(Worker entity)
        => new()
        {
            Id = entity.Id,
            Name = entity.Name,
            HourlyRate = entity.HourlyRate
        };
}
