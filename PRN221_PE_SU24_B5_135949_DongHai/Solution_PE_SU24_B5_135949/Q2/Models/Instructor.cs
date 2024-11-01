using System;
using System.Collections.Generic;

namespace Q2.Models
{
    public partial class Instructor
    {
        public int InstructorId { get; set; }
        public string? Fullname { get; set; }
        public DateTime? ContractDate { get; set; }
        public bool? IsFulltime { get; set; }
        public int? Department { get; set; }
    }
}
