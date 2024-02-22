using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.DataAccess.Repository;
using ShopOnline.DataAccess.Repository.IRepository;
using ShopOnline.Models;
using ShopOnline.Models.ViewModels;
using System.Diagnostics;
using System.Security.Claims;

namespace ShopOnline.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var productHomeVM = new ProductHomeViewModel();
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            productHomeVM.Products = productList.Select(x => new ProductViewModel
            {
                   Id = x.Id,
                   Name = x.Name,
                   ImageUrl= x.ImageUrl,
                   Company = x.Company,
                   Price100 = x.Price100,
                   ListPrice = x.ListPrice
            });
            
            IEnumerable<Slider> sliderList= _unitOfWork.Slider.GetAll();

            productHomeVM.Sliders = sliderList.Select(x => new SliderViewModel
            {
                ImageUrl = x.ImageUrl,
            });
            return View(productHomeVM);
        }
        public IActionResult Details(int productId)
        {
            ShoppingCart cart =new()
            {


                Product = _unitOfWork.Product.Get(u => u.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
            };
            
            return View(cart);
        }
        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
          var claimsIdentity=(ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId=userId;

            ShoppingCart cartFromDb= _unitOfWork.ShoppingCart.Get(u=>u.ApplicationUserId==userId && u.ProductId==shoppingCart.ProductId);
            if(cartFromDb!=null)
            {
                //shopping cart exist
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }
            else
            {
                //add cart report
                _unitOfWork.ShoppingCart.Add(shoppingCart);

            }
            
            _unitOfWork.Save();
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}