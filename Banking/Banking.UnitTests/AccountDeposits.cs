using Banking.Domain;
namespace Banking.UnitTests;

public class AccountDeposits
{
    [Fact]
    public void MNakingADepositIncreasesTheBalance()
    {
        // Given
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 10.15M;
        // When
        account.Deposit(amountToDeposit);
        // Then
        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance());
    }
}
