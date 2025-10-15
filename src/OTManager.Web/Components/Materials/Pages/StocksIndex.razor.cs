namespace OTManager.Web.Components.Materials.Pages;

public partial class StocksIndex
{
    private IQueryable<Item>? Items { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(500);
        Items = GetDemoItems();
    }

    public static IQueryable<Item> GetDemoItems() => new List<Item>{
            new ("002", "Item 2", "U", 13.5m ),
            new ("002", "Item 2", "U", 13.5m),
            new ("002", "Item 2", "U", 13.5m),
            new ("002", "Item 2", "U", 13.5m),
            new ("002", "Item 2", "U", 13.5m),
            new ("002", "Item 2", "U", 13.5m)
        }.AsQueryable();

    public record Item(
        string Code,
        string Name,
        string MeasureUnit,
        decimal UnitCost
        );
}

