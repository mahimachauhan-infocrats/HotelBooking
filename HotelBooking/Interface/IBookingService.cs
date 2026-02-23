using HotelBooking.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Interface
{
    public interface IBookingService
    {
        Booking CreateBooking(  Hotel hotel,   int roomNumber,  string guestName, BookingPeriod period);
    }
}
