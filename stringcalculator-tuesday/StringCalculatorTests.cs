
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
    [InlineData("18,12", 30)]
    [InlineData("18", 18)]
    public void TwoNumbersReturnSum(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3,4", 10)]
    [InlineData("2,4,8,16", 30)]
    [InlineData("10,12,14", 36)]
    public void MulitpleNumbersReturnSum(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2\n3,4", 10)]
    [InlineData("2\n4\n8\n16", 30)]
    [InlineData("1\n2,3", 6)]
    [InlineData("2,4,8\n16", 30)]
    public void NewlineNumbersReturnSum(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//;\n1;2;3;4", 10)]
    [InlineData("//.\n2.4.8.16", 30)]
    [InlineData("//:\n1:2:3", 6)]
    [InlineData("//{\n2{4{8{16", 30)]
    public void NewDelimeter(string numbers, int expected)
    {
        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
}

