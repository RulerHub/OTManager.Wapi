using OTManager.Core.Entities.Abstracts;

namespace OTManager.Core.Entities.OT;

public class WorkerCost : Auditable<Guid>
{
    public string Name { get; set; } = string.Empty!;
    public decimal HourlyRate
    {
        get => _hourlyRate;
        set { _hourlyRate = value; RecalculateTotalCost(); }
    }
    public Guid OrderId { get; set; }
    public Order? Order { get; set; }
    public decimal HoursWorked
    {
        get => _hoursWorked;
        set { _hoursWorked = value; RecalculateTotalCost(); }
    }
    public decimal TotalCost { get; private set; }

    private decimal _hourlyRate;
    private decimal _hoursWorked;

    private void RecalculateTotalCost() => TotalCost = HourlyRate * HoursWorked;
}