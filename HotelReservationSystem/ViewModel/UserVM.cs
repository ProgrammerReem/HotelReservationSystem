using HotelReservationSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.ViewModel
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImagePath { get; set; } // Form - path "D:/Ahmed"()
        public IFormFile? ImageFile { get; set; } // Form - path "D:/Ahmed"()
        [DataType(DataType.Password)]
        public string Password { get; set; }//confirm password 
        public string Email { get; set; }
        public int phone { get; set; }
        public string? Role { get; set; } // Admin - User
        public int CardID { get; set; } 
        public int CardCvv { get; set; } 
        

    }
}
