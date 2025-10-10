using OTManager.Api.Extensions;
using FastEndpoints;

var builder = WebApplication.CreateBuilder(args);

// Usar el nombre de clase estático para evitar ambigüedad
ApplicationDependencyInjection.AddApplicationDependency(builder.Services, builder.Configuration);
builder.Services.AddFastEndpoints();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/api/v1.json");
}

app.AddSwaggerBuilder(app.Environment);

app.UseHttpsRedirection();

app.UseFastEndpoints();

app.Run();
