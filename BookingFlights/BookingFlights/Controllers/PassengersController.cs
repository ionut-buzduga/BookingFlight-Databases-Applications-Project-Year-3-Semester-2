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
    public class PassengersController : Controller
    {
       
        private readonly IPassengerService _passengerService;
        public PassengersController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        // GET: Passengers
        public async Task<IActionResult> Index()
        {
            var passengers = _passengerService.GetAllQueryable();
            return View(await passengers.ToListAsync());
        }

        // GET: Passengers/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _passengerService.GetAllQueryable()
               .FirstOrDefaultAsync(m => m.Id == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // GET: Passengers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passengers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassengerName,PassengerSurname,Email,Telephone,Id")] Passenger passenger)
        {
            if (ModelState.IsValid)
            {
                passenger.Id = Guid.NewGuid();
                _passengerService.CreateFromEntity(passenger);
                await _passengerService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passenger);
        }

        // GET: Passengers/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _passengerService.GetAllQueryable().FirstOrDefaultAsync(m => m.Id == id);
            if (passenger == null)
            {
                return NotFound();
            }
            return View(passenger);
        }

        // POST: Passengers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("PassengerName,PassengerSurname,Email,Telephone,Id")] Passenger passenger)
        {
            if (id != passenger.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _passengerService.UpdateFromEntity(passenger);
                    await _passengerService.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassengerExists(passenger.Id))
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
            return View(passenger);
        }

        // GET: Passengers/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passenger = await _passengerService.GetAllQueryable().FirstOrDefaultAsync(m => m.Id == id);
            if (passenger == null)
            {
                return NotFound();
            }

            return View(passenger);
        }

        // POST: Passengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var passenger = await _passengerService.GetAllQueryable().FirstOrDefaultAsync(m => m.Id == id);
            _passengerService.DeleteFromEntity(passenger);
            await _passengerService.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassengerExists(Guid id)
        {
            return _passengerService.GetAllQueryable().Any(m => m.Id == id);
        }
    }
}
