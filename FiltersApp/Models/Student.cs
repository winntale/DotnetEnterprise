namespace FiltersApp.Models;

public sealed record Student
{
    public required Guid Id { get; init; }
    public required string FullName { get; init; }
}