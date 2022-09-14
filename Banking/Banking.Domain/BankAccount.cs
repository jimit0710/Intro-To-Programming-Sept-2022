namespace Banking.Domain;

public class BankAccount
{
    private readonly ICalculateAccoutBonuses _bonusCalculator;

    public BankAccount(ICalculateAccoutBonuses bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }

    private decimal _balance = 5000M;

    public void Deposit(decimal amountToDeposit)
    {
        // Write the code you wish you had

        decimal bonus = _bonusCalculator.GetBonusForDepositOnAccount(100000, amountToDeposit);
        _balance += amountToDeposit + bonus;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (AccountHasAvailableFunds(amountToWithdraw))
        {
            _balance -= amountToWithdraw;
        } else
        {
            throw new OverdraftException();
        }
    }

    private bool AccountHasAvailableFunds(decimal amountToWithdraw)
    {
        return amountToWithdraw <= _balance;
    }
}