namespace Backend.Application.Features.MovementManager.Queries
{
    public sealed class GetMovementByIdDto
    {
        public int Id { get; set; }
        public string MovementType { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int TotalQuantity { get; set; }
    }
}
