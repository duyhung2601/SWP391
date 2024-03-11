using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.DataAccess.Repository.IRepository;
using ShopOnline.Models;
using ShopOnline.Utility;

namespace ShopOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Role.Role_Admin)]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DashboardController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Order> objOrders = _unitOfWork.Order.GetAll(includeProperties: "ApplicationUser").ToList();
            DateTime date = DateTime.Now;
            List<DashboardVM> dashboardList = new List<DashboardVM>();
            for (int i = 0; i < 12; i++)
            {
                DateTime today = DateTime.Now;
                DashboardVM dashboardVM = new DashboardVM();
                dashboardVM.date = today.AddDays(-i);
                dashboardVM.total = GetTotal(objOrders, today.AddDays(-i));
                dashboardList.Insert(0,dashboardVM);
            }

            
            return View(dashboardList);
        }

        private double GetTotal(List<Order> orders, DateTime orderDate)
        {
            var result = orders.Where(n => n.OrderDate.Date == orderDate.Date)
                .Sum(n => n.OrderTotal);

            return result;
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Order> objOrders = _unitOfWork.Order.GetAll(includeProperties: "ApplicationUser").ToList();
            DateTime date = DateTime.Now;
            List<double> dashboardList = new List<double>();
            for (int i = 0; i < 7; i++)
            {
                double data = 0;
                DateTime today = DateTime.Now;
                data = GetTotal(objOrders, today.AddDays(-i));
                dashboardList.Insert(0, data);
            }
            return Json( dashboardList);
        }
        #endregion

    }
}
