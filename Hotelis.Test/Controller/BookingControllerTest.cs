using Hotelis.Controllers;
using Hotelis.Model;
using Hotelis.Repository;
using Hotelis.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelis.Test.Controller
{
    public class BookingControllerTest
    {
        private BookingController _controller;
        private Mock<IBookingRepository> _repo;

        public BookingControllerTest()
        {
            _repo = new Mock<IBookingRepository>();
            _controller = new BookingController(_repo.Object);
        }

        [Fact]
        public async Task GetAll_WithListOfBookings_ReturnsOkResult()
        {
            // Arrange


            var bookings = GetBookingData();
            _repo.Setup(repo => repo.GetAll()).ReturnsAsync(bookings);

            // Act

            var result = await _controller.GetAll();

            // Assert

            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Booking>>(okResult.Value);
            Assert.Equal(bookings, returnValue);
        }

        [Fact]
        public async Task Create_WithCreatedBooking_ReturnsOkResult()
        {
            // Arrange

            var booking = GetBooking();
            _repo.Setup(repo => repo.Create(It.IsAny<Booking>())).ReturnsAsync(booking);

            // Act


            var result = await _controller.Create(booking);

            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Booking>(okResult.Value);
            Assert.Equal(booking, returnValue);
        }

        [Fact]
        public async Task GetPriceFromBooking_WhenBookingDoesNotExist_ReturnsNotFound()
        {
            // Arrange

            _repo.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync((Booking)null);

            // Act

            var result = await _controller.GetPriceFromBooking(1);

            // Assert

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetPriceFromBooking_WithCalculatedPrice_ReturnsOkResult()
        {
            // Arrange

            var booking = GetBooking();
            _repo.Setup(repo => repo.Get(It.IsAny<int>())).ReturnsAsync(booking);
            var expectedPrice = 135;

            // Act

            var result = await _controller.GetPriceFromBooking(booking.ID);

            // Assert


            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<decimal>(okResult.Value);
            Assert.Equal(expectedPrice, returnValue);
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenBookingDoesNotExist()
        {
            // Arrange

            _repo.Setup(repo => repo.Delete(It.IsAny<int>())).ReturnsAsync((Booking)null);

            // Act

            var result = await _controller.Delete(1);

            // Assert

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_WithDeletedBooking_ReturnsOkResult()
        {
            // Arrange
 
            var bookings = GetBookingData();
            var bookingToDelete = bookings[0];

            _repo.Setup(repo => repo.Delete(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                var booking = bookings.FirstOrDefault(b => b.ID == id);
                if (booking != null)
                {
                    bookings.Remove(booking);
                }
                return booking;
            });

            _repo.Setup(repo => repo.GetAll()).ReturnsAsync(bookings);

            // Act


            var deleteResult = await _controller.Delete(1);
            var getAllResult = await _controller.GetAll();

            // Assert

            var okDeleteResult = Assert.IsType<OkObjectResult>(deleteResult);
            var returnValue = Assert.IsType<Booking>(okDeleteResult.Value);

            var okGetAllResult = Assert.IsType<OkObjectResult>(getAllResult);
            var remainingBookings = Assert.IsType<List<Booking>>(okGetAllResult.Value);

            Assert.Equal(bookingToDelete, returnValue);
            Assert.Equal(2, remainingBookings.Count); 
        }

        [Fact]
        public async Task Update_WhenBookingDoesNotExist_ReturnsNotFound()
        {
            // Arrange

            _repo.Setup(repo => repo.Update(It.IsAny<Booking>())).ReturnsAsync((Booking)null);

            // Act

            var result = await _controller.Update(GetBooking());

            // Assert

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Update_WithUpdatedBooking_ReturnsOkResult()
        {
            // Arrange

            var booking = GetBooking();
            _repo.Setup(repo => repo.Update(It.IsAny<Booking>())).ReturnsAsync(booking);

            // Act


            var result = await _controller.Update(booking);

            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Booking>(okResult.Value);
            Assert.Equal(booking, returnValue);
        }

        [Fact]
        public void GetPrice_WithCalculatedPrice_ReturnsOkResult()
        {
            // Arrange


            decimal roomCost = 100;
            int peopleCount = 2;
            bool breakfastOption = true;
            DateTime from = DateTime.Today;
            DateTime to = DateTime.Today.AddDays(2);
            var expectedPrice = 480;

            // Act

            var result = _controller.GetPrice(roomCost, peopleCount, breakfastOption, from, to);

            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<decimal>(okResult.Value);
            Assert.Equal(expectedPrice, returnValue);
        }



        private Booking GetBooking()
        {
            Booking booking = new Booking() 
            {
                ID = 1,
                HotelID = 1,
                HotelName = "Hotelis",
                Room = Rooms.Standard,
                From = new DateTime(year: 2024, month: 1, day: 1),
                To = new DateTime(year: 2024, month: 1, day: 2),
                PeopleCount = 1,
                Breakfast = true,
                Price = 0,
            };

            return booking;
        }
        private List<Booking> GetBookingData()
        {
            List<Booking> data = new List<Booking>
        {
            new Booking
            {
                ID = 1,
                HotelID = 1,
                HotelName = "Hotelis1",
                Room = Rooms.Standard,
                From = new DateTime(year: 2024, month: 1, day: 1),
                To = new DateTime(year: 2024, month: 1, day: 2),
                PeopleCount = 1,
                Breakfast = true,
                Price = 0,
            },
             new Booking
            {
                ID = 2,
                HotelID = 2,
                HotelName = "Hotelis2",
                Room = Rooms.Deluxe,
                From = new DateTime(year: 2024, month: 2, day: 2),
                To = new DateTime(year:2024,month: 2, day: 3),
                PeopleCount = 2,
                Breakfast = false,
                Price = 0,
            },
             new Booking
            {
                ID = 3,
                HotelID = 3,
                HotelName = "Hotelis3",
                Room = Rooms.Suite,
                From = new DateTime(year: 2024, month: 3, day: 3),
                To = new DateTime(year: 2024, month: 1, day: 4),
                PeopleCount = 3,
                Breakfast = true,
                Price = 0,
            },
        };
            return data;
        }


    }
}
