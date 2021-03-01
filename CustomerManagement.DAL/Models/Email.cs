using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerManagement.DAL.Models
{
    [Table("Emails", Schema = "customer")]
    public class Email
    {
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedTime { get; set; }

        public int CustomerID { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Phone> Phone { get; set; }
    }
}
