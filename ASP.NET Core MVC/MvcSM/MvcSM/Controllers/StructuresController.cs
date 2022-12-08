using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcSM.Data;
using MvcSM.Models;

namespace MvcSM.Controllers
{
    public class StructuresController : Controller
    {
        private readonly MvcSMContext _context;

        public StructuresController(MvcSMContext context)
        {
            _context = context;
        }

        // GET: Structures
        public async Task<IActionResult> Index()
        {
              return _context.Structure != null ? 
                          View(await _context.Structure.ToListAsync()) :
                          Problem("Entity set 'MvcSMContext.Structure'  is null.");
        }

        // GET: Structures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Structure == null)
            {
                return NotFound();
            }

            var structure = await _context.Structure
                .FirstOrDefaultAsync(m => m.Id == id);
            if (structure == null)
            {
                return NotFound();
            }

            return View(structure);
        }

        // GET: Structures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Structures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ReleaseDate,Genre,Student_Code")] Structure structure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(structure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(structure);
        }

        // GET: Structures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Structure == null)
            {
                return NotFound();
            }

            var structure = await _context.Structure.FindAsync(id);
            if (structure == null)
            {
                return NotFound();
            }
            return View(structure);
        }

        // POST: Structures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ReleaseDate,Genre,Student_Code")] Structure structure)
        {
            if (id != structure.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(structure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StructureExists(structure.Id))
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
            return View(structure);
        }

        // GET: Structures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Structure == null)
            {
                return NotFound();
            }

            var structure = await _context.Structure
                .FirstOrDefaultAsync(m => m.Id == id);
            if (structure == null)
            {
                return NotFound();
            }

            return View(structure);
        }

        // POST: Structures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Structure == null)
            {
                return Problem("Entity set 'MvcSMContext.Structure'  is null.");
            }
            var structure = await _context.Structure.FindAsync(id);
            if (structure != null)
            {
                _context.Structure.Remove(structure);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StructureExists(int id)
        {
          return (_context.Structure?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
