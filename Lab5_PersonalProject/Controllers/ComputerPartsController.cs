using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5_PersonalProject.Data;
using Lab5_PersonalProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace Lab5_PersonalProject.Controllers
{
    public class ComputerPartsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComputerPartsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ComputerParts
        public async Task<IActionResult> Index()
        {
            return View(await _context.parts.ToListAsync());
        }

        // GET: ComputerParts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerParts = await _context.parts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (computerParts == null)
            {
                return NotFound();
            }

            return View(computerParts);
        }

        // GET: ComputerParts/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ComputerParts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,computerBrand,computerPart,computerCreatedYear,computerPartPrice")] ComputerParts computerParts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(computerParts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(computerParts);
        }

        // GET: ComputerParts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerParts = await _context.parts.FindAsync(id);
            if (computerParts == null)
            {
                return NotFound();
            }
            return View(computerParts);
        }

        // POST: ComputerParts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,computerBrand,computerPart,computerCreatedYear,computerPartPrice")] ComputerParts computerParts)
        {
            if (id != computerParts.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computerParts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputerPartsExists(computerParts.ID))
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
            return View(computerParts);
        }

        // GET: ComputerParts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computerParts = await _context.parts
                .FirstOrDefaultAsync(m => m.ID == id);
            if (computerParts == null)
            {
                return NotFound();
            }

            return View(computerParts);
        }

        // POST: ComputerParts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var computerParts = await _context.parts.FindAsync(id);
            _context.parts.Remove(computerParts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputerPartsExists(int id)
        {
            return _context.parts.Any(e => e.ID == id);
        }

        // Search Parts
        public async Task<IActionResult> Search()
        {
            return View();
        }

        // Search Function
        public async Task<IActionResult> ShowSearchResults(string computerBrand)
        {
            return View("Index", await _context.parts.Where(s => s.computerBrand.Contains(computerBrand)).ToListAsync());
        }
    }
}
