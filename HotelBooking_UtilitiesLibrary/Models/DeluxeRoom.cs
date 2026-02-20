using HotelBooking_UtilitiesLibrary;

namespace HotelBooking.Models;

public class DeluxeRoom : Room
{
    public DeluxeRoom(int roomNumber, decimal price) : base(roomNumber, price) { }


    public override decimal CalculatePrice(int nights)
    {
        var basePrice = PricePerNight * nights; //protected access
        return basePrice + (basePrice * AppConstants.DeluxeChargePercentage);
    }
}
