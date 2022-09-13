﻿namespace Banking.Domain;

public class BankAccount
{
    private decimal _balance = 5000M;

    public void Deposit(decimal amountToDeposit)
    {
        _balance += amountToDeposit;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw <= _balance)
        {
            _balance -= amountToWithdraw;
        } else
        {
            throw new OverdraftException();
        }
    }

    public decimal GetBalance()
    {
        return _balance;
    }
}