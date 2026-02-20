using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Exceptions
{
    public class RoomNotAvailableException : Exception
    {
        public RoomNotAvailableException(string message)
            : base(message) { }
    }

    public class InvalidBookingException : Exception
    {
        public InvalidBookingException(string message) : base(message)
        {
        }
    }
}
