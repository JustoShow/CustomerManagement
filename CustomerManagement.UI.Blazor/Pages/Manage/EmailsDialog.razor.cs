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
    public partial class EmailsDialog
    {
        [Inject]
        public CMDbContext _context { get; set; }
        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; }
        [Inject]
        private ISnackbar Snackbar { get; set; }
        [Parameter]
        public Email EmailDetails { get; set; } = new Email();
        [Parameter]
        public bool IsNewEmail { get; set; } = true;
        [Parameter]
        public int CustomerId { get; set; } = 0;

        public async Task Submit(Email emailDetails)
        {
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomRight;
            if (IsNewEmail)
            {
                await AddCustomer(emailDetails);
            }
            else
            {
                await EditEmail(emailDetails);
            }
        }

        public void Cancel() => MudDialog.Cancel();

        public async Task AddCustomer(Email newEmail)
        {
            bool emailExist = _context.Emails.Any(c => c.EmailAddress == newEmail.EmailAddress);

            if (!emailExist)
            {
                try
                {
                    // TODO: Add Email
                    //await _context.SaveChangesAsync();
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

        public async Task EditEmail(Email email)
        {
            try
            {
                // TODO: Update Email
                //await _context.SaveChangesAsync();
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
