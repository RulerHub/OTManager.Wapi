using OTManager.App.Dtos.Clients;
using OTManager.App.Mappers.Interfaces;
using OTManager.App.Services.Interfaces;
using OTManager.Core.QueryParams;
using OTManager.Data.UoW;

namespace OTManager.App.Services.Implements;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IClientMapper _mapper;

    public ClientService(IUnitOfWork unitOfWork, IClientMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ReadClientDto>> GetAllAsync()
    {
        var clients = await _unitOfWork.Clients.GetAllAsync();
        return clients.Select(_mapper.ToEntityDto);
    }

    public async Task<(IEnumerable<ReadClientDto> Items, int TotalCount)> GetFilteredAsync(ClientQueryParams query)
    {
        var (items, total) = await _unitOfWork.Clients.GetFilteredAsync(query);
        return (items.Select(_mapper.ToEntityDto), total);
    }

    public async Task<ReadClientDto?> GetByIdAsync(Guid id)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(id);
        return client is null ? null : _mapper.ToEntityDto(client);
    }

    public async Task<ReadClientDto> CreateAsync(WriteClientDto dto)
    {
        var client = _mapper.FromWriteDto(dto);
        await _unitOfWork.Clients.AddAsync(client);
        await _unitOfWork.SaveChangesAsync();
        return _mapper.ToEntityDto(client);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateClientDto dto)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(id);
        if (client is null) return false;
        _mapper.FromUpdateDto(client, dto);
        await _unitOfWork.Clients.UpdateAsync(client);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var client = await _unitOfWork.Clients.GetByIdAsync(id);
        if (client is null) return false;
        await _unitOfWork.Clients.DeleteAsync(id);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }
}
