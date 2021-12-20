using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dES.Data;
using dES.Data.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dES.Pages
{
    public class ProductDetailsModel : PageModel
    {
        public readonly dESContext context;
        public Product Product { get; set; }
        public string Title { get; set; }
        
        public ProductDetailsModel(dESContext context)
        {
            this.context = context;

        }

        public void OnGet(string productId, string title)
        {
            Title = title;
            Product = context.Products.Find(int.Parse(productId));
        }
        public Brand GetBrand()
        {
            var laptop = GetLaptop();

            return context.Brands.Find(laptop.BrandId);
        }

        public Data.Model.OperatingSystem GetOS()
        {
            var laptop = GetLaptop();

            return context.OperatingSystems.Find(laptop.OSId);
        }

        public RAM GetRAM()
        {
            var laptop = GetLaptop();

            return context.RAMs.Find(laptop.RAMId);
        }

        public Processor GetProc()
        {
            var laptop = GetLaptop();
            return context.Processors.Find(laptop.ProcessorId);
        }
        public Laptop GetLaptop()
        {
            int laptopId = Product.LaptopId;
            return context.Laptops.Find(laptopId);
        }
    }
}
