using Microsoft.AspNetCore.Mvc;

namespace JWTDemo.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
