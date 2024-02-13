﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopOnline.Utility
{
    public static class Role
    {
        public const string Role_Customer = "Customer";
        
        public const string Role_Admin = "Admin";
        public const string Role_Employee = "Employee";

		public const string StatusPending = "Pending";
		public const string StatusApproved = "Approved";
		public const string StatusInProcess = "Processing";
		public const string StatusShipped = "Shipped";
		public const string StatusCancelled = "Cancelled";

		public const string PaymenStatusDelayedPayment = "Delayed";
		public const string PaymentStatusPending = "Pending";
		public const string PaymentStatusApproved = "Approved";
		public const string PaymentStatusReject = "Rejected";
	}
}
