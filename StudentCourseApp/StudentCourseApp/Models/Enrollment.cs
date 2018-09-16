using System;
using System.Collections.Generic;

namespace StudentCourseApp.Models
{
    public partial class Enrollment
    {
        public int Id { get; set; }
        public string CourseId { get; set; }
        public int? Sid { get; set; }

        public Course Course { get; set; }
        public Student S { get; set; }
    }
}
