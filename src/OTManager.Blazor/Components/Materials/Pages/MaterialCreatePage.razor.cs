using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

using OTManager.App.Dtos.Materials;

namespace OTManager.Web.Components.Materials.Pages;

public partial class MaterialCreatePage
{
    private EditContext _editContext = default!;
    [Parameter]
    public WriteMaterialDto Content { get; set; } = new();

    protected override void OnInitialized()
    {
        _editContext = new EditContext(Content);
    }

    private void Create()
    {
        _materialService.CreateAsync(Content);
        NavigationManager.NavigateTo($"/Materials/Index");
    }
    private void Cancel()
    {
        NavigationManager.NavigateTo($"/Materials/Index");
    }
}
