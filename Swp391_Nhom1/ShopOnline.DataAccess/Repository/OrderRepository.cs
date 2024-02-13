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
		public OrderRepository(ApplicationDbContext db) : base(db)
		{
			_db = db;
		}

		public void Update(Order obj)
		{
			_db.Orders.Update(obj);
		}

		public void UpdatePaymentID(int id, string sessionId, string PaymentIntentId)
		{
			var orderFromDb = _db.Orders.FirstOrDefault(u => u.Id == id);
			if (!string.IsNullOrEmpty(sessionId))
			{
				orderFromDb.SessionId = sessionId;

			}
			if (!string.IsNullOrEmpty(PaymentIntentId))
			{
				orderFromDb.PaymentIntentId = PaymentIntentId;
				orderFromDb.PaymentDate = DateTime.Now;
			}
		}

			public void UpdateStatus(int id, string orderStatus, string? paymentStatus = null)
			{
				var orderFromDb = _db.Orders.FirstOrDefault(u => u.Id == id);
				if (orderFromDb != null)
				{
					orderFromDb.OrderStatus = orderStatus;
					if (!string.IsNullOrEmpty(paymentStatus))
					{
						orderFromDb.PaymentStatus = paymentStatus;
					}
				}
			}
		}
	}
