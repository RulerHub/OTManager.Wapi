using OTManager.App.Dtos.Materials;
using OTManager.App.Mappers.Interfaces;
using OTManager.App.Services.Interfaces;
using OTManager.Core.QueryParams;
using OTManager.Data.UoW;

namespace OTManager.App.Services.Implements;

public class MaterialService : IMaterialService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMaterialMapper _mapper;

    public MaterialService(IUnitOfWork unitOfWork, IMaterialMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadMaterialDto>> GetAllAsync()
    {
        var items = await _unitOfWork.Materials.GetAllAsync();
        return items.Select(_mapper.ToEntityDto);
    }

    public async Task<(IEnumerable<ReadMaterialDto> Items, int TotalCount)> GetFilteredAsync(MaterialQueryParams query)
    {
        var (items, total) = await _unitOfWork.Materials.GetFilteredAsync(query);
        return (items.Select(_mapper.ToEntityDto), total);
    }

    public async Task<ReadMaterialDto?> GetByIdAsync(Guid id)
    {
        var item = await _unitOfWork.Materials.GetByIdAsync(id);
        return item is null ? null : _mapper.ToEntityDto(item);
    }

    public async Task<ReadMaterialDto> CreateAsync(WriteMaterialDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var entity = _mapper.FromWriteDto(dto);
            await _unitOfWork.Materials.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
            return _mapper.ToEntityDto(entity);
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateMaterialDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var entity = await _unitOfWork.Materials.GetByIdAsync(id);
            if (entity is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            _mapper.FromUpdateDto(entity, dto);
            await _unitOfWork.Materials.UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var entity = await _unitOfWork.Materials.GetByIdAsync(id);
            if (entity is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            await _unitOfWork.Materials.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
            return true;
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }
}
