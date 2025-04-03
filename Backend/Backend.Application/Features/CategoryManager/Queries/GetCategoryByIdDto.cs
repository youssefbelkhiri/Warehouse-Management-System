namespace Backend.Application.Features.CategoryManager.Queries
{
    public sealed class GetCategoryByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string DefaultUnit { get; set; } = string.Empty;
    }
}
