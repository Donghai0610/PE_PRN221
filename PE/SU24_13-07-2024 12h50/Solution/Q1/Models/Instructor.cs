using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class Instructor
    {
        public Instructor()
        {
            Courses = new HashSet<Course>();
        }

        public int InstructorId { get; set; }
        public string? Name { get; set; }
        public string? Bio { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
