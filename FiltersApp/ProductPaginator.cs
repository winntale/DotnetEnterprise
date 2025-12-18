using FiltersApp.Models;

namespace FiltersApp;

internal sealed class ProductPaginator
{
    public List<ProductRecord> GetPage(List<ProductRecord> products, int skip, int take)
    {
        int count = products.Count;
        int startIndex = skip;
        int endIndex = Math.Min(skip + take, count);

        if (startIndex >= count)
            return [];
        
        return products[startIndex..endIndex];
    }
}

public class RangeDemonstration
{
    public void DemonstrateRangeUsage()
    {
        var products = new List<ProductRecord>
        {
            new(1, "Product_1", 100),
            new(2, "Product_2", 110),
            new(3, "Product_3", 120),
            new(4, "Product_4", 130),
            new(5, "Product_5", 140)
        };

        var paginator = new ProductPaginator();
        
        var page1 = paginator.GetPage(products, 0, 2);
        Console.WriteLine("Page 1: " + string.Join(", ", page1.Select(p => p.Name)));

        var page2 = paginator.GetPage(products, 2, 2);
        Console.WriteLine("Page 2: " + string.Join(", ", page2.Select(p => p.Name)));
        
        var page3 = paginator.GetPage(products, 4, 2);
        Console.WriteLine("Page 3: " + string.Join(", ", page3.Select(p => p.Name)));

        var emptyPage = paginator.GetPage(products, 10, 5);
        Console.WriteLine("Empty page: " + emptyPage.Count); // 0
    }
}