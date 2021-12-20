using dES.Data;
using dES.Data.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace dES.Services
{
    public class CartService
    {

        public const string SESSSION_KEY = "__shopingcart";
        private readonly IHttpContextAccessor _ha;
        private readonly dESContext _context;

        private HttpContext HttpContext => _ha.HttpContext;
        private ISession Session => HttpContext?.Session;

        private ShoppingCart cached;

        public CartService(IHttpContextAccessor accessor, dESContext dataContext)
        {
            _context = dataContext;
            _ha = accessor;
        }

        
        public ShoppingCart GetShopingCart()
        {
            if(cached != null)
                return cached;

            var value = Session.GetString(SESSSION_KEY);
            if(value == null)
            {
                cached = new ShoppingCart();
                return cached;
            }
            var items = JsonSerializer.Deserialize<List<int>>(value);
            cached = new ShoppingCart();
            cached.Load(_context, items);
            return cached;
        }

        public void SaveShopingCart()
        {
            if (cached == null)
                return;
            var value = JsonSerializer.Serialize<List<int>>(cached.Simplify());
            Session.SetString(SESSSION_KEY, value);
        }

        public class ShoppingCart
        {
            public HashSet<Product> Items { get; set; } = new HashSet<Product>();

            public List<int> Simplify()
            {
                return Items.Select(i => i.Id).ToList();
            }

            public void Load(dESContext dataContext, List<int> items)
            {
                var prods = dataContext.Products
                    .Include(p => p.Laptop)
                    .ThenInclude(l => l.Brand)
                    .Include(p => p.Laptop)
                    .ThenInclude(l => l.Processor)
                    .Include(p => p.Laptop)
                    .ThenInclude(l => l.OS)
                    .Include(p => p.Laptop)
                    .ThenInclude(l => l.RAM)
                    .ToList();
                Items = new HashSet<Product>(items.Select(i =>
                    prods
                    .Where(p => p.Id == i)
                    .FirstOrDefault()
                    ));
            }
        }
    }
}
