using System.Net.Http.Json;
using OTManager.Web.ClientServices.DTOs.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;

namespace OTManager.Web.ClientServices.Authorize.AuthenticationService;

public class AuthService : IAuthService
{
    private readonly HttpClient _http;
    private readonly IAuthTokenProvider _tokenProvider;
    private readonly IAuthStateNotifier? _notifier;

    private const string ApiClientName = "ApiClient";

    public AuthService(IHttpClientFactory httpFactory, IAuthTokenProvider tokenProvider, AuthenticationStateProvider authStateProvider)
    {
        if (httpFactory == null) throw new ArgumentNullException(nameof(httpFactory));
        _http = httpFactory.CreateClient(ApiClientName);
        _tokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
        _notifier = authStateProvider as IAuthStateNotifier;
    }

    public async Task<string> GetTokenAsync()
    {
        try
        {
            var token = await _tokenProvider.GetTokenAsync();
            return token ?? string.Empty;
        }
        catch
        {
            return string.Empty;
        }
    }

    public async Task<LoginResponse?> LoginAsync(LoginRequest request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        var res = await _http.PostAsJsonAsync("session/login", new { Username = request.Username, Password = request.Password });
        if (!res.IsSuccessStatusCode)
        {
            var msg = await res.Content.ReadAsStringAsync();
            return new LoginResponse(false, null, msg);
        }

        var sessionResp = await res.Content.ReadFromJsonAsync<SessionWrapper>();
        if (sessionResp is null || !sessionResp.Success || sessionResp.Data?.Token is null)
        {
            return new LoginResponse(false, null, sessionResp?.Message ?? "Invalid response");
        }

        var token = sessionResp.Data.Token;
        await _tokenProvider.SetTokenAsync(token);

        try
        {
            _notifier?.NotifyUserAuthentication(token!);
        }
        catch
        {
            // ignore notifier errors
        }

        return new LoginResponse(true, token, sessionResp.Message);
    }

    public async Task LogOutAsync()
    {
        try
        {
            await _http.PostAsync("session/logout", null);
        }
        catch
        {
            // ignore logout errors
        }

        try
        {
            await _tokenProvider.SetTokenAsync(null);
        }
        catch
        {
            // ignore token provider errors
        }

        try
        {
            _notifier?.NotifyUserLogout();
        }
        catch
        {
            // ignore notifier errors
        }
    }

    public async Task<bool> RegisterAsync(RegisterRequest request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        var res = await _http.PostAsJsonAsync("session/register", request);
        return res.IsSuccessStatusCode;
    }

    // Internal types to map API generic response
    private class SessionWrapper
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public TokenData? Data { get; set; }
    }
    private class TokenData
    {
        public string? Token { get; set; }
        public object? SessionInfo { get; set; }
    }
}
