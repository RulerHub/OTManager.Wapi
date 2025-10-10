using OTManager.App.Dtos.MaterialCosts;
using OTManager.App.Mappers.Interfaces;
using OTManager.App.Services.Interfaces;
using OTManager.Core.QueryParams;
using OTManager.Data.UoW;

namespace OTManager.App.Services.Implements;

public class MaterialCostService : IMaterialCostService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMaterialCostMapper _mapper;

    public MaterialCostService(IUnitOfWork unitOfWork, IMaterialCostMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadMaterialCostDto>> GetAllAsync()
    {
        var items = await _unitOfWork.MaterialCosts.GetAllAsync();
        return items.Select(_mapper.ToEntityDto);
    }

    public async Task<(IEnumerable<ReadMaterialCostDto> Items, int TotalCount)> GetFilteredAsync(MaterialCostQueryParams query)
    {
        var (items, total) = await _unitOfWork.MaterialCosts.GetFilteredAsync(query);
        return (items.Select(_mapper.ToEntityDto), total);
    }

    public async Task<ReadMaterialCostDto?> GetByIdAsync(Guid id)
    {
        var item = await _unitOfWork.MaterialCosts.GetByIdAsync(id);
        return item is null ? null : _mapper.ToEntityDto(item);
    }

    public async Task<ReadMaterialCostDto> CreateAsync(WriteMaterialCostDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var entity = _mapper.FromWriteDto(dto);
            await _unitOfWork.MaterialCosts.AddAsync(entity);
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

    public async Task<bool> UpdateAsync(Guid id, UpdateMaterialCostDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var entity = await _unitOfWork.MaterialCosts.GetByIdAsync(id);
            if (entity is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            _mapper.FromUpdateDto(entity, dto);
            await _unitOfWork.MaterialCosts.UpdateAsync(entity);
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
            var entity = await _unitOfWork.MaterialCosts.GetByIdAsync(id);
            if (entity is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            await _unitOfWork.MaterialCosts.DeleteAsync(id);
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
