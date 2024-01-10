using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Data;
using ShopOnline.Models;

namespace ShopOnline.Pages.Suppliters
{
    public class DetailsModel : PageModel
    {
        private readonly ShopOnline.Data.ShopOnlineContext _context;

        public DetailsModel(ShopOnline.Data.ShopOnlineContext context)
        {
            _context = context;
        }

      public Supplier Supplier { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Suppliers == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.FirstOrDefaultAsync(m => m.SupplierId == id);
            if (supplier == null)
            {
                return NotFound();
            }
            else 
            {
                Supplier = supplier;
            }
            return Page();
        }
    }
}
