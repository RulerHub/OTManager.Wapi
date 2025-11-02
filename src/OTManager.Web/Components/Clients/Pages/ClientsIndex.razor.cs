namespace OTManager.Web.Components.Clients.Pages;

public partial class ClientsIndex
{
    private IQueryable<Item>? Items { get; set; }

    private Item? NewItem { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(500);
        Items = GetDemoItems();
    }

    private void OnDeleteEvent()
    {

    }
    private void OnEditEvent()
    {

    }
    private void OnOverseeEvent()
    {

    }

    public static IQueryable<Item> GetDemoItems() => new List<Item>{
            new ("001", "Client 1", "U", 13.5m ),
            new ("002", "Client 2", "U", 13.5m),
            new ("003", "Client 3", "U", 13.5m),
            new ("004", "Client 4", "U", 13.5m),
            new ("005", "Client 5", "U", 13.5m),
            new ("006", "Client 6", "U", 13.5m)
        }.AsQueryable();

    public record Item(
        string Code,
        string Name,
        string MeasureUnit,
        decimal UnitCost
        );
}
