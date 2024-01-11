using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopOnline.Pages
{
    public class LogoutModel : PageModel
    {
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("MyAuthScheme");
            return RedirectToPage("/Login");
        }
    }
}
