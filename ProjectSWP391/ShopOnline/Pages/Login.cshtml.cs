using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopOnline.Models;
using System.Security.Claims;

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
        private readonly ShopOnline.Data.ShopOnlineContext _context;

        public LoginModel(IHttpContextAccessor httpContextAccessor, Data.ShopOnlineContext context)
        {
            _httpContextAccessor = httpContextAccessor;
            this._context = context;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Account account = 
                _context.Account.FirstOrDefault(a => a.UserName.Equals(Username) && a.Password.Equals(Password));      
            if(account != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, account.AccountId.ToString()),
                    new Claim(ClaimTypes.Name, account.UserName)
                };
                var claimsIdentity =new ClaimsIdentity(claims, "MyAuthScheme");
                _httpContextAccessor.HttpContext
                    .SignInAsync("MyAuthScheme",
                    new ClaimsPrincipal(claimsIdentity),
                    new AuthenticationProperties());
                return RedirectToPage("/Index");

            }
            else
            {
                Msg = "Invalid";
                return Page();
            }
            
           
        }
    }
}
