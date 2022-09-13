namespace Banking.Domain;

public class BankAccount
{
    private decimal _balance = 5000M;

    public void Deposit(decimal amountToDeposit)
    {
        _balance += amountToDeposit;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        _balance -= amountToWithdraw;
    }

    public decimal GetBalance()
    {
        return _balance;
    }
}