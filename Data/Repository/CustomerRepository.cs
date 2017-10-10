using Data.Entities;
using Data.Enums;
using Data.Interfaces;
using System.Linq;

namespace Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext _context;
        public CustomerRepository()
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
                ComplaintCount = 0,
                CouponRedeemedCount = 0,
                CouponUnRedeemedCount = 0
            };
            user.CustomerInfo = customerInfo;
            return _context.SaveChanges() > 0;
        }
    }
}
