using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using dES.Data;
using dES.Data.Model;

namespace dES.Areas.Admin.Pages.Actions
{
    public class DetailsModel : PageModel
    {
        private readonly dES.Data.dESContext _context;

        public DetailsModel(dES.Data.dESContext context)
        {
            _context = context;
        }

        public ActionInformation ActionInformation { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ActionInformation = await _context.ActionInformation.FirstOrDefaultAsync(m => m.Id == id);

            if (ActionInformation == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
