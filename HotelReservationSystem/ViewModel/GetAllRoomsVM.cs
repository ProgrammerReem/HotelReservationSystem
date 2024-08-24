using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModel
{
    public class GetAllRoomsVM
    {
        public List<Room> Rooms { get; set; }

        public string? search {  get; set; }

        public DateTime To { get; set; }
        public DateTime From { get; set; }
    }
}
