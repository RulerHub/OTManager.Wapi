namespace OTManager.Core.QueryParams;

public record ClientQueryParams
(string? Search, string? SortBy, bool Descending = false, int Page = 1, int PageSize = 10);
