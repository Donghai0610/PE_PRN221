using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class Director
    {
        public Director()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? Dob { get; set; }
        public string? Description { get; set; }
        public bool? Male { get; set; }
        public string? Nationality { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
