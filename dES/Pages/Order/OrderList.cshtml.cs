using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dES.Data;
using dES.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace dES.Pages.Order
{
    public class OrderListModel : PageModel
    {
        private readonly dESContext _context;

        public OrderListModel(dESContext context)
        {
            _context = context;
        }

        public IList<Data.Model.Order> Order { get; set; }

        public async Task OnGetAsync()
        {
            Order = await _context.Orders.ToListAsync();
        }
    }
}
