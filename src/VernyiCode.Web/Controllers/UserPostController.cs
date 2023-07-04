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
        //● Получить N(максимум) последних сообщений для разных пользователей.Т.е.взять
        //максимум N пользователей, которые оставляли сообщения, и выбрать их последние
        //сообщения в порядке даты публикации

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
