using Microsoft.AspNetCore.Components;

using OTManager.App.Dtos.Materials;

namespace OTManager.Web.Components.Materials.Pages;

public partial class MaterialOverseePage
{
    [Parameter]
    public Guid Id { get; set; } = default!;
    private ReadMaterialDto Item { get; set; } = default!;
    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(100);
        Item = await GetItemByIdAsync(Id);
    }
    private async Task<ReadMaterialDto> GetItemByIdAsync(Guid Id)
    {
        var response = await _materialService.GetByIdAsync(Id);
        if (response != null)
        {
            return response;
        }
        else
        {
            return default!;
        }
    }
}
