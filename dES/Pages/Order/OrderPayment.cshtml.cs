using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dES.Data;
using dES.Data.Model;
namespace dES.Pages.Order
{
    public class OrderPaymentModel : PageModel
    {
        virtual public PaymentMethod Method { get; set; }
        public readonly dESContext _context;

        [BindProperty]
        public OrderPayment Payment { get; set; }
        public OrderPaymentModel(dESContext context)
        {
            this._context = context;
            Payment = new OrderPayment();
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public enum PaymentMethod
        {
            Cash,
            BankTrasnfer,
            Card
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Console.WriteLine(Payment.OrderId + " " + Payment.Method + " " + Payment.Ammount);
            _context.OrderPayments.Add(Payment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./OrderList");
        }
    }
}
