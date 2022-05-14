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

namespace BookingFlights
{
    public class FlightsController : Controller
    {  
        private readonly IFlightService _flightService;
        public FlightsController(IFlightService flightService)
        {
            
            _flightService = flightService;
        }

        // GET: Flights
        public async Task<IActionResult> Index()
        {
            var flights = _flightService.GetAllQueryable();
            return View(await flights.ToListAsync());
        }

        // GET: Flights/Details/5
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,DepartureCity,ArrivalCity,departureDate,arrivalDate,Id")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                flight.Id = Guid.NewGuid();
               _flightService.CreateFromEntity(flight);
                await _flightService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        // GET: Flights/Edit/5
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
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {

            var flight = await _flightService.GetAllQueryable().FirstOrDefaultAsync(m => m.Id == id);
            _flightService.DeleteFromEntity(flight);
            await _flightService.SaveAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool FlightExists(Guid id)
        {
            return _flightService.GetAllQueryable().Any(m => m.Id == id);
        }
    }
}
