using BookingFlights.Abstractions.Repository;
using BookingFlights.AppLogic.Services;
using BookingFlights.DataAccess;
using BookingFlights.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingFlights.UnitTests
{
    [TestClass]
    public class SeatTest
    {

        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=BookingFlightDb;Trusted_Connection=True";

        //function for intialization of the service
        private SeatService init()
        {
            BookingFlightsDbContext dbContext = new BookingFlightsDbContext(new DbContextOptionsBuilder<BookingFlightsDbContext>()
                .UseSqlServer(ConnectionString)
                .Options);
            IRepositoryWrapper repositoryWrapper = new RepositoryWrapper(dbContext);
            return new SeatService(repositoryWrapper);
        }

        [TestMethod]
        public void GetAllSeatsCreated()
        {
            //Arange
            SeatService _seatService = init();

            //Act
            var seatList = _seatService.GetAllQueryable().ToList();

            //Assert
            Assert.AreEqual(100, seatList.Count);
        }


        [TestMethod]
        public void GetByCondition()
        {
            //Arrange
            SeatService _seatService = init();
            Guid SeatId = Guid.Parse("ca8ef5a9-79a8-4a8a-57bc-08da3984ad00");
            Seat book = new Seat()
            {
                Id = Guid.Parse("ca8ef5a9-79a8-4a8a-57bc-08da3984ad00"),
                Number = 1,
                isAvailable = true,
                FlightId = Guid.Parse("bdc9b0c2-247d-4701-ead9-08da3984acee")

            };

            var findSeat = _seatService.GetByCondition(seat => seat.Id == SeatId);
            Assert.IsNotNull(findSeat);
        }
    }
}
