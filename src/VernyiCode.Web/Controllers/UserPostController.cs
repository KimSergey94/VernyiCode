using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;
using VernyiCode.Web.Entities;
using VernyiCode.Web.Repositories;
using VernyiCode.Web.Services;

namespace VernyiCode.Web.Controllers
{
    public class UserPostController : Controller
    {
        // GET: UserPost/
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserPost/TakeNLatestPostsByUserId
        public ActionResult TakeNLatestPostsByUserId(int userId, int n = 10)
        {
            return View(UserPostService.TakeNLatestPostsByUserId(userId, n));
        }

        // GET: UserPost/TakeNUsersNLatestPosts
        public ActionResult TakeNUsersNLatestPosts(int n = 10)
        {
            return View(UserPostService.TakeNUsersNLatestPosts(n));
        }
    }
}
