using System.Collections.Generic;
using System.Linq;
using Data.Entities;
using Data.Enums;
using Data.Interfaces;

namespace Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository()
        {
            _context = new DataContext();
        }
        public ApplicationUser GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public BusinessInfo GetBusinessInfoByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email)?.BusinessInfo;
        }

        public List<ApplicationUser> GetAllBusinesses()
        {
            var businesses = _context.Users.Where(x => x.AccountType == AccountType.Business).ToList();
            return businesses.Count > 0 ? businesses : new List<ApplicationUser>();
        }

        public List<BusinessInfo> GetAllBusinessesInfo()
        {
            var businessesInfo = _context.Users.Where(x => x.AccountType == AccountType.Business).Select(x => x.BusinessInfo).ToList();
            return businessesInfo.Count > 0 ? businessesInfo : new List<BusinessInfo>();
        }
    }
}
