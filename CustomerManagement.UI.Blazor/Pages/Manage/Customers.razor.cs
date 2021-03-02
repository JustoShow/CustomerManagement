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
    public partial class Customers
    {
        [Inject]
        private CMDbContext _context { get; set; }
        [Inject]
        private IDialogService DialogService { get; set; }
        private List<Customer> CustomerList { get; set; }

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
            CustomerList = await _context.Customers.OrderBy(c => c.Name).ToListAsync();
        }

        DialogOptions options = new DialogOptions() { DisableBackdropClick = true };

        // Add Customer
        private async Task OpenCustomerDialog()
        {
            var dialog = DialogService.Show<CustomersDialog>("Add Customer", options);
            
            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                // Reload after added
                await LoadCustomersAsync();
            }
        }

        // Edit Customer Details
        private async Task OpenCustomerDialog(int id)
        {
            // Pass the selected customer data as a parameter
            Customer selectedCustomer = CustomerList[CustomerList.FindIndex(c => c.ID == id)];

            var parameter = new DialogParameters { ["CustomerDetails"] = selectedCustomer, ["IsNewCustomer"] = false };
            var dialog = DialogService.Show<CustomersDialog>("Edit Customer", parameter, options);

            var result = await dialog.Result;

            if (!result.Cancelled)
            {
                // Reload after added
                await LoadCustomersAsync();
            }
        }
    }
}
