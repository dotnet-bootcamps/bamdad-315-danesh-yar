using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using App.Core.Domain.Entities;
using App.Infrastructures.Db.SqlServer.Ef.DbCtxs;

namespace App.EndPoints.TicketingUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PrioritiesController : Controller
    {
        private readonly AppDbContext _context;

        public PrioritiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Priorities
        public async Task<IActionResult> Index()
        {
            return View(await _context.TicketPriorities.ToListAsync());
        }

        // GET: Admin/Priorities/Details/5
        public async Task<IActionResult> Details(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPriority = await _context.TicketPriorities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketPriority == null)
            {
                return NotFound();
            }

            return View(ticketPriority);
        }

        // GET: Admin/Priorities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Priorities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Color")] TicketPriority ticketPriority)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketPriority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketPriority);
        }

        // GET: Admin/Priorities/Edit/5
        public async Task<IActionResult> Edit(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPriority = await _context.TicketPriorities.FindAsync(id);
            if (ticketPriority == null)
            {
                return NotFound();
            }
            return View(ticketPriority);
        }

        // POST: Admin/Priorities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(byte id, [Bind("Id,Title,Color")] TicketPriority ticketPriority)
        {
            if (id != ticketPriority.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketPriority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketPriorityExists(ticketPriority.Id))
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
            return View(ticketPriority);
        }

        // GET: Admin/Priorities/Delete/5
        public async Task<IActionResult> Delete(byte? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPriority = await _context.TicketPriorities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketPriority == null)
            {
                return NotFound();
            }

            return View(ticketPriority);
        }

        // POST: Admin/Priorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(byte id)
        {
            var ticketPriority = await _context.TicketPriorities.FindAsync(id);
            if (ticketPriority != null)
            {
                _context.TicketPriorities.Remove(ticketPriority);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketPriorityExists(byte id)
        {
            return _context.TicketPriorities.Any(e => e.Id == id);
        }
    }
}
