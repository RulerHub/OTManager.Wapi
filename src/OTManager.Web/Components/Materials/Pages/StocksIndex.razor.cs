using System.Reflection.Emit;

using Microsoft.FluentUI.AspNetCore.Components;

using OTManager.Core.QueryParams;
using OTManager.Web.ClientServices.Materials.Records;

namespace OTManager.Web.Components.Materials.Pages;

public partial class StocksIndex
{
    private MaterialQueryParams query = new(
            Search: string.Empty,
            Code: string.Empty,
            Name: string.Empty,
            CreatedAt: null,
            SortBy: "Name",
            Descending: false,
            Page: 1,
            PageSize: 10);

    private IQueryable<MaterialReadDto>? Items { get; set; }
    private MaterialQueryParams Query { get => query; set => query = value; }

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(500);
        await GetItemsAsync();
    }

    public void OnOversee(Guid Id)
    {
        NavigationManager.NavigateTo($"/oversee/{Id}");
    }
    
    public void OnEdit(Guid Id)
    {
        NavigationManager.NavigateTo($"/edite/{Id}");
    }

    public async Task OnDelete(Guid Id)
    {
        //var data = await GetItemByIdAsync(Id);


    }

    public async Task GetItemsAsync()
    {
        var response = await _materialService.GetFilteredAsync(Query);
        Items = response.AsQueryable();
    }

    //private async Task<MaterialReadDto> GetItemByIdAsync(Guid id)
    //{
    //    return await _materialService.GetByIdAsync(id);
    //}
}

