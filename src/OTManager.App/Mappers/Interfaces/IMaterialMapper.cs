using OTManager.App.Dtos.Materials;
using OTManager.App.Mappers.Abstractions;
using OTManager.Core.Entities.OT;

namespace OTManager.App.Mappers.Interfaces;

public interface IMaterialMapper : IMapper<Material, ReadMaterialDto, WriteMaterialDto, UpdateMaterialDto>
{
    [Obsolete]
    void FromReadToUpdate(UpdateMaterialDto updateMaterial, ReadMaterialDto readMaterial);

    void FromUpdateDto(Material entity, ReadMaterialDto dto);
}
