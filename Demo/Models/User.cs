using System;
using System.Collections.Generic;

#nullable disable

namespace Demo.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAdd { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
