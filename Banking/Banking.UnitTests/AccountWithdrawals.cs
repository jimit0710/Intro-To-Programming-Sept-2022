using Banking.Domain;
using System.Net;

namespace Banking.UnitTests;

public class AccountWithdrawals
{

    private readonly BankAccount _account;
    private readonly decimal _openingBalance;

    public AccountWithdrawals()
    {
        _account = new BankAccount();
        _openingBalance = _account.GetBalance();
    }


    [Fact]
    public void WithdrawingMoneyDecreasesBalance()
    {
        var amountToWithdraw = 10M;
        _account.Withdraw(amountToWithdraw);
        Assert.Equal(_openingBalance - amountToWithdraw, _account.GetBalance());
    }

    [Fact]
    public void UsersCanWitdrawFullBalance()
    {
        _account.Withdraw(_account.GetBalance());
        Assert.Equal(0, _account.GetBalance());
    }

    //[Fact]
    //public void OverdraftIsCurrentlyAllowed()
    //{
    //    var account = new BankAccount();
    //    var openingBalance = account.GetBalance();
    //    var amountToWithdraw = openingBalance + .01M;

    //    account.Withdraw(amountToWithdraw);

    //    Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    //}

    [Fact]
    public void OverdraftDoesNotDecreaseBalance()
    {
        var amountToWithdraw = _openingBalance + .01M;

        try
        {
            _account.Withdraw(amountToWithdraw);
        }
        catch (OverdraftException)
        {
            // Swallow!
        }
        finally
        {
            Assert.Equal(_openingBalance, _account.GetBalance());
        }
    }

    [Fact]
    public void OverdraftThrowsAnException()
    {
        Assert.Throws<OverdraftException>(() =>
            _account.Withdraw(_account.GetBalance() + 1)
        );
    }
}
