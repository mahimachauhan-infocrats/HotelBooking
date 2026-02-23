using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Models
{
    public struct BookingPeriod
    {
        public DateTime CheckIn { get; }
        public DateTime CheckOut { get; }

        public BookingPeriod(DateTime checkIn, DateTime checkOut)
        {
            if (checkOut <= checkIn)
                throw new ArgumentException("Invalid date range.");

            CheckIn = checkIn;
            CheckOut = checkOut;
        }

        public int TotalNights => (CheckOut - CheckIn).Days;
    }
}
