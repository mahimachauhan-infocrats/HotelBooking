using HotelBooking.Models;
using HotelBooking.Services;
using HotelBooking.Utilities;
using HotelBooking.Exceptions;
using HotelBooking_UtilitiesLibrary;

class Program
{
    static void Main()
    {
        var hotel = new Hotel("Grand Hotel");

        // Predefined rooms
        hotel.AddRoom(new StandardRoom(101, 100));
        hotel.AddRoom(new StandardRoom(102, 120));
        hotel.AddRoom(new DeluxeRoom(201, 200));
        hotel.AddRoom(new DeluxeRoom(202, 250));

        var bookingService = new BookingService();
        var paymentProcessor = new PaymentProcessor();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n===== HOTEL BOOKING SYSTEM =====");
            Console.WriteLine("1. View Rooms");
            Console.WriteLine("2. Book Room");
            Console.WriteLine("3. Exit");
            Console.Write("Select option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ViewRooms(hotel);
                    break;

                case "2":
                    BookRoom(hotel, bookingService, paymentProcessor);
                    break;

                case "3":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void ViewRooms(Hotel hotel)
    {
        Console.WriteLine("\nAvailable Rooms:");

        foreach (var room in hotel.GetAllRooms())
        {
            Console.WriteLine($"Room {room.RoomNumber} - Type: {room.Type} - Price: {room.PricePerNight} {AppConstants.Currency}");
        }
    }
    
    static void BookRoom(Hotel hotel, BookingService bookingService, PaymentProcessor paymentProcessor)
    {
        try
        {
            Console.Write("Enter Room Number: ");
            if (!int.TryParse(Console.ReadLine(), out int roomNumber))
            {
                Console.WriteLine("Invalid room number.");
                return;
            }

            Console.Write("Enter Guest Name: ");
            string guestName = Console.ReadLine();

            Console.Write("Enter Check-in Date (yyyy-mm-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime checkIn))
            {
                Console.WriteLine("Invalid check-in date.");
                return;
            }

            Console.Write("Enter Check-out Date (yyyy-mm-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime checkOut))
            {
                Console.WriteLine("Invalid check-out date.");
                return;
            }

            var period = new BookingPeriod(checkIn, checkOut);

            var booking = bookingService.CreateBooking(hotel, roomNumber, guestName, period);

            paymentProcessor.Process(booking.TotalPrice);

            Logger.Log($"Booking successful! Total price: {booking.TotalPrice} {AppConstants.Currency}");
        }
        catch (RoomNotAvailableException ex)
        {
            Logger.Log($"Room Error: {ex.Message}");
        }
        catch (InvalidBookingException ex)
        {
            Logger.Log($"Booking Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Logger.Log($"Unexpected Error: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Booking Done");
        }
    }
}
