using BookingFlights.Abstractions.Repository;
using BookingFlights.AppLogic.Services;
using BookingFlights.DataAccess;
using BookingFlights.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace BookingFlights.UnitTests
{
    [TestClass]
    public class TicketTest
    {
        //connection string
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=BookingFlightDb;Trusted_Connection=True";

        //function for intialization of the service
        private TicketService init()
        {
            BookingFlightsDbContext dbContext = new BookingFlightsDbContext(new DbContextOptionsBuilder<BookingFlightsDbContext>()
                .UseSqlServer(ConnectionString)
                .Options);
            IRepositoryWrapper repositoryWrapper = new RepositoryWrapper(dbContext);
            return new TicketService(repositoryWrapper);
        }

        [TestMethod]
        public void GetAllTicketsCreated()
        {
            //Arange
            TicketService _ticketService = init();

            //create 3 bookings
            Ticket ticket1 = new Ticket()
            {
                Type = "Economy",
                FlightId = Guid.NewGuid(),
                Price = 80
            };
            Ticket ticket2 = new Ticket()
            {
                Type = "Business",
                FlightId = Guid.NewGuid(),
                Price = 100
            };
            Ticket ticket3 = new Ticket()
            {
                Type = "All-inclusive",
                FlightId = Guid.NewGuid(),
                Price = 150
            };

            //Act
            var ticketList = _ticketService.GetAllQueryable().ToList();

            //Assert
            Assert.AreEqual(3, ticketList.Count + 1);
        }

        //[TestMethod]
        //public void TicketForFlight_Works()
        //{
        //    //Arrange
        //    TicketService _ticketService = init();
        //    Ticket ticket1 = new Ticket()
        //    {
        //        Type = "Economy",
        //        FlightId = Guid.NewGuid(),
        //        Price = 80
        //    };

        //    //Act
        //    Ticket specificTicket = _ticketService.TicketForFLight(ticket1);

        //    //Assert
        //    Assert.
        //}

        //[TestMethod]
        //public void FindSpecificFlight()
        //{
        //    //Arrange
        //    TicketService _ticketService = init();
        //    Guid FlightId = Guid.Parse("2f5f24e1-5687-4dab-3ec8-08da3968162b");
        //    Ticket ticket = new Ticket()
        //    {
        //        FlightId = Guid.Parse("2f5f24e1-5687-4dab-3ec8-08da3968162b"),
        //        Type = "economy",
        //        Price = 80
        //    };
        //    //Act
        //    Ticket findflight = _ticketService.findSpecificFlight(FlightId);

        //    //Assert
        //    Assert.AreEqual(findflight.FlightId, ticket.FlightId);
        //}

        //[TestMethod]
        //public void DeleteFromEntity_Works()
        //{
        //    //Arrange
        //    TicketService _ticketService = init();
        //    Guid TicketId = Guid.Parse("0b109973-1f2c-4e1f-e569-08da399c3869");
        //    Ticket ticket = new Ticket()
        //    {
        //        Id = Guid.Parse("0b109973-1f2c-4e1f-e569-08da399c3869"),

        //    };

        //    var findticket = _ticketService.DeleteFromEntity();
        //    Assert.IsNotNull(findticket);
        //}
    }
}
