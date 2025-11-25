namespace FiltersApp.Models;

public sealed record Project
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}