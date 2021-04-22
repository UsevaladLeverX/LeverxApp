using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Leverx.Data;
using Leverx.Models;

namespace Leverx.Controllers
{
    public class MenteesController : Controller
    {
        private readonly LeverxContextDb _context;

        public MenteesController(LeverxContextDb context)
        {
            _context = context;
        }

        // GET: Mentees
        public async Task<IActionResult> Index()
        {
            var leverxContextDb = _context.Mentee.Include(m => m.Level);
            return View(await leverxContextDb.ToListAsync());
        }

        // GET: Mentees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentee = await _context.Mentee
                .Include(m => m.Level)
                .FirstOrDefaultAsync(m => m.MenteeId == id);
            if (mentee == null)
            {
                return NotFound();
            }

            return View(mentee);
        }

        // GET: Mentees/Create
        public IActionResult Create()
        {
            ViewData["LevelId"] = new SelectList(_context.Set<Level>(), "LevelId", "LevelId");
            return View();
        }

        // POST: Mentees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenteeId,LevelId,MenteeName,Age")] Mentee mentee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mentee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LevelId"] = new SelectList(_context.Set<Level>(), "LevelId", "LevelId", mentee.LevelId);
            return View(mentee);
        }

        // GET: Mentees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentee = await _context.Mentee.FindAsync(id);
            if (mentee == null)
            {
                return NotFound();
            }
            ViewData["LevelId"] = new SelectList(_context.Set<Level>(), "LevelId", "LevelId", mentee.LevelId);
            return View(mentee);
        }

        // POST: Mentees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenteeId,LevelId,MenteeName,Age")] Mentee mentee)
        {
            if (id != mentee.MenteeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mentee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenteeExists(mentee.MenteeId))
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
            ViewData["LevelId"] = new SelectList(_context.Set<Level>(), "LevelId", "LevelId", mentee.LevelId);
            return View(mentee);
        }

        // GET: Mentees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mentee = await _context.Mentee
                .Include(m => m.Level)
                .FirstOrDefaultAsync(m => m.MenteeId == id);
            if (mentee == null)
            {
                return NotFound();
            }

            return View(mentee);
        }

        // POST: Mentees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mentee = await _context.Mentee.FindAsync(id);
            _context.Mentee.Remove(mentee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenteeExists(int id)
        {
            return _context.Mentee.Any(e => e.MenteeId == id);
        }
    }
}
