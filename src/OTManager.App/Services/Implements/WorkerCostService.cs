using OTManager.App.Dtos.WorkerCosts;
using OTManager.App.Mappers.Interfaces;
using OTManager.App.Services.Interfaces;
using OTManager.Core.QueryParams;
using OTManager.Data.UoW;

namespace OTManager.App.Services.Implements;

public class WorkerCostService : IWorkerCostService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWorkerCostMapper _mapper;

    public WorkerCostService(IUnitOfWork unitOfWork, IWorkerCostMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadWorkerCostDto>> GetAllAsync()
    {
        var items = await _unitOfWork.WorkerCosts.GetAllAsync();
        return items.Select(_mapper.ToEntityDto);
    }

    public async Task<(IEnumerable<ReadWorkerCostDto> Items, int TotalCount)> GetFilteredAsync(WorkerCostQueryParams query)
    {
        var (items, total) = await _unitOfWork.WorkerCosts.GetFilteredAsync(query);
        return (items.Select(_mapper.ToEntityDto), total);
    }

    public async Task<ReadWorkerCostDto?> GetByIdAsync(Guid id)
    {
        var item = await _unitOfWork.WorkerCosts.GetByIdAsync(id);
        return item is null ? null : _mapper.ToEntityDto(item);
    }

    public async Task<ReadWorkerCostDto> CreateAsync(WriteWorkerCostDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var entity = _mapper.FromWriteDto(dto);
            await _unitOfWork.WorkerCosts.AddAsync(entity);
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

    public async Task<bool> UpdateAsync(Guid id, UpdateWorkerCostDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var entity = await _unitOfWork.WorkerCosts.GetByIdAsync(id);
            if (entity is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            _mapper.FromUpdateDto(entity, dto);
            await _unitOfWork.WorkerCosts.UpdateAsync(entity);
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
            var entity = await _unitOfWork.WorkerCosts.GetByIdAsync(id);
            if (entity is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            await _unitOfWork.WorkerCosts.DeleteAsync(id);
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
