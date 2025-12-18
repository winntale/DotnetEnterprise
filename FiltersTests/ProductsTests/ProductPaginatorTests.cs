using FiltersApp;
using FiltersApp.Models;
using Xunit;

namespace NumbersFilterTests.ProductsTests;

public class ProductPaginatorTests
{
    private readonly ProductPaginator _paginator = new();
    private readonly List<ProductRecord> _products = new()
    {
        new(1, "P1", 100),
        new(2, "P2", 110),
        new(3, "P3", 120),
        new(4, "P4", 130),
        new(5, "P5", 140)
    };

    [Fact]
    public void GetPage_ShouldReturnFirstPage()
    {
        var result = _paginator.GetPage(_products, 0, 2);
        Assert.Equal(2, result.Count);
        Assert.Equal("P1", result[0].Name);
        Assert.Equal("P2", result[1].Name);
    }

    [Fact]
    public void GetPage_ShouldReturnMiddlePage()
    {
        var result = _paginator.GetPage(_products, 2, 2);
        Assert.Equal(2, result.Count);
        Assert.Equal("P3", result[0].Name);
        Assert.Equal("P4", result[1].Name);
    }

    [Fact]
    public void GetPage_ShouldReturnPartialLastPage()
    {
        var result = _paginator.GetPage(_products, 3, 3);
        Assert.Single(result);
        Assert.Equal("P4", result[0].Name);
    }

    [Fact]
    public void GetPage_ShouldReturnEmpty_WhenSkipExceedsCount()
    {
        var result = _paginator.GetPage(_products, 10, 5);
        Assert.Empty(result);
    }
}
