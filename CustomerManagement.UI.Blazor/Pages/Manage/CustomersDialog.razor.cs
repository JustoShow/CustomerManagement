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
    public partial class CustomersDialog
    {
        [Inject]
        public CMDbContext _context { get; set; }
        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }
        [Inject]
        private ISnackbar Snackbar { get; set; }
        [Parameter]
        public Customer CustomerDetails { get; set; } = new Customer();
        [Parameter]
        public bool IsNewCustomer { get; set; } = true;

        public async Task Submit(Customer customerDetails)
        {
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomRight;
           if (IsNewCustomer)
            {
                await AddCustomer(customerDetails);
            }
           else
            {
                await EditCustomer(customerDetails);
            }
        }

        public void Cancel() => MudDialog.Cancel();

        public async Task AddCustomer(Customer newCustomer)
        {
            bool customerExist = _context.Customers.Any(c => c.Name == newCustomer.Name);

            if (!customerExist)
            {
                try
                {
                    newCustomer.CreatedDate = DateTime.Now;
                    _context.Customers.Add(newCustomer);
                    await _context.SaveChangesAsync();
                    Snackbar.Add("Customer has been added!", Severity.Success);
                    MudDialog.Close(DialogResult.Ok(true));
                    return;
                }
                catch (DbUpdateException)
                {
                    Snackbar.Add("Error adding customer to the database!", Severity.Error);
                    return;
                }
            }
            Snackbar.Add("Customer is already in the database!", Severity.Error);
        }

        public async Task EditCustomer(Customer customer)
        {
            try
            {
                customer.UpdatedDate = DateTime.Now;
                _context.Update(customer);
                await _context.SaveChangesAsync();
                Snackbar.Add("Customer has been updated!", Severity.Success);
                MudDialog.Close(DialogResult.Ok(true));
                return;
            }
            catch (DbUpdateException)
            {
                Snackbar.Add("Error adding customer to the database!", Severity.Error);
                return;
            }
        }
    }    
}
