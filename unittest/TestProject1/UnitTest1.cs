namespace TestProject
{
    public class BankAccountTests
    {
        private BankAccount account;

        [SetUp]
        public void Setup()
        {
            account = new BankAccount("Lalith", 1000);
        }
        [Test]
        public void TestOwnerSet()
        {
            account.Owner = "Kumar";
            Assert.AreEqual("Kumar", account.Owner);
        }
        [Test]
        public void TestDeposit()
        {
            account.Deposit(500);
            Assert.AreEqual(1500, account.Balance);
        }
        [Test]
        public void TestWithdraw()
        {
            account.Withdraw(300);
            Assert.AreEqual(700, account.Balance);
        }   
        [Test]
        public void TestOverWithdraw()
        {
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(2000));
        }

        [Test]
        public void TestNegativeDeposit()
        {
            Assert.Throws<ArgumentException>(() => account.Deposit(-100));
        }

        [Test]
        public void TestEmptyOwner()
        {
            Assert.Throws<ArgumentException>(() => account.Owner = "");
        }

        [Test]
        public void TestInitialNegativeBalance()
        {
            Assert.Throws<ArgumentException>(() => new BankAccount("Lalith", -500));
        }
        [TestCase("Lalith", 1000, 500, 1500)]
        [TestCase("Kumar", 200, 300, 500)]
        public void TestDepositParameterized(string owner, double initialBalance, double depositAmount, double expectedBalance)
        {
            BankAccount acc = new BankAccount(owner, initialBalance);
            acc.Deposit(depositAmount);
            Assert.AreEqual(expectedBalance, acc.Balance);
        }
        [Test] 
        public void TestBalanceStateChange()
        {
            double initial = account.Balance;
            account.Deposit(250);
            Assert.That(account.Balance, Is.EqualTo(initial + 250));
        }
    }
}