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
            Assert.AreEqual(75, seatList.Count);
        }


        [TestMethod]
        public void GetAllSeatsForFlight()
        {
            //Arrange
            SeatService _seatService = init();
            Guid SeatId = Guid.Parse("42fdf6f2-0bff-4ee6-3ec7-08da3968162b");
            

            var findSeat = _seatService.GetByCondition(seat => seat.FlightId == SeatId);
            
            foreach (var seat in findSeat)
            {
                Assert.IsNotNull(seat);
            }

            Assert.AreEqual(25, findSeat.Count());
        }

        [TestMethod]
        public void UpdateSpecificSeat()
        {
            SeatService seatService = init();

            Guid seatGuid = Guid.Parse("668e7f08-260a-4d8f-1fd9-08da3968163c");
            Guid flightGuid = Guid.Parse("42fdf6f2-0bff-4ee6-3ec7-08da3968162b");

            Seat seat = new Seat()
            {
                Id = Guid.Parse("668e7f08-260a-4d8f-1fd9-08da3968163c"),
                Number = 1,
                isAvailable = true,
                FlightId = Guid.Parse("42fdf6f2-0bff-4ee6-3ec7-08da3968162b")
            };

            seatService.UpdateFromEntity(seat);

            var specificSeat = seatService.GetByCondition(seat => seat.Id == seatGuid && seat.FlightId == flightGuid);

            foreach(Seat updatedSeat in specificSeat)
            {
                Assert.IsTrue(updatedSeat.isAvailable);
            }
        }
    }
}
