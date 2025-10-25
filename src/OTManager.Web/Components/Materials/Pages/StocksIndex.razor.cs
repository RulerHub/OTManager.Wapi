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
            new ("001", "Material 1", "U", 13.5m ),
            new ("002", "Material 2", "U", 13.5m),
            new ("003", "Material 3", "U", 13.5m),
            new ("004", "Material 4", "U", 13.5m),
            new ("005", "Material 5", "U", 13.5m),
            new ("006", "Material 6", "U", 13.5m)
        }.AsQueryable();

    public record Item(
        string Code,
        string Name,
        string MeasureUnit,
        decimal UnitCost
        );
}

