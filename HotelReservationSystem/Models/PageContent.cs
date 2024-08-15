using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationSystem.Models
{
    public class PageContent
    {
        public int Id { get; set; }
        //Slider as image
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string ImagePath { get; set; }
        //About US => string
        public string AboutUs { get; set; }

        //contact us => string
        //? ConactUs Image
        public string ConactUs { get; set; }
        [NotMapped]
        public IFormFile ConactUsFile { get; set; }
        public string ConactUsPath { get; set; }
       

    }
}
