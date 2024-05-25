using Hotelis.Model;

namespace Hotelis.Services
{
    public static class BookingService
    {
        public static decimal CleaningFee = 20;
        public static decimal BreakfastCost = 15;

        public static decimal CalculatePriceFromId(Booking booking)
        {
            int stayLength = (booking.To - booking.From).Days;

            decimal breakfastCost = booking.Breakfast ? BreakfastCost * booking.PeopleCount * stayLength : 0;

            decimal price = (int)booking.Room * stayLength * booking.PeopleCount + breakfastCost + CleaningFee;

            booking.Price = price;

            return price;
        }


        public static decimal CalculatePrice(decimal roomCost, int peopleCount, bool breakfastOption, DateTime from, DateTime to)
        {
            int stayLength = (to - from).Days;
            decimal breakfastCost = breakfastOption ? stayLength * peopleCount * BreakfastCost : 0;

            decimal price = roomCost * stayLength * peopleCount + breakfastCost + CleaningFee;

            return price;
        }
    }
}
