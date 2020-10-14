using System;
using System.Collections.Generic;
using System.Text;

namespace StockTrackingCore.Entities.Concrete
{
    public class User
    {
        public User()
        {
           
        }
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        
    }
}
