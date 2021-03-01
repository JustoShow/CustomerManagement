using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.DAL.Models
{
    public class Email
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedTime { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Phone> Phone { get; set; }
    }
}
