using OTManager.App.Dtos.Factures;
using OTManager.App.Mappers.Interfaces;
using OTManager.App.Services.Interfaces;
using OTManager.Core.QueryParams;
using OTManager.Data.UoW;

namespace OTManager.App.Services.Implements;

public class FactureService : IFactureService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IFactureMapper _mapper;

    public FactureService(IUnitOfWork unitOfWork, IFactureMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadFactureDto>> GetAllAsync()
    {
        var factures = await _unitOfWork.Factures.GetAllAsync();
        return factures.Select(_mapper.ToEntityDto);
    }

    public async Task<(IEnumerable<ReadFactureDto> Items, int TotalCount)> GetFilteredAsync(FactureQueryParams query)
    {
        var (items, total) = await _unitOfWork.Factures.GetFilteredAsync(query);
        return (items.Select(_mapper.ToEntityDto), total);
    }

    public async Task<ReadFactureDto?> GetByIdAsync(Guid id)
    {
        var facture = await _unitOfWork.Factures.GetByIdAsync(id);
        return facture is null ? null : _mapper.ToEntityDto(facture);
    }

    public async Task<ReadFactureDto> CreateAsync(WriteFactureDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var facture = _mapper.FromWriteDto(dto);
            await _unitOfWork.Factures.AddAsync(facture);
            await _unitOfWork.SaveChangesAsync();
            await _unitOfWork.CommitTransactionAsync();
            return _mapper.ToEntityDto(facture);
        }
        catch
        {
            await _unitOfWork.RollbackTransactionAsync();
            throw;
        }
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateFactureDto dto)
    {
        await _unitOfWork.BeginTransactionAsync();
        try
        {
            var facture = await _unitOfWork.Factures.GetByIdAsync(id);
            if (facture is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            _mapper.FromUpdateDto(facture, dto);
            await _unitOfWork.Factures.UpdateAsync(facture);
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
            var facture = await _unitOfWork.Factures.GetByIdAsync(id);
            if (facture is null)
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
            await _unitOfWork.Factures.DeleteAsync(id);
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
