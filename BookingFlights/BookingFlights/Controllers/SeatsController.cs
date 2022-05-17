﻿using System;
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
    public class SeatsController : Controller
    {
        
        private readonly ISeatService _seatService;
        private readonly IFlightService _flightService;

        public SeatsController(ISeatService seatService, IFlightService flightService)
        {
           
            _seatService = seatService;
            _flightService = flightService;
        }

        // GET: Seats
        public async Task<IActionResult> Index(Guid id)
        {
            var seats = _seatService.GetAllQueryable();
            if (id != null)
            {
                seats = _seatService.GetByCondition(seats => seats.FlightId == id);
                return View(await seats.ToListAsync());
            }
            else {
                var flights = _flightService.GetAllQueryable();
                return View(await flights.ToListAsync());
            }
            
        }

        // GET: Seats/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seat = await _seatService.GetAllQueryable()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (seat == null)
            {
                return NotFound();
            }

            return View(seat);
        }

        // GET: Seats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,isAvailable,Id")] Seat seat)
        {
            if (ModelState.IsValid)
            {
               seat.Id = Guid.NewGuid();
                _seatService.CreateFromEntity(seat);
                await _seatService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seat);
        }

        // GET: Seats/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seat = await _seatService.GetAllQueryable().FirstOrDefaultAsync(m => m.Id == id);
            if (seat == null)
            {
                return NotFound();
            }
            return View(seat);
        }

        // POST: Seats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(Guid id, [Bind("Number,isAvailable,Id")] Seat seat,Flight flight)
        {
            var seats = _seatService.GetAllQueryable();
            if (id != seat.Id)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                try
                {
                    _seatService.UpdateFromEntity(seat);
                    //_context.Entry(seat).Property(u => u.FlightId).IsModified = false;
                    _seatService.SeatForFLight(seat);
                    await _seatService.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeatExists(seat.Id))
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
            
            return View();
        }

        // GET: Seats/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seat = await _seatService.GetAllQueryable().FirstOrDefaultAsync(m => m.Id == id);
            if (seat == null)
            {
                return NotFound();
            }

            return View(seat);
        }

        // POST: Seats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var seat = await _seatService.GetAllQueryable().FirstOrDefaultAsync(m => m.Id == id);
            _seatService.DeleteFromEntity(seat);
            await _seatService.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeatExists(Guid id)
        {
            return _seatService.GetAllQueryable().Any(m => m.Id == id);
        }
    }
}
