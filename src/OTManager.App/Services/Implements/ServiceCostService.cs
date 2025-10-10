using OTManager.App.Dtos.ServiceCosts;
using OTManager.App.Mappers.Interfaces;
using OTManager.App.Services.Interfaces;
using OTManager.Core.QueryParams;
using OTManager.Data.UoW;

namespace OTManager.App.Services.Implements;

public class ServiceCostService : IServiceCostService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceCostMapper _mapper;

    public ServiceCostService(IUnitOfWork unitOfWork, IServiceCostMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadServiceCostDto>> GetAllAsync()
    {
        var items = await _unitOfWork.ServiceCosts.GetAllAsync();
        return items.Select(_mapper.ToEntityDto);
    }

    public async Task<(IEnumerable<ReadServiceCostDto> Items, int TotalCount)> GetFilteredAsync(ServiceCostQueryParams query)
    {
        var (items, total) = await _unitOfWork.ServiceCosts.GetFilteredAsync(query);
        return (items.Select(_mapper.ToEntityDto), total);
    }

    public async Task<ReadServiceCostDto?> GetByIdAsync(Guid id)
    {
        var item = await _unitOfWork.ServiceCosts.GetByIdAsync(id);
        return item is null ? null : _mapper.ToEntityDto(item);
    }

    public async Task<ReadServiceCostDto> CreateAsync(WriteServiceCostDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var entity = _mapper.FromWriteDto(dto);
            await _unitOfWork.ServiceCosts.AddAsync(entity);
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

    public async Task<bool> UpdateAsync(Guid id, UpdateServiceCostDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var entity = await _unitOfWork.ServiceCosts.GetByIdAsync(id);
            if (entity is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            _mapper.FromUpdateDto(entity, dto);
            await _unitOfWork.ServiceCosts.UpdateAsync(entity);
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
            var entity = await _unitOfWork.ServiceCosts.GetByIdAsync(id);
            if (entity is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            await _unitOfWork.ServiceCosts.DeleteAsync(id);
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
