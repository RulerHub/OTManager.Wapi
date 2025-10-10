using OTManager.App.Dtos.Factures;
using OTManager.App.Mappers.Abstractions;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Interfaces;

public interface IFactureMapper : IMapper<Facture, ReadFactureDto, WriteFactureDto, UpdateFactureDto>
{
}
