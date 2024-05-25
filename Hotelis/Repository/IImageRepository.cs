using Microsoft.AspNetCore.Mvc;

namespace Hotelis.Repository
{
    public interface IImageRepository
    {

        string? GetByHotelId(int hotelID);
    }
}
