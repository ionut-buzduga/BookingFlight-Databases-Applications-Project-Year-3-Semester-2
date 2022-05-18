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
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly BookingFlightsDbContext _context;

        public TicketsController(BookingFlightsDbContext context, ITicketService _ticketService)
        {
            _context = context;
            this._ticketService = _ticketService;
        }

        // GET: Tickets
        public async Task<IActionResult> Index(Guid id)
        {
            Booking booking = new Booking{ UserName = "mitrica", FlightId = id};
            _context.Add(booking);
            await _context.SaveChangesAsync();
            var tickets = _ticketService.GetAllQueryable();
            return View(await tickets.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tickets = await _ticketService.GetAllQueryable()
               .FirstOrDefaultAsync(m => m.Id == id);
            if (tickets == null)
            {
                return NotFound();
            }

            return View(tickets);
        }

        [HttpPost]
        public async Task<IActionResult> chooseTicket1(Guid id)
        {
            
            return Redirect("/Seat/Index");
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Type,Price,FlightId,Id")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.Id = Guid.NewGuid();
                _ticketService.CreateFromEntity(ticket);
                await _ticketService.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _ticketService.GetAllQueryable().FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Type,Price,FlightId,Id")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ticketService.UpdateFromEntity(ticket);
                    _context.Entry(ticket).Property(u => u.FlightId).IsModified = false;
                    await _ticketService.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
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
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _ticketService.GetAllQueryable().FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var ticket = await _ticketService.GetAllQueryable().FirstOrDefaultAsync(m => m.Id == id);
            _ticketService.DeleteFromEntity(ticket);
            await _ticketService.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(Guid id)
        {
            return _ticketService.GetAllQueryable().Any(m => m.Id == id);
        }
    }
}
