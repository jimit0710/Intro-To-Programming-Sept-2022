using Banking.Domain;

namespace Banking.UnitTests;

public class GoldAccountsGetBonusOnDeposit
{
    [Fact]
    public void BonusAppliedOnDeposits()
    {
        var account = new GoldAccount();
        var openingBalance = account.GetBalance();
        var amounToDeposit = 100M;

        account.Deposit(amounToDeposit);

        Assert.Equal(openingBalance + amounToDeposit + 10M, account.GetBalance());
    }
}

