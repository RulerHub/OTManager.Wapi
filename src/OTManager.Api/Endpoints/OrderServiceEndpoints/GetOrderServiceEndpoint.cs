using FastEndpoints;
using OTManager.App.Services.Interfaces;
using OTManager.Core.QueryParams;

namespace OTManager.Api.Endpoints.OrderServiceEndpoints;

public class GetOrderServiceEndpoint : Endpoint<OrderServiceQueryParams>
{
    private readonly IOrderServiceService _service;
    public GetOrderServiceEndpoint(IOrderServiceService service) => _service = service;

    public override void Configure()
    {
        Get("/orderservices");
        AllowAnonymous();
        Summary(s =>
        {
            s.Summary = "Obtiene una lista paginada de servicios de orden.";
            s.Description = "Devuelve servicios de orden filtrados y paginados.";
        });
    }

    public override async Task HandleAsync(OrderServiceQueryParams req, CancellationToken ct)
    {
        if (req.Page < 1) AddError(r => r.Page, "El número de página debe ser mayor o igual a 1.");
        if (req.PageSize < 1 || req.PageSize > 100) AddError(r => r.PageSize, "El tamaño de página debe estar entre 1 y 100.");
        if (ValidationFailed) return;
        var (items, total) = await _service.GetFilteredAsync(req);
        await HttpContext.Response.SendAsync(new { items, total }, 200, null, ct);
    }
}
