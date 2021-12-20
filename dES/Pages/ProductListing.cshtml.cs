using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dES.Data;
using dES.Data.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dES.Pages
{
    public class ProductListingModel : PageModel
    {
        public readonly dESContext context;
        public List<Product> Products { get; set; }

        public Dictionary<string, string> GetRouteData(Product product, ProductListingModel model)
        {

            var routeData = new Dictionary<string, string>() { };
            routeData.Add("productId", product.Id.ToString());
            return routeData;
        }

        public ProductListingModel(dESContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
            Products = context.Products
                .Include(p => p.Laptop)
                .ThenInclude(l => l.Brand)
                .Include(p => p.Laptop)
                .ThenInclude(l => l.Processor)
                .ToList();
        }
    }
}
