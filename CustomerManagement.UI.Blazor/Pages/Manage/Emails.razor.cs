using CustomerManagement.DAL.Data;
using CustomerManagement.DAL.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.UI.Blazor.Pages.Manage
{
    public partial class Emails
    {
        [Inject]
        private CMDbContext _context { get; set; }
        [Inject]
        private IDialogService DialogService { get; set; }
        private List<Customer> CustomerList { get; set; }
        private List<Email> EmailList { get; set; }
        private Customer EmailDetails { get; set; } = new Customer();
        private string searchString = "";
        private int selectedCustomerId = 0;
        private bool _hasCustomers = false;

        protected override async Task OnInitializedAsync()
        {
            _hasCustomers = _context.Customers.Any();

            if (_hasCustomers)
            {
                await LoadCustomersAsync();
            }
        }

        public async Task LoadCustomersAsync()
        {
            try
            {
                CustomerList = await _context.Customers.OrderBy(c => c.Name).ToListAsync();
            }
            catch (DbUpdateException)
            {

                return;
            }
        }

        private async Task CustomerChanged(int customerId)
        {
            selectedCustomerId = customerId;
            await LoadEmailsAsync(customerId);
        }

        private async Task LoadEmailsAsync(int customerId)
        {
            await _context.Emails.Where(e => e.CustomerID == customerId).OrderBy(e => e.EmailAddress).ToListAsync();
        }

        DialogOptions options = new DialogOptions() { DisableBackdropClick = true };

        // Add Email to Customer
        private async Task OpenEmailDialog()
        {
            // TODO: Finish Adding Email
            var parameter = new DialogParameters { ["CustomerId"] = selectedCustomerId, ["IsNewEmail"] = true };
            var dialog = DialogService.Show<CustomersDialog>("Add Email", parameter, options);

            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                // Reload after added
                await LoadCustomersAsync();
            }
        }
    }
}
