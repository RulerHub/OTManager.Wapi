using System.Net.Http.Headers;

namespace OTManager.Web.ClientServices.Authorize.AuthenticationService;

public class AuthorizationMessageHandler : DelegatingHandler
{
    private readonly IAuthTokenProvider _tokenProvider;

    public AuthorizationMessageHandler(IAuthTokenProvider tokenProvider)
    {
        _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        try
        {
            var token = await _tokenProvider.GetTokenAsync();
            if (!string.IsNullOrWhiteSpace(token)) request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        catch
        {
            // ignore token provider issues
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
