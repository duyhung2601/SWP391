using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.DataAccess.Repository.IRepository
{
    public interface IOrderRepository:IRepository<Order>
    {
        void Update (Order obj);
		void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
		void UpdatePaymentID(int id, string sessionId, string PaymentIntentIdD);
	}
}
