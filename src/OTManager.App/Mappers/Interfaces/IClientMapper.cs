using OTManager.App.Dtos.Clients;
using OTManager.App.Mappers.Abstractions;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Interfaces;

public interface IClientMapper : IMapper<Client, ReadClientDto, WriteClientDto, UpdateClientDto>
{
}
