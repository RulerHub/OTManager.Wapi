using FastEndpoints;
using OTManager.App.Dtos.Orders;
using OTManager.App.Services.Interfaces;

namespace OTManager.Api.Endpoints.OrderServiceEndpoints;

public class CreateOrderServiceEndpoint : Endpoint<ReadOrderServiceDto>
{
    private readonly IOrderServiceAppService _service;
    public CreateOrderServiceEndpoint(IOrderServiceAppService service) => _service = service;

    public override void Configure()
    {
        Post("/orderservices");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Crea un nuevo servicio de orden.";
        });
    }

    public override async Task HandleAsync(ReadOrderServiceDto req, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(req.Name)) AddError(r => r.Name, "El nombre es obligatorio.");
        if (req.Price < 0) AddError(r => r.Price, "El precio debe ser mayor o igual a 0.");
        if (ValidationFailed) return;
        var created = await _service.CreateAsync(req);
        await HttpContext.Response.SendAsync(created, 201, null, ct);
    }
}
