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
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private ApplicationDbContext _db;
        public OrderRepository(ApplicationDbContext db):base(db)
        {
        _db = db;
        }

        public void Update(Order obj)
        {
          _db.Orders.Update(obj);
        }
    }
}
