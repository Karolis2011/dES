using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dES.Data;
using dES.Data.Model;

namespace dES.Areas.Admin.Pages.Priducts
{
    public class IndexModel : PageModel
    {
        private readonly dES.Data.dESContext _context;

        public IndexModel(dES.Data.dESContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
