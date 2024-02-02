using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Core.Domain.Entities;
using App.Infrastructures.Db.SqlServer.Ef.DbCtxs;

namespace App.EndPoints.TicketingUI.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class TicketsController : Controller
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Customer/Tickets
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Tickets.Include(t => t.Category).Include(t => t.CurrentStatus).Include(t => t.Priority);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Customer/Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Category)
                .Include(t => t.CurrentStatus)
                .Include(t => t.Priority)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: Customer/Tickets/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.TicketCategories, "Id", "Title");
            ViewData["CurrentStatusId"] = new SelectList(_context.TicketStatuses, "Id", "Title");
            ViewData["PriorityId"] = new SelectList(_context.TicketPriorities, "Id", "Title");
            return View();
        }

        // POST: Customer/Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Subject,CategoryId,PriorityId,CurrentStatusId,Description,SubmitedBy,SubmittedAt")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.TicketCategories, "Id", "Title", ticket.CategoryId);
            ViewData["CurrentStatusId"] = new SelectList(_context.TicketStatuses, "Id", "Title", ticket.CurrentStatusId);
            ViewData["PriorityId"] = new SelectList(_context.TicketPriorities, "Id", "Title", ticket.PriorityId);
            return View(ticket);
        }

        // GET: Customer/Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.TicketCategories, "Id", "Title", ticket.CategoryId);
            ViewData["CurrentStatusId"] = new SelectList(_context.TicketStatuses, "Id", "Title", ticket.CurrentStatusId);
            ViewData["PriorityId"] = new SelectList(_context.TicketPriorities, "Id", "Title", ticket.PriorityId);
            return View(ticket);
        }

        // POST: Customer/Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Subject,CategoryId,PriorityId,CurrentStatusId,Description,SubmitedBy,SubmittedAt")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
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
            ViewData["CategoryId"] = new SelectList(_context.TicketCategories, "Id", "Title", ticket.CategoryId);
            ViewData["CurrentStatusId"] = new SelectList(_context.TicketStatuses, "Id", "Title", ticket.CurrentStatusId);
            ViewData["PriorityId"] = new SelectList(_context.TicketPriorities, "Id", "Title", ticket.PriorityId);
            return View(ticket);
        }

        // GET: Customer/Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Tickets
                .Include(t => t.Category)
                .Include(t => t.CurrentStatus)
                .Include(t => t.Priority)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Customer/Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.Id == id);
        }
    }
}
