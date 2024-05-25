namespace Hotelis.Model
{
    public class Hotel
    {
        public int HotelID { get; set; }

        public string HotelName { get; set;}

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }
 
    }

    


    public enum Rooms
    {
        Standard = 100,
        Deluxe = 150,
        Suite = 200
    }
}
