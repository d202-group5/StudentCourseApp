using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentCourseApp.Models;

namespace StudentCourseApp.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly StudentCourseAppDBContext _context;

        public EnrollmentsController(StudentCourseAppDBContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public async Task<IActionResult> Index(String selectedId)
        {

            ViewData["students"] = new SelectList(_context.Student, "Id", "Id");

            var enrollments = _context.Enrollment
                .Include(e => e.S)
                .Include(e => e.Course)
                .AsNoTracking();

            if (!String.IsNullOrEmpty(selectedId))
            {

                enrollments = enrollments.Where(e => e.Sid.ToString().StartsWith(selectedId) && e.FutureEnroll.StartsWith("N"));
            }

            var studentCourseAppDBContext = _context.Enrollment.Include(e => e.Course).Include(e => e.S);
            return View(await enrollments.ToListAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.S)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create(string historyToggle)
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id");
            ViewData["Sid"] = new SelectList(_context.Student, "Id", "Id");

            ViewBag.historyToggleData = new SelectList(new[]
                       {
                new {id="Y", name="Future Enrollment"},
                new{id="N", name="Previously Completed"},
            },
                       "id", "name", historyToggle);
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
      [Bind("CourseId,Sid,FutureEnroll")] Enrollment enrol)
        {
          
                if (ModelState.IsValid)
                {
                    _context.Add(enrol);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Create));
                }
            
           
            return View(enrol);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment.SingleOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", enrollment.CourseId);
            ViewData["Sid"] = new SelectList(_context.Student, "Id", "Id", enrollment.Sid);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseId,Sid,FutureEnroll")] Enrollment enrollment)
        {
            if (id != enrollment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(enrollment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnrollmentExists(enrollment.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", enrollment.CourseId);
            ViewData["Sid"] = new SelectList(_context.Student, "Id", "Id", enrollment.Sid);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await _context.Enrollment
                .Include(e => e.Course)
                .Include(e => e.S)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await _context.Enrollment.SingleOrDefaultAsync(m => m.Id == id);
            _context.Enrollment.Remove(enrollment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return _context.Enrollment.Any(e => e.Id == id);
        }
    }
}
