using OTManager.Web.ClientServices.DTOs.Identity;

namespace OTManager.Web.ClientServices.DTOs.Enterprises;

public record EnterpriseReadDto
{
    public string Id { get; set; } = default!;
    public string EnterpriseName { get; set; } = default!;
    public string Description { get; set; } = default!;

    public IEnumerable<UserReadDto> Users { get; set; } = [];

    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    public bool IsActive { get; set; }
    public bool IsSortable { get; set; }
    public bool IsDeleted { get; set; }
}
