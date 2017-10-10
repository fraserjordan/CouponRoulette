using Data.Entities;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IUserService
    {
        ApplicationUser GetUserByEmail(string email);
        List<ApplicationUser> GetAllBusinesses();
        List<BusinessInfo> GetAllBusinessesInfo();
        BusinessInfo GetBusinessInfoByEmail(string email);
    }
}
