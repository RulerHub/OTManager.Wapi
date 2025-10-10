namespace OTManager.App.Dtos.WorkerCosts;

public class UpdateWorkerCostDto
{
    public string Name { get; set; } = string.Empty;
    public decimal HourlyRate { get; set; }
    public decimal HoursWorked { get; set; }
    public Guid OrderId { get; set; }
}
