namespace OTManager.Core.QueryParams;

public record OrderQueryParams(
    string? Search = null,
    string? OrderNumber = null,
    DateTime? CreatedAt = null,
    string? SortBy = null,
    bool Descending = false,
    int Page = 1,
    int PageSize = 10
);
