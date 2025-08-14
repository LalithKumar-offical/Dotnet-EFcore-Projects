using Xunit;

public class BankAccountTests
{
    private BankAccount account;

    public BankAccountTests()
    {
        account = new BankAccount("Lalith", 1000);
    }

    [Fact]
    public void Owner_Set_ValidName_UpdatesOwner()
    {
        account.Owner = "Kumar";
        Assert.Equal("Kumar", account.Owner);
    }

    [Fact]
    public void Deposit_ValidAmount_UpdatesBalance()
    {
        account.Deposit(500);
        Assert.Equal(1500, account.Balance);
    }

    [Fact]
    public void Withdraw_ValidAmount_UpdatesBalance()
    {
        account.Withdraw(300);
        Assert.Equal(700, account.Balance);
    }

    [Fact]
    public void Withdraw_TooMuch_ThrowsException()
    {
        Assert.Throws<InvalidOperationException>(() => account.Withdraw(2000));
    }

    [Fact]
    public void Deposit_NegativeAmount_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => account.Deposit(-100));
    }

    [Fact]
    public void Owner_SetEmptyName_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => account.Owner = "");
    }

    [Fact]
    public void Constructor_NegativeInitialBalance_ThrowsException()
    {
        Assert.Throws<ArgumentException>(() => new BankAccount("Lalith", -500));
    }
}
