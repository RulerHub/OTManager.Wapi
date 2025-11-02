namespace OTManager.Api.Account.Records;

public record SessionInfo
(Guid UserId, string Username, IReadOnlyList<string> Roles, IReadOnlyList<string> Permissions);

