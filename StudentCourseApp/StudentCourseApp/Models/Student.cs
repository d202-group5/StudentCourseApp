using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentCourseApp.Models
{
    public partial class Student
    {
        public Student()
        {
            Enrollment = new HashSet<Enrollment>();
        }
        // [RegularExpression(@"^[0-9]*[1-9]+$|^[1-9]+[0-9]*$]*$")]
        //[Required]
        //[StringLength(30)]
        [RegularExpression(@"^[0-9""'\s-]*$"), Required, StringLength(3)]
        public int Id { get; set; }
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
       // [Required]
        //[StringLength(30)]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
