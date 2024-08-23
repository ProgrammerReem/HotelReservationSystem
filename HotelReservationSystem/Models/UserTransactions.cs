namespace HotelReservationSystem.Models
{
    public class UserTransactions
    {
        public int Id { get; set; }

        public int UserID { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public decimal Price { get; set; }

        public int RoomId { get; set; }

        public User user { get; set; }
        public Room room { get; set; }

    }
}
