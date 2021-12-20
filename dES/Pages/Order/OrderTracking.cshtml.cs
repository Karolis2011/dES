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
    public class OrderTrackingModel : PageModel
    {
        public string orderID { get; set; }
        public void OnGet(string ID)
        {
            orderID = ID;
        }
    }
}
