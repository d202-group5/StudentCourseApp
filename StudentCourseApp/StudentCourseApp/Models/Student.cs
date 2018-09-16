using System;
using System.Collections.Generic;

namespace StudentCourseApp.Models
{
    public partial class Student
    {
        public Student()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
