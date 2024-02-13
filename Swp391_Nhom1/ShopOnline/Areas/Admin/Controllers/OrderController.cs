using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.DataAccess.Repository.IRepository;
using ShopOnline.Models;
using ShopOnline.Models.ViewModels;
using ShopOnline.Utility;
using System.Security.Claims;

namespace ShopOnline.Areas.Admin.Controllers
{
	[Area("admin")]
	public class OrderController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		[BindProperty]
		public OrderVM OrderVM { get; set; }
		public OrderController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Details(int orderId)
		{
			OrderVM = new()
			{
				Order = _unitOfWork.Order.Get(u => u.Id == orderId, includeProperties: "ApplicationUser"),
				OrderDetail = _unitOfWork.OrderDetail.GetAll(u => u.OrderId == orderId, includeProperties: "Product")
			};
			return View(OrderVM);
		}
		[Authorize(Roles = Role.Role_Admin + "," + Role.Role_Employee)]
		public IActionResult UpdateOrderDetail()
		{
			var orderFromDb = _unitOfWork.Order.Get(u => u.Id == OrderVM.Order.Id);
			orderFromDb.Name = OrderVM.Order.Name;
			orderFromDb.PhoneNumber = OrderVM.Order.PhoneNumber;
			orderFromDb.StreetAddress = OrderVM.Order.StreetAddress;
			orderFromDb.City = OrderVM.Order.City;
			orderFromDb.State = OrderVM.Order.State;
			orderFromDb.PostalCode = OrderVM.Order.PostalCode;
			if (!string.IsNullOrEmpty(OrderVM.Order.Carrier))
			{	

				orderFromDb.Carrier = OrderVM.Order.Carrier;
			}
			if (string.IsNullOrEmpty(OrderVM.Order.TrackingNumber))
			{
				orderFromDb.Carrier = OrderVM.Order.TrackingNumber;
			}
			_unitOfWork.Order.Update(orderFromDb);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Details), new { orderId = orderFromDb.Id });
		}

		#region API CALLS
		[HttpGet]
		public IActionResult GetAll()
		{
			IEnumerable<Order> objOrders;
			if (User.IsInRole(Role.Role_Admin) || User.IsInRole(Role.Role_Employee))
			{
				objOrders = _unitOfWork.Order.GetAll(includeProperties: "ApplicationUser").ToList();
			}
			else
			{
				var claimsIdentity = (ClaimsIdentity)User.Identity;
				var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
				objOrders = _unitOfWork.Order.GetAll(u => u.ApplicationUser.Id == userId, includeProperties: "ApplicationUser");
			}

			return Json(new { data = objOrders });
		}


		#endregion
	}
}