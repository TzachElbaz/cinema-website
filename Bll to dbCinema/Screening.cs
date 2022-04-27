using System;
using System.Collections.Generic;

#nullable disable

namespace Bll_to_dbCinema
{
    public partial class Screening
    {
        public Screening()
        {
            Orders = new HashSet<Order>();
        }

        public int ScreeningId { get; set; }
        public int MovieId { get; set; }
        public string Day { get; set; }
        public DateTime Date { get; set; }
        public string Hour { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
