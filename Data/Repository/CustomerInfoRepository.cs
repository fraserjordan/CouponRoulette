using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Enums;
using Data.Interfaces;

namespace Data.Repository
{
    public class CustomerInfoRepository : ICustomerInfoRepository
    {
        private readonly DataContext _context;
        public CustomerInfoRepository()
        {
            _context = new DataContext();
        }
        public CustomerInfo GetCustomerInfoByEmail(string email)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == email && x.AccountType == AccountType.Customer);

            return user?.CustomerInfo;
        }

        public bool CreateCustomerInfo(string userId)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userId && x.AccountType == AccountType.Customer);
            if (user == null) return false;
            var customerInfo = new CustomerInfo()
            {
                ActiveCoupon = null,
                CompaintCount = 0,
                CouponExpiredCount = 0
            };
            user.CustomerInfo = customerInfo;
            return _context.SaveChanges() > 0;
        }
    }
}
