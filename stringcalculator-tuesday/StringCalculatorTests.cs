
using System.Security.Cryptography.X509Certificates;

namespace StringCalculator;

public class StringCalculatorTests
{

    private StringCalculator calculator = new StringCalculator();

    [Fact]
    public void EmptyStringReturnsZero()
    {
        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("132", 132)]
    public void Length1ReturnsOne(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,4", 6)]
    public void TwoNumbersReturnSum(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3,4", 10)]
    [InlineData("2,4,8,16", 30)]
    public void MulitpleNumbersReturnSum(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
}

