namespace OTManager.App.Dtos.Orders
{
    public class UpdateOrderDto
    {
        public string OrderNumber { get; set; } = string.Empty;
        public string? OrderType { get; set; }
        public Guid ClientId { get; set; }
        public bool Status { get; set; }
        public decimal TotalCost { get; set; }
        // Puedes agregar listas de servicios, materiales y trabajadores si tienes los DTOs
    }
}
