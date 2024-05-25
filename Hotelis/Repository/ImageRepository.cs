using Microsoft.AspNetCore.Mvc;


namespace Hotelis.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly DatabaseContext.DatabaseContext _dbContext;

        public ImageRepository(DatabaseContext.DatabaseContext context)
        {
            _dbContext = context;
        }
        public string? GetByHotelId(int hotelID)
        {
            var image = _dbContext.Images.Where(x=>x.HotelID == hotelID).FirstOrDefault();

            if(image == null) 
            {
                return null;
            }

            return image.ImagePath;
        }
    }
}
