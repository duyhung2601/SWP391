using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.DataAccess.Repository;
using ShopOnline.DataAccess.Repository.IRepository;
using ShopOnline.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace ShopOnline.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SliderController : Controller
    {
        private readonly ILogger<SliderController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public SliderController(ILogger<SliderController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Slider> sliderList = _unitOfWork.Slider.GetAll();
            return View(sliderList);
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