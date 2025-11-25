namespace FiltersApp.Models;

public sealed record User
{
    public required Guid Id { get; init; }
    public required int Age { get; init; }
    public string? Name { get; init; }
    public ICollection<Project>? Projects { get; init; }
}