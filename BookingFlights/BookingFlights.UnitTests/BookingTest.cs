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
    public class BookingTest
    {
        //connection string
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=BookingFlightDb;Trusted_Connection=True";
        
        //function for intialization of the service
        private BookingService init()
        {
            BookingFlightsDbContext dbContext = new BookingFlightsDbContext(new DbContextOptionsBuilder<BookingFlightsDbContext>()
                .UseSqlServer(ConnectionString)
                .Options);
            IRepositoryWrapper repositoryWrapper = new RepositoryWrapper(dbContext);
            return new BookingService(repositoryWrapper);
        }

        [TestMethod]
        public void GetAllBookingsCreated()
        {
            //Arange
           BookingService _bookingService = init();

            //Act
            var bookingList = _bookingService.GetAllQueryable().ToList();

            //Assert
            Assert.AreEqual(5, bookingList.Count);
        }

        [TestMethod]
        public void FindBookingBySpecificFlightIdEmail()
        {
            //Arrange
            Guid FlightId = Guid.Parse("42fdf6f2-0bff-4ee6-3ec7-08da3968162b");
            Guid FlightId2 = Guid.Parse("2f5f24e1-5687-4dab-3ec8-08da3968162b");
            string UserMail = "user@gmail.com";
            string UserMail2 = "user2@gmail.com";
            BookingService _bookingService = init();

            Booking validBook = new Booking()
            {
                Id = Guid.Parse("9c7321c6-ad3c-4c4c-e566-08da399c3869"),
                UserName = "user@gmail.com",
                FlightId = Guid.Parse("42fdf6f2-0bff-4ee6-3ec7-08da3968162b"),
                SeatId = Guid.Parse("d37fa453-fff0-4d4d-1fde-08da3968163c"),
                TicketId = Guid.Parse("04ed9f49-991f-4d96-8777-5824dcd3fd26")
            };
            
            //Act
            Booking findBooking = _bookingService.FindUser(FlightId,UserMail);
            Booking nofindBooking = _bookingService.FindUser(FlightId2, UserMail2);

            //Assert
            Assert.AreEqual(validBook.Id, findBooking.Id);
            Assert.AreNotEqual(validBook.Id, nofindBooking.Id);
        }

        [TestMethod]
        public void FindBookingBySpecificEmail()
        {
            //Arrange
            Guid FlightId = Guid.Parse("42fdf6f2-0bff-4ee6-3ec7-08da3968162b");
            string UserMail = "user@gmail.com";
            BookingService _bookingService = init();

            Booking validBook = new Booking()
            {
                Id = Guid.Parse("9c7321c6-ad3c-4c4c-e566-08da399c3869"),
                UserName = "user@gmail.com",
                FlightId = Guid.Parse("42fdf6f2-0bff-4ee6-3ec7-08da3968162b"),
                SeatId = Guid.Parse("d37fa453-fff0-4d4d-1fde-08da3968163c"),
                TicketId = Guid.Parse("04ed9f49-991f-4d96-8777-5824dcd3fd26")
            };

            //Act
            Booking findBooking = _bookingService.FindEmail(UserMail);

            //Assert
            Assert.AreEqual(validBook.Id, findBooking.Id);
        }

        [TestMethod]
        public void GetByCondition()
        {
            //Arrange
            BookingService _bookingService = init();
            Guid BookingId = Guid.Parse("0b109973-1f2c-4e1f-e569-08da399c3869");
            Booking book = new Booking()
            {
                Id = Guid.Parse("0b109973-1f2c-4e1f-e569-08da399c3869"),
                UserName = "user2@gmail.com",
                FlightId = Guid.Parse("2f5f24e1-5687-4dab-3ec8-08da3968162b"),
                SeatId = Guid.Parse("ccc92ae1-2f8b-4610-1ffa-08da3968163c"),
                TicketId = Guid.Parse("5b88dfc3-3086-4dc4-9b9c-8ff08c340e3f")
            };

            var findBooking = _bookingService.GetByCondition(booking => booking.Id == BookingId);
            Assert.IsNotNull(findBooking);
        }

        [TestMethod]
        public void UpdateEntity()
        {
            BookingService _bookingService = init();
            Guid BookingId = Guid.Parse("002bf5aa-641f-4cd1-e396-08da39b03124");
            Booking book = new Booking()
            {
                Id = BookingId,
                UserName = "use@gmail.com",
                FlightId = Guid.Parse("2f5f24e1-5687-4dab-3ec8-08da3968162b"),
                SeatId = Guid.Parse("d28c138b-6715-4096-1ff9-08da3968163c"),
                TicketId = Guid.Parse("e0350e18-62c4-413c-b09e-4eaecc0f46a9")
            };

            _bookingService.UpdateFromEntity(book);

            var specificBook = _bookingService.GetByCondition(book => book.Id == BookingId);

            foreach(Booking testBooking in specificBook)
            {
                Assert.AreEqual("use@gmail.com", book.UserName);
            }
        }

    }
}
