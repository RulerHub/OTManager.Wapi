using System.Collections.ObjectModel;

using Microsoft.FluentUI.AspNetCore.Components;

namespace OTManager.Web.Components.Clients.Pages;

public partial class ClientsIndex
{
    private IQueryable<Item>? Items { get; set; }
    private ObservableCollection<Item> OverseeItems { get; set; } = [];
    private int SelectedIndex = 0;

    private Item? NewItem { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(500);
        Items = GetDemoItems();
        OverseeItems.CollectionChanged += (_, __) 
            => InvokeAsync(StateHasChanged);
    }

    public void OverseeClient(Item item)
    {
        OverseeItems.Add(item);
    }

    public void StopOverseeByIndex(int index)
    {
        if (index < 0 || index >= OverseeItems.Count) return;
        var wasSelected = SelectedIndex == index;
        OverseeItems.RemoveAt(index);

        if (OverseeItems.Count == 0) { 
            SelectedIndex   = -1;
            InvokeAsync(StateHasChanged);
            return;
        }

        if (wasSelected)
        {
            SelectedIndex = Math.Min(index, OverseeItems.Count - 1);
        }
        else if (index < SelectedIndex)
        {
            SelectedIndex--;
        }

        InvokeAsync(StateHasChanged);
    }

    public void HandleTabClose(FluentTab tab)
    {
        var client = (Item)tab.Data!;
        var index = OverseeItems.IndexOf(client);
        if (index == -1) return;
        StopOverseeByIndex(index);
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
