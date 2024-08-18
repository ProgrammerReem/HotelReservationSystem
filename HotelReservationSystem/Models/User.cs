using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Models
{
    public class User
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; } // Form - path "D:/Ahmed"()
        public string Password { get; set; }
        public string Email { get; set; }
        public int phone { get; set; }
        public string Role { get; set; } // Admin - User
        public DateTime CreatedAT { get; set; } = DateTime.Now;

        public List<Reservation> reservations { get; set; }
        public List<Resident> Residents { get; set; }
        public List<Testimonial> testimonials { get; set; }
        public List<UserTransactions> userTransactions { get; set; }



    }
}
