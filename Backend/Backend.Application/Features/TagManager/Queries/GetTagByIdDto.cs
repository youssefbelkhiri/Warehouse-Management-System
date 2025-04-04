namespace Backend.Application.Features.TagManager.Queries
{
    public sealed class GetTagByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
