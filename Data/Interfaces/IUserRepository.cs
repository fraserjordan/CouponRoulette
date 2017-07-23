using System.Collections.Generic;
using Data.Entities;

namespace Data.Interfaces
{
    public interface IUserRepository
    {
        ApplicationUser GetUserByEmail(string email);
        List<ApplicationUser> GetAllBusinesses();
        List<BusinessInfo> GetAllBusinessesInfo();
        BusinessInfo GetBusinessInfoByEmail(string email);
    }
}
