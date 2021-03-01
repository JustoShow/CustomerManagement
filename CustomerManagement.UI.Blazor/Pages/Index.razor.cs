using CustomerManagement.DAL.Data;
using CustomerManagement.DAL.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CustomerManagement.UI.Blazor.Pages
{
    public partial class Index
    {
        private string searchCustomer = String.Empty;

        [Inject]
        private CMDbContext _context { get; set; }
        [Inject]
        private IConfiguration _config { get; set; }
        private List<Customer> Customers { get; set; }
        private List<Email> Emails { get; set; }

        protected override async Task OnInitializedAsync()
        {

            await LoadCustomers();
            Emails = Customers[0].Emails.ToList();
        }

        private async Task LoadCustomers()
        {
            Customers = await _context.Customers
                .Include(c => c.Emails)
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        private void GetCustomerEmails(int customerId)
        {
            var customerIndex = Customers.FindIndex(c => c.ID == customerId);
            Emails = Customers[customerIndex].Emails.ToList();
        }

        private async Task SearchCustomer(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                Customers = await _context.Customers
                    .Where(c => c.Name.Contains(search))
                    .OrderBy(c => c.Name)
                    .ToListAsync();
            }

        }

        private async Task ClearSearch()
        {
            await LoadCustomers();
            searchCustomer = String.Empty;
            
        }

        private void SendEmail(List<Customer> emailTo, string subject, string body)
        {
            

            MailMessage message = new MailMessage();
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;

            foreach (var cust in emailTo)
            {
                foreach (var email in cust.Emails)
                {
                    message.To.Add(email.EmailAddress);
                }
            }

            string host = _config.GetValue<string>("Smtp:Server");
            int port = _config.GetValue<int>("Smtp:Port");
            string fromAddress = _config.GetValue<string>("Smtp:FromAddress");

            message.From = new MailAddress(fromAddress);

            using (var smtpClient = new SmtpClient(host, port))
            {
                smtpClient.Send(message);
            }
        }
    }
}
