using OTManager.Core.Entities.Abstracts;

namespace OTManager.Core.Entities.OT;

public class ServiceCost : Auditable<Guid>
{
    public string Name { get; set; } = string.Empty!;
    public string Description { get; set; } = string.Empty!;
    public decimal Price
    {
        get => _price;
        set { _price = value; RecalculateTotalPrice(); }
    }
    public Guid OrderId { get; set; }
    public Order? Order { get; set; }
    public int Quantity
    {
        get => _quantity;
        set { _quantity = value; RecalculateTotalPrice(); }
    }
    public decimal TotalPrice { get; private set; }

    private decimal _price;
    private int _quantity;

    private void RecalculateTotalPrice() => TotalPrice = Quantity * Price;
}
