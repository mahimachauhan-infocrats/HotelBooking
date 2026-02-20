using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Utilities
{
    public static class Logger
    {
        public static void Log(string message)
        {
            Console.WriteLine($"[{DateTime.Now}] {message}");
        }
    }
}
