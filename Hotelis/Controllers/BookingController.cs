using Hotelis.Model;
using Hotelis.Repository;
using Hotelis.Services;
using Microsoft.AspNetCore.Mvc;

namespace Hotelis.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookingController : ControllerBase
    {

        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var booking = await _bookingRepository.GetAll();

            return Ok(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            var result = await _bookingRepository.Create(booking);
            
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPriceFromBooking(int bookingId)
        {
            var booking = await _bookingRepository.Get(bookingId);
            if(booking == null)
            {
                return NotFound();
            }
            var price = BookingService.CalculatePriceFromId(booking);

            return Ok(price);
        }


        [HttpGet]
        public async Task<IActionResult> GetPrice(decimal roomCost, int peopleCount, bool breakfastOption,DateTime from, DateTime to)
        {
            decimal price = BookingService.CalculatePrice(roomCost, peopleCount, breakfastOption, from, to);

            return Ok(price);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookingRepository.Delete(id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Booking booking)
        {
            var result = await _bookingRepository.Update(booking);

            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
