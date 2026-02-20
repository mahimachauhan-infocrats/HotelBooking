using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Models
{
    public class StandardRoom : Room
    {
        public StandardRoom(int roomNumber, decimal price)
            : base(roomNumber, price) { }

        public override decimal CalculatePrice(int nights)
            => PricePerNight * nights;
    }
}
