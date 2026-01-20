using OTManager.Api.Extensions;
using OTManager.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Usar el nombre de clase estático para evitar ambigüedad
ApplicationDependencyInjection.AddApplicationDependency(builder.Services, builder.Configuration);

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/api/v1.json");
}

app.AddSwaggerBuilder(app.Environment);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
