#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingFlights.DataAccess;
using BookingFlights.DataModel;
using BookingFlights.Abstractions.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BookingFlights.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly IFlightService _flightService;
       
        public BookingController(IBookingService bookingService, IFlightService flightService)
        {
            _bookingService = bookingService;
            _flightService = flightService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.Email);

            var booking = _bookingService.GetByCondition(booking => booking.UserName== userId);

            return View(booking);
        }

        public ActionResult IndexViewData()
        {
            ViewBag.Message = "Welcome to my demo!";
            ViewData["Flights"] = _flightService.GetAllQueryable();
            //ViewData["Seats"] = GetStudents();
            //ViewData["Tickets"] = GetStudents();
            return View();
        }
    }
}
