using FiltersApp;
using FiltersApp.Models;
using Xunit;

namespace NumbersFilterTests.ProductsTests;

public class CompareProductTests
{
    private readonly ProductFilter _productFilter = new();

    private static readonly Product Product1 = new()
    {
        Id = 1,
        Name = "А",
        Price = 10m
    };

    private static readonly Product Product2 = new()
    {
        Id = 2,
        Name = "Б",
        Price = 20m
    };

    private static readonly Product Product3 = new()
    {
        Id = 3,
        Name = "В",
        Price = 30m
    };

    [Fact]
    public void CompareProducts_ShouldPairItemsByPosition_WhenLengthsAreEqual()
    {
        // Arrange
        ICollection<Product> current = new List<Product> { Product1, Product2 };
        ICollection<Product> previous = new List<Product> { Product2, Product3 };

        // Act
        var result = _productFilter.CompareProducts(current, previous);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal(Product1, result[0].Item1);
        Assert.Equal(Product2, result[0].Item2);
        Assert.Equal(Product2, result[1].Item1);
        Assert.Equal(Product3, result[1].Item2);
    }

    [Fact]
    public void CompareProducts_ShouldUseMinLength_WhenCurrentLonger()
    {
        // Arrange
        ICollection<Product> current = new List<Product> { Product1, Product2, Product3 };
        ICollection<Product> previous = new List<Product> { Product1 };

        // Act
        var result = _productFilter.CompareProducts(current, previous);

        // Assert
        Assert.Single(result);
        Assert.Equal(Product1, result[0].Item1);
        Assert.Equal(Product1, result[0].Item2);
    }

    [Fact]
    public void CompareProducts_ShouldUseMinLength_WhenPreviousLonger()
    {
        // Arrange
        ICollection<Product> current = new List<Product> { Product1 };
        ICollection<Product> previous = new List<Product> { Product1, Product2, Product3 };

        // Act
        var result = _productFilter.CompareProducts(current, previous);

        // Assert
        Assert.Single(result);
        Assert.Equal(Product1, result[0].Item1);
        Assert.Equal(Product1, result[0].Item2);
    }

    [Fact]
    public void CompareProducts_ShouldThrow_WhenCurrentIsNull()
    {
        // Arrange
        ICollection<Product>? current = null!;
        ICollection<Product> previous = new List<Product>();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() =>
            _productFilter.CompareProducts(current, previous));
    }
}
