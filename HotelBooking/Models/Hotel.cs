using HotelBooking.Models;

namespace HotelBooking.Models;

public class Hotel
{
    private readonly List<Room> _rooms = new();

    public string Name { get; }

    public Hotel(string name)
    {
        Name = name;
    }

    public void AddRoom(Room room)
    {
        _rooms.Add(room);
    }

    public Room? GetRoom(int roomNumber)
    {
        return _rooms.FirstOrDefault(r => r.RoomNumber == roomNumber);
    }

    public List<Room> GetAllRooms() => _rooms;
}
