using Microsoft.AspNetCore.Components.Authorization;

using OTManager.Web.ClientServices.Authorize;
using OTManager.Web.ClientServices.Authorize.AuthenticationService;
using OTManager.Web.Components;
using OTManager.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ApplicationDependencyInjection.AddApplicationDependency(builder.Services, builder.Configuration);

builder.Services.AddScoped<IAuthService, AuthService>();
// Use cookie-based token storage in the browser via JS
builder.Services.AddScoped<IAuthTokenProvider, CookieAuthTokenProvider>();
// Authorization message handler depends on IAuthTokenProvider
builder.Services.AddTransient<AuthorizationMessageHandler>();
// Register the authentication state provider and the notifier interface
builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<ApiAuthenticationStateProvider>());
builder.Services.AddScoped<IAuthStateNotifier>(sp => sp.GetRequiredService<ApiAuthenticationStateProvider>());

// Configure named HttpClient with AuthorizationMessageHandler
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7257/api/");
})
.AddHttpMessageHandler<AuthorizationMessageHandler>();

// Register UserService to use the named client "ApiClient"
builder.Services.AddScoped<UserService>(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    var client = factory.CreateClient("ApiClient");
    return new UserService(client);
});

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore(); // Use AddAuthorizationCore for Blazor

var app = builder.Build();

app.AddLocalizationBuilder();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
