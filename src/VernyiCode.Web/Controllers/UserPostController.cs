using Microsoft.AspNetCore.Mvc;

namespace VernyiCode.Web.Controllers
{
    public class UserPostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
