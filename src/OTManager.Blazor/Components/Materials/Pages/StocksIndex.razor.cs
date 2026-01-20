using Microsoft.AspNetCore.Components;
using Microsoft.FluentUI.AspNetCore.Components;

using OTManager.App.Dtos.Materials;

namespace OTManager.Web.Components.Materials.Pages;
public partial class StocksIndex
{
    private IQueryable<ReadMaterialDto>? Items { get; set; }

    private string nameFilter = string.Empty;
    private PaginationState pagination = new() { ItemsPerPage = 10 };
    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(500);
        await GetItemsAsync();
    }

    public void OnCreate()
    {
        NavigationManager.NavigateTo($"/create/new-material");
    }
    public void OnOversee(Guid Id)
    {
        NavigationManager.NavigateTo($"/oversee/{Id}/oversee-material");
    }

    public void OnEdit(Guid Id)
    {
        NavigationManager.NavigateTo($"/edite/{Id}/edite-material");
    }

    public async Task OnDelete(Guid Id)
    {
        await _materialService.DeleteAsync(Id);
        await GetItemsAsync();
    }

    public async Task GetItemsAsync()
    {
        var items = await _materialService.GetAllAsync();
        Items = items.AsQueryable();
    }

    private IQueryable<ReadMaterialDto>? FilteredItems => Items?.Where(x => x.Name.Contains(nameFilter, StringComparison.CurrentCultureIgnoreCase));
    private void HandlerMaterialFilter(ChangeEventArgs args)
    {
        if (args.Value is string value)
        {
            nameFilter = value;
        }
    }
    private void HandleClear()
    {
        if (string.IsNullOrWhiteSpace(nameFilter))
        {
            nameFilter = string.Empty;
        }
    }
}

