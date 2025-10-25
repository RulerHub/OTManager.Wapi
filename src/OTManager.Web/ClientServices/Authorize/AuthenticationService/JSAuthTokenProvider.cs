using Microsoft.JSInterop;

namespace OTManager.Web.ClientServices.Authorize.AuthenticationService
{
    public class JSAuthTokenProvider : IAuthTokenProvider
    {
        private readonly IJSRuntime _js;
        private const string TokenKey = "token";

        public JSAuthTokenProvider(IJSRuntime js)
        {
            _js = js ?? throw new ArgumentNullException(nameof(js));
        }

        public async ValueTask<string?> GetTokenAsync()
        {
            try
            {
                return await _js.InvokeAsync<string>("localStorage.getItem", TokenKey);
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
                    await _js.InvokeVoidAsync("localStorage.removeItem", TokenKey);
                }
                else
                {
                    await _js.InvokeVoidAsync("localStorage.setItem", TokenKey, token);
                }
            }
            catch
            {
                // ignore errors from JS
            }
        }
    }
}
