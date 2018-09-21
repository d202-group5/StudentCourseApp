using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentCourseApp.Models
{
    public partial class Enrollment
    {
        public int Id { get; set; }
        [Display(Name ="Course")]
        public string CourseId { get; set; }
        [Display(Name = "Student ID")]

        public int? Sid { get; set; }

        public string FutureEnroll { get; set; }

        public Course Course { get; set; }
        public Student S { get; set; }
    }
}
