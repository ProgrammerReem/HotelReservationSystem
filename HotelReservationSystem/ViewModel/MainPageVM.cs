using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModel
{
    public class MainPageVM
    {
        //hotel - testimonials - ContactUs
        public List<Hotel> hotels {  get; set; }
        public ContactUsVM contactUs { get; set; }
        //testimonial
        //page content
        public List<Testimonial> testimonials { get; set; } 
        public PageContent pageContent { get; set; }
    }
    public class ContactUsVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string text { get; set; }
    }
}
