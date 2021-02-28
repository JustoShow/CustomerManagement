using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.DAL.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Email> Emails { get; set; }
    }
}
