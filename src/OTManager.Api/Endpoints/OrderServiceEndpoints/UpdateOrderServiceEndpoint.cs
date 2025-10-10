using FastEndpoints;
using OTManager.App.Dtos.Orders;
using OTManager.App.Services.Interfaces;

namespace OTManager.Api.Endpoints.OrderServiceEndpoints;

public class UpdateOrderServiceEndpoint : Endpoint<ReadOrderServiceDto>
{
    private readonly IOrderServiceAppService _service;
    public UpdateOrderServiceEndpoint(IOrderServiceAppService service) => _service = service;

    public override void Configure()
    {
        Put("/orderservices/{id:guid}");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Actualiza un servicio de orden existente.";
        });
    }

    public override async Task HandleAsync(ReadOrderServiceDto req, CancellationToken ct)
    {
        var id = Route<Guid>("id");
        if (id == Guid.Empty)
        {
            AddError("id", "El id proporcionado no es válido.");
            await HttpContext.Response.SendErrorsAsync(ValidationFailures, 400, null, ct);
            return;
        }
        if (string.IsNullOrWhiteSpace(req.Name)) AddError(r => r.Name, "El nombre es obligatorio.");
        if (req.Price < 0) AddError(r => r.Price, "El precio debe ser mayor o igual a 0.");
        if (ValidationFailed) return;
        var updated = await _service.UpdateAsync(id, req);
        if (!updated)
        {
            await HttpContext.Response.SendAsync<object>(null, 404, null, ct);
            return;
        }
        await HttpContext.Response.SendAsync(new { updated }, 200, null, ct);
    }
}
