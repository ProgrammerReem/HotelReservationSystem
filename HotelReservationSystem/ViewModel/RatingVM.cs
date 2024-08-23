namespace HotelReservationSystem.ViewModel
{
    public class RatingVM
    {
        public List<int> RatingList { get; set; }   =new List<int>() { 1,2,3,4,5};
        
        public int Rating { get; set; }

        public int HotelId { get; set;}
    }
}
