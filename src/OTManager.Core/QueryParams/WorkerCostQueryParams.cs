namespace OTManager.Core.QueryParams;

public record WorkerCostQueryParams(
    string? Search = null,
    string? Name = null,
    DateTime? CreatedAt = null,
    string? SortBy = null,
    bool Descending = false,
    int Page = 1,
    int PageSize = 10
);
