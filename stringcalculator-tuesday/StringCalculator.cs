
using System.ComponentModel;

namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        if (String.IsNullOrEmpty(numbers))
        {
            return 0;
        }

        var delim = new List<char> { ',', '\n' };
        string numberString = numbers;
        if (numbers.StartsWith("//"))
        {
            delim.Add(Convert.ToChar(numberString[2]));
            numberString = numbers.Substring(4);
        }

        var result = numberString.Split(delim.ToArray())
            .Select(s => int.Parse(s))
            .Sum();
        return result;
    }
}
