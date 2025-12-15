using System;
using FiltersApp;
using Xunit;

namespace NumbersFilterTests.AggregationsTests;

public class ArrayCalculatorTests
{
    private readonly Aggregations.SumService _calculator = new();

    [Fact]
    public void SumCalculate_ShouldReturnSumCalculate_ForPositiveNumbers()
    {
        // Arrange
        int[] values = { 1, 2, 3, 4 };

        // Act
        var result = _calculator.SumCalculate(values);

        // Assert
        Assert.Equal(10, result);
    }

    [Fact]
    public void SumCalculate_ShouldReturnSumCalculate_ForNegativeAndPositiveNumbers()
    {
        // Arrange
        int[] values = { -5, 10, -3 };

        // Act
        var result = _calculator.SumCalculate(values);

        // Assert
        Assert.Equal(2, result);
    }

    [Fact]
    public void SumCalculate_ShouldThrowInvalidOperationException_ForEmptyArray()
    {
        // Arrange
        int[] values = [];

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => _calculator.SumCalculate(values));
    }

    [Fact]
    public void SumCalculate_ShouldThrowArgumentNullException_ForNullArray()
    {
        // Arrange
        int[]? values = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => _calculator.SumCalculate(values!));
    }
}
