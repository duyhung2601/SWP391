using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace ShopOnline.Pages
{
    public class ProfileModel : PageModel
    {
        private readonly ILogger<ProfileModel> _logger;

        public ProfileModel(ILogger<ProfileModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Lấy thông tin người dùng từ Claims (đối với xác thực thông thường)
            
            var fullName = User.FindFirstValue(ClaimTypes.Name);
            var dob = User.FindFirstValue(ClaimTypes.DateOfBirth);
            var phone = User.FindFirstValue(ClaimTypes.HomePhone);




            // Gửi thông tin người dùng đến trang Profile để hiển thị
            
            ViewData["FullName"] = fullName;
            ViewData["DOB"] = dob;
            ViewData["Phone"] = phone;
        }
    }
}