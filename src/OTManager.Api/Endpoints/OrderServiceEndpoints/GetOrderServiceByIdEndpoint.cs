using FastEndpoints;
using OTManager.App.Dtos.Orders;
using OTManager.App.Services.Interfaces;

namespace OTManager.Api.Endpoints.OrderServiceEndpoints;

public class GetOrderServiceByIdEndpoint : EndpointWithoutRequest
{
    private readonly IOrderServiceAppService _service;
    public GetOrderServiceByIdEndpoint(IOrderServiceAppService service) => _service = service;

    public override void Configure()
    {
        Get("/orderservices/{id:guid}");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Obtiene un servicio de orden por Id.";
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<Guid>("id");
        if (id == Guid.Empty)
        {
            AddError("id", "El id proporcionado no es válido.");
            await HttpContext.Response.SendErrorsAsync(ValidationFailures, 400, null, ct);
            return;
        }
        var result = await _service.GetByIdAsync(id);
        if (result is null)
        {
            await HttpContext.Response.SendAsync<object>(null, 404, null, ct);
            return;
        }
        await HttpContext.Response.SendAsync(result, 200, null, ct);
    }
}
