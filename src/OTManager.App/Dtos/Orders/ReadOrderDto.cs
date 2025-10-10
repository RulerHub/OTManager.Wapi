namespace OTManager.App.Dtos.Orders
{
    public class ReadOrderDto
    {
        public Guid Id { get; set; }
        public string? OrderNumber { get; set; }
        public string? OrderType { get; set; }
        public Guid ClientId { get; set; }
        public string? ClientName { get; set; }
        public bool Status { get; set; }
        public decimal TotalCost { get; set; }
        // Puedes agregar listas de servicios, materiales y trabajadores si tienes los DTOs
    }
}
