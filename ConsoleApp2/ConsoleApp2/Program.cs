// See https://aka.ms/new-console-template for more information
using ConsoleApp2.Models;

namespace EFCoreConsoleKanini
{
    internal class test
    {
        public static void Main(String[] args)
        {
            AssContext book=new AssContext();
            foreach(var b in book.Bookings)
            {
                Console.WriteLine(b.BookingId.ToString());
            }

        }
    }
}
