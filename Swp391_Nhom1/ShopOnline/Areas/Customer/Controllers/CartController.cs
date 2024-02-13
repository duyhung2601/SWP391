using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.DataAccess.Repository.IRepository;
using ShopOnline.Models;
using ShopOnline.Models.ViewModels;
using ShopOnline.Utility;
using System.Security.Claims;

namespace ShopOnline.Areas.Customer.Controllers
{
	[Area("customer")]
	[Authorize]
	public class CartController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		[BindProperty]
		public ShoppingCartVM ShoppingCartVM { get; set; }
		public CartController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			ShoppingCartVM = new()
			{
				ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
				includeProperties: "Product"),
				Order = new()
			};
			foreach (var cart in ShoppingCartVM.ShoppingCartList)
			{
				cart.Price = GetPriceBasedOnQuantity(cart);
				ShoppingCartVM.Order.OrderTotal += (cart.Price * cart.Count);
			}
			return View(ShoppingCartVM);
		}

		public IActionResult Summary()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
			ShoppingCartVM = new()
			{
				ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
				includeProperties: "Product"),
				Order = new()
			};

			ShoppingCartVM.Order.ApplicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);
			ShoppingCartVM.Order.Name = ShoppingCartVM.Order.ApplicationUser.Name;
			ShoppingCartVM.Order.PhoneNumber = ShoppingCartVM.Order.ApplicationUser.PhoneNumber;
			ShoppingCartVM.Order.StreetAddress = ShoppingCartVM.Order.ApplicationUser.StreetAdress;
			ShoppingCartVM.Order.City = ShoppingCartVM.Order.ApplicationUser.City;
			ShoppingCartVM.Order.State = ShoppingCartVM.Order.ApplicationUser.State;
			ShoppingCartVM.Order.PostalCode = ShoppingCartVM.Order.ApplicationUser.PostalCode;


			foreach (var cart in ShoppingCartVM.ShoppingCartList)
			{
				cart.Price = GetPriceBasedOnQuantity(cart);
				ShoppingCartVM.Order.OrderTotal += (cart.Price * cart.Count);
			}
			return View(ShoppingCartVM);
		}
		[HttpPost]
		[ActionName("Summary")]
		public IActionResult SummaryPost()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity;
			var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

			ShoppingCartVM.ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
				includeProperties: "Product");
			ShoppingCartVM.Order.OrderDate = System.DateTime.Now;
			ShoppingCartVM.Order.ApplicationUserId = userId;

			ApplicationUser appllicationUser = _unitOfWork.ApplicationUser.Get(u => u.Id == userId);



			foreach (var cart in ShoppingCartVM.ShoppingCartList)
			{
				cart.Price = GetPriceBasedOnQuantity(cart);
				ShoppingCartVM.Order.OrderTotal += (cart.Price * cart.Count);
			}

			ShoppingCartVM.Order.PaymentStatus = Role.PaymentStatusPending;
			ShoppingCartVM.Order.OrderStatus = Role.StatusPending;
			_unitOfWork.Order.Add(ShoppingCartVM.Order);
			_unitOfWork.Save();
			foreach (var cart in ShoppingCartVM.ShoppingCartList)
			{
				OrderDetail orderDetail = new()
				{
					ProductId = cart.ProductId,
					OrderId = ShoppingCartVM.Order.Id,
					Price = cart.Price,
					Count = cart.Count
				};
				_unitOfWork.OrderDetail.Add(orderDetail);
				_unitOfWork.Save();
			}
			return RedirectToAction(nameof(OrderInformation), new { id = ShoppingCartVM.Order.Id });
		}
		public IActionResult OrderInformation(int id)
		{
			Order order = _unitOfWork.Order.Get(u => u.Id == id, includeProperties: "ApplicationUser");
			return View(id);
		}



		public IActionResult Plus(int cartId)
		{
			var cartFormDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
			cartFormDb.Count += 1;
			_unitOfWork.ShoppingCart.Update(cartFormDb);
			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Minus(int cartId)
		{
			var cartFormDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
			if (cartFormDb.Count <= 1)
			{
				_unitOfWork.ShoppingCart.Remove(cartFormDb);
			}
			else
			{
				cartFormDb.Count -= 1;
				_unitOfWork.ShoppingCart.Update(cartFormDb);
			}


			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Remove(int cartId)
		{
			var cartFormDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
			_unitOfWork.ShoppingCart.Remove(cartFormDb);

			_unitOfWork.Save();
			return RedirectToAction(nameof(Index));
		}

		private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
		{
			if (shoppingCart.Count <= 50)
			{
				return shoppingCart.Product.Price;
			}
			else
			{
				if (shoppingCart.Count <= 100)
				{
					return shoppingCart.Product.Price50;
				}
				else
				{
					return shoppingCart.Product.Price100;
				}
			}
		}

	}
}