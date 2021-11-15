using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using dES.Data;
using dES.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace dES.Areas.Admin.Pages.Orders
{
    public class IndexModel : PageModel
    {
        private readonly dESContext _context;

        public IndexModel(dESContext context)
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
