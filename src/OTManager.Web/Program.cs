using OTManager.Web.ClientServices.Materials;
using OTManager.Web.Components;
using OTManager.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

ApplicationDependencyInjection.AddApplicationDependency(builder.Services, builder.Configuration);

// ToDo: move the logic to extension class
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7257/api/");
});

builder.Services.AddScoped<MaterialService>(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    var client = factory.CreateClient("ApiClient");
    return new MaterialService(client);
});

// ^^ move the logic to extension class ^^

builder.Services.AddOptions();
builder.Services.AddAuthorizationCore(); // Use AddAuthorizationCore for Blazor

var app = builder.Build();

app.MapDefaultEndpoints();

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
