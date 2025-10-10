using OTManager.App.Dtos.Workers;
using OTManager.App.Mappers.Abstractions;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Interfaces;

public interface IWorkerMapper : IMapper<Worker, ReadWorkerDto, WriteWorkerDto, UpdateWorkerDto>
{
}
