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
    public class CourseInstancesController : Controller
    {
        private readonly CourseContext _context;

        public CourseInstancesController(CourseContext context)
        {
            _context = context;
        }

        // GET: CourseInstances
        public async Task<IActionResult> Index()
        {
            var courseContext = _context.Courses.Include(c => c.Description);
            return View(await courseContext.ToListAsync());
        }

        // GET: CourseInstances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseInstance = await _context.Courses
                .Include(c => c.Description)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (courseInstance == null)
            {
                return NotFound();
            }

            return View(courseInstance);
        }

        // GET: CourseInstances/Create
        public IActionResult Create()
        {
            //ViewData["DescriptionID"] = new SelectList(_context.Description, "DescriptionId", "DescriptionId");
            return View();
        }

        // POST: CourseInstances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Dept,Number,Semester,Year,DescriptionID")] CourseInstance courseInstance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseInstance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DescriptionID"] = new SelectList(_context.Description, "DescriptionId", "DescriptionId", courseInstance.ID);
            return View(courseInstance);
        }

        // GET: CourseInstances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseInstance = await _context.Courses.FindAsync(id);
            if (courseInstance == null)
            {
                return NotFound();
            }
            ViewData["DescriptionID"] = new SelectList(_context.Description, "DescriptionId", "DescriptionId", courseInstance.ID);
            return View(courseInstance);
        }

        // POST: CourseInstances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Dept,Number,Semester,Year,DescriptionID")] CourseInstance courseInstance)
        {
            if (id != courseInstance.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseInstance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseInstanceExists(courseInstance.ID))
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
            ViewData["Id"] = new SelectList(_context.Description, "DescriptionId", "DescriptionId", courseInstance.ID);
            return View(courseInstance);
        }

        // GET: CourseInstances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseInstance = await _context.Courses
                .Include(c => c.Description)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (courseInstance == null)
            {
                return NotFound();
            }

            return View(courseInstance);
        }

        // POST: CourseInstances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseInstance = await _context.Courses.FindAsync(id);
            _context.Courses.Remove(courseInstance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseInstanceExists(int id)
        {
            return _context.Courses.Any(e => e.ID == id);
        }
    }
}
