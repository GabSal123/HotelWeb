using Hotelis.Model;
using Hotelis.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Hotelis.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hotels = await _hotelRepository.GetAll();

            return Ok(hotels);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var hotel = await _hotelRepository.GetById(id);

            if(hotel == null)
            {
                return NotFound();
            }
            else
            {
               return Ok(hotel);
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetRooms()
        {
            var values = Enum.GetValues(typeof(Rooms)).Cast<Rooms>()
                .Select(s => new { Name = s.ToString(), Number = (int)s }).ToList();
            
            if(values == null)
            {
                return NotFound();
            }
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetByCity(string city)
        {
            var result = await _hotelRepository.GetByCity(city);

            return Ok(result);

        }
    }

}

