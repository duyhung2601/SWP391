using ShopOnline.DataAccess.Data;
using ShopOnline.DataAccess.Repository.IRepository;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db):base(db)
        {
        _db = db;
        }
        

       

        public void Update(Product obj)
        {
          var objFromDb = _db.Products.FirstOrDefault(u=> u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.SKU = obj.SKU;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Company = obj.Company;
                objFromDb.CategoryId= obj.CategoryId;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Price50 = obj.Price50;
                if(obj.ImageUrl!= null)
                {
                    objFromDb.ImageUrl=obj.ImageUrl;
                }
            }
        }
    }
}
