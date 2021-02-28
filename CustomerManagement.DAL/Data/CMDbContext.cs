using CustomerManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagement.DAL.Data
{
    public class CMDbContext : DbContext
    {
        public CMDbContext(DbContextOptions<CMDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Email> Emails { get; set; }
    }
}
