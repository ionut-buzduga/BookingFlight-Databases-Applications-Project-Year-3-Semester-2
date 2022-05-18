using BookingFlights.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookingFlights.Controllers
{
    public class BookingController : Controller
    {
        private readonly BookingFlightsDbContext _context;

        public BookingController(BookingFlightsDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var booking = _context.Booking.Where(booking => booking.UserName=="mitrica");

            return View(booking);
        }
    }
}
