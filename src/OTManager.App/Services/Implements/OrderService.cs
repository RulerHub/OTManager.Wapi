using OTManager.App.Dtos.Orders;
using OTManager.App.Mappers.Interfaces;
using OTManager.App.Services.Interfaces;
using OTManager.Core.QueryParams;
using OTManager.Data.UoW;

namespace OTManager.App.Services.Implements;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IOrderMapper _mapper;

    public OrderService(IUnitOfWork unitOfWork, IOrderMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadOrderDto>> GetAllAsync()
    {
        var orders = await _unitOfWork.Orders.GetAllAsync();
        return orders.Select(_mapper.ToEntityDto);
    }

    public async Task<(IEnumerable<ReadOrderDto> Items, int TotalCount)> GetFilteredAsync(OrderQueryParams query)
    {
        var (items, total) = await _unitOfWork.Orders.GetFilteredAsync(query);
        return (items.Select(_mapper.ToEntityDto), total);
    }

    public async Task<ReadOrderDto?> GetByIdAsync(Guid id)
    {
        var order = await _unitOfWork.Orders.GetByIdAsync(id);
        return order is null ? null : _mapper.ToEntityDto(order);
    }

    public async Task<ReadOrderDto> CreateAsync(WriteOrderDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var order = _mapper.FromWriteDto(dto);
            await _unitOfWork.Orders.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
            return _mapper.ToEntityDto(order);
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateOrderDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            _mapper.FromUpdateDto(order, dto);
            await _unitOfWork.Orders.UpdateAsync(order);
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
            var order = await _unitOfWork.Orders.GetByIdAsync(id);
            if (order is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            await _unitOfWork.Orders.DeleteAsync(id);
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
