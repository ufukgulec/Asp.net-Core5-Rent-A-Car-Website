using CoreAracKiralama.Data;
using CoreAracKiralama.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreAracKiralama.Areas.AdminPaneli.Controllers
{
    [Area("AdminPaneli")]
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(Admin admin)
        {
            using (Context context = new Context())
            {
                var adminData = context.Admins.FirstOrDefault(x => x.Email == admin.Email && x.Password == admin.Password);
                if (adminData != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name,adminData.AdminName)
                    };
                    var userIdentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}
