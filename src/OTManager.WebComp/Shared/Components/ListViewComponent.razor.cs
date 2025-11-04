using Microsoft.AspNetCore.Components;

namespace OTManager.WebComp.Shared.Components;

public partial class ListViewComponent
{
    /// <summary>
    /// Clase css opcional
    /// </summary>
    [Parameter] public string Class { get; set; } = string.Empty;
    [Parameter] public string Content { get; set; } = string.Empty;
    [Parameter] public string Username { get; set; } = string.Empty;
    [Parameter] public string Status { get; set; } = string.Empty;
    [Parameter] public DateTime LastModification { get; set; }
    [Parameter] public EventCallback OnOverseeEvent { get; set; }
    [Parameter] public EventCallback OnEditEvent { get; set; }
    [Parameter] public EventCallback OnDeleteEvent { get; set; }
}
