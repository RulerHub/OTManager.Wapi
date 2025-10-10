using OTManager.App.Dtos.Factures;
using OTManager.App.Mappers.Interfaces;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Implements;

public class FactureMapper : IFactureMapper
{
    public void FromUpdateDto(Facture entity, UpdateFactureDto dto)
    {
        // TODO: Map fields from UpdateFactureDto to Facture
    }

    public Facture FromWriteDto(WriteFactureDto dto)
        => new()
        {
            Id = Guid.NewGuid(),
            // TODO: Map fields from WriteFactureDto
        };

    public ReadFactureDto ToEntityDto(Facture entity)
        => new(); // TODO: Map fields from Facture to ReadFactureDto
}
