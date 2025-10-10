using OTManager.App.Dtos.Clients;
using OTManager.App.Mappers.Interfaces;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Implements;

public class ClientMapper : IClientMapper
{
    public void FromUpdateDto(Client entity, UpdateClientDto dto)
    {
        entity.Code = dto.Code;
        entity.Name = dto.Name;
    }

    public Client FromWriteDto(WriteClientDto dto)
        => new()
        {
            Id = Guid.NewGuid(),
            Code = dto.Code,
            Name = dto.Name
        };

    public ReadClientDto ToEntityDto(Client entity)
        => new(entity.Id, entity.Code, entity.Name, [], []); // Orders y Factures pueden mapearse aquí si es necesario
}
