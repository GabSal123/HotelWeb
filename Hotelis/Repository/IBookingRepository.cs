using Hotelis.Model;

namespace Hotelis.Repository
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAll();
        Task<Booking?> Get(int id);
        Task<Booking?> Delete(int id);
        Task<Booking> Create(Booking booking);
        Task<Booking?> Update(Booking booking);

    }
}
