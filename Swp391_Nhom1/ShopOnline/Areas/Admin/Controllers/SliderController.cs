using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopOnline.DataAccess.Data;
using ShopOnline.DataAccess.Repository.IRepository;
using ShopOnline.Models;
using ShopOnline.Models.ViewModels;
using ShopOnline.Utility;

namespace ShopOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Role.Role_Admin)]
    public class SliderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SliderController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Slider> objSliderList = _unitOfWork.Slider.GetAll().ToList();

            return View(objSliderList);
        }
        public IActionResult Upsert(int? id)
        {


            SliderVM sliderVM = new()
            {
                Slider = new Slider()
            };
            if (id == null || id == 0)
            {
                //create
                return View(sliderVM);
            }
            else
            {
                //update
                sliderVM.Slider = _unitOfWork.Slider.Get(u => u.Id == id);
                return View(sliderVM);
            }

        }
        [HttpPost]
        public IActionResult Upsert(SliderVM sliderVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string sliderPath = Path.Combine(wwwRootPath, @"images\slider");
                    if (!string.IsNullOrEmpty(sliderVM.Slider.ImageUrl))
                    {
                        //delete old image
                        var oldImagePath = Path.Combine(wwwRootPath, sliderVM.Slider.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(sliderPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    sliderVM.Slider.ImageUrl = @"\images\slider\" + fileName;
                }
                if (sliderVM.Slider.Id == 0)
                {
                    _unitOfWork.Slider.Add(sliderVM.Slider);
                }
                else
                {
                    _unitOfWork.Slider.Update(sliderVM.Slider);
                }

                _unitOfWork.Save();
                TempData["success"] = "Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View(sliderVM);
            }
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Slider> objSliderList = _unitOfWork.Slider.GetAll().ToList();
            return Json(new { data = objSliderList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var sliderToBeDeleted = _unitOfWork.Slider.Get(u => u.Id == id);
            if (sliderToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, sliderToBeDeleted.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.Slider.Remove(sliderToBeDeleted);
            _unitOfWork.Save();


            return Json(new { success = true, message = "Delete Sucessfull" });
        }
        #endregion
    }
}
