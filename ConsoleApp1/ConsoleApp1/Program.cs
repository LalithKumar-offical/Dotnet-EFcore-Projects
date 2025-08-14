using ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        IOrderTypeHandler typeHandler = new OrderTypeHandler();
        IOrderRepository repository = new OrderRepository();
        IEmailService emailService = new EmailService();

        OrderProcessor processor = new OrderProcessor(typeHandler, repository, emailService);
        processor.ProcessOrder("Online", 100.0);
    }
}
