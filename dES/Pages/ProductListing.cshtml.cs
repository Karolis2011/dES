using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dES.Data;
using dES.Data.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace dES.Pages
{
    public class ProductListingModel : PageModel
    {
        public readonly dESContext context;
        public List<Product> Products { get; set; }
        public List<Laptop> Laptops { get; set; }

        public Dictionary<string, string> GetRouteData(Product product, ProductListingModel model)
        {

            var routeData = new Dictionary<string, string>() { };
            routeData.Add("productId", product.Id.ToString());
            var title = GetProductTitle(product, model);
            routeData.Add("title", title);
            return routeData;
        }
        public Brand GetBrand(Product product)
        {
            var laptop = GetLaptop(product);

            return context.Brands.Find(laptop.BrandId);
        }

        public Data.Model.OperatingSystem GetOS(Product product)
        {
            var laptop = GetLaptop(product);

            return context.OperatingSystems.Find(laptop.OSId);
        }

        public Processor GetProc(Product product)
        {
            var laptop = GetLaptop(product);
            return context.Processors.Find(laptop.ProcessorId);
        }
        public Laptop GetLaptop(Product product)
        {
            int laptopId = product.LaptopId;
            return context.Laptops.Find(laptopId);
        }
        public ProductListingModel(dESContext context)
        {
            Products = context.Products.ToList();
            this.context = context;
        }

        public static string GetProductTitle(Product product, ProductListingModel plm)
        {
            var brand = plm.GetBrand(product);
            var proc = plm.GetProc(product);
            string title = string.Format($"{brand.Name} {product.Name} {proc.Name} {proc.Frequency}");
            return title;
        }

        public void OnGet()
        {
            Products = context.Products.ToList();
        }
    }
}
