using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheaterWebsiteProject.Models;

namespace TheaterWebsiteProject.Controllers
{
    [Authorize]
    public class SnacksController : Controller
    {
        private readonly DataContext _context;

        public SnacksController(DataContext context)
        {
            _context = context;
        }

        // GET: Snacks
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Snacks.Include(s => s.Ticket);
            return View(await dataContext.ToListAsync());
        }

        // GET: Snacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snack = await _context.Snacks
                .Include(s => s.Ticket)
                .FirstOrDefaultAsync(m => m.SnackID == id);
            if (snack == null)
            {
                return NotFound();
            }

            return View(snack);
        }

        // GET: Snacks/Create
        public IActionResult Create()
        {
            ViewData["TicketID"] = new SelectList(_context.Tickets, "TicketID", "TicketID");
            return View();
        }

        // POST: Snacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SnackID,Food,Drink,Candy,TicketID")] Snack snack)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snack);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketID"] = new SelectList(_context.Tickets, "TicketID", "TicketID", snack.TicketID);
            return View(snack);
        }

        // GET: Snacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snack = await _context.Snacks.FindAsync(id);
            if (snack == null)
            {
                return NotFound();
            }
            ViewData["TicketID"] = new SelectList(_context.Tickets, "TicketID", "TicketID", snack.TicketID);
            return View(snack);
        }

        // POST: Snacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SnackID,Food,Drink,Candy,TicketID")] Snack snack)
        {
            if (id != snack.SnackID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnackExists(snack.SnackID))
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
            ViewData["TicketID"] = new SelectList(_context.Tickets, "TicketID", "TicketID", snack.TicketID);
            return View(snack);
        }

        // GET: Snacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snack = await _context.Snacks
                .Include(s => s.Ticket)
                .FirstOrDefaultAsync(m => m.SnackID == id);
            if (snack == null)
            {
                return NotFound();
            }

            return View(snack);
        }

        // POST: Snacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snack = await _context.Snacks.FindAsync(id);
            _context.Snacks.Remove(snack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnackExists(int id)
        {
            return _context.Snacks.Any(e => e.SnackID == id);
        }
    }
}
