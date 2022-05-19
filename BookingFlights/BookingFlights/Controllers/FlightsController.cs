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
using Microsoft.AspNetCore.Authorization;

namespace BookingFlights
{
    public class FlightsController : Controller
    {  
        private readonly IFlightService _flightService;
        private readonly ISeatService _seatService;
        private readonly ITicketService _ticketService;
        public FlightsController(IFlightService flightService , ISeatService seatService, ITicketService ticeketService)
        {
            _flightService = flightService;
            _seatService = seatService;
            _ticketService = ticeketService;
        }

        // GET: Flights
        [Authorize]
        public async Task<IActionResult> Index(string departureCity, string arrivalCity, DateTime departureDate)
        {
            if (departureCity != null && arrivalCity != null)
            {
               var specificFlight = _flightService.SearchFlight(departureCity, arrivalCity, departureDate);

               if (specificFlight.Any())
                {
                    return View(await specificFlight.ToListAsync());
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
                
               
            }
            var allFlights = _flightService.GetAllQueryable();
            return View(allFlights);
        }



        // GET: Flights/Details/5
        [Authorize]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _flightService.GetAllQueryable()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // GET: Flights/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Name,DepartureCity,ArrivalCity,departureDate,arrivalDate,Id")] Flight flight)
        {
            if (ModelState.IsValid)
            {

               
                
                _flightService.CreateFromEntity(flight);
                await _flightService.SaveAsync();
                for (int i = 1; i <= 25; i++)
                {
                    Seat seat = new Seat { Number = i, isAvailable = false, FlightId = flight.Id,Flight = flight};
                    flight.Seats.Add(seat);
                    await _seatService.SaveAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
            var flight = await _flightService.GetAllQueryable().FirstOrDefaultAsync(m => m.Id == id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,DepartureCity,ArrivalCity,departureDate,arrivalDate,Id")] Flight flight)
        {
            if (id != flight.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _flightService.UpdateFromEntity(flight);
                    await _flightService.SaveAsync();
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightExists(flight.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var flight = await _flightService.GetAllQueryable().FirstOrDefaultAsync(m => m.Id == id);
            
            if (flight == null)
            {
                return NotFound();
            }

            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var flight = await _flightService.GetAllQueryable().FirstOrDefaultAsync(m => m.Id == id);
            _flightService.DeleteFromEntity(flight);
           
            var seat = await _seatService.GetAllQueryable().FirstOrDefaultAsync(m => m.FlightId == id);

            _seatService.DeleteFromEntity(seat);

            await _seatService.SaveAsync();
            await _flightService.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(Guid id)
        {
            return _flightService.GetAllQueryable().Any(m => m.Id == id);
        }
    }
}
