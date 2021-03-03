using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerManagement.DAL.Models
{
    [Table("Customers", Schema = "customer")]
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
#nullable enable
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? MailAddress { get; set; }
        public string? MailCity { get; set; }
        public string? MailState { get; set; }
        public string? MailZipCode { get; set; }
        public string? Notes { get; set; }
        public DateTime? UpdatedDate { get; set; }
#nullable disable
        public DateTime CreatedDate { get; set; }

        public ICollection<Email> Emails { get; set; }

        public string FullAddress 
        {
            get
            {
                return $"{Address} {City}, {State} {ZipCode}";
            }
        }

        public string FullMailAddress
        {
            get
            {
                return $"{MailAddress}\n{MailCity}, {MailState} {MailZipCode}";
            }
        }
    }
}
