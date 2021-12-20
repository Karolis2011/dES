using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dES.Data.Model;
using dES.Data;
namespace dES.Pages.Order
{
    public class OrderInvoiceModel : PageModel
    {
        private readonly dES.Data.dESContext _context;
        public OrderPayment Payment { get; set; }
        public OrderInvoiceModel(dES.Data.dESContext context)
        {
            _context = context;
        }
        public void OnGet(string orderID)
        {
            Payment = _context.OrderPayments.FirstOrDefault(x => x.OrderId == int.Parse(orderID));
        }
    }
}
