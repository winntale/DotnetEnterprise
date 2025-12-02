namespace FiltersApp.Models;

public sealed record Course
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required Guid StudentId { get; init; }
}