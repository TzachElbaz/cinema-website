using System;
using System.Collections.Generic;

#nullable disable

namespace Bll_to_dbCinema
{
    public partial class Client
    {
        public Client()
        {
            Orders = new HashSet<Order>();
        }

        public string ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string CreditCardNumber { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
