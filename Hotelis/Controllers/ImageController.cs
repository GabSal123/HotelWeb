using Hotelis.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Hotelis.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ImageController : ControllerBase
    {

        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }


        [HttpGet]
        public IActionResult GetImage(int hotelID)
        {

            var imagePath = _imageRepository.GetByHotelId(hotelID);
            if (!System.IO.File.Exists(imagePath))
            {
                return NotFound();
            }

            var image = System.IO.File.OpenRead(imagePath);
            return File(image, "image/jpg");
        }
    }
}
