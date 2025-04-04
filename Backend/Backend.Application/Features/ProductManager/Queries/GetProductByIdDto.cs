namespace Backend.Application.Features.ProductManager.Queries
{
    public sealed class GetProductByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryId { get; set; }
        public string DefaultQuantityUnit { get; set; } = null!;
        public bool HasDetails { get; set; }
    }
}
