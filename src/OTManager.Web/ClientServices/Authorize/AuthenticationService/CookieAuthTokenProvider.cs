using Microsoft.JSInterop;

namespace OTManager.Web.ClientServices.Authorize.AuthenticationService
{
    public class CookieAuthTokenProvider : IAuthTokenProvider
    {
        private readonly IJSRuntime _js;
        private const string TokenKey = "token";
        private const int DefaultMaxAgeSeconds = 60 * 60; // 1 hour

        public CookieAuthTokenProvider(IJSRuntime js)
        {
            _js = js ?? throw new ArgumentNullException(nameof(js));
        }

        public async ValueTask<string?> GetTokenAsync()
        {
            try
            {
                // Read document.cookie via JS; returns string like "a=1; b=2"
                var cookie = await _js.InvokeAsync<string>("eval", "document.cookie");
                if (string.IsNullOrWhiteSpace(cookie)) return null;

                var parts = cookie.Split(';');
                foreach (var part in parts)
                {
                    var trimmed = part.Trim();
                    if (trimmed.StartsWith(TokenKey + "=", StringComparison.OrdinalIgnoreCase))
                    {
                        return Uri.UnescapeDataString(trimmed.Substring(TokenKey.Length + 1));
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public async ValueTask SetTokenAsync(string? token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    // Delete cookie
                    await _js.InvokeVoidAsync("eval", $"document.cookie = '{TokenKey}=; path=/; max-age=0; expires=Thu, 01 Jan 1970 00:00:00 GMT' ");
                }
                else
                {
                    var safe = Uri.EscapeDataString(token);
                    // Use secure, samesite=strict and a default max-age
                    await _js.InvokeVoidAsync("eval", $"document.cookie = '{TokenKey}={safe}; path=/; max-age={DefaultMaxAgeSeconds}; samesite=strict' ");
                }
            }
            catch
            {
                // ignore JS errors
            }
        }
    }
}
