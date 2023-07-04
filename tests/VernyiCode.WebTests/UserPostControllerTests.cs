using Microsoft.AspNetCore.Mvc;
using Moq;
using VernyiCode.Web.Controllers;
using VernyiCode.Web.Entities;
using VernyiCode.Web.Repositories;
using VernyiCode.Web.Services;

namespace VernyiCode.WebTests
{
    public class UserPostControllerTests
    {
       [Fact]
        public void TakeNLatestPostsByUserId()
        {
            // Arrange
            var controller = new UserPostController();
            Random rnd = new Random();
            var users = UserRepository.Instance.List().ToList();
            var user = users.ElementAt(rnd.Next(users.Count));
            var n = 3;

            // Act
            var result = controller.TakeNLatestPostsByUserId(user.ID, n);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Post>>(viewResult.Model);
            var userPosts = UserPostService.TakeNLatestPostsByUserId(user.ID, n);

            Assert.Equal(userPosts, model);
        }

        [Fact]
        public void TakeNUsersNLatestPosts()
        {
            // Arrange
            var controller = new UserPostController();
            var n = 3;

            // Act
            var result = controller.TakeNUsersNLatestPosts(n);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Post>>(viewResult.Model);
            var nUsersNPosts = UserPostService.TakeNUsersNLatestPosts(n);
            Assert.Equal(nUsersNPosts, model);
        }
    }
}