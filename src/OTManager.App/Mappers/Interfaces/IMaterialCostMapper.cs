using OTManager.App.Dtos.MaterialCosts;
using OTManager.App.Mappers.Abstractions;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Interfaces;

public interface IMaterialCostMapper : IMapper<MaterialCost, ReadMaterialCostDto, WriteMaterialCostDto, UpdateMaterialCostDto>
{
}
