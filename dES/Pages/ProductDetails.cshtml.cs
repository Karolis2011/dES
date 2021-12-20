using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dES.Data;
using dES.Data.Model;
using dES.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace dES.Pages
{
    public class ProductDetailsModel : PageModel
    {
        public readonly dESContext context;
        private readonly CartService _cartService;
        public Product Product { get; set; }
        
        public ProductDetailsModel(dESContext context, CartService cartService)
        {
            this.context = context;
            _cartService = cartService;
        }

        public void OnGet(int productId)
        {
            Product = context.Products
                .Include(p => p.Laptop)
                .ThenInclude(l => l.Brand)
                .Include(p => p.Laptop)
                .ThenInclude(l => l.Processor)
                .Include(p => p.Laptop)
                .ThenInclude(l => l.OS)
                .Include(p => p.Laptop)
                .ThenInclude(l => l.RAM)
                .FirstOrDefault(p => p.Id == productId);
        }

        public IActionResult OnPost(int productId)
        {
            var cart = _cartService.GetShopingCart();
            cart.Items.Add(context.Products.Find(productId));
            _cartService.SaveShopingCart();
            return Redirect("/ShoppingCart");
        }
        public Brand GetBrand()
        {
            return GetLaptop().Brand;
        }

        public Data.Model.OperatingSystem GetOS()
        {
            return GetLaptop().OS;
        }

        public RAM GetRAM()
        {
            return GetLaptop().RAM;
        }

        public Processor GetProc()
        {
            return GetLaptop().Processor;
        }
        public Laptop GetLaptop()
        {
            return Product.Laptop;
        }
    }
}
