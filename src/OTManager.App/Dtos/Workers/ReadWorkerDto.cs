namespace OTManager.App.Dtos.Workers;

public class ReadWorkerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal HourlyRate { get; set; }
}
