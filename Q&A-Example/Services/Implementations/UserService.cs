using Q_A_Example.Context;
using Q_A_Example.Models;
using Q_A_Example.Services.Interfaces;

namespace Q_A_Example.Services.Implementations
{
    public class UserService:IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public User? Authenticate(string username, string password)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            var user = _context.Users.FirstOrDefault(u => u.Username == username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
                return null;

            return user;
        }

        public User Register(string username, string password)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            var user = new User
            {
                Username = username,
                PasswordHash = passwordHash
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User? GetById(int id)
        {
            return _context.Users.Find(id);
        }
    }
}
