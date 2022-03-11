using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        public User Create(User user, string password);
        public User GetById(int id);
    }
}
