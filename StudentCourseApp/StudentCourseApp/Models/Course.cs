using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace StudentCourseApp.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        [Display(Name = "Course ID")]
        public string Id { get; set; }
        [Display(Name = "Course Name")]
        public string Cname { get; set; }
        [Display(Name = "Course Description")]
        public string Desc { get; set; }
        [Display(Name = "Semester Offered")]
        public string Semester { get; set; }
        [Display(Name = "Pre-requisites")]
        public string PreReq { get; set; }

        public string Compulsory { get; set; }
        [Display(Name = "Year Level")]
        public int YearLevel { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
