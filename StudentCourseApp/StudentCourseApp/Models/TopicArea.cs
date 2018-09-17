using System;
using System.Collections.Generic;

namespace StudentCourseApp.Models
{
    public partial class TopicArea
    {
        public TopicArea()
        {
            Course = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string AreaName { get; set; }

        public ICollection<Course> Course { get; set; }
    }
}
