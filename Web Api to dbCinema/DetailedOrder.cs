using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_to_dbCinema
{
    public class DetailedOrder
    {

        // Class that joins together relevant Order details for showing to client.  
        public int orderNumber { get; set; } // 'orderId' from Orders table
        public int tickets { get; set; } // 'NumberOfTickets' from Orders table 
        public string orderDate { get; set; } // 'Date' from Screenings table
        public string orderTime { get; set; } // 'Time' from Screening table
        public string movieTitle { get; set; } // 'Title' from Movies table

    }
}
