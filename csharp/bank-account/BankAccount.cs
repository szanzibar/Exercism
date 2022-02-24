using System;

public class BankAccount
{
    private readonly object balanceLock = new object();
    private decimal balance;
    private bool isOpen;
    public void Open()
    {
        balance = 0;
        isOpen = true;
    }

    public void Close()
    {
        isOpen = false;
    }

    public decimal Balance
    {
        get
        {
            if (!isOpen) throw new InvalidOperationException();
            return balance;
        }
    }

    public void UpdateBalance(decimal change)
    {
        if (!isOpen) throw new InvalidOperationException();
        lock (balanceLock)
        {
            balance += change;
        }
    }
}
