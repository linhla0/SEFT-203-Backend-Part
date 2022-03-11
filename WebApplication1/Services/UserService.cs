using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService : BaseService<UserService>, IUserService
    {
        public UserService(DataContext context, ILogger<UserService> logger) 
            : base(context, logger) { }

        private bool VerifyHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrEmpty(password)) 
                throw new ArgumentException("Password cannot be empty or null");

            using (var code = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = code.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                _logger.LogInformation("Key={passwordSalt}", passwordSalt);
                _logger.LogInformation("Hash={passwordHash}", passwordHash);
                _logger.LogInformation("Compute={computedHash}", computedHash);
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Users.SingleOrDefault(x => x.Username == username);
            if (user == null)
                return null;

            if (!VerifyHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private void HashPassword(string password, out byte[] passwordSalt, out byte[] passwordHash)
        {
            using (var code = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = code.Key;
                passwordHash = code.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                _logger.LogInformation("Key={passwordSalt}", passwordSalt);
                _logger.LogInformation("Hash={passwordHash}", passwordHash);
            }
        }

        public User Create(User user, string password)
        {
            if (_context.Users.Any(x => x.Username == user.Username))
                throw new Exception("This username existed");
            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrEmpty(password))
                throw new Exception("Password is empty");
            
            HashPassword(password, out byte[] passwordSalt, out byte[] passwordHash);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }
    }
}
