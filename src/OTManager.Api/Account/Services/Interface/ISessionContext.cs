using OTManager.Api.Account.Records;

namespace OTManager.Api.Account.Services.Interface;

public interface ISessionContext
{
    SessionInfo? GetCurrent();
    string? GetCorrelationId();
}
