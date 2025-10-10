using OTManager.App.Dtos.Workers;
using OTManager.App.Mappers.Interfaces;
using OTManager.App.Services.Interfaces;
using OTManager.Core.QueryParams;
using OTManager.Data.UoW;

namespace OTManager.App.Services.Implements;

public class WorkerService : IWorkerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWorkerMapper _mapper;

    public WorkerService(IUnitOfWork unitOfWork, IWorkerMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadWorkerDto>> GetAllAsync()
    {
        var items = await _unitOfWork.Workers.GetAllAsync();
        return items.Select(_mapper.ToEntityDto);
    }

    public async Task<(IEnumerable<ReadWorkerDto> Items, int TotalCount)> GetFilteredAsync(WorkerQueryParams query)
    {
        var (items, total) = await _unitOfWork.Workers.GetFilteredAsync(query);
        return (items.Select(_mapper.ToEntityDto), total);
    }

    public async Task<ReadWorkerDto?> GetByIdAsync(Guid id)
    {
        var item = await _unitOfWork.Workers.GetByIdAsync(id);
        return item is null ? null : _mapper.ToEntityDto(item);
    }

    public async Task<ReadWorkerDto> CreateAsync(WriteWorkerDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var entity = _mapper.FromWriteDto(dto);
            await _unitOfWork.Workers.AddAsync(entity);
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

    public async Task<bool> UpdateAsync(Guid id, UpdateWorkerDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var entity = await _unitOfWork.Workers.GetByIdAsync(id);
            if (entity is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            _mapper.FromUpdateDto(entity, dto);
            await _unitOfWork.Workers.UpdateAsync(entity);
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
            var entity = await _unitOfWork.Workers.GetByIdAsync(id);
            if (entity is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            await _unitOfWork.Workers.DeleteAsync(id);
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
