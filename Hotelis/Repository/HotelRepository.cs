using Hotelis.DatabaseContext;
using Hotelis.Model;
using Microsoft.EntityFrameworkCore;

namespace Hotelis.Repository
{
    public class HotelRepository : IHotelRepository
    {
        private readonly DatabaseContext.DatabaseContext _dbContext;

        public HotelRepository(DatabaseContext.DatabaseContext context)
        {
            _dbContext = context;
        }


        public Task<List<Hotel>> GetAll()
        {
            return _dbContext.Hotels.ToListAsync();
        }

        public Task<List<Hotel>> GetByCity(string city)
        {
            return _dbContext.Hotels.Where(x => x.City.StartsWith(city)).ToListAsync();
        }

        public Task<Hotel?> GetById(int id)
        {
            return _dbContext.Hotels.Where(x => x.HotelID.Equals(id)).FirstOrDefaultAsync();
        }

       
    }
}
