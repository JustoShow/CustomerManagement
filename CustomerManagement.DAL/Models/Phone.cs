using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CustomerManagement.DAL.Models
{
    [Table("Phones", Schema = "customer")]
    public class Phone
    {
        public int ID { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public int EmailID { get; set; }
        public Email Email { get; set; }
    }
}
