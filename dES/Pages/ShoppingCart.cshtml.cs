using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dES.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace dES.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly CartService _cartService;

        public CartService.ShoppingCart ShoppingCart { get; set; }
        public double Sum { get; set; }

        public ShoppingCartModel(CartService cartService)
        {
            _cartService = cartService;
        }

        public void OnGet()
        {
            ShoppingCart = _cartService.GetShopingCart();
            Sum = ShoppingCart.Items.Sum(p => p.Price);
        }
    }
}
