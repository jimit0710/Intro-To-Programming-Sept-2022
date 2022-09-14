namespace CSharpSyntaxStuff;

public class AccountHolderTests
{
    [Fact]
    public void AccountHolderStuff()
    {
        var ah = new AccountHolder("Bob Smith", "xyz-pdq");
        var ah2 = new AccountHolder("Jill Jones", "9999") { Email = "Jill@aol.com" };

        // ah.Email = "Bob@aol.com";

        var name = ah.Name;
        // ah.Name = "Bob Smith";
        Assert.Equal("Bob Smith", ah.Name);

        // Assert.Equal("This Account Holder is Bob Smith", ah.GetInfo());

        var rover = new Dog()
        {
            Name = "Rover",
            Breed = "Terrier"
        };
        rover.RollOver();
    }
}
