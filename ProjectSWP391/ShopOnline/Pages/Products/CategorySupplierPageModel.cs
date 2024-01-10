using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopOnline.Data;
using ShopOnline.Models;

namespace ShopOnline.Pages.Products
{
    public class CategorySupplierPageModel
    {
        public SelectList CategoryNameSL {  get; set; }
        public SelectList SupplierNameSL { get; set; }
        public void GetCategoriesDropDownList(ShopOnlineContext _context,object selectedCategoy = null)
        {
            var CategoriesQuery=from c in _context.Categories
                                orderby c.CategoryName
                                select c;
            CategoryNameSL= new SelectList(CategoriesQuery.AsNoTracking(),
                nameof(Category.CategoryId),
                nameof(Category.CategoryName),
                selectedCategoy);
        }
        public void GetSupplierDropDownList(ShopOnlineContext _context, object selectedSupplier = null)
        {
            var SupplierQuery = from s in _context.Suppliers
                                  orderby s.CompanyName
                                  select s;
            CategoryNameSL = new SelectList(SupplierQuery.AsNoTracking(),
                nameof(Supplier.SupplierId),
                nameof(Supplier.CompanyName),
                selectedSupplier);
        }
    }
}
