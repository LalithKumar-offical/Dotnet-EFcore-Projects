using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OrderRepository : IOrderRepository
    {
        public void SaveOrder()
        {
            Console.WriteLine("Order saved to database.");
        }
    }

}
