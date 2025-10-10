using OTManager.App.Dtos.Materials;
using OTManager.App.Mappers.Interfaces;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Implements;

public class MaterialMapper : IMaterialMapper
{
    public void FromUpdateDto(Material entity, UpdateMaterialDto dto)
    {
        entity.Code = dto.Code;
        entity.Name = dto.Name;
        entity.MeasureUnit = dto.MeasureUnit;
        entity.UnitCost = dto.UnitCost;
    }

    public Material FromWriteDto(WriteMaterialDto dto)
        => new()
        {
            Id = Guid.NewGuid(),
            Code = dto.Code,
            Name = dto.Name,
            MeasureUnit = dto.MeasureUnit,
            UnitCost = dto.UnitCost
        };

    public ReadMaterialDto ToEntityDto(Material entity)
        => new()
        {
            Id = entity.Id,
            Code = entity.Code,
            Name = entity.Name,
            MeasureUnit = entity.MeasureUnit,
            UnitCost = entity.UnitCost
        };
}
