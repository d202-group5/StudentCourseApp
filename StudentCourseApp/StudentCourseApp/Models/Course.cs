using System;
using System.Collections.Generic;

namespace StudentCourseApp.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollment = new HashSet<Enrollment>();
        }

        public string Id { get; set; }
        public string Cname { get; set; }
        public string Desc { get; set; }
        public string Semester { get; set; }
        public string PreReq { get; set; }
        public string Compulsory { get; set; }
        public int YearLevel { get; set; }
        public int? TId { get; set; }

        public TopicArea TopicA { get; set; }
        public ICollection<Enrollment> Enrollment { get; set; }
    }
}
