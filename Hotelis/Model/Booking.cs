namespace Hotelis.Model
{
    public class Booking
    {
        public int ID { get; set; }
        public int HotelID { get; set; }
        public string HotelName { get; set; }
        public Rooms Room { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int PeopleCount { get; set; }
        public bool Breakfast { get; set; }
        public decimal Price { get; set; }


    }
}
