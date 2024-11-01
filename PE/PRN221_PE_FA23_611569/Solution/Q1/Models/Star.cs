using System;
using System.Collections.Generic;

namespace Q1.Models
{
    public partial class Star
    {
        public Star()
        {
            MovieStars = new HashSet<MovieStar>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool? Male { get; set; }
        public string? Description { get; set; }
        public DateTime? Dob { get; set; }
        public string? Nationality { get; set; }

        public virtual ICollection<MovieStar> MovieStars { get; set; }
    }
}
