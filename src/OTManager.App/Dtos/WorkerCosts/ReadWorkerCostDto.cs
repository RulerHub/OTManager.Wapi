namespace OTManager.App.Dtos.WorkerCosts;

public class ReadWorkerCostDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal HourlyRate { get; set; }
    public decimal HoursWorked { get; set; }
    public decimal TotalCost { get; set; }
    public Guid OrderId { get; set; }
}
