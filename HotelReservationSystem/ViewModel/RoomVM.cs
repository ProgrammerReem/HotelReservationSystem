using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.ViewModel
{
    public class RoomVM
    {
        //room number - RoomType(xx) - Price -Decs - image - HoteNamex(xx)
        public int roomNumber { get; set; }
        [Required]
        public string RoomType { get; set; }
        public  List<string>? RoomTypes { get; set; } = new List<string>() { "Single", "Suite" ,"meeting","Party" };
        public decimal PriceByNight { get; set; }
        [Required]
        public string Desc { get; set; }
        public IFormFile? ImageFile { get; set; }

        public IEnumerable<SelectListItem>? Hotels { get; set; }
        //value - text 
        public int hotelId { get; set; }
        //id - hotel name - ImagePath
        public int id { get; set; } 
        public string HotelName { get; set; }
        public string? ImagePath { get; set;}
    }
}
