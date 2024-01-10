using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Data;
using ShopOnline.Models;

namespace ShopOnline.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly ShopOnline.Data.ShopOnlineContext _context;

        public IndexModel(ShopOnline.Data.ShopOnlineContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Product != null)
            {
                Product = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.Supplier).ToListAsync();
            }


            IQueryable<Product> products = from m in _context.Products select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(m => m.ProductName.Contains(SearchString));
            }

            Products = await products.ToListAsync();
        }
    }
}
