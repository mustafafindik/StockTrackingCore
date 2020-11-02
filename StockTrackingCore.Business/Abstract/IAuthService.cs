using StockTrackingCore.Entities.Concrete;
using System.Threading.Tasks;

namespace StockTrackingCore.Business.Abstract
{
    public interface IAuthService
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}
