using OTManager.Core.QueryParams;
using OTManager.Web.ClientServices.Materials.Records;

namespace OTManager.Web.Components.Materials.Pages;

public partial class StocksIndex
{
    private MaterialQueryParams query = new(
            Search: "PitBoy",
            Code: string.Empty,
            Name: string.Empty,
            CreatedAt: null,
            SortBy: "Name",
            Descending: false,
            Page: 1,
            PageSize: 3);

    private IQueryable<MaterialReadDto>? Items { get; set; }
    private MaterialQueryParams Query { get => query; set => query = value; }
    private MaterialReadDto? Item { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(500);
        await GetItemsAsync();
    }

    public async Task GetItemsAsync()
    {
        var response = await _materialService.GetFilteredAsync(Query);
        Items = response.AsQueryable();
    }

    private async Task GetItemByIdAsync(string id)
    {
        var response = await _materialService.GetByIdAsync(id);
        if (response is not null)
        {
            Item = response;
        }
        else
        {
            Item = null;
        }
    }
}

