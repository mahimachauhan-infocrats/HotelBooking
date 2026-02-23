
using HotelBooking.Exceptions;
using HotelBooking.Interface;
using HotelBooking.Models;

namespace HotelBooking.Services;

public class BookingService : IBookingService
{
    public Booking CreateBooking(Hotel hotel,int roomNumber,string guestName, BookingPeriod period)
    {
        var room = hotel.GetRoom(roomNumber);

        if (room == null)
            throw new Exception("Room not found.");

        if (!room.IsAvailable(period))
            throw new RoomNotAvailableException("Room is already booked.");

        var totalPrice = room.CalculatePrice(period.TotalNights);

        var booking = new Booking(guestName, period, totalPrice);

        room.AddBooking(booking);

        return booking;
    }
}
