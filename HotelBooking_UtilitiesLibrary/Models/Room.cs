using HotelBooking_UtilitiesLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelBooking.Models
{
    public abstract class Room
    {
        private readonly List<Booking> _bookings = new();

        public int RoomNumber { get; }
        public decimal PricePerNight { get; }
        public RoomType Type { get; }

        protected Room(int roomNumber, decimal pricePerNight)
        {
            RoomNumber = roomNumber;
            PricePerNight = pricePerNight;
        }


        public abstract decimal CalculatePrice(int nights);

        public bool IsAvailable(BookingPeriod period)
        {
            return !_bookings.Any(b => period.CheckIn < b.Period.CheckOut && period.CheckOut > b.Period.CheckIn);
        }

        internal void AddBooking(Booking booking)
        {
            _bookings.Add(booking);
        }
    }
}
