using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class OrderTypeHandler : IOrderTypeHandler
    {
        public void HandleOrderType(string productType)
        {
            if (productType == "Online")
                Console.WriteLine("Online order placed.");
            else if (productType == "Store")
                Console.WriteLine("Store order placed.");
            else
                Console.WriteLine("Unknown product type.");
        }
    }

}
