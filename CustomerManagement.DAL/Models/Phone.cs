using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.DAL.Models
{
    public class Phone
    {
        public int ID { get; set; }
        public string PhoneNumber { get; set; }

        public int EmailID { get; set; }
        public Email Email { get; set; }
    }
}
