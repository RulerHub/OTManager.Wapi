using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using OTManager.App.Dtos.Materials;

namespace OTManager.Web.Components.Materials.Pages;

public partial class MaterialEditPage
{
    private EditContext _editContext = default!;
    [Parameter]
    public ReadMaterialDto Content { get; set; } = new();

    [Parameter]
    public Guid Id { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        _editContext = new EditContext(Content);
        Content = await GetItemByIdAsync(Id);
    }

    private async Task<ReadMaterialDto> GetItemByIdAsync(Guid id)
    {
        var item = await _materialService.GetByIdAsync(id);
        if (item != null)
            return item;
        else return new();
    }
    private void Save()
    {
        _materialService.UpdateAsync(Id, Content);
        NavigationManager.NavigateTo($"/Materials/Index");
    }
    private void Cancel()
    {
        NavigationManager.NavigateTo($"/Materials/Index");
    }
}
