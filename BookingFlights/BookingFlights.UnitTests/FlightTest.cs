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
    public class FlightTest
    {
        //connection string
        private const string ConnectionString = @"Server=(localdb)\mssqllocaldb;Database=BookingFlightDb;Trusted_Connection=True";

        //function for intialization of the service
        private FlightService init()
        {
            BookingFlightsDbContext dbContext = new BookingFlightsDbContext(new DbContextOptionsBuilder<BookingFlightsDbContext>()
                .UseSqlServer(ConnectionString)
                .Options);
            IRepositoryWrapper repositoryWrapper = new RepositoryWrapper(dbContext);
            return new FlightService(repositoryWrapper);
        }

        [TestMethod]
        public void GetAllFlightsCreated()
        {
            //Arange
            FlightService _flightService = init();

            //Act
            var flightList = _flightService.GetAllQueryable().ToList();

            //Assert
            Assert.AreEqual(6, flightList.Count);
        }

        [TestMethod]
        public void SearchFlight_Works()
        {
            //Arange
            FlightService _flightService = init();
            Guid FlightId = Guid.Parse("71b931fb-1c09-4bb4-99ae-a04be89bbaf6");
            string FlightName = "Z3123";
            string departureCity = "Craiova";
            string arrivalCity = "Cluj";
            DateTime departureDate = new DateTime(2022, 05, 18, 23, 48, 00);

            //Act
            var searchflight = _flightService.SearchFlight(departureCity, arrivalCity, departureDate);

            //Assert
            Assert.IsNotNull(searchflight);
        }
    }
}
