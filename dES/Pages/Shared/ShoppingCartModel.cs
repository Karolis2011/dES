using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dES.Pages.Shared
{
    public class ShoppingCartModel : PageModel
    {
       public ShoppingCartModel()
        {
            var count = new byte[8];
            var countOk = HttpContext.Session.TryGetValue("cart_count",out count);
            if (countOk) 
            {
                
            }

        }
        public void OnGet()
        {

        }
    }
}
