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
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db):base(db)
        {
        _db = db;
        }
        

       

        public void Update(ApplicationUser obj)
        {
          _db.ApplicationUsers.Update(obj);
        }
    }
}
