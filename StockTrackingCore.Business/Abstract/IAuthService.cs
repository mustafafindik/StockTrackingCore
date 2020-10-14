using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using StockTrackingCore.Entities.Concrete;

namespace StockTrackingCore.Business.Abstract
{
    public interface IAuthService
    {
        Task<User> Register(User user, string password); 
        Task<User> Login(string userName, string password);
        Task<bool> UserExists(string userName);
    }
}
