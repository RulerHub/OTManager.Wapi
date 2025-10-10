using OTManager.App.Dtos.MaterialCosts;
using OTManager.App.Mappers.Interfaces;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Implements;

public class MaterialCostMapper : IMaterialCostMapper
{
    public void FromUpdateDto(MaterialCost entity, UpdateMaterialCostDto dto)
    {
        entity.Code = dto.Code;
        entity.Name = dto.Name;
        entity.MeasureUnit = dto.MeasureUnit;
        entity.UnitCost = dto.UnitCost;
        entity.Quantity = dto.Quantity;
        entity.OrderId = dto.OrderId;
    }

    public MaterialCost FromWriteDto(WriteMaterialCostDto dto)
        => new()
        {
            Id = Guid.NewGuid(),
            Code = dto.Code,
            Name = dto.Name,
            MeasureUnit = dto.MeasureUnit,
            UnitCost = dto.UnitCost,
            Quantity = dto.Quantity,
            OrderId = dto.OrderId
        };

    public ReadMaterialCostDto ToEntityDto(MaterialCost entity)
        => new()
        {
            Id = entity.Id,
            Code = entity.Code,
            Name = entity.Name,
            MeasureUnit = entity.MeasureUnit,
            UnitCost = entity.UnitCost,
            Quantity = entity.Quantity,
            TotalCost = entity.TotalCost,
            OrderId = entity.OrderId
        };
}
