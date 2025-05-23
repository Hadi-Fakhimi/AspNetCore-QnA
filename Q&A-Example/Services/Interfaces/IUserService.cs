using Q_A_Example.Models;

namespace Q_A_Example.Services.Interfaces
{
    public interface IUserService
    {
        User? Authenticate(string username, string password);
        User Register(string username, string password);
        User? GetById(int id);
    }
}
