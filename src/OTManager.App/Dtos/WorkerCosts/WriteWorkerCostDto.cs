namespace OTManager.App.Dtos.WorkerCosts;

public class WriteWorkerCostDto
{
    public string Name { get; set; } = string.Empty;
    public decimal HourlyRate { get; set; }
    public decimal HoursWorked { get; set; }
    public Guid OrderId { get; set; }
}
