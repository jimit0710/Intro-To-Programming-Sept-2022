using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace CSharpSyntaxStuff;

public class AccountHolder
{
       
   public AccountHolder(string name, string accountNumber)
    {
        Name = name;
        AccountNumber = accountNumber;
    }

    //public string Name
    //{
    //    get { return _name; }
    //    set { _name = value; }
    //}
    // backing field
    public string Name { get; set; } = string.Empty;

    // "Auto Property"
    public string Email { get; init; } = string.Empty;
    
    public string AccountNumber { get; private set; } = string.Empty; 

    public string GetInfo()
    {
        return $"This Account Holder is {Name} and reach them at {Email}";
    }
}

public class Dog
{
    public string Name { get; set; }
    public string Breed { get; set; }
    public void RollOver()
    {

    }
}
