namespace FiltersApp.Models;

public record Paginate<T>
{
    public required List<T> CurrentPageUsers { get; init; }
    public required int TotalCount { get; init; }
}