using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ShopOnline.Data;
using ShopOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ShopOnline.Pages.Authen
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string Msg { get; set; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ShopOnlineContext _context;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(IHttpContextAccessor httpContextAccessor, ShopOnlineContext context, ILogger<LoginModel> logger)
        {
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            // Chỗ này có thể cần xử lý nếu có logic riêng cho trang đăng nhập
            return Page();
        }

        public IActionResult OnPost()
        {
            Account account = _context.Account.FirstOrDefault(a => a.UserName.Equals(Username) && a.Password.Equals(Password));

            if (account != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, account.AccountId.ToString()),                  
                    new Claim(ClaimTypes.Name, account.FullName),
                    new Claim(ClaimTypes.DateOfBirth, account.Dob.ToString("yyyy-MM-dd")),
                    new Claim(ClaimTypes.HomePhone, account.Phone)
                    // Thêm các Claim khác nếu cần thiết
                };

                var claimsIdentity = new ClaimsIdentity(claims, "MyAuthScheme");
                _httpContextAccessor.HttpContext.SignInAsync("MyAuthScheme", new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties());

                // Log the claims for debugging
                foreach (var claim in claims)
                {
                    _logger.LogInformation($"Claim Type: {claim.Type}, Claim Value: {claim.Value}");
                }

                return RedirectToPage("/Index");
            }
            else
            {
                Msg = "Account or password is incorrect, please try again.";
                return Page();
            }
        }

        public IActionResult OnPostCancel()
        {
            return RedirectToPage("/Index");
        }
    }
}
