using OTManager.Core.Entities.Abstracts;

namespace OTManager.Core.Entities.OT;

public class MaterialCost : Auditable<Guid>
{
    public string Code { get; set; } = string.Empty!;
    public string Name { get; set; } = string.Empty!;
    public string MeasureUnit { get; set; } = string.Empty!;
    public decimal UnitCost 
    { 
        get => _unitCost; 
        set { _unitCost = value; RecalculateTotalCost(); } 
    }
    public Guid OrderId { get; set; }
    public Order? Order { get; set; }
    public decimal Quantity 
    { 
        get => _quantity; 
        set { _quantity = value; RecalculateTotalCost(); } 
    }
    public decimal TotalCost { get; private set; }

    private decimal _unitCost;
    private decimal _quantity;

    private void RecalculateTotalCost() => TotalCost = UnitCost * Quantity;
}
