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

        public async Task OnGetAsync(int? categoryId, string searchString, string? sortBy)
        {
            IQueryable<Product> queriedProducts = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier);

            if (!string.IsNullOrEmpty(searchString))
            {
                queriedProducts = queriedProducts.Where(m => m.ProductName.Contains(searchString));
            }

            if (categoryId.HasValue)
            {
                queriedProducts = queriedProducts.Where(p => p.CategoryId == categoryId);
            }
            if (!string.IsNullOrEmpty(sortBy) && sortBy.Equals("UnitPrice"))
            {
                queriedProducts = queriedProducts.OrderBy(p => p.UnitPrice); // Sắp xếp theo UnitPrice
            }


            Product = await queriedProducts.ToListAsync();
        }
    }
}
