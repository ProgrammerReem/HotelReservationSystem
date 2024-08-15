using System.ComponentModel.DataAnnotations;

namespace HotelReservationSystem.ViewModel
{

    public class HotelsVM
    {
        [Required]
        public string Name { get; set; }

        public IFormFile? ImageFile { get; set; }
        public string? Desc { get; set; }
        [Required]

        public string Loc { get; set; }
      

    }
}
