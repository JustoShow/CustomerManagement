using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.DAL.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? MailAddress { get; set; }
        public string? MailCity { get; set; }
        public string? MailState { get; set; }
        public string? MailZipCode { get; set; }

        public ICollection<Email> Emails { get; set; }
    }
}
