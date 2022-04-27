using System;
using System.Collections.Generic;

#nullable disable

namespace Bll_to_dbCinema
{
    public partial class Movie
    {
        public Movie()
        {
            Orders = new HashSet<Order>();
            Screenings = new HashSet<Screening>();
        }

        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string MovieLength { get; set; }
        public string Summary { get; set; }
        public string PosterPhoto { get; set; }
        public int? NumberOfScreenings { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Screening> Screenings { get; set; }
    }
}
