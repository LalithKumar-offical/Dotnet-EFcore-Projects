using System;

public class BankAccount
{
    private string _owner;
    private double _balance;

    public string Owner
    {
        get { return _owner; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Owner name cannot be empty.");
            _owner = value;
        }
    }

    public double Balance
    {
        get { return _balance; }
        private set
        {
            if (value < 0)
                throw new ArgumentException("Balance cannot be negative.");
            _balance = value;
        }
    }

    public BankAccount(string owner, double initialBalance)
    {
        Owner = owner;
        Balance = initialBalance;
    }

    public void Deposit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Deposit amount must be positive.");
        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Withdrawal must be positive.");
        if (amount > Balance)
            throw new InvalidOperationException("Insufficient funds.");
        Balance -= amount;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Create a bank account
            BankAccount account = new BankAccount("Lalith Kumar", 1000.0);

            Console.WriteLine($"Account Owner: {account.Owner}");
            Console.WriteLine($"Initial Balance: ₹{account.Balance}");

            // Deposit
            account.Deposit(500);
            Console.WriteLine($"After Deposit: ₹{account.Balance}");

            // Withdraw
            account.Withdraw(300);
            Console.WriteLine($"After Withdrawal: ₹{account.Balance}");

            // Try withdrawing more than balance
            account.Withdraw(2000); // Will throw exception
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.ReadLine(); // Keep the window open
    }
}
