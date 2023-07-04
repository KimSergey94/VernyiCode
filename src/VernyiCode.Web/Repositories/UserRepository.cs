using VernyiCode.Web.Entities;

namespace VernyiCode.Web.Repositories
{
    public class UserRepository
    {
        private UserRepository()
        {
        }

        private static readonly UserRepository _instance = new UserRepository();

        private readonly IList<User> _list = new List<User>()
        {
            new User() { ID = 1, Name = "User1" },
            new User() { ID = 2, Name = "User2" },
            new User() { ID = 3, Name = "User3" }
        };

        public static UserRepository Instance => _instance;

        public IList<User> List()
        {
            return _list;
        }

        public bool Create(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (string.IsNullOrWhiteSpace(user.Name)) return false;

            user.ID = _list.Any() ? _list.Max(x => x.ID) + 1 : 1;
            _list.Add(user);
            return true;
        }

        public void Delete(int id)
        {
            var user = _list.FirstOrDefault(x => x.ID == id);
            if (user == null) throw new Exception("User doesn't exist!");
            _list.Remove(user);
        }

        public bool Update(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            var storedUser = _list.FirstOrDefault(n => n.ID == user.ID);
            if (storedUser == null) return false;

            storedUser.Name = user.Name;
            return true;
        }
    }
}
