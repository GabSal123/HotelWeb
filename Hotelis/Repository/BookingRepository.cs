using Hotelis.Model;
using Hotelis.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Hotelis.Services;

namespace Hotelis.Repository
{
    public class BookingRepository : IBookingRepository
    {

        private readonly DatabaseContext.DatabaseContext _dbContext;

        public BookingRepository(DatabaseContext.DatabaseContext context)
        {
            _dbContext = context;
        }
        public async Task<Booking> Create(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
            await _dbContext.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking?> Delete(int id)
        {
            var booking =  await _dbContext.Bookings.FirstOrDefaultAsync(x=>x.ID.Equals(id));
            if(booking == null)
            {
                return null;
            }
            _dbContext.Bookings.Remove(booking);
            await _dbContext.SaveChangesAsync();
            return booking;

        }

        public Task<Booking?> Get(int id)
        {
            var booking = _dbContext.Bookings.FirstOrDefaultAsync(x=>x.ID.Equals(id));

            return booking;
        }

        public Task<List<Booking>> GetAll()
        {
            return _dbContext.Bookings.ToListAsync();
        }

        public async Task<Booking?> Update(Booking booking)
        {
            var result =await _dbContext.Bookings.FirstOrDefaultAsync(x=>x.ID.Equals(booking.ID));
            if (result == null)
            {
                return null;
            }
            result.Room = booking.Room;
            result.From = booking.From;
            result.To = booking.To;
            result.PeopleCount = booking.PeopleCount;
            result.Breakfast = booking.Breakfast;

            decimal price = BookingService.CalculatePriceFromId(result);

            result.Price = price;
            await _dbContext.SaveChangesAsync();
            return result;
        }
    }
}
