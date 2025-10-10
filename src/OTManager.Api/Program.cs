using OTManager.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDependency(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi("/api/v1.json");
}

app.AddSwaggerBuilder(app.Environment);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
