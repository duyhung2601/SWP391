using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopOnline.Data;
using ShopOnline.Models;

namespace ShopOnline.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ShopOnline.Data.ShopOnlineContext _context;

        public CreateModel(ShopOnline.Data.ShopOnlineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Set<Category>(), "CategoryId", "CategoryName");
        ViewData["SupplierId"] = new SelectList(_context.Set<Supplier>(), "SupplierId", "CompanyName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || Product == null)
            {
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
