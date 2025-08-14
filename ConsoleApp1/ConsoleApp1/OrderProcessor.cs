using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OrderProcessor
    {
        private readonly IOrderTypeHandler _orderTypeHandler;
        private readonly IOrderRepository _orderRepository;
        private readonly IEmailService _emailService;

        public OrderProcessor(IOrderTypeHandler orderTypeHandler, IOrderRepository orderRepository, IEmailService emailService)
        {
            _orderTypeHandler = orderTypeHandler;
            _orderRepository = orderRepository;
            _emailService = emailService;
        }

        public void ProcessOrder(string productType, double amount)
        {
            Console.WriteLine("Order processing started...");

            _orderTypeHandler.HandleOrderType(productType);
            _orderRepository.SaveOrder();
            _emailService.SendEmail();

            Console.WriteLine("Order processing finished.");
        }
    }

}
