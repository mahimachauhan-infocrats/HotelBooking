
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Models
{
    public class Booking 
    {
        public string GuestName { get; }
        public BookingPeriod Period { get; }
        public decimal TotalPrice { get; }

        public Booking(string guestName, BookingPeriod period, decimal totalPrice)
        {
            GuestName = guestName;
            Period = period;
            TotalPrice = totalPrice;
        }
    }
}
