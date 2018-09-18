﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentCourseApp.Models;

namespace StudentCourseApp.Controllers
{
    public class CoursesController : Controller
    {
        private readonly StudentCourseAppDBContext _context;

        public CoursesController(StudentCourseAppDBContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index(String topicChoice)
        {
            ViewBag.topics = new SelectList(new[]
            {
                new {id="S", name="Software Development"},
                new{id="I", name="Information Management"},
                new{id="T", name="Technology"},
            },
            "id", "name", topicChoice);

            var courses = _context.Course
                .Include(c => c.TopicA)
                .AsNoTracking();

            if (!String.IsNullOrEmpty(topicChoice))
            {
                courses = courses.Where(c => c.TopicA.AreaName.StartsWith(topicChoice));
            }

            return View(await courses.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .SingleOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }
    }
}
