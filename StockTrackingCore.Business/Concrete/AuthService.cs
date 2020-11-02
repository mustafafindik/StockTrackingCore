using StockTrackingCore.Business.Abstract;
using StockTrackingCore.DataAccess.Abstract;
using StockTrackingCore.Entities.Concrete;
using System.Threading.Tasks;

namespace StockTrackingCore.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public Task<User> Register(User user, string password)
        {
            return _authRepository.Register(user, password);
        }

        public Task<User> Login(string userName, string password)
        {
            return _authRepository.Login(userName, password);
        }

        public Task<bool> UserExists(string userName)
        {
            return _authRepository.UserExists(userName);
        }
    }
}
