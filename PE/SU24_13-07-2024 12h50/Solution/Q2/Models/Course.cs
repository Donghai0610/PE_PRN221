using System;
using System.Collections.Generic;

namespace Q2.Models
{
    public partial class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
            Reviews = new HashSet<Review>();
            Categories = new HashSet<CourseCategory>();
        }

        public int CourseId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? InstructorId { get; set; }

        public virtual Instructor? Instructor { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<CourseCategory> Categories { get; set; }
    }
}
