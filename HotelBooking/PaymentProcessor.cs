using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Utilities
{
    public sealed class PaymentProcessor
    {
        public bool Process(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount}");
            return true;
        }
    }
}
