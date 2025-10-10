using FastEndpoints;
using OTManager.App.Dtos.Orders;
using OTManager.App.Services.Interfaces;

namespace OTManager.Api.Endpoints.OrderServiceEndpoints;

public class DeleteOrderServiceEndpoint : EndpointWithoutRequest
{
    private readonly IOrderServiceAppService _service;
    public DeleteOrderServiceEndpoint(IOrderServiceAppService service) => _service = service;

    public override void Configure()
    {
        Delete("/orderservices/{id:guid}");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Elimina un servicio de orden por su identificador.";
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
        var deleted = await _service.DeleteAsync(id);
        if (!deleted)
        {
            await HttpContext.Response.SendAsync<object>(null, 404, null, ct);
            return;
        }
        await HttpContext.Response.SendAsync(new { deleted }, 200, null, ct);
    }
}
