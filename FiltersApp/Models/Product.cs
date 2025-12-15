namespace FiltersApp.Models;

public class Product : IEquatable<Product>
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    
    public bool Equals(Product? other)
    {
        return Id == other?.Id && Name == other.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }
}