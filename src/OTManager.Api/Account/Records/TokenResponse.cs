namespace OTManager.Api.Account.Records;

public record TokenResponse
(string AccessToken, DateTime ExpireAtUtc);
