using FiltersApp.Models;

namespace FiltersApp;

public class ProductFilter
{
    public List<(Product Current, Product? Previous)> CompareProducts(
        ICollection<Product> currentProducts,
        ICollection<Product> previousProducts)
    {
        return currentProducts
            .Zip(previousProducts,
                (current, previous) => (current, (Product?)previous))
            .ToList();
    }
}