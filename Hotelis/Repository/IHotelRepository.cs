using Hotelis.Model;

namespace Hotelis.Repository
{
    public interface IHotelRepository
    {

        Task<List<Hotel>> GetAll();
        Task<Hotel?> GetById(int id);
        Task<List<Hotel>> GetByCity(string country);



    }
}
