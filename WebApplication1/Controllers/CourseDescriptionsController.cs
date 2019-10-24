using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CourseDescriptionsController : Controller
    {
        private readonly CourseContext _context;

        public CourseDescriptionsController(CourseContext context)
        {
            _context = context;
        }

        // GET: CourseDescriptions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Description.ToListAsync());
        }

        // GET: CourseDescriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDescription = await _context.Description
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseDescription == null)
            {
                return NotFound();
            }

            return View(courseDescription);
        }

        // GET: CourseDescriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseDescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DescriptionId,Description")] CourseDescription courseDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseDescription);
        }

        // GET: CourseDescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDescription = await _context.Description.FindAsync(id);
            if (courseDescription == null)
            {
                return NotFound();
            }
            return View(courseDescription);
        }

        // POST: CourseDescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DescriptionId,Description")] CourseDescription courseDescription)
        {
            if (id != courseDescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseDescriptionExists(courseDescription.Id))
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
            return View(courseDescription);
        }

        // GET: CourseDescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseDescription = await _context.Description
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseDescription == null)
            {
                return NotFound();
            }

            return View(courseDescription);
        }

        // POST: CourseDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseDescription = await _context.Description.FindAsync(id);
            _context.Description.Remove(courseDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseDescriptionExists(int id)
        {
            return _context.Description.Any(e => e.Id == id);
        }
    }
}
