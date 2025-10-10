namespace OTManager.App.Mappers.Abstractions;

/// <summary>
/// Mappers
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TReadDto"></typeparam>
/// <typeparam name="TWriteDto"></typeparam>
/// <typeparam name="TUpdateDto"></typeparam>
public interface IMapper<TEntity, TReadDto, TWriteDto, TUpdateDto>
{
    /// <summary>
    /// Mapp the entity to dto
    /// </summary>
    /// <param name="entity"></param>
    /// <returns>The dto for the entity</returns>
    TReadDto ToEntityDto(TEntity entity);
    /// <summary>
    /// Mapp from Write dto
    /// </summary>
    /// <param name="dto"></param>
    /// <returns>The Writhed entity</returns>
    TEntity FromWriteDto(TWriteDto dto);
    /// <summary>
    /// Mapp from Update dto
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="dto"></param>
    /// <return>The updated entity</return>
    void FromUpdateDto(TEntity entity, TUpdateDto dto);
}
