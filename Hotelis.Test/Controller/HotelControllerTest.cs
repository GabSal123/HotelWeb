using Hotelis.Controllers;
using Hotelis.Model;
using Hotelis.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotelis.Test.Controller
{
    public class HotelControllerTest
    {
        private HotelController _controller;
        private Mock<IHotelRepository> _repo;

        public HotelControllerTest()
        {
            _repo = new Mock<IHotelRepository>();
            _controller = new HotelController(_repo.Object);
        }

        [Fact]
        public async Task GetAll_WithListOfHotels_ReturnsOkResult()
        {
            // Arrange

            var hotels = GetHotelData();
            _repo.Setup(repo => repo.GetAll()).ReturnsAsync(hotels);

            // Act


            var result = await _controller.GetAll();

            // Assert

            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Hotel>>(okResult.Value);
            Assert.Equal(hotels, returnValue);
        }

        [Fact]
        public async Task GetById_WhenHotelDoesNotExist_ReturnsNotFound()
        {
            // Arrange

            _repo.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((Hotel)null);

            // Act

            var result = await _controller.GetById(1);

            // Assert

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetById_WithHotel_ReturnsOkResult()
        {
            // Arrange

            var hotel = GetHotel();
            _repo.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(hotel);

            // Act


            var result = await _controller.GetById(1);

            // Assert


            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<Hotel>(okResult.Value);
            Assert.Equal(hotel, returnValue);
        }

        [Fact]
        public async Task GetByCity_WithHotelsInCity_ReturnsOkResult()
        {
            // Arrange


            var hotels = GetHotelData();
            _repo.Setup(repo => repo.GetByCity("Kaunas")).ReturnsAsync(hotels);

            // Act

            var result = await _controller.GetByCity("Kaunas");

            // Assert


            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnValue = Assert.IsType<List<Hotel>>(okResult.Value);
            Assert.Equal(hotels, returnValue);
        }



        private Hotel GetHotel()
        {
            Hotel hotel = new Hotel()
            {
                HotelID = 10,
                HotelName = "Hotelis",
                Country = "Lithuania",
                City = "Kaunas",
                Street = "Zaros",
                Number = "2-1"
            };
            return hotel;
        }
        private List<Hotel> GetHotelData()
        {
            List<Hotel> data = new List<Hotel>
        {
            new Hotel
            {
                HotelID = 1,
                HotelName = "Hotelis1",
                Country = "Lithuania",
                City = "Kaunas",
                Street = "Studentu",
                Number = "2-3"
            },
             new Hotel
            {
                HotelID = 2,
                HotelName = "Hotelis2",
                Country = "Lithuania",
                City = "Vilnius",
                Street = "Vilniaus",
                Number = "15"

            },
             new Hotel
            {
                HotelID = 3,
                HotelName = "Hotelis3",
                Country = "Lithuania",
                City = "Klaipeda",
                Street = "Nemuno",
                Number = "18"

            },
        };
            return data;
        }
    }
}

