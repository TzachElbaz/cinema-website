using System;
using System.Collections.Generic;

#nullable disable

namespace Bll_to_dbCinema
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public string ClientId { get; set; }
        public int MovieId { get; set; }
        public int ScreeningId { get; set; }
        public int NumberOfTickets { get; set; }

        public virtual Client Client { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual Screening Screening { get; set; }
    }
}
