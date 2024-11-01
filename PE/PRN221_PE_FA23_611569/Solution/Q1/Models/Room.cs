using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class Room
    {
        public Room()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int? Capacity { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
