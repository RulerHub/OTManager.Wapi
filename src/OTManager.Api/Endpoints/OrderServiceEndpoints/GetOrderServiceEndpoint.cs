using FastEndpoints;
using OTManager.App.Dtos.Orders;
using OTManager.App.Services.Interfaces;

namespace OTManager.Api.Endpoints.OrderServiceEndpoints;

public class GetOrderServiceEndpoint : EndpointWithoutRequest
{
    private readonly IOrderServiceAppService _service;
    public GetOrderServiceEndpoint(IOrderServiceAppService service) => _service = service;

    public override void Configure()
    {
        Get("/orderservices");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Obtiene todos los servicios de orden.";
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var result = await _service.GetAllAsync();
        await HttpContext.Response.SendAsync(result, 200, null, ct);
    }
}
