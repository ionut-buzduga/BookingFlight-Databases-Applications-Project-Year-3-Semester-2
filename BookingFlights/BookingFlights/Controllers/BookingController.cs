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

namespace BookingFlights.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            //_context = context;
            _bookingService = bookingService;
        }

        public IActionResult Index()
        {
            var booking = _bookingService.GetByCondition(booking => booking.UserName=="mitrica");

            return View(booking);
        }


    }
}
