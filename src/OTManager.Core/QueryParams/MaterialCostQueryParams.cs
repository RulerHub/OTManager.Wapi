namespace OTManager.Core.QueryParams;

public record MaterialCostQueryParams(
    string? Search = null,
    string? Code = null,
    string? Name = null,
    DateTime? CreatedAt = null,
    string? SortBy = null,
    bool Descending = false,
    int Page = 1,
    int PageSize = 10
);
