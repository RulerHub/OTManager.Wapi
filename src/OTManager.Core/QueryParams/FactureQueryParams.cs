namespace OTManager.Core.QueryParams;

public record FactureQueryParams
    (string? Search = null,
     string? Code = null,
     DateTime? CreatedAt = null,
     string? SortBy = null,
     bool Descending = false,
     int Page = 1,
     int PageSize = 10);
