using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BankApp.Pages
{
    public class BankModel : PageModel
    {
        private static decimal balance = 0;  // shared balance

        [BindProperty]
        public decimal Amount { get; set; }

        public string Message { get; set; }

        public decimal CurrentBalance => balance;

        public void OnPostDeposit()
        {
            if (Amount > 0)
            {
                balance += Amount;
                Message = $"Deposited ?{Amount}";
            }
            else
            {
                Message = "Enter a valid amount";
            }
        }

        public void OnPostWithdraw()
        {
            if (Amount > 0 && Amount <= balance)
            {
                balance -= Amount;
                Message = $"Withdrew ?{Amount}";
            }
            else
            {
                Message = "Invalid or insufficient amount";
            }
        }

        public void OnGet()
        {
            Message = "Welcome to the Bank!";
        }
    }
}
