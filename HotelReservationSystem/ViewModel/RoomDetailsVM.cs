using HotelReservationSystem.Models;

namespace HotelReservationSystem.ViewModel
{
    public class RoomDetailsVM
    {
        //room -  Addtest -Enroll
        public Room room { get; set; } 
        public AddTestimonialVM testimonialsVM {  get; set; }
        public ReservationVM resveration {  get; set; }

    }
    public class AddTestimonialVM
    {
        //Text - RoomID
        public string Text { get; set; }
        public int RoomId { get; set; }
    }
    public class ReservationVM //Enroll
    {
        //roomid - checkin - check out 
        public int roomid { get; set; }
        public DateTime checkIn { get; set; }
        public DateTime checkOut { get; set; }

    }
}
